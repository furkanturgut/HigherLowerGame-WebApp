import LogoImage from "./logo.png"
const Logo = () => {
  return (
    <div className="
      w-full 
      flex 
      justify-center 
      items-center
      mt-8
      md:mt-20
    ">
      <div className="
        relative
        w-[90%]
        md:w-[800px]
        h-[120px]
        md:h-[180px]
        bg-[#2D3339]
      ">
        <div className="
          absolute 
          left-1/2 
          top-1/2 
          -translate-x-1/2 
          -translate-y-1/2
        ">
          <img 
            src={LogoImage} 
            alt="Higher Lower Game Logo" 
            className="
              w-[160px]
              h-[160px]
              md:w-[200px]
              md:h-[200px]
              object-contain
            "
          />
        </div>
      </div>
    </div>
  );
};

export default Logo;