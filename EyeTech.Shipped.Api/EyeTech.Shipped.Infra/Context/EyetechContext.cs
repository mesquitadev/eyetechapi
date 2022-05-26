using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Infra.Migrations;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Context
{
    public class EyetechContext
    {
        private string NameBanco = "eyetech";
        private string ConectionString = "mongodb://mongodb:27017";
        //private string ConectionString = "mongodb://localhost:27017";
        //private string ConectionString = "mongodb://192.168.1.102:27017";

        private readonly MongoClient Client;
        public readonly IMongoDatabase DataBase;

        public EyetechContext()
        {
            Client = new MongoClient(ConectionString);
            DataBase = Client.GetDatabase(NameBanco);
            //new Configuration(DataBase);
        }

        public IMongoCollection<Apartamento> Apartamentos { get
            {
                return DataBase.GetCollection<Apartamento>(typeof(Apartamento).Name);
            }
        }
        public IMongoCollection<Menu> Menus
        {
            get
            {
                return DataBase.GetCollection<Menu>(typeof(Menu).Name);
            }
        }
        public IMongoCollection<Usuario> Usuarios
        {
            get
            {
                return DataBase.GetCollection<Usuario>(typeof(Usuario).Name);
            }
        }
        public IMongoCollection<Perfil> Perfis
        {
            get
            {
                return DataBase.GetCollection<Perfil>(typeof(Perfil).Name);
            }
        }
        public IMongoCollection<Cliente> Clientes
        {
            get
            {
                return DataBase.GetCollection<Cliente>(typeof(Cliente).Name);
            }
        }
        public IMongoCollection<Visitante> Visitantes
        {
            get
            {
                return DataBase.GetCollection<Visitante>(typeof(Visitante).Name);
            }
        }
        public IMongoCollection<Morador> Moradores
        {
            get
            {
                return DataBase.GetCollection<Morador>(typeof(Morador).Name);
            }
        }
        public IMongoCollection<Veiculo> Veiculos
        {
            get
            {
                return DataBase.GetCollection<Veiculo>(typeof(Veiculo).Name);
            }
        }
        public IMongoCollection<VersionDataBase> VersionDataBase
        {
            get
            {
                return DataBase.GetCollection<VersionDataBase>(typeof(VersionDataBase).Name);
            }
        }
        public IMongoCollection<Portaria> Portaria
        {
            get
            {
                return DataBase.GetCollection<Portaria>(typeof(Portaria).Name);
            }
        }
    }
}