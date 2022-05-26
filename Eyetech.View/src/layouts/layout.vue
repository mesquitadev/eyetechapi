<template>
  <q-layout view="lHh Lpr lFf" class="layout">
    <q-layout-header>
      <q-toolbar
        color="grey-10"
      >
        <q-btn
          flat
          dense
          round
          @click="leftDrawerOpen = !leftDrawerOpen"
          aria-label="Menu"
        >
          <q-icon name="menu" class="text-yellow-8" />
        </q-btn>

        <q-toolbar-title class="text-yellow-8">
          Eyetech
          <div slot="subtitle">App</div>
        </q-toolbar-title>
        <q-btn icon='fas fa-video' round class="camera" @click.native='$router.push("/vigilancia")'/>
        <div class="buttonUser">
          <q-btn icon='far fa-user' round color='white' class="text-black">
              <q-popover>
                <div class="containerUser">
                  <img src="statics/user.png" alt="User">
                  <p>{{user.login}}</p>
                </div>
                <q-list>
                  <q-item>
                    <q-btn icon='fas fa-sign-out-alt' flat label='Sair' @click.native='Sair'></q-btn>
                  </q-item>
                </q-list>
              </q-popover>
          </q-btn>
        </div>
      </q-toolbar>
    </q-layout-header>

    <q-layout-drawer
      v-model="leftDrawerOpen"
      id="Menu"
    >
      <q-list
        no-border
        link
        inset-delimiter
      >
        <q-list-header class="logo">
          <img src="statics/logo.png" alt="">
        </q-list-header>
        <q-item>
            <q-item-side icon="dashboard" />
            <router-link to="/">
            <q-item-main label="Dashboard" />
          </router-link>
        </q-item>
        <q-item v-for="m in menus" :key="m.key" v-if='m.ativoMenu'>
            <q-item-side :icon="m.icone" />
            <router-link :to="m.url">
              <q-item-main :label="m.nome" />
            </router-link>
        </q-item>
        <!-- <q-item>
            <q-item-side icon="far fa-id-card" />
            <router-link to="/">
              <q-item-main label="Visitantes" />
            </router-link>
        </q-item>
        <q-item>
            <q-item-side icon="far fa-building" />
            <router-link to="/">
              <q-item-main label="Apartamentos" />
            </router-link>
        </q-item>
        <q-item>
            <q-item-side icon="fas fa-car" />
            <router-link to="/">
              <q-item-main label="Veículos" />
            </router-link>
        </q-item>
        <q-item>
            <q-item-side icon="fas fa-user" />
            <router-link to="/">
              <q-item-main label="Usuários" />
            </router-link>
        </q-item> -->
      </q-list>
    </q-layout-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>
import {QPopover} from 'quasar'
export default {
  components: {
    QPopover
  },
  name: 'MyLayout',
  data () {
    return {
      showing: false,
      leftDrawerOpen: this.$q.platform.is.desktop
    }
  },
  methods: {
    Sair () {
      this.$store.commit('mod/Logout')
      this.$router.go('/')
    }
  },
  computed: {
    user () {
      return this.$store.state.mod.auth.user
    },
    menus () {
      return this.$store.state.mod.auth.menus
    }
  }
}
</script>

<style lang="stylus">
.layout
  background: #212121
  color: #fff
  .buttonUser
    margin-right: 20px
  .camera
    background: #FFE11B !important
    margin-right: 20px
    color #000
  #Menu
    background: #212121 !important
    color #FFE11B !important
    i
      color #FFE11B !important
    a
      text-decoration: none
      color #FFE11B !important
    .logo
      width 100%
      display flex
      justify-content: center;
      align-items: center
      padding 20px
      img
        margin 0 auto
        width 100%
        max-width: 150px
.q-popover
  .containerUser
    min-width 200px
    padding 10px
    display flex
    flex-direction: column;
    justify-content: center;
    align-items: center
    img
      width 100%
      max-width: 100px
    p
      margin-top 10px
</style>
