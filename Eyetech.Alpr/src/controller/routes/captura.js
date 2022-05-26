const { exec } = require('child_process')
    Cameras = require('./../../models/camera'),
    OpStream = require('./../../operacao/OpStream')

module.exports = [
    {
        method: 'OPTIONS',
        path: '/',
        config: {
            description: 'PUBLIC Inicia Captura',
            handler: (request, response) => {
                console.log("INICIANDO CAPTURA DE IMAGENS")
                const ExecutaLeitura = (dados) => {
                    if (dados.length >= 1) {
                        dados.forEach(cam => {
                            var stream = new OpStream(cam.Nome, cam.Endereco, cam.Qualidade, cam.Porta)
                        });
                    } else {
                        console.log('nenhuma camera cadastrada')
                    }
                }

                Cameras.find({}).lean().exec((e, dados) => {
                    if (e) {
                        console.log(e)
                    }
                    ExecutaLeitura(dados)   
                })
                return { status: "iniciando captura"};
            }
        }
    },
    {
        method: 'OPTIONS',
        path: '/pausar',
        config: {
            description: 'PUBLIC Inicia Captura',
            handler: (request, response) => {
                console.log("Finalizando Captura")
                exec('killall ffmpeg')
                return { status: "Parando captura"};
            }
        }
    }
]