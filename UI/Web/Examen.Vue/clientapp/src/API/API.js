import axios from 'axios'

function uploadFile(file) {
  return axios.post('/File', file, { headers: { 'Content-Type': 'multipart/form-data' } })
}

export default {
  uploadFile
}