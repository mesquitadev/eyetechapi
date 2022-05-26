import cv2
import os

class ReconhecimentoPadoes:
    def __init__(self, imagem, pathUpload):
        self.Imagem = imagem
        self.pathUpload = pathUpload
        self.ImagemProcessada = ""
        self.Original = ""
        self.IniciaLeitura()

    def IniciaLeitura(self):
        img = cv2.imread(self.Imagem)

        cinza = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
        # cv2.imshow("cinza", cinza)
        # cascade_src = 'cars2.xml'
        # car_cascade = cv2.CascadeClassifier(cascade_src)
        # cars = car_cascade.detectMultiScale(cinza, 1.1, 2)
        # print(cars)
        # for (x, y, w, h) in cars:
        #     cv2.rectangle(img, (x, y), (x + w, y + h), (0, 0, 255), 2)
        #
        # cv2.imshow('video', img)
        # _, bin = cv2.threshold(cinza, 120,255,cv2.THRESH_BINARY)
        self.criaImagem(cinza, img)
        #cv2.imshow("BIN", bin)

        #desfoque = cv2.GaussianBlur(bin, (5,5), 1)
        #cv2.imshow("des", desfoque)
        #_, contornos, hier = cv2.findContours(desfoque, cv2.RETR_TREE, cv2.CHAIN_APPROX_NONE)

        #for c in contornos:
        #    perimetro = cv2.arcLength(c, True)
        #    if perimetro > 1220:
        #        aprox = cv2.approxPolyDP(c, 0.05 * perimetro, True)
        #        if len(aprox) == 4:
        #            (x, y, alt, larg) = cv2.boundingRect(c)
        #            cv2.rectangle(img, (x,y), (x+alt, y + larg), (0,0,255), 5)
        #            #cv2.imwrite("imagens/img.jpg", cinza)
        #            #cv2.imshow("origuim", img)
        #            print("EXISTE VEICULO")
        #            self.criaImagem(cinza, img)

        cv2.waitKey(0)
        cv2.destroyAllWindows()

    def criaImagem(self, imagem, original):
        pasta = self.pathUpload + "imagensprocessadas/"
        placa = self.pathUpload + 'placas/'
        #nome = os.path.basename(self.Imagem)
        # print(pasta)
        if (os.path.exists(pasta) == False):
            os.mkdir(pasta)
        if (os.path.exists(self.pathUpload + 'placas/') == False):
            os.mkdir(placa)

        from datetime import datetime
        data = datetime.now()
        nome = str(data).replace("-", "_").replace(":", "_").replace(".", "_").replace(" ", "_") + ".jpg"
        self.ImagemProcessada = pasta + nome
        self.Original = placa + nome
        cv2.imwrite(self.ImagemProcessada, imagem)
        cv2.imwrite(self.Original, original)
        #print(nome)
