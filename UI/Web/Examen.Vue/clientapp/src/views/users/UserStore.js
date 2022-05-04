import axios from 'axios'

const store = {
    namespaced: true,
    state: {
        cargando: true,
        Edit: false,
        Delete: false,
        New: false,
        userList: [], userSelect: {}, search: '', headers: [
            { text: 'Nombre', value: 'nombre' },
            { text: 'Email', value: 'email' },
            { text: 'Activo', value: 'isActive', sortable: false },
            { text: 'Creado por', value: 'creadoPor' },
            { text: 'Modulos', value: 'modulos' },
            { text: 'Fecha Creacion', value: 'fechaCreacion' },
        ]
    },
    mutations: {
        setUserList(state, items) {
            state.cargando = false
            state.userList = items
        },
        setShowDelete(state, show) {
            state.Delete = show
        },
        setShowEdit(state, show) {
            state.Edit = show
        },
        setShowNew(state, show) {
            state.New = show
        }
    },
    actions: {
        ObtenerUsuarios({ commit }) {
            axios.get('/Usuario').then(res => commit("setUserList", res.data)).catch(e => console.log(e.response))
        },
        SetSearch({ state }, search) {
            state.search = search
        },
        SetLoading({ state }, loading) {
            state.loading = loading
        },
        showDelete({ commit }, value) {
            commit('setShowDelete', value)
        },
        showEdit({ commit }, value) {
            commit('setShowEdit', value)
        },
        showNew({ commit }, value) {
            commit('setShowNew', value)
        },
        success({ commit }, value) {
        if(value==='edit')  commit('setShowEdit', false)
         console.log('success', value)
        },
        cancel({ commit }, value) {
            if(value==='edit')  commit('setShowEdit', false)
            console.log('cancel', value)
        }
    }

}

export default store