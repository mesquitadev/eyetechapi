using EyeTech.Shipped.Domain.DbEntity.App;
using EyeTech.Shipped.Infra.Context;
using MongoDB.Bson;
using System.Collections.Generic;

namespace EyeTech.Shipped.Infra.Migrations
{
    public class SeedMenu
    {
        public void Inicia(EyetechContext context)
        {
            List<Menu> menus = new List<Menu>();
            // MORADOR
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "account_box",
                Status = true,
                Nome = "Moradores",
                NomeRouter = "index.morador",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Moradores",
                Pagina = "./pages/morador"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "account_box",
                Status = true,
                Nome = "Alterar Morador",
                NomeRouter = "editar.morador",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Moradores/editar/:id",
                Pagina = "./pages/morador/form"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "account_box",
                Status = true,
                Nome = "Cadastra Morador",
                NomeRouter = "cadastrar.morador",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Moradores/novo",
                Pagina = "./pages/morador/form"
            });
            // VISITANTE
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "far fa-id-card",
                Status = true,
                Nome = "Visitantes",
                NomeRouter = "index.visitante",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Visitantes"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-id-card",
                Status = true,
                Nome = "Altear Visitante",
                NomeRouter = "editar.visitante",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Visitantes/editar/:id"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-id-card",
                Status = true,
                Nome = "Cadastrar Visitante",
                NomeRouter = "cadastrar.visitante",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Visitantes/novo"
            });
            // VISITANTE
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "far fa-building",
                Status = true,
                Nome = "Apartamentos",
                NomeRouter = "index.apartamento",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Apartamentos"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-building",
                Status = true,
                Nome = "Alterar Apartamento",
                NomeRouter = "editar.apartamento",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Apartamentos/editar/:id"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-building",
                Status = true,
                Nome = "Cadastrar Apartamento",
                NomeRouter = "cadastrar.apartamento",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/Apartamentos/novo"
            });
            // VEICULOS
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "fas fa-car",
                Status = true,
                Nome = "Veículos",
                NomeRouter = "index.veiculo",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/veiculos"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "fas fa-car",
                Status = true,
                Nome = "Alterar Veículos",
                NomeRouter = "editar.veiculo",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/veiculos/editar/:id"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "fas fa-car",
                Status = true,
                Nome = "Cadastrar Veículo",
                NomeRouter = "cadastrar.veiculo",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/veiculos/novo"
            });
            // USUÁRIOS
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "far fa-user",
                Status = true,
                Nome = "Usuários",
                NomeRouter = "index.usuario",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/usuarios"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-user",
                Status = true,
                Nome = "Alterar Usuário",
                NomeRouter = "editar.usuario",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/usuarios/editar/:id"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "far fa-user",
                Status = true,
                Nome = "Cadastrar Usuário",
                NomeRouter = "cadastrar.usuario",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/usuarios/novo"
            });
            // PERFIL
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "fas fa-user-cog",
                Status = true,
                Nome = "Perfil de Usuário",
                NomeRouter = "index.perfil",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/perfis"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "fas fa-user-cog",
                Status = true,
                Nome = "Altear Perfil",
                NomeRouter = "editar.perfil",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/perfis/editar/:id"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "fas fa-user-cog",
                Status = true,
                Nome = "Cadastra Perfil",
                NomeRouter = "cadastrar.perfil",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/perfis/novo"
            });
            // CAMERAS
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "videocam",
                Status = true,
                Nome = "Cameras",
                NomeRouter = "index.camera",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/cameras",
                Pagina = "./pages/camera"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "videocam",
                Status = true,
                Nome = "Alterar Camera",
                NomeRouter = "editar.camera",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/cameras/editar/:id",
                Pagina = "./pages/camera/form"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "videocam",
                Status = true,
                Nome = "Cadastra Camera",
                NomeRouter = "cadastro.camera",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/cameras/novo",
                Pagina = "./pages/camera/form"
            });
            // Configurações
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "settings",
                Status = true,
                Nome = "Configuração",
                NomeRouter = "index.configuracoes",
                Publica = false,
                Supervisor = false,
                Suporte = true,
                Url = "/configuracoes",
                Pagina = "./pages/configuracoes"
            });
            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = true,
                Icone = "account_circle",
                Status = true,
                Nome = "Cliente",
                NomeRouter = "index.cliente",
                Publica = false,
                Supervisor = true,
                Suporte = true,
                Url = "/cliente",
                Pagina = "./pages/cliente"
            });

            menus.Add(new Menu()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                AtivoMenu = false,
                Icone = "video_library",
                Status = true,
                Nome = "Vigilancia Portaria",
                NomeRouter = "index.vigilancia",
                Publica = false,
                Supervisor = false,
                Suporte = false,
                Url = "/vigilancia",
                Pagina = "./pages/vigilancia"
            });
            context.DataBase.GetCollection<Menu>(typeof(Menu).Name).InsertMany(menus);
        }

        public void AtualizaMenu(EyetechContext context)
        {
            List<Menu> menus = new List<Menu>();
            // Cliente
            
        }
    }
}