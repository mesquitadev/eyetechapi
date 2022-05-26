using EyeTech.Shipped.Infra.Context;
using MongoDB.Driver;

namespace EyeTech.Shipped.Infra.Migrations
{
    public class Configuration
    {
        public void Inicia(EyetechContext context)
        {
            new SeedUsuario(context);
            new SeedMenu().Inicia(context);
        }

        public void Atualiza(EyetechContext context)
        {
            new SeedMenu().AtualizaMenu(context);
        }

    }
}
