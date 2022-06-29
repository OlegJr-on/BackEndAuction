import {Auction} from "../pages/Auction";
import {About} from "../pages/About";
import { Home } from "../pages/Home";
import { Registration } from "../pages/Registration";
import { SignIn } from "../pages/SignIn";
import {BrowserRouter,Route,Routes,NavLink} from 'react-router-dom'


function Header(){
    return ( <BrowserRouter>
        <div className="header">
            <nav className=" grey darken-1">
                <div className="nav-wrapper">
                    <a href="#" className="brand-logo">Auction</a>
                        <ul id="nav-mobile" className="right hide-on-med-and-down">
                            <NavLink className="btn grey darken-2" to="/Home" >
                                Home
                            </NavLink>
                            <NavLink className="btn grey darken-2" to="/Auction" >
                                Auction
                            </NavLink>
                            <NavLink className="btn grey darken-2" to="/About" >
                                About
                            </NavLink>
                            <NavLink className="btn grey darken-2" to="/Registration" >
                                Registration
                            </NavLink>
                            <NavLink className="btn grey darken-2" to="/SignIn" >
                                Sign In
                            </NavLink>
                        </ul>   
                </div>
            </nav>
            <Routes>
                <Route path='/Auction' element={<Auction />}/>
                <Route path='/About' element={<About/>}/>
                <Route path='/Home' element={<Home/>}/>
                <Route path='/Registration' element={<Registration/>}/>
                <Route path='/SignIn' element={<SignIn/>}/>
            </Routes>
      </div>
      </BrowserRouter>)
}

export {Header}