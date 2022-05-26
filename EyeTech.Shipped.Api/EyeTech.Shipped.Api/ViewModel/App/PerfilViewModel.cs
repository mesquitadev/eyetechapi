using System.Collections.Generic;

namespace EyeTech.Shipped.Api.ViewModel.App
{
    public class PerfilViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string ClienteId { get; set; }
        public int Nivel { get; set; }
        public bool Status { get; set; }
        public List<string> MenuId { get; set; }
    }
}