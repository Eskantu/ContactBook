import axios from 'axios'
import store from '@/store'

let headerConfig = {
  'JSON': {
    'headers':{'Content-Type': 'application/json'}
  }
}

function GET(controller, action='', data, config = headerConfig.JSON) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
return axios.get(`/${controller}/${action}`, {params: data, headers: config.headers})
}
function POST(controller, action='', data, config = headerConfig.JSON) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
  return axios.post(`/${controller}/${action}`, data, { headers: config.headers })
}
function PUT(controller, action='', data, config = headerConfig.JSON) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
  return axios.put(`/${controller}/${action}`, data, { headers: config.headers })
}
function DELETE(controller, action='', data, config = headerConfig.JSON) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${store.state.user.token}`
  return axios.delete(`/${controller}/${action}`, { params: data, headers: config.headers })
}

export default {
  GET,
  POST,
  PUT,
  DELETE,
  headerConfig
}