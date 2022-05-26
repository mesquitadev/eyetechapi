<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Veículos',
    table: {
      novo: '/veiculos/novo',
      editar: '/veiculos/editar/',
      controller: 'veiculos',
      pk: 'id',
      campos: [
        { label: 'Placa', field: 'placa' },
        { label: 'Cor', field: 'cor' },
        { label: 'Apartamento', field: 'apartamento', format (value) { return value.numero } },
        { label: 'Bloco', field: 'apartamento', format (value) { return value.bloco } }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
