<template>
  <div id="vigilante">
     <c-form titulo='Vigilância' desabilitaBtn>
       <c-alerta v-if="VerificaAlerta && aviso" v-model="registro" @statusAviso="aviso = $event"></c-alerta>
       <div class="row container-camera">
         <div class="Camera">
           <div class="video" :class="tela">
             <div class="button">
               <button class="material-icons" @click='telaCheia()' v-if="!fullScreen">zoom_out_map</button>
               <button class="material-icons" @click='fullScreen = false' v-else>fullscreen_exit</button>
             </div>
             <canvas id="video"></canvas>
             </div>
         </div>
         <div class="historico">
           <h1>Histórico de acessos</h1>
           <div class="">
             <table>
               <tr>
                 <th>Veiculo</th>
                 <th>Data</th>
                 <th>Saída</th>
                 <th>Identificado</th>
               </tr>
               <tr v-for="plate in registros" :key="plate.id">
                 <td>{{plate.Veiculo.Placa}}</td>
                 <td>{{plate.Entrada | data}}</td>
                 <td>{{plate.Saida | data}}</td>
                 <td>{{plate.Identificado | identificado}}</td>
               </tr>
               <tr v-if="registros.length <= 0">
                 <th colspan="5">Nenhuma Entrada registrada</th>
               </tr>
             </table>
           </div>
         </div>
       </div>
     </c-form>
  </div>
</template>
<script>
import cAlerta from './alerta'
var Jsmpeg = require('jsmpeg')
import server from '@service/server'
import { videoPlayer } from 'vue-video-player'
import {date} from 'quasar'
export default {
  components: {
    videoPlayer, cAlerta
  },
  data: () => ({
    videoId: 'video',
    scaleFactor: 0.25,
    snapshots: [],
    play: null,
    logo: 'statics/logo.png',
    fullScreen: false,
    registros: [],
    socketApi: null,
    socketCam: null,
    desativaAviso: false,
    registro: {},
    aviso: false
  }),
  destroyed () {
    this.socketApi.close()
    this.socketCam.close()
    this.PausarCaptura()
  },
  mounted () {
    this.ControleAcesso()
    this.video()
    this.IniciaCaptura()
  },
  filters: {
    data (value) {
      var data = date.formatDate(value, 'DD/MM/YYYY H:m:s')
      if (data === '31/12/0000 20:15:40') return '00/00/0000 00:00:00'
      else return data
    },
    identificado (value) {
      if (value) {
        return 'Sim'
      } else {
        return 'Não'
      }
    }
  },
  computed: {
    VerificaAlerta () {
      if (this.registros.find(x => x.Alerta === true)) {
        this.AbrirAlerta()
        return true
      } else {
        return false
      }
    },
    tela () {
      if (this.fullScreen) {
        return 'TelaCheia'
      }
      return ''
    }
  },
  methods: {
    AbrirAlerta () {
      this.registro = this.registros.find(x => x.Alerta === true)
      this.aviso = true
    },
    PausarCaptura () {
      this.$axios({
        method: 'OPTIONS',
        url: server.ServerAlpr() + '/pausar'
      })
        .then(resp => {
          console.log(resp)
        })
    },
    IniciaCaptura () {
      this.$axios({
        method: 'OPTIONS',
        url: server.ServerAlpr()
      })
        .then(resp => {
          console.log(resp)
        })
    },
    ControleAcesso () {
      this.socketApi = new WebSocket('ws://' + server.Server() + '/ControleDeAcesso')
      this.socketApi.onopen = (event) => {
        console.log('conectado ao cliente')
        this.socketApi.send('conectar')
      }
      this.socketApi.onmessage = (event) => {
        if (event.data) {
          this.registros = JSON.parse(event.data)
          this.socketApi.send('conectar')
        }
      }
    },
    telaCheia () {
      this.fullScreen = true
    },
    video () {
      var quadro = document.getElementById('video')
      this.socketCam = new WebSocket(server.stream())
      this.play = new Jsmpeg(this.socketCam, {canvas: quadro, autoplay: false, loop: true, poster: this.logo, control: true})
    },
    Captura () {
    }
  }
}
</script>
<style lang="stylus" scoped>
#vigilante
  .container-camera
    display flex
    justify-content: center
    align-items: flex-start
    flex-direction:row;
    width 100%
    overflow: hidden;
    .Camera
      display flex
      justify-content:flex-start;
      align-items: flex-start
      width 100%
      max-width: 50%
      overflow: hidden;
      .video
        position: relative
        overflow: hidden;
        border 3px solid rgba(247, 228, 239, 0.1)
        width 100%
        max-width: 560px
        min-width: 350px
        #video
          width 100% !important
          min-height:350px
        .button
          display flex
          width 100%
          position absolute
          padding 5px
          background: rgba(0, 0, 0, 0.5)
          font-size 19px
          button
            background transparent
            border none
            color #fff
            cursor pointer
      .TelaCheia
        position fixed
        top 0
        left 0px
        width 100%
        max-width: 100%
        height: 100%
        z-index 90000
        background: #000
    .historico
      width 50%
      margin-top 0px
      padding 0px
      h1
        font-size 18px
        margin-top 0px
        background: rgba(247, 228, 239, 0.1)
        padding 10px
      table
        width 100%
        tr
          th
            border-bottom 1px solid rgba(247, 228, 239, 0.1)
            padding 10px
        tr
          td
            border-bottom 1px solid rgba(247, 228, 239, 0.1)
            padding 10px
@media (min-width:200px) and (max-width:758px)
  #vigilante
    .container-camera
      flex-direction: column;
      .Camera
        max-width: 100%
        justify-content: center;
      .historico
        width 100%
        padding 10px
        overflow-x: scroll;
        table
          width 100%
</style>
