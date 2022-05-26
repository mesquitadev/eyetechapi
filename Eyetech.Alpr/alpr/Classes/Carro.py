
import cv2
import base64


class Carro:
    def __init__(self):
        self.Placa = ""
        self.Data = ""
        self.Cor = ""
        self.Imagem = ""
        self.Taxa = 0

    def CarregaDados(self, placa, data, cor, imagem, taxa):
        self.Placa = placa
        self.Data = data
        self.Taxa = taxa
        self.Cor = cor
        self.Imagem = self.Base64Image(imagem)

    def Base64Image(self, imagem):

        with open(imagem, "rb") as img:
            img_encoded = base64.b64encode(img.read())

        return img_encoded