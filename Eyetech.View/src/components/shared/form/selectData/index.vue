<template>
    <transition
      appear
      enter-active-class="animated fadeIn"
      leave-active-class="animated fadeOut"
    >
      <div id="input">
          <q-select v-model="model" :stack-label="label" :filter='filter' :autofocus-filter='true'
          :prefix='prefix' :suffix='suffix' :color='color' :disable='disable' :warning='warning'
          :error='erro' :id='id' :name='name' :options='options' :filter-placeholder='filterPlaceholder'
          :autofocus='autofocus' :multiple='multiple' :loading='loading'  :inverted-light='inverted' rightInverted
          chips
          chips-color="black" chips-bg-color="amber" leftTextColor='black' rightColor='black' rightTextColor='black'/>
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
    filter: {
      type: Boolean,
      default: false
    },
    filterPlaceholder: {
      type: String,
      default: 'Pesquisar'
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
    multiple: {
      type: Boolean,
      default: false
    },
    msgError: {
      type: String,
      default: null
    },
    controller: {
      type: String
    },
    text: {
      type: String,
      default: 'nome'
    },
    selectValue: {
      type: String,
      default: 'id'
    },
    inverted: {
      type: Boolean,
      default: true
    },
    dados: {
      type: Array
    }
  },
  name: 'cSelectData',
  data: () => ({
    model: {},
    erro: false,
    options: []
  }),
  mounted () {
    if (this.multiple) {
      if (this.value) {
        this.model = this.value
      } else {
        this.model = []
      }
    } else {
      this.model = this.value
    }
    this.erro = this.error
    if (this.controller) {
      this.BuscarDados()
    } else {
      this.dataArray()
    }
  },
  methods: {
    dataArray () {
      this.options = this.dados
    },
    BuscarDados () {
      this.$store.dispatch('mod/GetRequest', { endereco: this.controller })
        .then(resp => {
          this.AlimentaOption(resp)
        })
    },
    AlimentaOption (dados) {
      this.options = []
      dados.forEach(resp => {
        this.options.push({
          label: resp[this.text],
          value: resp[this.selectValue]
        })
      })
    }
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
