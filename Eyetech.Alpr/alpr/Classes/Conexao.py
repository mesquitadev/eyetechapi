import pymongo
import sys

class Conexao:
    def __init__(self):
        self.BANCO = "eyetech"
        self.ENDERECO = "mongodb://localhost"
        self.PORTA = 27017

    def Conectar(self):
        try:
            conection = pymongo.MongoClient(self.ENDERECO, self.PORTA)
            banco = conection[self.BANCO]
            return banco
        except:
            print("Erro ao tentar conectar ao banco de dados, " + sys.exc_info())
