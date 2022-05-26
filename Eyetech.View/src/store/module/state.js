import services from '@service'
import { LocalStorage } from 'quasar'

export default {
  auth: {
    status: LocalStorage.get.item('StatusPagamentos') || [],
    menus: LocalStorage.get.item('menus') || [],
    login: services.checkLogin() || false,
    user: LocalStorage.get.item('user') || {},
    plano: LocalStorage.get.item('plano') || {},
    token: services.token() || null,
    chat: false
  }
}
