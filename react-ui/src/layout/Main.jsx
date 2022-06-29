import React from 'react';
import {BrowserRouter,Route,Routes} from 'react-router-dom'
import {Auction} from "../pages/Auction";
import {About} from "../pages/About";
import { Home } from "../pages/Home";
import {Rou} from "../layout/Header"

function Main(){
    return (
        <main className="container content">
            
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