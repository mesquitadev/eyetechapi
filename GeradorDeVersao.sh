version="v1"
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
cd /
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
git clone https://rodrigojpaiva:Ro45456363@dev.azure.com/eyetech2018/_git/Eyetech.Api.Shipped
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
echo "                           BUILD DOCKER COMPOSE"
echo "##########################################################################################"
echo ""
echo ""
echo ""
sudo apt update
sudo apt install docker-compose
cd /eyetech/Eyetech.Api.Shipped/
sudo docker-compose build
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                          VERIFICANDO IMAGENS EXE                                 "
echo "##########################################################################################"
echo ""
echo ""
echo ""
sudo docker ps
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                        LISTANDO IMAGENS DOCKER                                          "
echo "##########################################################################################"
echo ""
echo ""
sudo docker images
cd /eyetech/Eyetech.Api.Shipped/
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                       CRIANDO IMAGEM DA VERSOA  $version"
echo "##########################################################################################"
echo ""
echo ""
sudo docker build -t eyetech2008/apiback:$version .
docker tag eyetech2008/apiback:$version eyetech2008/apiback:$version
echo ""
echo ""
sudo docker build -t eyetech2008/stream:$version .
docker tag eyetech2008/stream:$version eyetech2008/stream:$version
echo ""
echo ""
sudo docker build -t eyetech2008/eyetechfront:$version .
docker tag eyetech2008/eyetechfront:$version eyetech2008/eyetechfront:$version
echo ""
echo ""
sudo docker build -t eyetech2008/alpr:$version .
docker tag eyetech2008/alpr:$version eyetech2008/alpr:$version
echo ""
echo ""
echo ""
echo "##########################################################################################"
echo "                                    ENVIANDO VERSAO  "
echo "##########################################################################################"
echo ""
echo ""
sudo docker push eyetech2008/apiback:$version
echo ""
echo ""
sudo docker push eyetech2008/stream:$version
echo ""
echo ""
sudo docker push eyetech2008/eyetechfront:$version
echo ""
echo ""
sudo docker push eyetech2008/alpr:$version
echo ""
echo ""
cd /eyetech/
sudo rm -R Eyetech.Api.Shipped/
sudo docker-compose up


#export PATHALPR=/eyetech/Eyetech.Api.Shipped/Eyetech.Alpr/alpr/ && export PYTHONALPR=/eyetech/Eyetech.Api.Shipped/Eyetech.Alpr/alpr/main.py