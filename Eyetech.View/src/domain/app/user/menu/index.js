export default class Menu {
  constructor (
    id = null,
    nome = null,
    url = null,
    icone = null,
    nameRoute = null
  ) {
    this.id = id
    this.nome = nome
    this.url = url
    this.icone = icone
    this.nameRoute = nameRoute
  }
}
