<template>
  <div id="Apartamento">
    <c-form titulo="Cadastro Apartamento" @Submit="Salvar()">
      <c-input v-model='ape.numero' name='Numero' label='Numero' data-vv-name="Numero"
      :msgError="vErrors.first('Numero')" v-validate="'required|min:02'"
      class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='ape.bloco' name='Bloco' label='Bloco' data-vv-name="Bloco"
      :msgError="vErrors.first('Bloco')" v-validate="'required|min:01'"
      class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='ape.telefone' name='Interfone' label='Interfone' data-vv-name="Interfone"
      :msgError="vErrors.first('Interfone')" v-validate="'required|min:01'"
      class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>
    </c-form>
  </div>
</template>
<script>
import Apartamento from '@domain/app/ambiente/apartamento'
export default {
  data: () => ({
    ape: new Apartamento(),
    endereco: 'apartamentos'
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    Buscar () {
      this.$store.dispatch('mod/GetRequestId', { endereco: this.endereco, params: this.$route.params.id })
        .then(resp => {
          this.ape = resp
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', { endereco: this.endereco, data: this.ape })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Apartamentos')
          }
        })
    },
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', { endereco: this.endereco, data: this.ape })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Apartamentos')
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.ape.id) {
              this.Update()
            } else {
              this.Cadastrar()
            }
          }
        })
    }
  }
}
</script>
<style lang="stylus" scoped>
</style>
