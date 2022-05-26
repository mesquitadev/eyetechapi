import store from '../store/module/state'

const validaUrl = (pasta) => {
  if (store.auth.menus) {
    if (store.auth.menus.find(x => x.nomeRouter.toLowerCase() === pasta.name.toLowerCase()) || pasta.name === 'dashboard') {
      return true
    } else {
      return false
    }
  }
  return false
}

export default (to, from, next) => {
  if (to.matched.some(record => record.meta.auth)) {
    if (!store.auth.login) {
      next({
        path: '/auth'
      })
    } else {
      if (validaUrl(to)) {
        next()
      } else {
        next('/')
      }
    }
  } else {
    next()
  }
}
