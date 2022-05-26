import axios from 'axios'
import server from '@service/server'

axios.defaults.baseURL = server.hostServer()

export default ({ Vue }) => {
  Vue.prototype.$axios = axios
}
