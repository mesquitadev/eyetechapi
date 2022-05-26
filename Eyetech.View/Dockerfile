FROM node

RUN apt update && apt-get upgrade -y
RUN npm install -g vue-cli && npm install -g quasar-cli

WORKDIR /app

COPY . ./arquivos

RUN cd arquivos/ && ls && npm i && quasar build

RUN cp -R arquivos/dist/spa-mat/* /app/
RUN npm install -g lite-server 
RUN ls
RUN rm -rf arquivos

EXPOSE 3000

ENTRYPOINT ["lite-server"]


