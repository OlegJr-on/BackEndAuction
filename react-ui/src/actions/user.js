import axios from 'axios'
import { variables } from '../ApiEndPoints/Variables'


export const registration = async (name,surname,location,phoneNumber,email,password,accessLevel = 2 ) =>
{
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