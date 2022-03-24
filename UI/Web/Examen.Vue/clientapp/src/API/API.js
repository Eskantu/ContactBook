import axios from 'axios'

function uploadFile(file) {
  // console.log(file)
  return axios.post('/upload', file, { headers: { 'Content-Type': 'multipart/form-data' } })
}

export default {
  uploadFile
}