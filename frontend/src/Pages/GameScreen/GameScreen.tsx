import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import PlayerCard from '../../Components/PlayerCard/PlayerCard'
import VsCircle from '../../Components/VsCircle/VsCircle';
import GameOver from '../../Components/GameOver/GameOver';
import { PlayerSearch } from '../../player';
import { searchPlayer } from '../../api';

const PAGE_SIZE = 10; // Sabit page size

const GameScreen = () => {
  const navigate = useNavigate();
  const [players, setPlayers] = useState<PlayerSearch[]>([]);
  const [currentPlayer, setCurrentPlayer] = useState<PlayerSearch | null>(null);
  const [nextPlayer, setNextPlayer] = useState<PlayerSearch | null>(null);
  const [currentIndex, setCurrentIndex] = useState(0);
  const [currentPage, setCurrentPage] = useState(1);
  const [isAnimating, setIsAnimating] = useState(false);
  const [score, setScore] = useState(0);
  const [showGameOver, setShowGameOver] = useState(false);
  const [isLoading, setIsLoading] = useState(false);

  const fetchPlayers = async (pageNumber: number) => {
    try {
      setIsLoading(true);
      const response = await searchPlayer(pageNumber, PAGE_SIZE);
      if (pageNumber === 1) {
        setPlayers(response.data);
      } else {
        setPlayers(prev => [...prev, ...response.data]);
      }
    } catch (error) {
      console.error('Error fetching players:', error);
    } finally {
      setIsLoading(false);
    }
  };

  const fetchAndSetupGame = async () => {
    setCurrentPage(1);
    setCurrentIndex(0);
    setScore(0);
    setShowGameOver(false);
    await fetchPlayers(1);
  };

  // Oyun başlangıcında ilk sayfayı yükle
  useEffect(() => {
    fetchAndSetupGame();
  }, []);

  // Yeni oyuncular geldiğinde ilk iki oyuncuyu ayarla (sadece oyun başlangıcında)
  useEffect(() => {
    if (players.length >= 2 && currentIndex === 0) {
      setCurrentPlayer(players[0]);
      setNextPlayer(players[1]);
    }
  }, [players]);

  // Oyuncular azaldığında yeni sayfa yükle
  useEffect(() => {
    const remainingPlayers = players.length - currentIndex - 2;
    if (remainingPlayers < 3 && !isLoading && !showGameOver) {
      fetchPlayers(currentPage + 1);
      setCurrentPage(prev => prev + 1);
    }
  }, [currentIndex, players.length]);

  const checkAnswer = (isHigher: boolean) => {
    if (!currentPlayer || !nextPlayer || isAnimating || isLoading) return;

    const isCorrect = isHigher 
      ? nextPlayer.value > currentPlayer.value 
      : nextPlayer.value < currentPlayer.value;

    if (isCorrect) {
      setIsAnimating(true);
      setScore(prev => prev + 1);
      
      setTimeout(() => {
        setCurrentPlayer(nextPlayer);
        const newNextPlayer = players[currentIndex + 2];
        if (newNextPlayer) {
          setNextPlayer(newNextPlayer);
          setCurrentIndex(prev => prev + 1);
        }
        setIsAnimating(false);
      }, 500);
    } else {
      setShowGameOver(true);
    }
  };

  const handleRestart = () => {
    fetchAndSetupGame();
  };

  const handleHome = () => {
    navigate('/');
  };

  if (!currentPlayer || !nextPlayer) return <div>Loading...</div>;

  return (
    <>
      <div className="h-screen w-full flex flex-col md:flex-row overflow-hidden relative">
        <div className="
          absolute 
          top-4 
          left-1/2 
          -translate-x-1/2 
          bg-[#FF9500] 
          px-6 
          py-2 
          rounded-full 
          text-white 
          font-bold 
          z-20
        ">
          Score: {score}
        </div>

        <PlayerCard 
          playerName={currentPlayer.playerName}
          value={currentPlayer.value}
          imageUrl="/default-player.jpg"
          teamName={currentPlayer.teamName}
          countryName={currentPlayer.countryName}
          isExiting={isAnimating}
        />
        
        <div className="
          absolute 
          left-1/2 
          top-1/2 
          -translate-x-1/2 
          -translate-y-1/2 
          z-10 
          scale-75 
          md:scale-100
          transition-transform
          duration-500
        ">
          <VsCircle />
        </div>

        <PlayerCard 
          playerName={nextPlayer.playerName}
          imageUrl="/default-player.jpg"
          isGuessing={true}
          teamName={nextPlayer.teamName}
          countryName={nextPlayer.countryName}
          onHigherClick={() => checkAnswer(true)}
          onLowerClick={() => checkAnswer(false)}
          isSliding={isAnimating}
        />

        {isAnimating && (
          <div className="
            absolute 
            right-0 
            top-0 
            w-1/2 
            h-full 
            transform 
            translate-x-full 
            transition-transform 
            duration-500
          ">
            <PlayerCard 
              playerName={players[currentIndex + 2]?.playerName || ''}
              imageUrl="/default-player.jpg"
              isGuessing={true}
              teamName={players[currentIndex + 2]?.teamName || ''}
              countryName={players[currentIndex + 2]?.countryName || ''}
            />
          </div>
        )}
      </div>

      {showGameOver && (
        <GameOver 
          score={score}
          onRestart={handleRestart}
          onHome={handleHome}
        />
      )}
    </>
  );
};

export default GameScreen;



