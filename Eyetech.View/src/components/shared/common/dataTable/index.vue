<template>
  <div id="table">
    <q-card>
      <q-card-title class="title">
        <h1>{{titulo}}</h1>
      </q-card-title>
      <q-card-separator />
      <q-card-main class="corpotable">
        <div class="containerButton">
          <router-link :to="dataTable.novo">
            <q-btn icon='add' round flat></q-btn>
          </router-link>
        </div>
        <div class="container-table">
          <q-list highlight>
            <q-item v-for="ln in lista" :key="ln.key">
              <q-item-side left class="buttonLinha">
                  <q-btn icon='edit' flat round @click='editar(ln[dataTable.pk])'></q-btn>
                  <q-btn icon='far fa-trash-alt' @click='excluir(ln)' flat round></q-btn>
              </q-item-side>
              <q-item-side left v-for="campo in dataTable.campos" :key="campo.key" class="itemLinha">
                <div>
                  <label class="header">{{campo.label}}:</label>
                </div>
                <div>
                  <label for="" v-if="campo.format">{{campo.format(ln[campo.field])}}</label>
                  <label for="" v-else>{{ln[campo.field]}}</label>
                </div>
              </q-item-side>
              <q-item-separator />
            </q-item>
            <div class="ResultBusca" v-if="lista.length <= 0">
              Nenhum registro encontrado
            </div>
          </q-list>
          <div class="paginacao">
          </div>
        </div>
      </q-card-main>
    </q-card>
  </div>
</template>
<script>
export default {
  props: {
    titulo: {
      type: String,
      default: 'TITULO'
    },
    dataTable: {
      type: Object
    }
  },
  data: () => ({
    dados: []
  }),
  mounted () {
    this.BuscarGet()
  },
  computed: {
    lista () {
      return this.dados
    }
  },
  methods: {
    editar (id) {
      this.$router.push(this.dataTable.editar + id)
    },
    excluir (dado) {
      if (dado) {
        this.$store.dispatch('mod/DeleteRequest', { endereco: this.dataTable.controller, data: dado })
          .then(resp => {
            this.$mensagens.FormResponse(resp.message, resp.success)
            if (resp.success) {
              this.BuscarGet()
            }
          })
      }
    },
    BuscarGet () {
      this.$store.dispatch('mod/GetRequest', { endereco: this.dataTable.controller })
        .then(resp => {
          this.dados = resp
        })
    }
  }
}
</script>
<style lang="stylus" scoped>
#table
  padding: 15px
  .title
    h1
      color #FFE11B !important
      text-align: right
      font-size: 40px !important
      font-weight: 100
      margin 2px
  .corpotable
    .containerButton
      display flex
      width 100%
      justify-content:flex-end;
      button
        color #FFE11B !important
        font-size 22px !important
    .container-table
      margin-top 10px
      background: rgba(247, 228, 239, 0.1);
      color #fff !important
      .q-list
        padding 10px
        border none
        .q-item
          color #fff !important
          border-bottom: 1px solid #fff
          display flex
          justify-content: flex-start;
          flex-direction: row;
          flex-wrap: wrap;
          .q-item-side
            color #fff
            font-weight: bold
            margin-left: 20px
            min-width 150px
            width 20%
          .itemLinha
            .header
              font-size 14px
              color #FFE11B !important
            label
              width 100%
              font-weight: 400;
              font-size 16px
        .buttonLinha
          display flex
          justify-content: center
          align-items: center
          width 100%
          max-width: 80px !important
          button
            color #FFE11B !important
            width 100% !important
            max-width: 40px
      .ResultBusca
        padding 10px
        text-align: center
</style>
