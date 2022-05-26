using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EyeTech.Shipped.Api.Functions.App
{
    public class Upload
    {
        public string Pasta = Path.Combine(Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "uploads");
        public string NomeArquivo { get; set; }
        private string Formato { get; set; }
        public Upload(string pasta, string formato = null)
        {
            Pasta = Path.Combine(Pasta + Path.DirectorySeparatorChar + pasta);
            if (!Directory.Exists(Pasta))
            {
                Directory.CreateDirectory(Pasta);
            }
            this.Formato = formato;
        }

        public void ApagarImagem(string arquivo)
        {
            if (!String.IsNullOrEmpty(arquivo) && !String.IsNullOrEmpty(BuscarFormato(arquivo)))
            {
                if (Directory.Exists(Pasta))
                {
                    var imagem = Path.Combine(Pasta, arquivo);
                    if (File.Exists(imagem))
                    {
                        File.Delete(imagem);
                    }
                }
            }
        }

        private string BuscarFormato(string imagem)
        {
            if (imagem.Contains("data:image/jpeg;base64") == true)
            {
                this.Formato = ".jpeg";
                return imagem.Replace("data:image/jpeg;base64,", "");
            }
            else if (imagem.Contains("b'") == true)
            {
                return imagem.Replace("b'", "").Replace("'", "");
            }
            else
            {
                this.Formato = ".png";
                return imagem.Replace("data:image/png;base64,", "");
            }
        }
        public void ConverterImagem(string imagem)
        {
            imagem = BuscarFormato(imagem);
            byte[] newfile = Convert.FromBase64String(imagem);
            GeraNomeArquivo(imagem);
            string path = Path.Combine(this.Pasta + Path.DirectorySeparatorChar + this.NomeArquivo);
            File.WriteAllBytes(path, newfile);
        }
        public void GeraNomeArquivo(string nome)
        {
            if (this.NomeArquivo == null)
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(nome + DateTime.Now);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                this.NomeArquivo = sb.ToString() + this.Formato;
            }
            else
            {
                this.NomeArquivo = this.NomeArquivo + this.Formato;
            }
        }
    }
}
