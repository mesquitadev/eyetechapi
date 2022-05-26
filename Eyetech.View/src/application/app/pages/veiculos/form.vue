<template>
  <c-form titulo="Cadastro Moradores" @Submit="Salvar()" :disabilitaSalvar='desabilita'>
    <c-input v-model='veiculo.placa' name='Placa' label='Placa' data-vv-name="Placa"
    :msgError="vErrors.first('Placa')" v-validate="'required|min:8|max:8'" :mask='placa'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

    <c-input v-model='veiculo.cor' name='cor' label='cor' data-vv-name="cor"
    :msgError="vErrors.first('cor')" v-validate="'required|min:2'"
    class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

    <c-input v-model='veiculo.modelo' name='Modelo' label='Modelo'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

    <s-data v-model="veiculo.apartamentoId" :filter='true' controller='Apartamentos' text='numero' selectValue='id'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6" label="Apartamento" data-vv-name="Apartamento"
    :msgError="vErrors.first('Apartamento')" v-validate="'required'"/>

    <c-status v-model='veiculo.status' class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"  data-vv-name="Apartamentos"
    :msgError="vErrors.first('Apartamentos')" v-validate="'required'"></c-status>
  </c-form>
</template>
<script>
import Carro from '@domain/app/ambiente/carro'
export default {
  data: () => ({
    desable: false,
    veiculo: new Carro(),
    placa: 'AAA-9999',
    endereco: 'veiculos'
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', {endereco: this.endereco, data: this.veiculo})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/veiculos')
          }
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', {endereco: this.endereco, data: this.veiculo})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/veiculos')
          }
        })
    },
    Buscar () {
      this.$store.dispatch('mod/GetRequestId', {endereco: this.endereco, params: this.$route.params.id})
        .then(resp => {
          this.veiculo = resp
        })
    },
    ValidaPlaca () {
      this.$store.dispatch('mod/PostRequest', {endereco: this.endereco + '/ConsultaPlaca', data: this.veiculo})
        .then(resp => {
          if (!resp.success) {
            this.$mensagens.FormResponse(resp.message, resp.success)
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.veiculo.id) {
              this.Update()
            } else {
              this.Cadastrar()
            }
          }
        })
    }
  },
  computed: {
    desabilita () {
      if (this.$validator.errorBag.any()) {
        return true
      } else {
        return false
      }
    }
  },
  watch: {
    'veiculo.placa' () {
      if (this.veiculo.placa) {
        var placa = this.veiculo.placa.toUpperCase()
        this.veiculo.placa = placa
        if (placa.length >= 8) {
          this.ValidaPlaca()
        }
      }
    }
  }
}
</script>
<style lang="stylus" scoped>
</style>
