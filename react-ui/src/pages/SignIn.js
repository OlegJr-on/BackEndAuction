import React,{Component} from 'react';
import { variables } from '../ApiEndPoints/Variables';


export class SignIn extends Component{

    constructor(props){
        super(props);
        this.state = {
            user: []
        }
    }
    
    render(){
        const{
            user,
            Email,
            Password,
        } = this.state;

        return (
            <div class="registration-cssave">
                <form>
                    <h3 class="text-center">Login</h3>
                    <div class="form-group">
                        <input class="form-control item" type="text" name="email" maxlength="50" minlength="4" pattern="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" id="email" placeholder="Email" required/>
                    </div>
                    <div class="form-group">
                        <input class="form-control item" type="password" name="password" minlength="6" id="password" placeholder="Password" required/>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btn-block create-account" type="submit">Sign In</button>
                    </div>
                </form>
            </div>

        )
    }
}

