export default class Perfil {
  constructor (
    id = null,
    nome = null,
    nivel = null,
    clienteId = null,
    status = true,
    menuId = []
  ) {
    this.id = id
    this.nome = nome
    this.nivel = nivel
    this.clienteId = clienteId
    this.status = status
    this.menuId = menuId
  }
}
