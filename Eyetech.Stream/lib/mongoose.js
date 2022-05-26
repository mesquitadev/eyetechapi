/**
 * @author Victor Mesquita  - 24/10/2019
 * @description : Classe de conexão com o banco de dados
 * @type {Mongoose}
 * @exports : Objeto de Conexão
 */
const mongoose = require('mongoose');

//String para conexão pelo docker
// const mongo = "mongodb://mongodb:27017/eyetech";

//String para conexão por servidor local
const mongo = 'mongodb://localhost:27017/eyetech';

//Parâmetros do mongodb
mongoose.connect(mongo, {
    useNewUrlParser: true,
    useUnifiedTopology :true
});


const db = mongoose.connection;

db.on('open', () => {
    console.log('============================================================');
    console.log('\n                  BANCO INICIADO ... \n');
    console.log('============================================================');
});

db.on('error', (error) => {
    console.log('============================================================');
    console.log('\n                  PROBLEMAS NA CONEXAO ... \n');
    console.log(`\n ${error} \n`);
    console.log('============================================================');
});

module.exports = mongoose;
