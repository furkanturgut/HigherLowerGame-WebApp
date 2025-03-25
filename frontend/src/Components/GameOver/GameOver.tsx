interface GameOverProps {
  score: number;
  onRestart: () => void;
  onHome: () => void;
}

const GameOver = ({ score, onRestart, onHome }: GameOverProps) => {
  return (
    <div className="
      fixed 
      inset-0 
      bg-black/80 
      flex 
      items-center 
      justify-center 
      z-50
    ">
      <div className="
        bg-[#2D3339] 
        p-8 
        rounded-lg 
        text-center 
        text-white
        w-[90%]
        max-w-[400px]
      ">
        <h2 className="text-2xl font-bold mb-2">Game Over!</h2>
        <p className="text-xl mb-6">Final Score: {score}</p>
        
        <div className="flex flex-col gap-4">
          <button 
            onClick={onRestart}
            className="
              bg-[#FF9500] 
              hover:bg-[#E68600] 
              text-white 
              py-3 
              px-8 
              rounded-full 
              transition-all
            "
          >
            Play Again
          </button>
          
          <button 
            onClick={onHome}
            className="
              bg-transparent 
              border-2 
              border-[#FF9500] 
              text-[#FF9500] 
              hover:bg-[#FF9500] 
              hover:text-white 
              py-3 
              px-8 
              rounded-full 
              transition-all
            "
          >
            Back to Home
          </button>
        </div>
      </div>
    </div>
  );
};

export default GameOver;
