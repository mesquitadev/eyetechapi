Servidor de Streaming EyeTech
==============================
Instruções de Instalação em modo DEV
------------------------------
##Requisitos:
    1. Docker
    2. Node JS
    2. Npm / Yarn
### Build Docker
```js
    docker build -t eyetech/streaming:v1 .
```
#### Com Npm:
```js
    npm install
    npm install nodemon
    #Starta a Aplicação
    npm start || nodemon || node index.js
```

#### Com Yarn
```js
    yarn install 
    yarn install nodemon
    yarn start || nodemon || yarn index.js
```
