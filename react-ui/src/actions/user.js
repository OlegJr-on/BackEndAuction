import axios from 'axios'
import { variables } from '../ApiEndPoints/Variables'


export const registration = async (name,surname,location,phoneNumber,email,password,confirmPassword,accessLevel = 2 ) =>
{
    if(password != confirmPassword){
        alert('Password don`t similar')
    }

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

    }
    catch (e) {
        alert(e)
    }
}