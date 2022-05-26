var mongoose = require('./lib/index'),
    Cameras = require('./models/camera'),
    OpStream = require('./operacao/OpStream')

Cameras.find({}).lean().exec((e, dados) => {
    if (e) {
        console.log(e)
    }
    ExecutaLeitura(dados)   
})

const ExecutaLeitura = (dados) => {
    if (dados.length >= 1) {
        dados.forEach(cam => {
            var stream = new OpStream(cam.Nome, cam.Endereco, cam.Qualidade, cam.Porta)
        });
    } else {
        console.log('nenhuma camera cadastrada')
    }
}