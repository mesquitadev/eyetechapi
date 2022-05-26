export default class Apartamento {
  constructor (
    id = null,
    numero = null,
    bloco = null,
    telefone = null,
    veiculos = [],
    moradores = [],
    dataEnvio = null,
    enviado = null,
    clienteId = null
  ) {
    this.id = id
    this.numero = numero
    this.bloco = bloco
    this.telefone = telefone
    this.veiculos = veiculos
    this.moradores = moradores
    this.dataEnvio = dataEnvio
    this.enviado = enviado
    this.clienteId = clienteId
  }
}
