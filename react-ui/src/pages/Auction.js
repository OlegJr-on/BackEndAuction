import React,{Component} from 'react';
import { variables } from '../ApiEndPoints/Variables';


export class Auction extends Component{
    
    constructor(props){
        super(props);
        this.state = {
            lots: []
        }
    }
    
    refreshList(){
        fetch(variables.API_URL+'lot/GetAllLotsWithPhoto')
        .then(response => response.json())
        .then(data => {
            this.setState({lots:data});
        });
    }

    componentDidMount(){
        this.refreshList();
    }

    render(){
        const{
            lots
        } = this.state;

        return (
            <div className='auction'> 
                 <table class="table-auction striped">
                    <thead>
                        <tr>
                            <th>Img</th>
                            <th>Lot №</th>
                            <th>Title</th>
                            <th>Start price </th>
                            <th>Start date</th>
                            <th>End date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lots.map(lot => 
                            <tr key= {lot.Id}>
                                <td><img height="45" width="55" src={lot.PhotoSrc}/></td>
                                <td>{lot.id}</td>
                                <td> <a href = {variables.API_URL+'lot/GetById/'+lot.id}>{lot.Title} </a></td>
                                <td>{lot.StartPrice} $</td>
                                <td>{lot.StartDate}</td>
                                <td>{lot.EndDate}</td>
                            </tr>
                            )}
                    </tbody>
                </table>
            </div>
        )
    }
}
