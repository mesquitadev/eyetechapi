import os
import json


#CARREGA INFORMAÇOES DE CONFIGURACAO CONFIG.JSON IMPORTANTE VERIFICA AS INFORMAÇOES DA API
class Configuracoes:
    def __init__(self):
        self.Api = ""
        self.TempoParada = 40
        self.RegistraVeiculo = ""
        self.LoadArquivo()

    def LoadArquivo(self):
        try:
            path = os.getcwd() + '/alpr/config.json'
            config = json.loads(open(path).read())
            self.Api = config["Api"]
            self.TempoParada = int(config["TempoParada"])
            self.RegistraVeiculo = config["RegistraVeiculo"]
        except Exception as e:
            print("ERRO AO LER CONFIG.JSON " + str(e))
