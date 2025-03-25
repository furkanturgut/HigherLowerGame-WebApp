import React from 'react'
import Logo from '../../Components/Logo/Logo';
import ButtonHomeList from '../../Components/buttonHomeList/buttonHomeList';
import { Outlet } from 'react-router-dom';

type Props = {}

const HomePage = (props: Props) => {
  return (
    <div className="
    min-h-screen 
    bg-white
  ">
    <Logo />
    <ButtonHomeList />
  </div>
  );
}

export default HomePage