import os
import glob

from Classes.CapturaPlaca import CapturaPlaca

class ValidaImagem:
    def __init__(self, imagem, path):
        self.imagem = imagem
        self.path = path
        self.pasta = "/app/uploads/"
        self.Arquivo = self.pasta + "camera/" + imagem
        #print(self.Arquivo)
        self.VerificaExistencia()

    def VerificaExistencia(self):

        if (os.path.exists(self.Arquivo)):
            CapturaPlaca(self.Arquivo, self.pasta, self.path)
        else:
            print("ARQUIVO NAO EXISTE " + self.pasta + " " + self.Arquivo)



