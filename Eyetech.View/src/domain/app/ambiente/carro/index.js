export default class Carro {
  constructor (
    id = null,
    placa = null,
    status = true,
    apartamentoId = null,
    cor = null
  ) {
    this.id = id
    this.placa = placa
    this.status = status
    this.apartamentoId = apartamentoId
    this.cor = cor
  }
}
