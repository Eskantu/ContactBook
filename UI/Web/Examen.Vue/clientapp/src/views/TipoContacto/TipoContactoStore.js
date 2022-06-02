import TipoContacto from '../../API/TipoContacto';
import MainStore from '../../store/index'
const store = {
  namespaced: true,
  state: {
    accion:'nuevo',
    items: [],
    selectedItems:[],
    headers: [
      { isCustom: false, text: 'Nombre', value: 'nombre', align: 'center', },
    ],
    keyItem: 'idTipoContacto',
    search: '',
  },
  mutations: {
    setItems(state, items) {
      state.items = items;
    },
    setSelectedItems(state, item) {
      if (state.selectedItems.includes(item)) {
        state.selectedItems = state.selectedItems.filter((i) => i !== item);
      } else {
        state.selectedItems.push(item);
      }
    },
    setSearch(state, search) {
      state.search = search;
    },
    setAccion(state, accion) {
      state.accion = accion;
    }
  },
  actions: {
    ObtenerTipoContacto({ commit }) {
      TipoContacto.Obtener().then((response) => {
        commit('setItems', response.data);
      });
    },

    EditarContacto({ commit }, item) {
      MainStore.commit('TipoContactoFormStore/SetTipoContacto', item)
      commit('setSelectedItems', item)
    },
    EliminarTipoContacto({ commit,dispatch }, tipoContacto) {
      TipoContacto.Eliminar(tipoContacto.idTipoContacto).then(res => {
        MainStore.commit('SnackStore/SetSnack', 'Code:' + res.status + ' Tipo de contacto eliminado')
        commit('setSelectedItems', tipoContacto)
        dispatch('ObtenerTipoContacto');
      }).catch((error) => {
        MainStore.commit('SnackStore/SetSnack', 'Error al eliminar tipo de contacto,' + error.response.data)
      })
    }
  },
  getters: {
    DisabledButtonEditDelete(state) {
      if (state.selectedItems.length == 0) {
        return { edit: true, delete: true };
      } else if (state.selectedItems.length == 1) {
        return { edit: false, delete: false };
      } else if (state.selectedItems.length > 1) {
        return { edit: true, delete: false };
      } else {
        return { edit: false, delete: true };
      }
    }
  }
}

export default store

