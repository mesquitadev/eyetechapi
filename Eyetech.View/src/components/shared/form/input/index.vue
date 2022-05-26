<template>
    <transition
      appear
      enter-active-class="animated fadeIn"
      leave-active-class="animated fadeOut"
    >
      <div id="input">
          <q-input v-model="model" :stack-label="label" :placeholder='placeholder'  :inverted-light='inverted'
          :prefix='prefix' :suffix='suffix' :color='color' :disable='disable' :warning='warning'
          :error='erro' :id='id' :name='name' v-on:blur='AplicaMask()' :rows='rows'
          :max-height="height" :type='type' :autofocus='autofocus' :loading='loading'/>
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
import VMasker from 'vanilla-masker'
import {QInput} from 'quasar'
export default {
  components: {
    QInput
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
    mask: {
      type: String,
      default: null
    },
    rows: {
      default: null
    },
    moeda: {
      type: Boolean,
      default: false
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
      this.ValidaMask()
      if (this.moeda && this.model) {
        this.Moeda()
      } else {
        this.$emit('input', this.model)
      }
    },
    msgError () {
      if (this.msgError) {
        this.erro = true
      } else {
        this.erro = false
      }
    }
  },
  methods: {
    ValidaMask () {
      if (this.mask && this.model) {
        var er = /[^a-z0-9]/gi
        var caracter = this.mask.replace(er, '')
        var dados = this.model
        if (caracter.length === dados.replace(er, '').length) {
          this.AplicaMask()
        }
      }
    },
    Moeda () {
      var er = /[^a-z0-9]/gi
      var valor = this.model.toString().replace(er, '')
      this.model = VMasker.toMoney(valor)
      this.$emit('input', this.model.toString().replace('.', '').replace(',', '.'))
    },
    AplicaMask () {
      if (this.mask && this.model) {
        this.model = VMasker.toPattern(this.model, this.mask)
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
