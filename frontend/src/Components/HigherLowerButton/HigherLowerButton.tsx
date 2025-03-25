const HigherLowerButtons = () => {
  return (
    <div className="flex flex-col gap-3">
      <button className="
        bg-[#FF9500] 
        text-white 
        py-3 
        px-12 
        rounded-full 
        font-medium 
        hover:bg-[#E68600] 
        transition-colors
      ">
        Higher
      </button>
      
      <button className="
        bg-[#FF9500] 
        text-white 
        py-3 
        px-12 
        rounded-full 
        font-medium 
        hover:bg-[#E68600] 
        transition-colors
      ">
        Lower
      </button>
    </div>
  );
};

export default HigherLowerButtons;
