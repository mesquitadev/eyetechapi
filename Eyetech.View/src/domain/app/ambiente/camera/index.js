export default class Camera {
  constructor (
    id = null,
    nome = null,
    endereco = null,
    status = true,
    qualidade = null
  ) {
    this.id = id
    this.nome = nome
    this.endereco = endereco
    this.status = status
    this.qualidade = qualidade
  }
}
