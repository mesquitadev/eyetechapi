using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MongoDB.Bson;

namespace EyeTech.Shipped.Api.ViewModel.App
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string ClienteId { get; set; }
        public DateTime DataUltimoAcesso { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }
        public int Nivel { get; set; }
        public List<PerfilViewModel> Perfis { get; set; }
        public List<string> PerfisId { get; set; }
        public bool Excluido { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool Enviado { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }

        public string CriptografaMd5(string senha)
        {
            try
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}