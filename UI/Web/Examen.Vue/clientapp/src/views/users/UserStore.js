import Mainstore from '../../store'
import Usuario from '../../API/Usuario'
const store = {
    namespaced: true,
    state: {
        cargando: true,
        Edit: false,
        Delete: false,
        New: false,
        userList: [], userSelect: {}, search: '', headers: [
            { text: 'Nombre', value: 'nombre',align: 'start', },
            { text: 'Detalles', value: 'detalles',align: 'start', },
            { text: 'Email', value: 'email',align: 'start' },
            { text: 'Activo', value: 'isActive',align: 'start', sortable: false },
            { text: 'Creado por', value: 'creadoPor',align: 'start' },
            { text: 'Modulos', value: 'modulos',align: 'start' },
            { text: 'Fecha Creacion', value: 'fechaCreacion',align: 'start' },
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
            Usuario.Obtener().then(res => commit("setUserList", res.data)).catch(e => {
                console.log(e.response)
                 Mainstore.commit("SnackStore/SetSnack", e.status)
            })
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
            Mainstore.commit('UsuarioFormStore/SetUsuario', value.usuario)
            commit('setShowEdit', value.show)
        },
        showNew({ commit }, value) {
            commit('setShowNew', value)
        },
        cancel({ commit }, value) {
            if (value === 'edit') commit('setShowEdit', false)
            console.log('cancel', value)
        },
        guardarUser({ commit, dispatch, state }, object) {
            if (object.form.submitform(object.action)) {
                state.userSelect = []
                commit('setShowNew', false)
                commit('setShowEdit', false)
            }
            dispatch('ObtenerUsuarios')
        },
        eliminarUsuario({ commit, dispatch, state }, usuario) {
            // Usuario.Eliminar(usuario.idUsuario).then(res => {
            //     state.userSelect = []
            //     dispatch('ObtenerUsuarios')
            // }).catch(e => console.log(e.response))
        }
    }

}

export default store