
var FormatMoedaEnv = (valor) => {
  if (valor) {
    return valor.replace('.', '').replace(',', '.')
  }
  return valor
}

export default { FormatMoedaEnv }
