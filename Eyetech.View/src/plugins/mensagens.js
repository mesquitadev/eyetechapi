import {Notify} from 'quasar'

const FormResponse = (msg, success) => {
  if (success) {
    Notify.create({
      message: msg,
      type: 'positive'
    })
  } else {
    Notify.create({
      message: msg,
      type: 'negative'
    })
  }
}

export default ({ Vue }) => {
  Vue.prototype.$mensagens = { FormResponse }
}
