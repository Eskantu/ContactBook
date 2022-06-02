
import TipoUsuario from '../../API/TipoContacto'
import Rules from '../../utils/validators'
import MainStore from '../../store/index'
const store = {
  namespaced: true,
  state: { tipoContacto: {}, rules: Rules },
  mutations: {
    SetTipoContacto(state, tipoContacto) {
      console.log('SetTipoContacto', tipoContacto)
      state.tipoContacto = tipoContacto
    },
    cleanTipoContacto(state) {
      state.tipoContacto = {}
    }
  },
  actions: {
    CrearTipoContacto({ commit }, tipoContacto) {
      TipoUsuario.Crear(tipoContacto).then(res => {
        console.log('res', res)
        MainStore.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Tipo de contacto creado')
        commit('cleanTipoContacto');
      }).catch((error) => {
        MainStore.commit('SnackStore/SetSnack', 'Error al crear tipo de contacto,' + error.response.data)
      })
    },
    EditarTipoContacto({ commit }, tipoContacto) {
      TipoUsuario.Actualizar(tipoContacto).then(res => {
        MainStore.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Tipo de contacto actualizado')
        commit('cleanTipoContacto');
      }).catch((error) => {
        MainStore.commit('SnackStore/SetSnack', 'Error al actualizar tipo de contacto,' + error.response.data)
      })
    },

  },
};
export default store;