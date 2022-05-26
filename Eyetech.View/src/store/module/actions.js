import axios from 'axios'
import { Loading } from 'quasar'
import reflesh from '@service/refleshToken'

export const Login = (context, data) => {
  context.commit('Logout')
  context.commit('setToken', data)
  context.commit('setlogado')
  context.dispatch('GetUser')
}

export const GetMenus = (context) => {
  axios.get('/api/menus')
    .then(resp => {
      context.commit('setMenus', resp.data)
    })
}

export const GetUser = (context) => {
  axios.get('/api/usuarios/logado')
    .then(resp => {
      context.dispatch('GetMenus')
      context.commit('setUser', resp.data)
    })
}

export const GetRequest = (context, objeto) => {
  Loading.show()
  return axios.get('/api/' + objeto.endereco)
    .then(resp => {
      Loading.hide()
      return resp.data
    })
    .catch(erro => {
      Loading.hide()
      reflesh.RefleshToken(erro.request.status)
      return JSON.parse(erro.request.response)
    })
}

export const GetRequestId = (context, objeto) => {
  Loading.show()
  return axios.get('/api/' + objeto.endereco + '/' + objeto.params)
    .then(resp => {
      Loading.hide()
      return resp.data
    })
    .catch(erro => {
      Loading.hide()
      reflesh.RefleshToken(erro.request.status)
      return JSON.parse(erro.request.response)
    })
}

export const PostRequest = (context, objeto) => {
  return axios.post('/api/' + objeto.endereco, objeto.data)
    .then(resp => {
      Loading.hide()
      return resp.data
    })
    .catch(erro => {
      if (erro.request.status === 401) {
        reflesh.RefleshToken(erro.request.status)
      } else {
        Loading.hide()
        return JSON.parse(erro.request.response)
      }
    })
}

export const PutRequest = (context, objeto) => {
  return axios.put('/api/' + objeto.endereco, objeto.data)
    .then(resp => {
      Loading.hide()
      return resp.data
    })
    .catch(erro => {
      if (erro.request.status === 401) {
        reflesh.RefleshToken(erro.request.status)
      } else {
        Loading.hide()
        return JSON.parse(erro.request.response)
      }
    })
}

export const DeleteRequest = (context, objeto) => {
  return axios.delete('/api/' + objeto.endereco, { data: objeto.data })
    .then(resp => {
      Loading.hide()
      return resp.data
    })
    .catch(erro => {
      if (erro.request.status === 401) {
        reflesh.RefleshToken(erro.request.status)
      } else {
        Loading.hide()
        return JSON.parse(erro)
      }
    })
}
