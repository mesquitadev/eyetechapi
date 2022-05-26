<template>
  <c-form @Submit='Salvar()' titulo='Cadastro de Usuário'>
    <c-input v-model='user.login' name='login' label='login' data-vv-name="login"
    :msgError="vErrors.first('login')" v-validate="'required|min:03'"
    class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

    <c-input v-model='user.nome' name='Nome' label='Nome'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

    <c-input v-model='user.senha' name='Senha' label='Senha' data-vv-name="Senha"
    :msgError="vErrors.first('Senha')" v-validate="'required|min:06'"
    class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3" type='password'/>

    <c-input v-model='confirme' name='Confirmar' label='Confirmar' data-vv-name="Confirmar"
    :msgError="vErrors.first('Confirmar')" v-validate="'required|confirmed:Senha'" type='password'
    class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

    <c-status v-model='user.status' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"  data-vv-name="Status"
    :msgError="vErrors.first('Status')" v-validate="'required'"></c-status>

    <s-data data-vv-name="Perfis" label='Perfis' v-model="user.perfisId"
    :msgError="vErrors.first('Perfis')" v-validate="'required'" filter
    controller='perfis/ativos' text='nome' selectValue='id' multiple
    name='Perfis' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>
    <div class="col-12">
    </div>
  </c-form>
</template>
<script>
import Usuario from '@domain/app/user/usuario'
export default {
  data: () => ({
    user: new Usuario(),
    endereco: 'Usuarios',
    confirme: null
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    Buscar () {
      this.$carregar.loading(true)
      this.$store.dispatch('mod/GetRequestId', { endereco: this.endereco, params: this.$route.params.id })
        .then(resp => {
          this.user = resp
          this.confirme = resp.senha
          this.$carregar.loading(false)
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', { endereco: this.endereco, data: this.user })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Usuarios')
          }
        })
    },
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', { endereco: this.endereco, data: this.user })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/Usuarios')
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.$route.params.id) {
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
