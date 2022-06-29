import React,{Component} from 'react';
import { variables } from '../ApiEndPoints/Variables';


export class Registration extends Component{

    constructor(props){
        super(props);
        this.state = {
            user: []
        }
    }
    
    refreshList(){
        fetch(variables.API_URL+'user/add',{
            method: 'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body: JSON.stringify({
                Name:this.state.Name
            })
        })
        .then(response => response.json());
    }

    componentDidMount(){
        this.refreshList();
    }

    render(){
        const{
            user,
            Id,
            Name,
            Surname,
            Location,
            PhoneNumber,
            Email,
            Password,
            ConfirmPassword
        } = this.state;

        return (
            <form action={variables.API_URL+'user/add'}>
                <div class="container">
                    <h1>Register</h1>
                    <p>Please fill in this form to create an account.</p>
                    <hr/>

                    <label for="name"><b>Name</b></label>
                    <input type="text" placeholder="Enter Name" name="name" required/>

                    <label for="surname"><b>Surname</b></label>
                    <input type="text" placeholder="Enter Surname" name="surname" required/>

                    <label for="location"><b>Location</b></label>
                    <input type="text" placeholder="Enter Location" name="location" required/>

                    <label for="PhoneNumber"><b>Phone Number</b></label>
                    <input type="text" placeholder="Enter Number" name="phoneNumber" required/>

                    <label for="email"><b>Email</b></label>
                    <input type="text" placeholder="Enter Email" name="email" required/>

                    <label for="psw"><b>Password</b></label>
                    <input type="password" placeholder="Enter Password" name="psw" required/>

                    <label for="psw-repeat"><b>Confirm Password</b></label>
                    <input type="password" placeholder="Confirm Password" name="psw-repeat" required/>
                    <hr/>
                    <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

                    <button type="submit" class="registerbtn">Register</button>
                </div>
                
                <div class="container signin">
                    <p>Already have an account? <a href="#">Sign in</a>.</p>
                </div>
            </form>
        )
    }
}

