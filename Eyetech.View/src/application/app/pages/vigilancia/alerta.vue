<template>
  <div class="AlertaVisitante">
     <div class="titulo">
       <h1>REGISTRO DE VEÍCULOS</h1>
       <q-btn icon='close' flat @click='Fechar()'></q-btn>
     </div>
     <div class="dados">
       <div class="imagem">
         <img :src='endereco' />
       </div>
       <div class="informacoes">
         <h1 class="active" v-if="model.Identificado">IDENTIFICADO</h1>
         <h1 class="noactive" v-else>NÃO IDENTIFICADO</h1>
        <div class="container row">
          <div class="veiculo col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6" >
            <p>Placa: {{model.Veiculo.Placa}}</p>
            <p>Cor: {{model.Veiculo.Cor}}</p>
          </div>
          <div class="Apartamento col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6" v-if="apartamento != null">
            <p>Apartamento: {{apartamento.numero}}</p>
            <p>Bloco: {{apartamento.bloco}}</p>
          </div>
          <div class="Apartamento col-xs-12" v-if="visitante != null">
            <p>Nome: {{visitante.nome}}</p>
            <p>Telefone: {{visitante.telefone}}</p>
            <p>Data Entrada: {{visitante.dataEntrada}}</p>
            <p>Data Saída: {{visitante.dataSaida}}</p>
          </div>
        </div>
       </div>
     </div>
  </div>
</template>
<script>
import Server from '@service/server'
export default {
  props: {
    value: {
      required: true
    }
  },
  data: () => ({
    model: {},
    aviso: true,
    visitante: null,
    apartamento: null
  }),
  mounted () {
    this.model = this.value
    if (this.visitante === null && this.apartamento === null && this.model.ApartamentoId != null) {
      console.log('buscou')
      this.BuscarAp()
    }
  },
  computed: {
    endereco () {
      return Server.hostServer() + '/api/ImagensVeiculos/' + this.model.Imagem
    }
  },
  watch: {
    value () {
      this.model = this.value
    },
    model () {
      this.$emit('input', this.model)
    }
  },
  methods: {
    BuscarAp () {
      this.$store.dispatch('mod/GetRequestId', { endereco: 'ControleDeAcesso', params: this.model.Id })
        .then(resp => {
          this.apartamento = resp.apartamento
          this.visitante = resp.visitante
        })
    },
    FecharAlerta () {
      this.$store.dispatch('mod/GetRequestId', { endereco: 'ControleDeAcesso/Portaria', params: this.model.Id })
        .then(resp => {
        })
    },
    Fechar () {
      this.aviso = false
      this.FecharAlerta()
      this.model = {}
      this.$emit('statusAviso', false)
    }
  }
}
</script>
<style lang="stylus" scoped>
.AlertaVisitante
  position fixed
  top 0px
  left 0px
  background #212121
  height: 100%
  width 100%
  z-index 9999
  border 10px solid #FFE11B
  .titulo
    background: rgba(247, 228, 239, 0.1)
    display flex
    padding 10px
    flex-direction: row
    justify-content: center
    align-items: center
    h1
      color #FFE11B !important
      margin 0 auto
      font-size 18px
      width: 80%
      text-align: center
    button
      color #FFE11B !important
  .dados
    padding 10px
    display flex
    flex-direction: row
    justify-content: center
    align-items: center
    .imagem
      border 5px solid #FFE11B
      max-width 450px
      img
        width 100%
        height: 100%;
    .informacoes
      width 50%
      background: rgba(247, 228, 239, 0.1)
      padding 10px
      margin 10px
      p
        font-size 22px
        margin 2px
      h1
        font-size 45px
        margin 2px
        padding-bottom: 10px
        border-bottom: 3px solid #212121
        margin-bottom: 10px
      .active
        color green
        font-weight: bold
      .noactive
        font-weight: bold
        color red
      .container
        .veiculo
          margin-top 10px
          border-bottom: 3px solid #212121
          padding-bottom: 10px
        .Apartamento
            margin-top 10px
            border-bottom: 3px solid #212121
            padding-bottom: 10px
</style>
