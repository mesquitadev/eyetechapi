from Classes.ReconhecimentoPadoes import ReconhecimentoPadoes
from Classes.WebService import WebService
from Classes.Carro import Carro
from datetime import datetime
from threading import Thread
from openalpr import Alpr
import numpy as np
import cv2
import os

class CapturaPlaca:
    def __init__(self, imagem, pasta, path):
        self.Imagem = imagem
        self.COLOR_TABLE = {}
        self.IniciaCor()
        self.Config = path + 'openalpr.conf'
        self.PastaData = path + "runtime_data"
        self.Pasta = pasta
        prox = ReconhecimentoPadoes(self.Imagem, pasta)
        if (prox.ImagemProcessada != ""):
            t = Thread(target=self.VerificaPlaca, args=[prox.ImagemProcessada, prox.Original])
            t.start()
            # self.VerificaPlaca(prox.ImagemProcessada, prox.Original)

    def AplicaALPR(self, imagem, original):
        try:
            alpr = Alpr("br", self.Config, self.PastaData)
            if not alpr.is_loaded():
                print("Erro ao carregar o OpenALPR")
                self.ExcluiArquivo(imagem, original)
                return False
            else:
                alpr.set_top_n(10)
                alpr.set_default_region("br")
                result = alpr.recognize_file(imagem)
                return result
        except:
            self.ExcluiArquivo(imagem, original)


    def VerificaPlaca(self, imagem, original):
        try:
           Placa = original
           cv2.imwrite(Placa, cv2.imread(self.Imagem))
           frame = cv2.imread(Placa)
           result = self.AplicaALPR(imagem, original)
           carro = Carro()
           if (len(result['results']) >= 1):
               for plate in result['results']:
                   _x, _y = plate['coordinates'][0]['x'], plate['coordinates'][0]['y'] - 100
                   roi = frame[_y - 200:_y + 150, _x - 220:_x + 320]
                   color_car, similarity = self.get_color(roi)
                   cv2.rectangle(frame, (plate['coordinates'][0]['x'], plate['coordinates'][0]['y']),
                                 (plate['coordinates'][2]['x'], plate['coordinates'][2]['y']), (0, 0, 255), 2)
                   corte = frame[_y:_y + 350, _x - 0:_x + 550]
                   cv2.imwrite(Placa, roi)
                   plate['plate'] = plate['plate'][:3] + "-" + self.ExtrairNumeros(plate['plate'][3:])
                   # print(carro.Taxa)
                   if (carro.Taxa < plate['confidence']):
                       carro.CarregaDados(plate['plate'], datetime.now(), color_car, Placa, plate['confidence'])

           if (carro.Taxa > 0):
               #print(carro.Placa)
               t = Thread(target=WebService, args=[carro])
               t.start()
               # WebService(carro)
               self.ExcluiArquivo(imagem, original)

           else:
               self.ExcluiArquivo(imagem, original)
               print("NÃO CONTEM PLACA")

        except:
            print("OUVE ERRO")
            self.ExcluiArquivo(imagem, original)

    def ExtrairNumeros(self, numero):
        #print(numero)
        return numero.replace('O', '0')

    def ExcluiArquivo(self, imagem, original):
        try:
            os.remove(imagem)
            os.remove(original)
            print("EXCLUIDO")
        except:
            print("Erro ao excluir")

    def get_color(self, roi):
        data = np.reshape(roi, (-1, 3))
        data = np.float32(data)

        criteria = (cv2.TERM_CRITERIA_EPS + cv2.TERM_CRITERIA_MAX_ITER, 10, 1.0)
        flags = cv2.KMEANS_RANDOM_CENTERS
        try:
            compactness, labels, centers = cv2.kmeans(data, 2, None, criteria, 100, flags)
            values, counts = np.unique(labels, return_counts=True)
            most_common = centers[values[np.argmax(counts)]]
            most_common = most_common[::-1]
            min_k, min_v = None, 10 ** 6
            #print(most_common)

            for k, v in self.COLOR_TABLE.items():

                if np.dot(most_common - np.array(v), most_common - np.array(v)) < min_v:
                    min_v = np.dot(most_common - np.array(v), most_common - np.array(v))
                    min_k = k
        except:
            min_k, min_v = "Nao Identificada", 0

        #print("Cor: ", min_k)
        #print("Min_V: ", min_v)

        return min_k, min_v

    def IniciaCor(self):
        self.COLOR_TABLE = {
            "Preto": (0, 0, 0),
            "Branco": (255, 255, 255),
            "Vermelho": (255, 0, 0),
            "Lima": (0, 255, 0),
            "Azul": (0, 0, 255),
            "Amarelo": (255, 255, 0),
            "Ciano": (0, 255, 255),
            "Magenta": (255, 0, 255),
            "Prata": (220, 220, 220),
            "Cinza": (128, 128, 128),
            "Marrom": (128, 0, 0),
            "Oliva": (128, 128, 0),
            "Verde": (0, 128, 0),
            "Roxo": (128, 0, 128),
            "Cerceta": (0, 128, 128),
            "Azul-Marinho": (0, 0, 128)
        }