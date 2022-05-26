const { exec } = require('child_process'),
      fs = require('fs')

module.exports = class OpStream {
    constructor (nome, camera, qualidade, porta) {
        this.nome = nome
        this.camera = camera
        this.qualidade = qualidade
        this.porta = porta
        this.nomeImagem = nome + ".jpg"
        this.arquivo = `/app/uploads/camera/${this.nomeImagem}`         
        exec('rm -R /app/uploads/placas/* && rm -R /app/uploads/imagensprocessadas/* ');        
        this.CapturaFrame()
        this.VerificaArquivo(this.nomeImagem)
    }

    CapturaFrame () {
        exec(`ffmpeg -i "${this.camera}" -s ${this.qualidade} -r 1 -b 16000k -f image2 -updatefirst 1 ${this.arquivo} -y`);
    }

    VerificaArquivo (imagem) {
        var self = this
        fs.exists(this.arquivo, async (exist) => {
            if (!exist) {
              console.log("################################")
              console.log("\n CRIANDO ARQUIVO  \n")
              console.log("################################")
              await fs.writeFile(this.arquivo, ``)
            } else {
                fs.watch(this.arquivo, async () => {
                     this.IniciaAlpr(imagem)      
                })
            }            
          }) 
    }

    IniciaAlpr (imagem) {
        console.log("################################")
        console.log("\n CHAMANDO PYTHON ALPR  \n")
        var campos = `python3 $PYTHONALPR ${imagem} $PATHALPR `
        exec(campos, async (error, resp) => {
            console.log(await error)
            console.log(await resp)              
        })   
        console.log("################################")
    }

}