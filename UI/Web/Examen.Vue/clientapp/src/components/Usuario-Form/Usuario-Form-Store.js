 import StorePrincipal from '../../store/index'

 import auth from '../../auth/auth'
const store = {
    namespaced: true,
    state: { usuario: {}, error: '' },
    mutations: {
        SetUsuario(state, usuario) {
            state.usuario = usuario
        },
        cleanUser(state) {
            state.usuario = {}
        }
    },
    actions: {
        CrearUsuario( {commit },usuario) {
            auth.register(usuario).then(res => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Usuario creado')
                commit('cleanUser');
            }).catch((error) => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Error al crear usuario,'+error.response.data)
            })

        },
    },
};
export default store;
