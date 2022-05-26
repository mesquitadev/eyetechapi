const Stream = require('node-rtsp-stream');

module.exports = class OpStream {
    constructor (nome, camera, qualidade, porta) {
        this.nome = nome;
        this.camera = camera;
        this.qualidade = qualidade;
        this.porta = porta;
        this.nomeImagem = nome + ".jpg";
        this.arquivo = `/app/uploads/camera/${this.nomeImagem}`;
    }

    IniciaStream () {
       var stream = new Stream({
            streamUrl: this.camera,
            wsPort: this.porta,
            name: this.nome,
            ffmpegOptions: {
              '-force_fps': 30
            },
            wsServer: {
              WebSocketServer: {
                path: this.nome
              }
            }
        });
    }
};