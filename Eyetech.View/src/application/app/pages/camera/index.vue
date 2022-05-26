<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Cameras',
    table: {
      novo: '/cameras/novo',
      editar: '/cameras/editar/',
      controller: 'cameras',
      pk: 'id',
      campos: [
        { label: 'Nome', field: 'nome' },
        { label: 'Url', field: 'endereco' }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
