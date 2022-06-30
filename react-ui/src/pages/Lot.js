import React,{ useEffect, useState} from 'react';
import { useParams } from 'react-router-dom';
import { variables } from '../ApiEndPoints/Variables';


export function Lot(){

    const params = useParams()
    const lotId = params.lotId
    const [lot,setLot] = useState({})
    const [photo,setPhotos] = useState([])
    
    function refreshList(){
        fetch(variables.API_URL+ 'lot/GetPhotoInGroup/' + lotId)
        .then(response => response.json())
        .then(data => { setPhotos(data) 
        });

        fetch(variables.API_URL+ 'lot/GetById/'+ lotId)
        .then(response => response.json())
        .then(data => { setLot(data) 
        });
    }

    useEffect(
        () => refreshList ,[]
    )

    return(
        <div className="lot-description">

            {/* <div className="w3-content w3-display-container">
            {
                photo.map(photo => 
                <div key= {photo.Id}>
                    <img className="mySlides" src={photo.PhotoSrc}/> 
                 </div>)
            }
                <button className="w3-button w3-black w3-display-left" onclick="plusDivs(-1)">&#10094;</button>
                <button className="w3-button w3-black w3-display-right" onclick="plusDivs(1)">&#10095;</button>
            </div> */}
            <div classNameName='photo-slider'>
                {

                    photo.map(photo => 
                    <p key= {photo.Id}>
                       <img height="350" width="500" src={photo.PhotoSrc}/> 
                    </p>)
                }
            </div>

                <table>

                    <tr>
                        <td><h3>{lot.Title}</h3></td>
                    </tr>
                    <tr>
                        <td>Price Now:</td>
                        <td> <b>$ {lot.CurrentPrice}</b></td>
                    </tr>
                    <tr>
                        <td>Start price:</td>
                        <td> <b>$ {lot.StartPrice}</b></td>
                    </tr>
                    <tr>
                        <td>Minimum rate: </td>
                        <td> <b>{lot.MinRate} $</b></td>
                    </tr>
                    <tr>
                        <td>Status lot:</td> <td>
                             <b>
                                {lot.Status == 1 ? "lot" : "lotbid"}
                             </b>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>Period:</h4></td>
                    </tr>
                    <tr>
                        <td>Start: </td>
                        <td> <b>{lot.StartDate}</b></td>
                    </tr>
                    <tr>
                        <td>End: </td>
                        <td> <b> {lot.EndDate} </b></td>
                    </tr>

                </table>
             </div>
        ) 
}