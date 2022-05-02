import axios from 'axios'

const store = {
    namespaced: true,
    state: {
        cargando: true,
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
        }
    }
}

export default store