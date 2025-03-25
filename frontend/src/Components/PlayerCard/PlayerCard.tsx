interface PlayerCardProps {
  playerName: string;
  value?: number;
  imageUrl: string;
  isGuessing?: boolean;
  teamName: string;
  countryName: string;
  onHigherClick?: () => void;
  onLowerClick?: () => void;
  isSliding?: boolean;
  isExiting?: boolean;
}

const PlayerCard = ({ 
  playerName, 
  value, 
  imageUrl, 
  isGuessing = false, 
  teamName, 
  countryName,
  onHigherClick,
  onLowerClick,
  isSliding = false,
  isExiting = false
}: PlayerCardProps) => {
  return (
    <div className={`
      relative 
      w-full     
      md:w-1/2   
      h-[50vh]   
      md:h-screen
      transition-all
      duration-500
      ease-in-out
      ${isSliding ? '-translate-x-full' : ''}
      ${isExiting ? '-translate-x-full opacity-0' : ''}
    `}>
      {/* Background Image */}
      <div className="
        absolute 
        inset-0 
        w-full 
        h-full
      ">
        <img 
          src={imageUrl} 
          alt={playerName}
          className="
            w-full 
            h-full 
            object-cover 
            brightness-[0.6]
          "
        />
      </div>

      <div className="
        absolute 
        inset-0 
        flex 
        flex-col 
        justify-center 
        items-center 
        text-white 
        p-4        
        md:p-8    
        gap-4      
        md:gap-8  
      ">
        {/* Value Card */}
        <div className="
          bg-[#FF9500] 
          rounded-full 
          px-6       
          md:px-12  
          py-3       
          md:py-4    
          w-[90%]    
          md:w-auto  
          min-w-[200px]      
          md:min-w-[300px]   
          text-center
        ">
          {!isGuessing && value && (
            <div className="
              text-xs     
              md:text-sm  
              mb-1
            ">
              ${value}
            </div>
          )}
          <div className="
            font-bold 
            text-lg      
            md:text-xl   
          ">
            {playerName}
          </div>
          <div className="
            text-xs
            md:text-sm
            mt-1
            flex
            flex-col
            gap-0.5
          ">
            {teamName && (
              <div className="opacity-90">{teamName}</div>
            )}
            {countryName && (
              <div className="opacity-90">{countryName}</div>
            )}
          </div>
        </div>

        {/* Buttons */}
        {isGuessing && (
          <div className="
            flex 
            flex-col 
            gap-3        
            md:gap-4    
            mt-2        
            md:mt-4    
            w-[90%]     
            md:w-auto   
          ">
            <button 
              onClick={onHigherClick}
              className="
                bg-[#FF9500]
                hover:bg-[#E68600] 
                text-white 
                py-2        
                md:py-3      
                px-8         
                md:px-16     
                rounded-full 
                transition-all
                text-sm      
                md:text-base 
                w-full       
                md:w-auto    
                min-w-[150px]      
                md:min-w-[200px]   
              "
            >
              Higher
            </button>
            <button 
              onClick={onLowerClick}
              className="
                bg-[#FF9500]
                hover:bg-[#E68600] 
                text-white 
                py-2         
                md:py-3      
                px-8         
                md:px-16     
                rounded-full 
                transition-all
                text-sm    
                md:text-base 
                w-full
                md:w-auto   
                min-w-[150px]      
                md:min-w-[200px]  
              "
            >
              Lower
            </button>
          </div>
        )}
      </div>
    </div>
  );
};

export default PlayerCard;
