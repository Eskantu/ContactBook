
import axios from 'axios'
import Cookies from 'js-cookie'
async function register(usuario) {
    return axios.post('/Usuario', usuario)

}
function Login(credenciales) {
    return axios.post("Authentication/RequestToken", credenciales.state.credenciales)
}
async function setUserLogged(userLogged) {
    Cookies.set('token', userLogged.token);
}
function getUserLogged() {
    return Cookies.get('token')
}
function deleteUserLogged() {
    Cookies.remove('userLogged');
}
export default {
    register, Login, setUserLogged, getUserLogged, deleteUserLogged
}

