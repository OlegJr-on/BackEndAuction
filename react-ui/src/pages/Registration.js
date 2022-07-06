import React,{Component} from 'react';
import { registration } from '../actions/user';
import { Link } from 'react-router-dom';

class Registration extends Component {
    constructor (props) {
      super(props);
      this.state = {
        name:'',
        surname:'',
        location: '',
        phoneNumber: '',
        email: '',
        password: '',
        confirmPassword: '',

        formErrors: {email: '', password: '',name:'', surname:'',location: '',phoneNumber: '',confirmPassword: ''},

        emailValid: false,
        passwordValid: false,
        nameValid: false,
        surnameValid: false,
        locationValid: false,
        phoneNumberValid: false,
        confirmPasswordValid: false,
        formValid: false
      }
    }
  
    handleUserInput = (e) => {
      const name = e.target.name;
      const value = e.target.value;
      this.setState({[name]: value},
                    () => { this.validateField(name, value) });
    }
  
    validateField(fieldName, value) {
      let fieldValidationErrors = this.state.formErrors;
      let nameValid = this.state.nameValid;
      let surnameValid = this.state.surnameValid;
      let locationValid = this.state.locationValid;
      let phoneNumberValid = this.state.phoneNumberValid;
      let emailValid = this.state.emailValid;
      let passwordValid = this.state.passwordValid;
      let confirmPasswordValid = this.state.confirmPasswordValid;
  
      switch(fieldName) {

        case 'surname':
          surnameValid = !/\d/.test(fieldName) && value.length >= 2 && value.length < 25;
          fieldValidationErrors.surname = surnameValid ? '': ' is invalid';
          break;

        case 'name':
          nameValid = !/\d/.test(fieldName) && value.length >= 2 && value.length < 15;
          fieldValidationErrors.name = nameValid ? '': ' is invalid';
          break;

        case 'location':
            locationValid =  value.match(/^([\w-]{3,}),([\w]{3,})$/);
            fieldValidationErrors.location = locationValid ? '': ' is invalid (Example: Kyiv,Ukraine)';
            break;
        
        case 'phoneNumber':
            phoneNumberValid =  value.match(/^([0-9]{3,3})-([0-9]{3,3})-([0-9]{4,4})$/);
            fieldValidationErrors.phoneNumber = phoneNumberValid ? '': ' is invalid (Example: 066-666-3033)';
            break;

        case 'email':
          emailValid = value.match(/^([\w.%+-]+)@([\w-]+\.)+([\w]{2,})$/i);
          fieldValidationErrors.email = emailValid ? '' : ' is invalid';
          break;

        case 'password':
          passwordValid = value.length >= 6;
          fieldValidationErrors.password = passwordValid ? '': ' is too short';
          break;
        
        case 'confirmPassword':
            confirmPasswordValid = (this.state.password == this.state.confirmPassword);
            fieldValidationErrors.confirmPassword = confirmPasswordValid ? '': ' -> passwords must match';
            break;

        default:
          break;
      }
      this.setState({formErrors: fieldValidationErrors,
                      nameValid: nameValid,
                      surnameValid: surnameValid,
                      locationValid: locationValid,
                      phoneNumberValid: phoneNumberValid,
                      emailValid: emailValid,
                      passwordValid: passwordValid,
                      confirmPasswordValid: confirmPasswordValid
                    }, this.validateForm);
    }
  
    validateForm() {
      this.setState({formValid: this.state.nameValid && this.state.emailValid && 
                                this.state.surnameValid && this.state.passwordValid &&
                                this.state.locationValid && this.state.phoneNumberValid && 
                                this.state.confirmPasswordValid});
    }
  
    errorClass(error) {
      return(error.length === 0 ? '' : 'has-error');
    }
  
    render () {
      return (
        <form className="demoForm">
            <div className="container">
                    <h1>Register</h1>
                    <p>Please fill in this form to create an account.</p>
                    <hr/>

                <div className={`form-group ${this.errorClass(this.state.formErrors.name)}`}>
                    <label htmlFor="name">Name</label>
                    <input type="text" required className="form-control" name="name"
                    placeholder="Your Name"
                    value={this.state.name}
                    onChange={this.handleUserInput}  />
                </div>

                <div className={`form-group ${this.errorClass(this.state.formErrors.surname)}`}>
                    <label htmlFor="surname">Surname</label>
                    <input type="text" required className="form-control" name="surname"
                    placeholder="Your Surname"
                    value={this.state.surname}
                    onChange={this.handleUserInput}  />
                </div>

                <div className={`form-group ${this.errorClass(this.state.formErrors.location)}`}>
                    <label htmlFor="location">Location Adress</label>
                    <input type="text" required className="form-control" name="location"
                    placeholder="Your Location"
                    value={this.state.location}
                    onChange={this.handleUserInput}  />
                </div>

                <div className={`form-group ${this.errorClass(this.state.formErrors.phoneNumber)}`}>
                    <label htmlFor="phoneNumber">Phone Number</label>
                    <input type="text" required className="form-control" name="phoneNumber"
                    placeholder="Your Phone"
                    value={this.state.phoneNumber}
                    onChange={this.handleUserInput}  />
                </div>

                <div className={`form-group ${this.errorClass(this.state.formErrors.email)}`}>
                    <label htmlFor="email">Email address</label>
                    <input type="email" required className="form-control" name="email"
                    placeholder="Your Email"
                    value={this.state.email}
                    onChange={this.handleUserInput}  />
                </div>

                <div className={`form-group ${this.errorClass(this.state.formErrors.password)}`}>
                    <label htmlFor="password">Password</label>
                    <input type="password" className="form-control" name="password"
                    placeholder="Your Password"
                    value={this.state.password}
                    onChange={this.handleUserInput}  />
                </div>   

                <div className={`form-group ${this.errorClass(this.state.formErrors.confirmPassword)}`}>
                    <label htmlFor="confirmPassword">Confirm Password</label>
                    <input type="password" className="form-control" name="confirmPassword"
                    placeholder="Enter Password"
                    value={this.state.confirmPassword}
                    onChange={this.handleUserInput}  />
                </div>   

                <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

                <button onClick={() => registration(this.state.name,this.state.surname,this.state.location,
                                                    this.state.phoneNumber,this.state.email,this.state.password)}
                         className="btn btn-primary" disabled={!this.state.formValid}
                         type="submit" 
                         >Register</button>
                    <div className="panel panel-default">
                        <FormErrors formErrors={this.state.formErrors} />
                    </div>
            </div>
            
            <div class="container signin">
                <p>Already have an account? <Link to="/SignIn">Sign in</Link>.</p>
            </div>   
        </form>
      )
    }
  }
  
  
  const FormErrors = ({formErrors}) =>
  <div className='formErrors'>
    {Object.keys(formErrors).map((fieldName, i) => {
        if(formErrors[fieldName].length > 0){
            return (
                <p style={{color:'red'}} key={i}>*{fieldName} {formErrors[fieldName]}</p>
                )        
            } else {
                return '';
            }
        })}
  </div>
