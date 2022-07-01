import React,{Component, useState} from 'react';
import { registration } from '../actions/user';
import { Input } from '../components/input';
import { Link } from 'react-router-dom';

const useInput = (initialValue) => {

    const [value,setValue] = useState(initialValue)
    const [isDirty,setDirty] = useState(false)

    const onChange = (e) => {
        setValue(e.target.value)
    }

    const onBlur = (e) => {
        setDirty(true)
    }

    return(
        value,
        onChange,
        onBlur
    )
}



const Registration = () =>{
     
    const [name,setName] = useState("")
    const [surname,setSurname] = useState("")
    const [location,setLocation] = useState("")
    const [phoneNumber,setPhoneNumber] = useState("")
    const [email,setEmail] = useState("")
    const [password,setPassword] = useState("")
    const [confirmPassword,setConfirmPasswordl] = useState("")

    return (
        <>
            <div class="container">
                <h1>Register</h1>
                <p>Please fill in this form to create an account.</p>
                <hr/>

                <label><b>Name</b></label>
                <Input value={name} setValue={setName} type="text" placeholder="Enter Name" />

                <label><b>Surname</b></label>
                <Input value={surname} setValue={setSurname} type="text" placeholder="Enter Surname" />

                <label><b>Location</b></label>
                <Input value={location} setValue={setLocation} type="text" placeholder="Enter Location" />

                <label><b>Phone Number</b></label>
                <Input value={phoneNumber} setValue={setPhoneNumber} type="text" placeholder="Enter Number" />

                <label><b>Email</b></label>
                <Input value={email} setValue={setEmail} type="text" placeholder="Enter Email" pattern="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"/>

                <label><b>Password</b></label>
                <Input value={password} setValue={setPassword} type="password" placeholder="Enter Password" />

                <label><b>Confirm Password</b></label>
                <Input value={confirmPassword} setValue={setConfirmPasswordl} type="password" placeholder="Enter Password" />

                <hr/>
                <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

                <button onClick={() => registration(name,surname,location,phoneNumber,email,password,confirmPassword)}
                         type="submit" 
                         class="registerbtn">Register</button>
            </div>
            
            <div class="container signin">
                <p>Already have an account? <Link to="/SignIn">Sign in</Link>.</p>
            </div>
        </>
    )
}

export default Registration;

{/* <label for="name"><b>Name</b></label>
<input onChange={() => name} value={name} type="text" placeholder="Enter Name" name="name" required/>

<label for="surname"><b>Surname</b></label>
<input value={surname} type="text" placeholder="Enter Surname" name="surname" required/>

<label for="location"><b>Location</b></label>
<input value={location} type="text" placeholder="Enter Location" name="location" required/>

<label for="PhoneNumber"><b>Phone Number</b></label>
<input value={phoneNumber} type="text" placeholder="Enter Number" name="phoneNumber" required/>

<label for="email"><b>Email</b></label>
<input value={email} type="text" placeholder="Enter Email" name="email" required/>

<label for="password"><b>Password</b></label>
<input value={password} type="password" placeholder="Enter Password" name="password" required/>

<label for="ConfirmPassword"><b>Confirm Password</b></label>
<input value={confirmPassword} type="password" placeholder="Confirm Password" name="confirmPassword" required/> */}


// export class Registration extends Component{
    
//     constructor(props){
//         super(props);
//         this.state = {
//             user: []
//         }
//     }
    
//     refreshList(){
//         fetch(variables.API_URL+'user/add',{
//             method: 'POST',
//             headers:{
//                 'Accept':' */*',
//                 'Content-Type':'application/json-patch+json'
//             },
//             body: JSON.stringify({
//                 Name:this.state.Name
//             })
//         })
//         .then(response => response.json());
//     }

//     componentDidMount(){
//         this.refreshList();
//     }

//     render(){
//         const{
//             user,
//             Id,
//             Name,
//             Surname,
//             Location,
//             PhoneNumber,
//             Email,
//             Password,
//             ConfirmPassword
//         } = this.state;

//         return (
//             <form action={variables.API_URL+'user/add'}>
//                 <div class="container">
//                     <h1>Register</h1>
//                     <p>Please fill in this form to create an account.</p>
//                     <hr/>

//                     <label for="name"><b>Name</b></label>
//                     <input type="text" placeholder="Enter Name" name="name" required/>

//                     <label for="surname"><b>Surname</b></label>
//                     <input type="text" placeholder="Enter Surname" name="surname" required/>

//                     <label for="location"><b>Location</b></label>
//                     <input type="text" placeholder="Enter Location" name="location" required/>

//                     <label for="PhoneNumber"><b>Phone Number</b></label>
//                     <input type="text" placeholder="Enter Number" name="phoneNumber" required/>

//                     <label for="email"><b>Email</b></label>
//                     <input type="text" placeholder="Enter Email" name="email" required/>

//                     <label for="password"><b>Password</b></label>
//                     <input type="password" placeholder="Enter Password" name="password" required/>

//                     <label for="ConfirmPassword"><b>Confirm Password</b></label>
//                     <input type="password" placeholder="Confirm Password" name="confirmPassword" required/>
//                     <hr/>
//                     <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

//                     <button type="submit" class="registerbtn">Register</button>
//                 </div>
                
//                 <div class="container signin">
//                     <p>Already have an account? <a href="#">Sign in</a>.</p>
//                 </div>
//             </form>
//         )
//     }
// }




