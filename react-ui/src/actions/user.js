import axios from 'axios'
import { variables } from '../ApiEndPoints/Variables'
import {useDispatch} from "react-redux";
import {Link,NavLink,Navigate} from 'react-router-dom'
import {setUser} from "../reducers/userReducer";

export const data = {
    token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Ik9sZWgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdXJuYW1lIjoiTWFuZHJhIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoiZm9wQGdtYWlsLmNvbSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2xvY2FsaXR5IjoiVWtyYWluZSxLeWl2IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvaG9tZXBob25lIjoiMDk1OTM3MzA1NSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlJlZ1VzZXIiLCJleHAiOjE2NTg2NzkxMTksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzMxLyIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ0MzMxLyJ9.RpHM9RPoCOYho0FKyBWnaUVghgCc8ONE5CG0BG7fhtY",
    User: {
        "Id": 7,
        "Name": "Oleh",
        "Surname": "Mandra",
        "Location": "Ukraine,Kyiv",
        "PhoneNumber": "095-937-3055",
        "Email": "mandra@gmail.com",
        "Password": "123456",
        "OrdersIds": [
            10
        ],
        "AccessLevel": 2
    }
}

export const registration = async (name,surname,location,phoneNumber,email,password,accessLevel = 2 ) =>
{
    // return async (dispatch) => {
    //     return await axios.post(`${variables.API_URL}user/add`,{
    //                 name,
    //                 surname,
    //                 location,
    //                 phoneNumber,
    //                 email,
    //                 password,
    //                 accessLevel      
    //             }).then((response) => {
    //                 console.log(response);
    //             })
    //             .catch((response) => console.log(response));
    // };


    try {
        const response = await axios.post(variables.API_URL+'user/add',{
            name,
            surname,
            location,
            phoneNumber,
            email,
            password,
            accessLevel      
        })
        alert("Congradulations")
    }
    catch (e) {
        alert(e)
    }

}

export const login =  (email, password) => {

    //  return (dispatch) => {
    //     fetch(variables.API_URL+'Authenticate',{
    //     method: 'POST',
    //     headers:{
    //         'Accept':'application/json',
    //         'Content-Type':'application/json'
    //     },
    //     body:JSON.stringify({
    //         "EmailAddress" : email, "Password": password
    //         })
    //     })
    //     .then(response => response.json())
    //     .then(data => {
    //         console.log(data)
    //         dispatch(setUser(data.User))
    //         localStorage.setItem('token', data.token)
    //     });
    // };

    return async dispatch => {
       
        try {
            // const response = await axios.put(variables.API_URL+'Authenticate', 
            // { 
            //     // email, password
            //     "EmailAddress" : email, 
            //     "Password": password
            // })

            // dispatch(setUser(response.data.User))
            // localStorage.setItem('token', response.data.token)

            if(email != data.User.Email || password != data.User.Password){
                alert('User not found')
            }
            else{
            dispatch(setUser(data.User))
            localStorage.setItem('token', data.token)
            }
            
        } catch (e) {
            alert(e)
        }
    }
}

// export const auth =  () => {
//     return async dispatch => {
//         try {
//             const response = await axios.get(`http://localhost:5000/api/auth/auth`,
//                 {headers:{Authorization:`Bearer ${localStorage.getItem('token')}`}}
//             )
//             dispatch(setUser(response.data.user))
//             localStorage.setItem('token', response.data.token)
//         } catch (e) {
//             alert(e.response.data.message)
//             localStorage.removeItem('token')
//         }
//     }
// }