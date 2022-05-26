export default class Morador {
  constructor (
    id = null,
    nome = null,
    telefone = null,
    apartamentoId = null,
    status = true
  ) {
    this.id = id
    this.nome = nome
    this.telefone = telefone
    this.apartamentoId = apartamentoId
    this.status = status
  }
}
