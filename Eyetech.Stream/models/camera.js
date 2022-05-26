const mongoose = require('mongoose'),
      Schema = mongoose.Schema;

var Cam = new Schema({
    Nome: {
        type: String
    },
    Endereco: {
        type: String
    },
    Qualidade: {
        type: String
    },
    Enviado: {
        type: Boolean
    },
    Status: {
        type: Boolean
    },
    Porta: {
        type: Number
    },
    ClienteId: {
        type: String
    },
    DataEnvio: {
        type: Date
    }
}, { collection: 'Cameras' })

module.exports = mongoose.model('Cameras', Cam)