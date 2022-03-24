import StorePrincipal from '../../store/index'

import auth from '../../auth/auth'
import axios from 'axios'
const store = {
    namespaced: true,
    state: { usuario: {}, error: '' },
    mutations: {
        SetUsuario(state, usuario) {
            state.usuario = usuario
        }
    },
    actions: {
        CrearUsuario(user) {
            auth.register(user).then(res => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Usuario creado')
            }).catch(() => {
                StorePrincipal.commit('SnackStore/SetSnack', 'Error al crear usuario, verifique datos')
            })

        },
        ObtenerUsuario(/*user*/) {
            axios.post('/user',).then(() => {
               
            }).catch(() => { })
        }
    },
};
export default store;
