using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Infra.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EyeTech.Shipped.Infra.Migrations
{
    public class SeedUsuario
    {
        List<Perfil> list = new List<Perfil>();
        public SeedUsuario(EyetechContext context)
        {
            Cliente(context);
        }

        private void Cliente(EyetechContext context)
        {
            var cliente = new Cliente()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Fantasia = "Eyetech",
                Cnpj = "11.111.111/1111-11",
                EmailContato = "rodrigo@webpago.com.br",
                
            };
            context.DataBase.GetCollection<Cliente>(typeof(Cliente).Name).InsertOne(cliente);

            Perfil(context, cliente.Id);
            var perfis = new List<string>();
            perfis.Add(list.First(x => x.Nivel == 2).Id);

            var user = new Usuario()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                ClienteId = cliente.Id,
                Login = "suporte@eyetech.com.br",
                Senha = CriptografaMd5("123456"),
                Status = true,
                Excluido = false,
                DataCadastro = DateTime.Now,
                PerfisId = perfis,
                Enviado = true
            };
            context.DataBase.GetCollection<Usuario>(typeof(Usuario).Name).InsertOne(user);
        }

        private void Perfil(EyetechContext context, string clienteId)
        {
            list.Add(new Perfil()
            {
                ClienteId = clienteId, Nivel = 1, Nome = "Supervisor", Id = ObjectId.GenerateNewId().ToString()
            });
            list.Add(new Perfil()
            {
                ClienteId = clienteId, Nivel = 2, Nome = "Suporte", Id = ObjectId.GenerateNewId().ToString()
            });
            list.Add(new Perfil()
            {
                ClienteId = clienteId, Nivel = 3, Nome = "Adminstrador", Id = ObjectId.GenerateNewId().ToString()
            });

            context.DataBase.GetCollection<Perfil>(typeof(Perfil).Name).InsertMany(list);
        }

        private string CriptografaMd5(string senha)
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