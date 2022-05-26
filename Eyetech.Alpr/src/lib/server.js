const Hapi = require('hapi'),
    blipp = require('blipp'),
    server = new Hapi.Server({
        port: process.env.PORT || 3000,
        host: process.env.HOST || '0.0.0.0'
    })

    const init = async () => {
      
      server.start()
      
      await server.register({
        plugin: blipp,
        options: { }
      });

      console.log('=======================================================')
      console.log('                EYETECH CORPORATION SERVICE            ')
      console.log('=======================================================')
      console.log(`   Service User is running  ${server.info.uri}         `)

    }

    process.on('unhandledRejection', (err) => {
      console.log(err);
    });


    init()
      
module.exports = { server }