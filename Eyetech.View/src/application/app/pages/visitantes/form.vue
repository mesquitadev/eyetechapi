<template>
  <c-form @Submit="Salvar()" titulo='Cadastro de Visitante'>
    <c-input v-model='visitante.nome' label='Nome' data-vv-name="Nome"
    :msgError="vErrors.first('Nome')" v-validate="'required|min:2'" name='Nome'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"/>

    <c-input v-model='visitante.telefone' name='Telefone' label='Telefone' data-vv-name="Telefone"
    :msgError="vErrors.first('Telefone')" v-validate="'required|min:14|max:16'" :mask='telefone'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"/>

    <s-data v-model="visitante.apartamentoId" :filter='true' controller='Apartamentos' text='numero' selectValue='id'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4" label="Apartamento" data-vv-name="Apartamento"
    :msgError="vErrors.first('Apartamento')" v-validate="'required'" />

    <c-date v-model="visitante.dataEntrada" type='date' label="Data Chegada" name='DataEntrada'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"  data-vv-name="Data Chegada"
    :msgError="vErrors.first('Data Chegada')" v-validate="'required'"/>

    <c-date v-model="visitante.dataSaida" type='date' label="Data Saída" name='dataSaida'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4"/>

    <div class="col-12">
      <q-checkbox v-model='visitante.motorizado' color='white' label='Motorizado'></q-checkbox>
      <div class="row" v-if='visitante.motorizado' >

        <c-input v-model='visitante.veiculo.placa' name='Placa' label='Placa' :mask='placa'
        class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3" />

        <c-input v-model='visitante.veiculo.cor' name='cor' label='cor' data-vv-name="cor"
        :msgError="vErrors.first('cor')" v-validate="'required|min:2'"
        class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

        <c-input v-model='visitante.veiculo.modelo' name='Modelo' label='Modelo'
        class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>
      </div>
    </div>

  </c-form>
</template>
<script>
import {QCheckbox} from 'quasar'
import Visitante from '@domain/app/ambiente/visitante'
export default {
  components: {
    QCheckbox
  },
  data: () => ({
    visitante: new Visitante(),
    telefone: '(99) 9999-9999',
    placa: 'AAA-9999',
    endereco: 'Visitante'
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.visitante.id) {
              this.Update()
            } else {
              this.Cadastro()
            }
          }
        })
    },
    Cadastro () {
      this.$store.dispatch('mod/PostRequest', { endereco: this.endereco, data: this.visitante })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/visitantes')
          }
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', { endereco: this.endereco, data: this.visitante })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/visitantes')
          }
        })
    },
    Buscar () {
      this.$store.dispatch('mod/GetRequestId', { endereco: this.endereco, params: this.$route.params.id })
        .then(resp => {
          this.visitante = resp
        })
    }
  },
  watch: {
    'visitante.veiculo.placa' () {
      this.visitante.veiculo.placa = this.visitante.veiculo.placa.toUpperCase()
    },
    'visitante.telefone' () {
      if (this.visitante.telefone) {
        if (this.visitante.telefone.length < 10) {
          this.telefone = '(99) 9999-9999'
        } else if (this.visitante.telefone.length >= 10) {
          this.telefone = '(99) 9 9999-9999'
        }
      }
    }
  }
}
</script>
<style lang="stylus" scoped>
</style>
