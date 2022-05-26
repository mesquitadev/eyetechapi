<template>
  <div id="Apartamento">
    <c-form titulo="Cadastro Apartamento" @Submit="Salvar()">
      <c-input v-model='camera.nome' name='Nome' label='Nome' data-vv-name="Nome"
      :msgError="vErrors.first('Nome')" v-validate="'required|min:01'"
      class="col-xs-12 col-sm-12 col-md-4 col-lg-4 col-xl-4"/>

      <c-input v-model='camera.endereco' name='Url' label='Url' data-vv-name="Url"
      :msgError="vErrors.first('Url')" v-validate="'required|min:01'"
      class="col-xs-12 col-sm-12 col-md-8 col-lg-8 col-xl-8"/>

      <c-status v-model='camera.status' class="col-xs-12 col-sm-12 col-md-2 col-lg-2 col-xl-2"  data-vv-name="Apartamentos"
      :msgError="vErrors.first('Apartamentos')" v-validate="'required'"></c-status>

      <s-data data-vv-name="Qualidade" label='Qualidade' v-model="camera.qualidade"
      :msgError="vErrors.first('Qualidade')" v-validate="'required'"
      :dados='qualidade' filter
      name='Qualidade' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

      <s-data data-vv-name="Porta" label='Porta' v-model="camera.porta"
      :msgError="vErrors.first('Porta')" v-validate="'required'"
      :dados='portas' filter
      name='Porta' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>
    </c-form>
  </div>
</template>
<script>
import Camera from '@domain/app/ambiente/camera'
export default {
  data: () => ({
    camera: new Camera(),
    endereco: 'cameras',
    qualidade: [
      { label: 'ntsc 720x480', value: 'ntsc' },
      { label: 'uxga 1600x1200', value: 'uxga' },
      { label: 'svga 800x600', value: 'svga' },
      { label: 'xga 1024x768', value: 'xga' },
      { label: 'uxga 1600x1200', value: 'uxga' },
      { label: 'hd720 1280x720', value: 'hd720' },
      { label: 'qxga 2048x1536', value: 'qxga' }
    ],
    portas: [
      { label: '9999', value: 9999 },
      { label: '9998', value: 9998 },
      { label: '9997', value: 9997 },
      { label: '9996', value: 9996 },
      { label: '9995', value: 9995 }
    ]
  }),
  mounted () {
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  watch: {
    'camera.nome' () {
      if (this.camera.nome) {
        var er = /[^a-z0-9]/gi
        this.camera.nome = this.camera.nome.toLowerCase().replace(er, '')
      }
    }
  },
  methods: {
    Buscar () {
      this.$store.dispatch('mod/GetRequestId', { endereco: this.endereco, params: this.$route.params.id })
        .then(resp => {
          this.camera = resp
        })
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', { endereco: this.endereco, data: this.camera })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/cameras')
          }
        })
    },
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', { endereco: this.endereco, data: this.camera })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/cameras')
          }
        })
    },
    Salvar () {
      this.$validator.validateAll()
        .then(success => {
          if (success) {
            if (this.camera.id) {
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
