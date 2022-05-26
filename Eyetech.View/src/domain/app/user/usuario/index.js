export default class Usuario {
  constructor (
    id = null,
    nome = null,
    senha = null,
    status = true,
    clienteId = null,
    perfisId = [],
    excluido = false,
    enviado = false,
    login = null
  ) {
    this.id = id
    this.nome = nome
    this.senha = senha
    this.status = status
    this.clienteId = clienteId
    this.perfisId = perfisId
    this.excluido = excluido
    this.enviado = enviado
    this.login = login
  }
}
