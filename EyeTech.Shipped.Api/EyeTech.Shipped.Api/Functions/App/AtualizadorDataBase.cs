using EyeTech.Shipped.Infra.Context;
using EyeTech.Shipped.Infra.Migrations;
using MongoDB.Driver;

namespace EyeTech.Shipped.Api.Functions.App
{
    public class AtualizadorDataBase
    {
        public void IniciaSistema(EyetechContext context)
        {
            new Configuration().Inicia(context);
        }

        public void Atualiza(EyetechContext context)
        {
            new Configuration().Atualiza(context);
        }
    }
}
