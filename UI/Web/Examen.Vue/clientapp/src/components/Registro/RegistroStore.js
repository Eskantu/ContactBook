 import StorePrincipal from '../../store/index'

 import auth from '../../auth/auth'
const store = {
    namespaced: true,
    state: { usuario: {}, error: '' },
    mutations: {
        SetUsuario(state, usuario) {
            state.usuario = usuario
        }
    },
    actions: {
        CrearUsuario( {commit },usuario) {
            console.log(usuario)
            console.log(commit)
            auth.register(usuario).then(res => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Usuario creado')
            }).catch((error) => {
                console.log(error.response.data)
                StorePrincipal.commit('SnackStore/SetSnack', 'Error al crear usuario,'+error.response.data)
            })

        },
    },
};
export default store;
