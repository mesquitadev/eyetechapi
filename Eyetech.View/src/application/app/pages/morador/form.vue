<template>
  <div id="">
    <c-form titulo="Cadastro Moradores" @Submit="Salvar()">
      <c-input v-model='morador.nome' name='Nome' label='Nome Completo' data-vv-name="Nome"
      :msgError="vErrors.first('Nome')" v-validate="'required|min:05'"
      class="col-xs-12 col-sm-12 col-md-6 col-lg-8 col-xl-8"/>

      <c-input v-model='morador.telefone' name='Telefone' label='Telefone' data-vv-name="Telefone"
      :msgError="vErrors.first('Telefone')" v-validate="'required|min:14|max:16'" :mask='telefone'
      class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"/>

      <s-data v-model="morador.apartamentoId" :filter='true' controller='Apartamentos' text='numero' selectValue='id'
      class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4" label="Apartamento" data-vv-name="Apartamento"
      :msgError="vErrors.first('Apartamento')" v-validate="'required'"/>

      <c-status v-model='morador.status' class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"  data-vv-name="Apartamentos"
      :msgError="vErrors.first('Apartamentos')" v-validate="'required'"></c-status>
    </c-form>
  </div>
</template>
<script>
import Morador from '@domain/app/ambiente/morador'
export default {
  data: () => ({
    morador: new Morador(),
    telefone: '(99) 9999-9999',
    endereco: 'moradores'
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    Buscar () {
      this.$carregar.loading(true)
      this.$store.dispatch('mod/GetRequestId', {endereco: this.endereco, params: this.$route.params.id})
        .then(resp => {
          console.log(resp)
          this.morador = resp
          this.$carregar.loading(false)
        })
    },
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', {endereco: this.endereco, data: this.morador})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Moradores')
          }
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', {endereco: this.endereco, data: this.morador})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Moradores')
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.morador.id) {
              this.Update()
            } else {
              this.Cadastrar()
            }
          }
        })
    }
  },
  watch: {
    'morador.telefone' () {
      if (this.morador.telefone) {
        if (this.morador.telefone.length < 10) {
          this.telefone = '(99) 9999-9999'
        } else if (this.morador.telefone.length >= 10) {
          this.telefone = '(99) 9 9999-9999'
        }
      }
    }
  }
}
</script>
<style lang="stylus" scoped>
</style>
