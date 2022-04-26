import StorePrincipal from '../../store'
import router from "../../router";
import auth from '../../auth/auth'
const store = {
    namespaced: true,
    state: {
        cargando: false,
        credenciales: { UserName: '', Password: '' }
    },
    mutations: {

    },
    actions: {
        ObtenerUsuario(credenciales) {
            auth.Login(credenciales).then(res => {
                StorePrincipal.commit("setUserProfile", res.data)
                StorePrincipal.commit("SnackStore/SetSnack", "Login correcto")
                auth.setUserLogged(res.data)
                this.cargando = false
                router.push({ name: 'Home' })
            }).catch(() => {
                StorePrincipal.commit("SnackStore/SetSnack", "Credenciales incorrectas")
            })

        },
        setLoading({ state }, value) {
            state.cargando = value
        }
    }
}

export default store