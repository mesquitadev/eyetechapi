
from Classes.Configuracoes import Configuracoes
from Classes.CarroJson import CarroJson
import requests
import _thread
import webbrowser
import json

#responsavel so por enviar imagem/dados para o webbservice

class WebService:
    def __init__(self, carro):
        self.Carro = carro
        self.Json = CarroJson()
        self.UltimoCarro = self.Json.Carro
        self.Config = Configuracoes()
        self.ValidaVeiculo()

    def ValidaVeiculo(self):
        try:
            if (self.Carro.Placa != self.UltimoCarro.Placa or self.UltimoCarro.Placa == ""):
                self.ConsultaWebService()
                self.Json.Escrever(self.Carro)
            if (self.Carro.Placa == self.UltimoCarro.Placa):
                tempo = self.Carro.Data - self.UltimoCarro.Data
            if (tempo.seconds > self.Config.TempoParada):
                self.ConsultaWebService()
                self.Json.Escrever(self.Carro)
            else:
                print("############################")
                print("Mesmo Veiculo")
        except Exception as e:
            print("ERRO " + str(e))

    def ConsultaWebService(self):
        try:
            # print("\n\n########################\n\n")
            # print(self.Dados())
            # print("\n\n########################\n\n")
            # print("ENVIANDO PARA SERVER")
            self.PostWebService(self.Config.RegistraVeiculo)
        except:
            return 0

    def Dados(self):
        dados = { "placa": self.Carro.Placa, "taxa": str(self.Carro.Taxa), "imagem": str(self.Carro.Imagem), "cor": str(self.Carro.Cor) }
        return dados

    def PostWebService(self, endereco):
        try:
            env = requests.post(url=self.Config.Api + endereco, data=self.Dados())
            print(env.text)
        except:
            print("erro ao enviar")

