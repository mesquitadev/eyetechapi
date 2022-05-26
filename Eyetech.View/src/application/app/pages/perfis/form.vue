<template>
  <c-form titulo='Cadastro de Pefil de Usuário' @Submit='Salvar()'>

    <c-input v-model='perfil.nome' name='Nome' label='Nome' data-vv-name="Nome"
    :msgError="vErrors.first('Nome')" v-validate="'required|min:03'"
    class="col-xs-12 col-sm-12 col-md-6 col-lg-6 col-xl-6"/>

    <s-data data-vv-name="Nivel" label='Nível' v-model="perfil.nivel"
    :msgError="vErrors.first('Nivel')" v-validate="'required'"
    :dados='niveis' filter
    name='Nivel' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"/>

    <c-status v-model='perfil.status' class="col-xs-12 col-sm-12 col-md-6 col-lg-3 col-xl-3"  data-vv-name="Status"
    :msgError="vErrors.first('Status')" v-validate="'required'"></c-status>

    <div class="col-12 menus">
      <q-list>
        <q-list-header>Restrições</q-list-header>
        <q-item>
          <q-item-side v-for="m in menus" :key="m.id">
            <div>
              <!-- <q-icon :name='m.icone'/>
              <label for="">{{m.nome}}</label> -->
              <q-checkbox v-model='perfil.menuId' color='amber'
               :label='m.nome' :val='m.id' :checked-icon='m.icone'
               :unchecked-icon='m.icone' class="activeMenus"/>
            </div>
          </q-item-side>
        </q-item>
      </q-list>
    </div>
  </c-form>
</template>
<script>
import { QCollapsible, QCheckbox } from 'quasar'
import Perfil from '@domain/app/user/perfil'
export default {
  components: {
    QCollapsible, QCheckbox
  },
  data: () => ({
    perfil: new Perfil(),
    niveis: [
      { label: 'Supervisor', value: 1 },
      { label: 'Suporte', value: 2 },
      { label: 'Administrador', value: 3 },
      { label: 'Usuário', value: 4 }
    ],
    menus: [],
    endereco: 'Perfis'
  }),
  mounted () {
    this.BuscarMenu()
    if (this.$route.params.id) {
      this.Buscar()
    }
  },
  methods: {
    colorCheck (id) {
      if (this.menus.find(x => x === id)) {
        return 'amber'
      }
      return 'white'
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
    },
    Update () {
      this.$store.dispatch('mod/PutRequest', { endereco: this.endereco, data: this.perfil })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/perfis')
          }
        })
    },
    Cadastrar () {
      this.$store.dispatch('mod/PostRequest', { endereco: this.endereco, data: this.perfil })
        .then(resp => {
          this.$mensagens.FormResponse(resp.message, resp.success)
          if (resp.success) {
            this.$router.push('/perfis')
          }
        })
    },
    Buscar () {
      this.$store.dispatch('mod/GetRequestId', { endereco: this.endereco, params: this.$route.params.id })
        .then(resp => {
          this.perfil = resp
        })
    },
    BuscarMenu () {
      this.$store.dispatch('mod/GetRequest', { endereco: 'Menus' })
        .then(resp => {
          this.menus = resp
        })
    }
  }
}
</script>
<style lang="stylus" scoped>
.menus
  padding 5px
  .q-list
    .q-list-header
      color #fff !important
    .q-item
      color #fff !important
      display flex
      flex-wrap:wrap;
      justify-content: flex-start;
      align-items: center;
      .q-item-side
        padding 10px
        margin 2px
        width 20%
        .activeMenus
          color: #fff
</style>
