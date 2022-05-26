import Veiculo from './../carro'
export default class Visitante {
  constructor (
    id = null,
    nome = null,
    veiculo = new Veiculo(),
    apartamentoId = null,
    telefone = null,
    motorizado = true
  ) {
    this.id = id
    this.nome = nome
    this.veiculo = veiculo
    this.apartamentoId = apartamentoId
    this.telefone = telefone
    this.motorizado = motorizado
  }
}
