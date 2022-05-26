from Classes.Carro import Carro
from string import Template
from datetime import datetime
import json
import os

#capira informacoes do ultimo carro lido pela camera informacoes existentes em Carro.json

class CarroJson:
    def __init__(self):
        self.Carro = Carro()
        self.Arquivo = os.getcwd() + "/alpr/carro.json"
        self.AlimentaJson()

    def AlimentaJson(self):
        self.VerficaJson()
        self.LerJson()

    def LerJson(self):
        try:
            config = json.loads(open(self.Arquivo).read())
            self.Carro.Placa = config['Placa']
            self.Carro.Cor = config['Cor']
            if (config['Data'] != ""):
                self.StringToDate(config['Data'])
        except Exception as e:
            print("ERRO AO LER CARRO.JSON " + str(e))

    def StringToDate(self, data):
        try:
            data = datetime.strptime(data, '%Y-%m-%d %H:%M:%S.%f')
            self.Carro.Data = data
        except:
            self.Carro.Data = None

    def Escrever(self, carro):
        try:
            dado = '{ "Placa": "'+ carro.Placa +'", "Data": "'+ str(carro.Data) +'", "Cor": "'+carro.Cor +'" }'
            arquivo = open(self.Arquivo, "w")
            arquivo.write(dado)
        except Exception as e:
            print("ERRO AO ESCREVER CARRO.JSON " + str(e))

    def VerficaJson(self):
        if (os.path.exists(self.Arquivo) == False):
            arquivo = open(self.Arquivo, "w")
            dado = '{ "Placa": "", "Data": "", "Cor": "" }'
            arquivo.write(dado)