'use strict';
const mongoose = require('./lib/mongoose'),
      Cameras = require('./models/camera'),
      OpStream = require('./operacao/OpStream');

//Busca as Câmeras e coloca disponível
Cameras.find({}).lean().exec((e, dados) => {
    if (e) {
        console.log(e)
    }
    ExecutaLeitura(dados)   
});

//Recebe os dados do banco e inicia o stream
const ExecutaLeitura = (dados) => {
    if (dados.length >= 1) {
        dados.forEach(cam => {
            var stream = new OpStream(cam.Nome, cam.Endereco, cam.Qualidade, cam.Porta);
            stream.IniciaStream()
        });
    } else {
        console.log('nenhuma camera cadastrada');
    }
};