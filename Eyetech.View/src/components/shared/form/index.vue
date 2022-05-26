<template>
  <form id="Form" @submit.prevent='Submit()'>
    <q-card>
      <q-card-title>
        <h1>{{titulo}}</h1>
      </q-card-title>
      <q-card-separator />
      <q-card-main>
        <form @submit.prevent='Submit()' class="row">
          <slot/>
        </form>
      </q-card-main>
      <q-card-actions class="Botoes" v-if="!desabilitaBtn">
        <q-btn type="submit" :disabled='disabilitaSalvar'>{{btnSalvar}}</q-btn>
        <q-btn type="reset">{{btnCancelar}}</q-btn>
      </q-card-actions>
    </q-card>
  </form>
</template>
<script>
export default {
  props: {
    disabilitaSalvar: {
      type: Boolean,
      defaul: false
    },
    desabilitaBtn: {
      type: Boolean,
      default: false
    },
    titulo: {
      type: String,
      default: 'Titulo'
    },
    btnSalvar: {
      type: String,
      default: 'Salvar'
    },
    colorSalvar: {
      type: String,
      default: 'teal-3'
    },
    btnCancelar: {
      type: String,
      default: 'Cancelar'
    }
  },
  data: () => ({

  }),
  methods: {
    Submit () {
      this.$emit('Submit', true)
    }
  }
}
</script>
<style lang="stylus" scoped>
#Form
  padding 15px
  .q-card-title
    h1
      color #FFE11B !important
      text-align: right
      font-size: 30px
      width 100%
      margin 5px
      padding: 10px
  .q-card-main
    background: rgba(247, 228, 239, 0.1)
  .Botoes
    button
      margin 5px
      padding: 15px
      width 150px
      background: #FFE11B
      color #000
      cursor pointer
</style>
