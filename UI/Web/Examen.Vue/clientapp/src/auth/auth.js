
import axios from 'axios'
import Cookies from 'js-cookie'
async function register(usuario) {

    var x = await fetch('https://api.ipify.org?format=json');
    var iP = await x.json();
    usuario.state.usuario.createdFor = iP.ip
    return axios.post('/user', usuario.state.usuario)

}
function Login(credenciales) {
    return axios.post("user/buscar", credenciales.state.credenciales)
}
async function setUserLogged(userLogged) {
    Cookies.set('userLogged', userLogged);
}
function getUserLogged() {
    return Cookies.get('userLogged')
}
function deleteUserLogged() {
    Cookies.remove('userLogged');
}
export default {
    register, Login, setUserLogged, getUserLogged, deleteUserLogged
}

