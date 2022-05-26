import {Loading} from 'quasar'

const loading = (acao) => {
  if (acao) {
    Loading.show()
  } else {
    Loading.hide()
  }
}

export default ({ Vue }) => {
  Vue.prototype.$carregar = { loading }
}
