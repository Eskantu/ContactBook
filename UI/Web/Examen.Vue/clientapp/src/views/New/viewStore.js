import StorePrincipal from '../../store/index'
import router from '../../router/index'

const store = {
    namespaced: true,
    state: {},
    mutations: {},
    actions: {
        CreateProject() {
            StorePrincipal.commit("SnackStore/SetSnack", "Proyecto creado")
            router.push({ name: "Home" })
        }
    }
}

export default store