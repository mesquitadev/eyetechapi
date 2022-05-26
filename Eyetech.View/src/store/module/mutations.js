import { LocalStorage } from 'quasar'

export const setUser = (state, user) => {
  state.auth.user = user
  LocalStorage.set('user', user)
}
export const setMenus = (state, menus) => {
  state.auth.menus = menus
  LocalStorage.set('menus', menus)
}

export const setlogado = (state) => {
  state.auth.login = true
}

export const setToken = (state, data) => {
  state.auth.token = data.accessToken
  state.auth.expiration = data.expiration
  LocalStorage.set('token', data.accessToken)
  LocalStorage.set('expiration', data.expiration)
  require('@service/interceptor')
}

export const Logout = (state) => {
  LocalStorage.remove('user')
  LocalStorage.remove('token')
  LocalStorage.remove('menus')
  LocalStorage.remove('expiration')
  state.auth.login = false
}
