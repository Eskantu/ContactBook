const store = {
  namespaced: true,
  state: {
    items: [],
    selectedItems: [],
    search: '',
    accion: '',
    showModal: false,
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
    setShowModal(state, showModal) {
      state.showModal = showModal;
    }

  },
  actions: {
    // ObtenerTipoContacto({ commit }) {
    //   TipoContacto.Obtener().then((response) => {
    //     commit('setItems', response.data);
    //   });
    // }
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
    },
  }
}

export default store