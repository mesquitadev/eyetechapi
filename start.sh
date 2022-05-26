echo "##########################################################################################"
echo "                                  INICIO SCRIPT"
echo "##########################################################################################"
echo ""
echo ""
echo "##########################################################################################"
echo "                           VERIFICANDO PASTA REPOSITORIO"
echo "##########################################################################################"
echo ""
echo ""
cd 
if [ -d "eyetech/" ];
then
    sudo chmod -R 777 eyetech/ && cd /eyetech/
    rm -R *
else
    mkdir eyetech/
    sudo chmod -R 777 eyetech/ && cd /eyetech/    
fi
echo "##########################################################################################"
echo "                           BAIXANDO ARQUIVOS                              "
echo "##########################################################################################"
echo ""
git clone https://gitlab.com/eyetech-access-control/Eyetech.Api
echo ""
echo "##########################################################################################"
echo "                           VERIFICANDO ULTIMOS 3 COMMITS"
echo "##########################################################################################"
echo ""
echo ""
echo ""
cd /eyetech/Eyetech.Api.Shipped/
git log --pretty=oneline -3
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                           LISTANDO PASTA"
echo "##########################################################################################"
echo ""
echo ""
echo ""
ls
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                           INSTALANDO DOCKER EXECUTANDO BUILD"
echo "##########################################################################################"
echo ""
echo ""
echo ""
sudo apt update
sudo apt install docker
sudo apt install docker-compose
curl -fsSL get.docker.com -o get-docker.sh && sh get-docker.sh
sudo groupadd docker
echo ""
echo "##########################################################################################"
echo "                        REALIZANDO BUILD ARQUIVOS                                         "
echo "##########################################################################################"
echo ""
echo ""
cd /eyetech/Eyetech.Api.Shipped/
sudo docker-compose build
echo ""
echo "##########################################################################################"
echo "                        LISTANDO IMAGENS DOCKER                                          "
echo "##########################################################################################"
echo ""
echo ""
cd /eyetech/Eyetech.Api.Shipped/
sudo docker images
echo ""
echo ""
echo "##########################################################################################"
echo "                                    LEVANTANDO SISTEMA                                    "
echo "##########################################################################################"
echo ""
echo ""
chmod -R 777 /eyetech/*
cd /eyetech/Eyetech.Api.Shipped/
sudo docker-compose up

