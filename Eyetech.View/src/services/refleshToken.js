import { Loading, LocalStorage } from 'quasar'
// import axios from 'axios'
const RefleshToken = (error) => {
  if (error === 401) {
    Loading.show({
      message: 'Revalidando dados do usuário'
    })
    // var auth = store.state.mod.auth
    // var user = auth.user
    // var token = LocalStorage.get.item('token')
    // user.token = token
    LocalStorage.remove('user')
    LocalStorage.remove('token')
    LocalStorage.remove('menus')
    LocalStorage.remove('expiration')
    window.location.href = '/'
    // axios.post('api/auth/refleshToken', user)
    //   .then(resp => {
    //     store.dispatch('mod/Login', resp.data.accessToken)
    //     Loading.hide()
    //   })
    //   .catch(error => {
    //     Notify.create({
    //       message: error.response.data.message,
    //       type: 'negative'
    //     })
    //     Loading.hide()
    //     store.commit('mod/Logout')
    //     window.location.href = '/'
    //   })
  }
}

export default { RefleshToken }
