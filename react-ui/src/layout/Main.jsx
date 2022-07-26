import {Route,Routes,Navigate} from 'react-router-dom'
import {Auction} from "../pages/Auction";
import {About} from "../pages/About";
import { Home } from "../pages/Home";
import {Registration} from "../pages/Registration";
import { SignIn } from "../pages/SignIn";
import {Lot} from '../pages/Lot';
import {Profile} from '../pages/UserProfile';
import {Basket} from '../pages/Basket'
import { NotFound } from '../pages/NotFound';
import { Congrats } from '../pages/Congrats';
import React, {useEffect} from 'react';
import {useDispatch,useSelector} from 'react-redux'

function Main(){

    const isAuth = useSelector(state => state.user.isAuth)
    const dispatch = useDispatch()
  
    // useEffect(() => {
    //     dispatch(auth())
    // }, [])

    return (
            <main className="container content">
                <Routes>
                    <Route path='/Auction' element={<Auction />}/>
                    <Route path='/Auction/:lotId' element={<Lot/>}/>
                    <Route path='/About' element={<About/>}/>
                    <Route path='/' element={<Home/>}/>
                    <Route path='/Home' element={<Home/>}/>
                    {!isAuth &&
                     <>
                    <Route path='/Registration' element={<Registration/>}/>
                    <Route path='/SignIn' element={<SignIn/>}/>  
                    </>
                    }
                    <Route path='/Profile' element={<Profile/>}/>   
                    <Route path='/Basket' element={<Basket/>}/>                  
                    <Route path="/Congrats" element={ <Congrats/>} />
                    <Route path="*" element={ <NotFound/>} />
                </Routes>
            </main>
    )
}

// class Main extends React.Component{
    
//     state = {
//         lots: [],
//     }

//     componentDidMount(){
//         fetch('https://localhost:44331/api/lot/GetAllLotsWithPhoto').then(response => response.json)
//                  .then(data => this.setState({lots: data}))
//     }

//     render(){
//         const {lots} = this.state;

//             return <main className="container content">
//                 {
//                     // lots.length ?  (
//                     // <LotList lots = {this.state.lots} />
//                     // ) : <h3>Loading...</h3>
//                 }  
//             </main> 
//     }
 
// }


export {Main}