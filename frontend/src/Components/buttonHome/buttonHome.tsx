import React, { JSX } from 'react'
import { Link } from 'react-router-dom'

interface Props 
 {
    name:string
 }

const buttonHome:React.FC<Props> = ({name}: Props): JSX.Element => {
  return (

      <button className="
        w-full
        md:w-auto
        max-w-[400px]
        bg-[#FF9500] 
        text-white 
        py-3 
        px-8
        md:px-12
        rounded-lg 
        font-medium 
        hover:bg-[#E68600] 
        transition-colors 
        duration-200
        text-sm
        md:text-base
      ">
        {name}
      </button>
 
  );
};

export default buttonHome;