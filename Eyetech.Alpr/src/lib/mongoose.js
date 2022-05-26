var mongoose = require('mongoose')

var mongo = "mongodb://mongodb:27017/eyetech"
// var mongo = 'mongodb://localhost:27017/eyetech'

mongoose.connect(mongo, {useNewUrlParser: true})
// mongoose.connect(mongo)

var db = mongoose.connection

db.on('open', () => {
    console.log('============================================================')
    console.log('\n                  BANCO INICIADO ... \n')
    console.log('============================================================')
})

db.on('error', (error) => {
    console.log('============================================================')
    console.log('\n                  PROBLEMAS NA CONEXAO ... \n')
    console.log(`\n ${error} \n`)
    console.log('============================================================')
})

module.exports = mongoose
