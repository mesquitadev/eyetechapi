import cInput from '@root/components/shared/form/input'
import cTable from '@root/components/shared/common/dataTable'
import cForm from '@root/components/shared/form/'
import sData from '@components/shared/form/selectData'
import cStatus from '@components/shared/form/status'
import cDate from '@components/shared/form/date'

export default ({ Vue }) => {
  Vue.component('cInput', cInput)
  Vue.component('cTable', cTable)
  Vue.component('cForm', cForm)
  Vue.component('sData', sData)
  Vue.component('cStatus', cStatus)
  Vue.component('cDate', cDate)
}
