<template>
    <transition
      appear
      enter-active-class="animated fadeIn"
      leave-active-class="animated fadeOut"
    >
      <div id="input">
          <q-select v-model="model" :stack-label="label"
          :prefix='prefix' :suffix='suffix' :color='color' :disable='disable' :warning='warning'
          :error='erro' :id='id' :name='name' :options='options'
          :autofocus='autofocus' :loading='loading'  :inverted-light='inverted'/>
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
import {QSelect} from 'quasar'
export default {
  components: {
    QSelect
  },
  props: {
    name: {
      type: String,
      default: 'Status'
    },
    id: {
      type: String,
      default: 'Status'
    },
    label: {
      type: String,
      default: 'Status'
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
  name: 'cInput',
  data: () => ({
    model: null,
    erro: false,
    options: [
      { label: 'Ativo', value: true },
      { label: 'Desativado', value: false }
    ]
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
  .q-input
    padding 5px
    border 2px solid #e5e8e9
</style>
