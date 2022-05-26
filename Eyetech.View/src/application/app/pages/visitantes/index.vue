<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Visitantes',
    table: {
      novo: '/visitantes/novo',
      editar: '/visitantes/editar/',
      controller: 'Visitante',
      pk: 'id',
      campos: [
        { label: 'Nome', field: 'nome' },
        { label: 'Telefone', field: 'telefone' },
        { label: 'Data Chegada', field: 'dataEntrada' },
        { label: 'Data Saída', field: 'dataSaida' },
        { label: 'Motorizado', field: 'motorizado', format (value) { if (value) { return 'Sim' } else { return 'Não' } } },
        { label: 'Placa', field: 'veiculo', format (value) { return value.placa } },
        { label: 'Apartamento', field: 'apartamento', format (value) { return value.numero } },
        { label: 'Bloco', field: 'apartamento', format (value) { return value.bloco } }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
