<template>
  <div id="Apartamento">
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Apartamentos',
    table: {
      novo: '/Apartamentos/novo',
      editar: '/Apartamentos/editar/',
      controller: 'apartamentos',
      pk: 'id',
      campos: [
        { label: 'Numero', field: 'numero' },
        { label: 'Bloco', field: 'bloco' },
        { label: 'Telefone', field: 'telefone' }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
