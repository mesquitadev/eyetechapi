<template>
  <div id="Login">
    <div class="container-login">
      <img src="statics/logo.png" alt="eyetech">

      <form @submit.prevent='Salvar()'>
        <c-input v-model='user.login' name='login' label='Login' data-vv-name="login"  color='white'
        :msgError="vErrors.first('login')" v-validate="'required|min:02'" :inverted="true"
        class="col-xs-12 "/>
        <c-input v-model='user.senha' type='password' name='senha' label='senha'
        :msgError="vErrors.first('senha')" v-validate="'required|min:02|max:08'"
        class="col-xs-12 " data-vv-name="senha" :inverted="true"  color='white' />
        <div class="col-xs-12 button">
          <button type="submit" name="button">ENTRAR</button>
        </div>
        <div class="link">
            <router-link to="/Alterar-Senha">Alterar Senha</router-link>
        </div>
      </form>

    </div>
  </div>
</template>
<script>
export default {
  data: () => ({
    user: {
      // login: 'suporte@eyetech.com.br',
      // senha: '123456'
      login: '',
      senha: ''
    }
  }),
  methods: {
    Login () {
      this.$carregar.loading(true)
      this.$store.dispatch('mod/PostRequest', { endereco: 'token', data: this.user })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$store.dispatch('mod/Login', resp)
            this.$router.push('/')
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            this.Login()
          }
        })
    }
  }
}
</script>
<style lang="stylus" scoped>
#Login
  padding 10px
  height: 100%
  width 100%
  display flex
  position absolute
  .container-login
    padding: 20px
    border 1px solid rgb(255, 225, 27)
    height: 100%
    width 100%
    display flex
    flex-direction: column
    justify-content: center
    align-items: center
    img
      max-width 200px
      width 100%
    form
      margin 5px
      width 100%
      max-width 350px
      padding 10px
      .button
        padding 5px
        button
          border 1px solid rgb(255, 225, 27)
          padding 10px
          width 100%
          cursor pointer
          background: rgb(255, 225, 27)
          color #000
          border-radius 5px
          font-weight: bold
          font-size 12px
      .link
        text-align: right
        padding 10px
        color #000
        a
          color #fff
          text-decoration: none
          font-size 12px
</style>
