<template>
    <transition
      appear
      enter-active-class="animated fadeIn"
      leave-active-class="animated fadeOut"
    >
      <div id="input">
            <q-datetime v-model='model' :id='id' :name='name'
             :type='type' :autofocus='autofocus' :suffix='suffix'
             :color='color' :disable='disable' :warning='warning'
             :prefix='prefix' :format='format' :clearable='true' :inverted-light='inverted'
             :error='erro' :stack-label="label" :placeholder='placeholder'
            />
            <transition
              appear
              enter-active-class="animated fadeIn"
              leave-active-class="animated fadeOut"
            >
              <span class="error-validacao" v-if='msgError'>{{msgError}}</span>
            </transition>
      </div>
  </transition>
</template>
<script>
import {QDatetime} from 'quasar'
export default {
  components: {
    QDatetime
  },
  props: {
    name: {
      type: String,
      required: true
    },
    id: {
      type: String
    },
    label: {
      type: String
    },
    format: {
      type: String,
      default: 'DD/MM/YYYY'
    },
    type: {
      type: String,
      default: 'text'
    },
    color: {
      type: String,
      default: 'white'
    },
    warning: {
      type: Boolean,
      default: false
    },
    disable: {
      type: Boolean,
      default: false
    },
    error: {
      type: Boolean,
      default: false
    },
    autofocus: {
      type: Boolean
    },
    height: {
      type: Number
    },
    suffix: {
      type: String
    },
    prefix: {
      type: String
    },
    placeholder: {
      type: String
    },
    loading: {
      type: Boolean
    },
    value: {
      required: true
    },
    msgError: {
      type: String,
      default: null
    },
    inverted: {
      type: Boolean,
      default: true
    }
  },
  name: 'cDate',
  data: () => ({
    model: null,
    erro: false
  }),
  mounted () {
    this.model = this.value
    this.erro = this.error
  },
  watch: {
    value () {
      this.model = this.value
    },
    model () {
      this.$emit('input', this.model)
    },
    msgError () {
      if (this.msgError) {
        this.erro = true
      } else {
        this.erro = false
      }
    }
  }
}
</script>
<style lang="stylus" scoped>
#input
  padding 5px
  min-height 72px
  .error-validacao
    color red
    font-size 10px
.inputBorderDefault
  .q-datetime
    padding 5px
    border 2px solid #e5e8e9
</style>