export {Registration};






// const useValidation = (value,validations) => {

//     const [isEmpty,setEmpty] = useState(true)
//     const [minLengthError,setMinLengthError] = useState(false)

//     useEffect( () => {
//         for(const validation in validations)
//         {
//             switch(validation){
//                 case 'minLength':
//                     value.length < validations[validation] ? setMinLengthError(true) : setMinLengthError(false)
//                     break;
                
//                 case 'isEmpty':
//                     value ? setEmpty(false) : setEmpty(true)
//                     break;
//             }
//         }
//     },[value])

//     return(
//         isEmpty,
//         minLengthError
//     )
// }

// const useInput = (initialValue,validations) => {

//     const [value,setValue] = useState(initialValue)
//     const [isDirty,setDirty] = useState(false)
//     const valid = useValidation(value,validations)

//     const onChange = (e) => {
//         setValue(e.target.value)
//     }

//     const onBlur = (e) => {
//         setDirty(true)
//     }

//     return(
//         value,
//         onChange,
//         onBlur,
//         isDirty,
//         valid
//     )
// }



// const Registration = () =>{

//     const [name,setName] = useState("")
//     const [surname,setSurname] = useState("")
//     const [location,setLocation] = useState("")
//     const [phoneNumber,setPhoneNumber] = useState("")

//     const [email,setEmail] = useState("")
//     const [password,setPassword] = useState("")
//     const [emailDirty,setEmailDirty] = useState(false)
//     const [passwordDirty,setPasswordDirty] = useState(false)
//     const [emailError,setEmailError] = useState('Email must not be empty')
//     const [passwordError,setPasswordError] = useState('Password must not be empty')
    
//     const [confirmPassword,setConfirmPasswordl] = useState("")
    
//     const emailHandler = (e) =>{
//         setEmail(e.target.value)
//         const val = "^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" 
//         if(!val.test(String(e.target.value).toLowerCase())){
//             setEmailError('Noncorrect Email')
//         }
//         else{
//             setEmailError('')
//         }
//     }


//     const blurHandler = (e) =>{
//         switch(e.target.name){
//             case 'email':
//                 setEmailDirty(true)
//                 break;
            
//             case 'password':
//                 setPasswordDirty(true)
//                 break;
//         }
//     }



//     return (
//         <>
//             {/* <div class="container">
//                 <h1>Register</h1>
//                 <p>Please fill in this form to create an account.</p>
//                 <hr/>

//                 <label><b>Name</b></label>
//                 <input value={name} onChange={(event) => name.setValue(setName(event.target.value))}  type="text" placeholder="Enter Name" />

//                 <label><b>Surname</b></label>
//                 <input value={surname}  type="text" placeholder="Enter Surname" />

//                 <label><b>Location</b></label>
//                 <input value={location} type="text" placeholder="Enter Location" />

//                 <label><b>Phone Number</b></label>
//                 <input value={phoneNumber} type="text" placeholder="Enter Number" />

//                 {(emailDirty && emailError) && <div style={{color:'red'}}>{emailError}</div>}
//                 <label><b>Email</b></label>
//                 <input onChange={e => emailHandler(e)} onBlur={(e => blurHandler(e))} value={email}  type="text" placeholder="Enter Email" name='email'/>

//                 {(passwordDirty && passwordError) && <div style={{color:'red'}}>{passwordError}</div>}
//                 <label><b>Password</b></label>
//                 <input onBlur={(e => blurHandler(e))} value={password} type="password" placeholder="Enter Password" name='password' />

//                 <label><b>Confirm Password</b></label>
//                 <input value={confirmPassword}  type="password" placeholder="Enter Password" />

//                 <hr/>
//                 <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

//                 <button onClick={() => registration(name,surname,location,phoneNumber,email,password,confirmPassword)}
//                          type="submit" 
//                          class="registerbtn">Register</button>
//             </div>
            
//             <div class="container signin">
//                 <p>Already have an account? <Link to="/SignIn">Sign in</Link>.</p>
//             </div> */}
//         </>
//     )
// }

// export default Registration;



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




