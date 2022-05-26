export default class Cliente {
  constructor (
    id = null,
    fantasia = null,
    razao = null,
    cnpj = null,
    cep = null,
    rua = null,
    bairro = null,
    cidade = null,
    uf = null,
    numero = null,
    telefone = null,
    emailContato = null,
    emailFinanceiro = null
  ) {
    this.id = id
    this.fantasia = fantasia
    this.razao = razao
    this.cnpj = cnpj
    this.cep = cep
    this.rua = rua
    this.bairro = bairro
    this.cidade = cidade
    this.uf = uf
    this.numero = numero
    this.telefone = telefone
    this.emailContato = emailContato
    this.emailFinanceiro = emailFinanceiro
  }
}
