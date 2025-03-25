import { Link } from "react-router-dom";
import ButtonHome from "../buttonHome/buttonHome";

const buttonHomeList = () => {
    return (
        <div className="
       flex 
      flex-col        
      md:flex-row   
      items-center 
      justify-center  
      gap-4
      md:gap-6
      mt-[100px]
      md:mt-[200px]
      px-4
      md:px-0
      ">
        <Link to="select" > <ButtonHome name="Choose League"/></Link>
        <Link to="game"><ButtonHome name="Start Game"/></Link>
        <Link to="select" ><ButtonHome name="Choose Nation"/></Link>
      </div>
    );
  };
  
  export default buttonHomeList;