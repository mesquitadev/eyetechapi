<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Usuários',
    table: {
      novo: '/usuarios/novo',
      editar: '/usuarios/editar/',
      controller: 'usuarios',
      pk: 'id',
      campos: [
        { label: 'Login', field: 'login' },
        { label: 'Status', field: 'status', format (value) { if (value) return 'Ativo'; else return 'Desativado' } }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
