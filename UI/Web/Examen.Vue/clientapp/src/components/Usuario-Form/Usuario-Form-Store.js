 import StorePrincipal from '../../store/index'
 import auth from '../../auth/auth'
import Usuario from '../../API/Usuario';
const store = {
    namespaced: true,
    state: { usuario: {}, error: '' },
    mutations: {
        SetUsuario(state, usuario) {
            console.log('SetUsuario', usuario)
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
        EditarUsuario({ commit }, usuario) {
            console.log('EditarUsuario', usuario)
            Usuario.Actualizar(usuario).then(res => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Usuario actualizado')
                commit('cleanUser');
            }).catch((error) => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Error al actualizar usuario,' + error.response.data)
            })
        }
    },
};
export default store;
