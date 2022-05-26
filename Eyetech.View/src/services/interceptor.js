import axios from 'axios'
import { defaults } from 'lodash'
import chave from './index'
import server from './server'

axios.defaults.baseURL = server.hostServer()
axios.defaults.headers.common['Authorization'] = 'Bearer ' + chave.token()
axios.defaults.headers['Content-Type'] = 'application/json'
axios.defaults.headers['WebPago'] = 'bcfa709971dba83db68bc1bb371310d8'
axios.defaults.headers['Accept'] = 'application/json'
axios.defaults.headers['cache-control'] = 'no-cache'

export const createCliente = (options = {}) => axios.create(defaults({
  baseURL: server.hostServer()
}, options))

export default createCliente({})
