<template>
  <div id="Cliente">
    <c-form titulo='DADOS DO CLIENTE' @Submit='Salvar()'>
      <c-input v-model='cliente.fantasia' name='Fantasia' label='Fantasia' data-vv-name="Fantasia"
      :msgError="vErrors.first('Fantasia')" v-validate="'required|min:2'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.razao' name='Razao' label='Razão Social' data-vv-name="Razao"
      :msgError="vErrors.first('Razao')" v-validate="'required|min:6'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.cnpj' name='CNPJ' label='CNPJ' data-vv-name="CNPJ" mask='99.999.999/9999-99'
      :msgError="vErrors.first('CNPJ')" v-validate="'required|min:18|max:18'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.telefone' name='Telefone' label='Telefone' data-vv-name="Telefone" :mask='telefone'
      :msgError="vErrors.first('Telefone')" v-validate="'required|min:14|max:16'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.emailContato' name='Email' label='Email Contato' data-vv-name="Email Contato"
      :msgError="vErrors.first('Email Contato')" v-validate="'required|email|min:6'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.emailFinanceiro' name='emailFinanceiro' label='Email Financeiro' data-vv-name="Email Financeiro"
      :msgError="vErrors.first('Email Financeiro')" v-validate="'required|email|min:6'" class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='cliente.cep' name='cep' label='Cep' data-vv-name="Cep" mask='99999-999'
      :msgError="vErrors.first('Cep')" v-validate="'required|min:9|max:9'" class="col-xs-12 col-sm-12 col-md-2 col-lg-2 col-xl-2"/>

      <c-input v-model='cliente.uf' name='Uf' label='Uf' data-vv-name="Uf"
      :msgError="vErrors.first('Uf')" v-validate="'required|min:2|max:3'" class="col-xs-12 col-sm-12 col-md-2 col-lg-2 col-xl-2"/>

      <c-input v-model='cliente.numero' name='Numero' label='Numero' data-vv-name="Numero"
      :msgError="vErrors.first('Numero')" v-validate="'required|min:1'" class="col-xs-12 col-sm-12 col-md-2 col-lg-2 col-xl-2"/>

      <c-input v-model='cliente.rua' name='Rua' label='Rua' data-vv-name="Rua"
      :msgError="vErrors.first('Rua')" v-validate="'required|min:1'" class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

      <c-input v-model='cliente.bairro' name='Bairro' label='Bairro' data-vv-name="Bairro"
      :msgError="vErrors.first('Bairro')" v-validate="'required|min:2'" class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

      <c-input v-model='cliente.cidade' name='Cidade' label='Cidade' data-vv-name="Cidade"
      :msgError="vErrors.first('Cidade')" v-validate="'required|min:2'" class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>
    </c-form>
  </div>
</template>
<script>
import Cliente from '@domain/app/cliente'
export default {
  data: () => ({
    cliente: new Cliente(),
    telefone: '(99) 9 9999-9999'
  }),
  mounted () {
    this.buscar()
  },
  methods: {
    Cep () {
      this.$http.get(`http://viacep.com.br/ws/${this.cliente.cep}/json`)
        .then(resp => {
          this.cliente.bairro = resp.data.bairro || this.cliente.bairro
          this.cliente.rua = resp.data.rua || this.cliente.rua
          this.cliente.cidade = resp.data.localidade || this.cliente.cidade
          this.cliente.uf = resp.data.uf || this.cliente.uf
          this.cliente.rua = resp.data.logradouro || this.cliente.rua
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.cliente.id) {
              this.update()
            } else {
              this.cadastrar()
            }
          }
        })
    },
    buscar () {
      this.$store.dispatch('mod/GetRequest', {endereco: 'cliente'})
        .then(resp => {
          if (resp) {
            this.cliente = resp
          } else {
            this.cliente = new Cliente()
          }
        })
    },
    cadastrar () {
      this.$store.dispatch('mod/PostRequest', {endereco: 'cliente', data: this.cliente})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.buscar()
          }
        })
    },
    update () {
      this.$store.dispatch('mod/PutRequest', {endereco: 'cliente', data: this.cliente})
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.buscar()
          }
        })
    }
  },
  watch: {
    'cliente.cep' () {
      if (this.cliente.cep) {
        if (this.cliente.cep.length >= 9) {
          this.Cep()
        }
      }
    },
    'cliente.telefone' () {
      if (this.cliente.telefone) {
        if (this.cliente.telefone.length <= 14) {
          this.telefone = '(99) 9999-9999'
        } else if (this.cliente.telefone.length >= 15) {
          this.telefone = '(99) 9 9999-9999'
        }
      }
    }
  }
}
</script>
<style lang="stylus" scoped>
</style>
