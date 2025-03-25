import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePagse";
import GameScreen from "../Pages/GameScreen/GameScreen";
import ModeSelectionPage from "../Pages/ModeSelectionPage/ModeSelectionPage";


export const router = createBrowserRouter ([
{
    path: "/",
    element: <App/>,
    children: [
        {index:true, element:<HomePage/>},
        {path:"game", element:<GameScreen/>},
        {path:"select", element:<ModeSelectionPage/>}
    ]
}

])