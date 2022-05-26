<template>
  <div id="dasboard" class="row">
    <div class="atalhos col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
      <q-card>
        <q-card-title>
          <h6>Atalhos</h6>
        </q-card-title>
        <q-card-separator />
        <q-card-main>
          <q-btn icon='fas fa-user-secret' @click='$router.push("/vigilancia")' title='Portaria'></q-btn>
          <q-btn icon='far fa-id-card' @click='$router.push("/visitantes")' title='Visitantes'></q-btn>
          <q-btn icon='account_box' @click='$router.push("/Moradores")' title='Moradores'></q-btn>
        </q-card-main>
      </q-card>
    </div>
    <c-form titulo='Veículos Cadastrados' desabilitaBtn class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
      <h1>{{dashboard.veiculos}}</h1>
    </c-form>
    <c-form titulo='Visitantes Cadastrados' desabilitaBtn class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
      <h1>{{dashboard.visitantes}}</h1>
    </c-form>
    <c-form titulo='Acessos Não Autorizados' desabilitaBtn class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
      <h1>{{dashboard.naoAutorizado}}</h1>
    </c-form>
    <c-form titulo='Cameras' desabilitaBtn class="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-xl-4">
      <h1>{{dashboard.cameras}}</h1>
    </c-form>
  </div>
</template>
<script>
export default {
  data: () => ({
    dashboard: {}
  }),
  mounted () {
    this.Carregar()
  },
  methods: {
    Carregar () {
      this.$store.dispatch('mod/GetRequest', { endereco: 'Dashboard' })
        .then(resp => {
          console.log(resp)
          this.dashboard = resp
        })
    }
  }
}
</script>
<style lang="stylus" scoped>
#dasboard
  h1
    color #FFE11B
    font-weight: bold
    margin 2px
    text-align: center
    width 100%
  .atalhos
    padding 15px
    .q-card
      .q-card-title
        h6
          font-size 22px
          color #FFE11B !important
          font-weight: 300;
          margin 10px
      .q-card-main
        padding 20px
        display flex
        justify-content: center
        button
          margin 5px
          background: #FFE11B !important
          color #212121
          font-size 50px
</style>
