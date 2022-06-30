import {Link,NavLink} from 'react-router-dom'
 

function Header(){
    return ( 
        <div className="header">
            <nav className=" grey darken-1">
                <div className="nav-wrapper">
                    <Link to="/" className="brand-logo">Auction</Link>
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
                            {/* <NavLink className="btn grey darken-2" to="#" >
                                <img className="user-ico" src="img/user_icon-icons.com_57997.svg" />
                            </NavLink>
                            <NavLink className="btn grey darken-2" to="#" >
                                <img className="basket-ico" src="../img/basket_78591.svg" />
                            </NavLink> */}
                        </ul>   
                </div>
            </nav>
            {/* <Routes>
                <Route path='/Auction' element={<Auction />}/>
                <Route path='/About' element={<About/>}/>
                <Route path='/Home' element={<Home/>}/>
                <Route path='/Registration' element={<Registration/>}/>
                <Route path='/SignIn' element={<SignIn/>}/>
            </Routes> */}
      </div>
    )
}

export {Header}