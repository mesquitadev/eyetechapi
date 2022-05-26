import { LocalStorage } from 'quasar'

const checkLogin = () => {
  var token = LocalStorage.get.item('token') || null
  if (!token) return false
  else return true
}

const token = () => {
  var obj = LocalStorage.get.item('token')
  if (obj) {
    return obj
  } else {
    return null
  }
}

export default { checkLogin, token }
