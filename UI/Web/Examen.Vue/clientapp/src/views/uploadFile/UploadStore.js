import API from '../../API/API';

const store = {
  namespaced: true,
  state: {
    filesUploaded: [],
    fileNotUploaded: [],
    fileSelect: [],
    showFilesUploaded: false,
    isUploading: false,
    headers: [
      { text: 'Nombre', value: 'name' },
      { text: 'Tipo', value: 'type' },
      { text: 'Tamaño', value: 'size' },
    ]
  },
  mutations: {
    UpdateFileList(state, payload) {
      state.fileNotUploaded = [];
      state.filesUploaded.push(payload);
    },
    setIsUploading(state, value) {
      state.isUploading = value;

    },
    setFile(state, payload) {
      //  console.log(payload);
      // if (state.fileNotUploaded.length == 0) {
      //   state.fileNotUploaded.push(new FormData());
      // }
      payload.forEach(element => {
        state.fileNotUploaded.push({ name: element.name, type: element.type, size: element.size, file: element });
      });
      // state.fileNotUploaded[0].append('file', payload);
      // console.log(state.fileNotUploaded[0]);
      // console.log(state.fileNotUploaded[0].getAll('file'));

    }
  },
  actions: {
    handleFileUpload({ commit }, event) {
      commit('setFile', event);
    },
    upload({ commit }, data) {
      commit('setIsUploading', true);
      var file = new FormData();
      data.forEach(element => {
        file.append('file', element.file);
      });
      return API.uploadFile(file)
        .then(response => {
          commit('setIsUploading', false);
          commit('UpdateFileList', response.data.data)
        })
        .catch(() => {
          commit('setIsUploading', false);
        });
    }
  },
}

export default store