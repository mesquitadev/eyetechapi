<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Moradores',
    table: {
      novo: '/Moradores/novo',
      editar: '/Moradores/editar/',
      controller: 'moradores',
      pk: 'id',
      campos: [
        { label: 'Nome', field: 'nome' },
        { label: 'Telefone', field: 'telefone' },
        { label: 'Apartamento', field: 'apartamento', format (value) { return value.numero } },
        { label: 'Bloco', field: 'apartamento', format (value) { return value.bloco } }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
