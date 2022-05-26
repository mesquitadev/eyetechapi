echo "##########################################################################################"
echo "                                    INICIANDO INSTALADOR                                  "
echo "                                         EYETECH                                       "
echo "                                        Version 1.0                                       "
echo "##########################################################################################"
echo ""
echo ""
echo "##########################################################################################"
echo "                                    VERIFICANDO DOCKER                                   "
echo "##########################################################################################"
echo ""
echo ""
echo -n docker
echo ""
echo ""
pacote=$(dpkg --get-selections | grep "$nome" )
echo ""
echo -n "Verificando se o Pacote $nome esta instalado"
echo ""
echo ""
echo ""
sleep 2
if [ -n "$pacote" ] ;
then echo
     echo "Pacote $nome ja instalado"
else echo
     echo "Pacote $nome Necessario-> Nao instalado"
     echo "Instalando Automaticamente Pacote Dialog..."
     sudo apt update
     sudo apt install docker
     sudo apt install docker-compose
     curl -fsSL get.docker.com -o get-docker.sh && sh get-docker.sh
     sudo groupadd docker
fi

echo "##########################################################################################"
echo "                       COPIANDO ARQUIVO PARA PASTA RAIZ                                   "
echo "##########################################################################################"
mkdir /eyetech/
chmod -R 777 /eyetech
cp -R docker-compose.yml /eyetech/
mkdir /EytechPath && mkdir /EytechPath/uploads && mkdir /EytechPath/DB
chmod -R 777 /EytechPath
cd /eyetech && sudo docker-compose up