import React,{Component,useState} from 'react';
// import { Auth0Provider } from '@auth0/auth0-react'
import { variables } from '../ApiEndPoints/Variables';

// export class SignIn extends Component{
export function SignIn(){

    //render(){
        const [email,setEmail] = useState('')
        const [password,setPassword] = useState('')
        
        return (
            <div class="registration-cssave">
                <form>
                    <h3 class="text-center">Login</h3>

                    <div class="form-group">
                        <input value={email}  onChange={(e) => setEmail(e.target.value) } 
                                class="form-control item" type="text" name="email" maxlength="50" minlength="4" pattern="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" id="email" placeholder="Email" required/>
                    </div>

                    <div class="form-group">
                        <input value={password}   onChange={(e) => setPassword   (e.target.value) } 
                                class="form-control item" type="password" name="password" minlength="6" id="password" placeholder="Password" required/>
                    </div>
                    <div class="form-group">
                        <button class="btn btn-primary btn-block create-account"
                                 type="submit" 
                                 disabled={!(!!(email)) || !(!!(password))}>Sign In</button>
                    </div>
                </form>
            </div>

        )
}

