<template>
  <div>
    <c-table :titulo='titulo' :dataTable='table'/>
  </div>
</template>
<script>
export default {
  data: () => ({
    titulo: 'Perfil de Usuário',
    table: {
      novo: '/perfis/novo',
      editar: '/perfis/editar/',
      controller: 'perfis',
      pk: 'id',
      campos: [
        { label: 'Nome', field: 'nome' },
        { label: 'Status', field: 'status', format (value) { if (value) return 'Ativo'; else return 'Desativado' } },
        { label: 'Nivel', field: 'nivel', format (value) { if (value === 1) { return 'Supervisor' } else if (value === 2) { return 'Suporte' } else if (value === 3) { return 'Administrador' } else { return 'Usuário' } } }
      ]
    }
  })
}
</script>
<style lang="stylus" scoped>
</style>
