import VeeValidate from 'vee-validate'
import messagesBr from 'vee-validate/dist/locale/pt_BR'
VeeValidate.Validator.addLocale(messagesBr)

export default ({ Vue }) => {
  Vue.use(VeeValidate, {
    errorBagName: 'vErrors',
    locale: 'pt_BR',
    dictionary: {
      pt_BR: { messages: messagesBr }
    }
  })
}
