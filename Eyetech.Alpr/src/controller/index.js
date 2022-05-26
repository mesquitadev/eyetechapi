var Server = require('./../lib/server'),
glob = require('glob'),
path = require('path')


glob(path.join(__dirname,"routes/*.js"), function (er, files) {
   files.forEach((file) => {
    var router = require(file)
    Server.server.route(router)
   })
})

// glob.sync(path.join(__dirname,"routes/*.js"))
// .forEach((file) => {
// }) 