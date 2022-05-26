using System.Collections.Generic;

namespace EyeTech.Shipped.Api.ViewModel.App
{
    public class MenusViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<SubmenuViewModel> Submenus { get; set; }
        public string Icone { get; set; }
        public string Url { get; set; }
        public string NomeRouter { get; set; }
        public string Pagina { get; set; }
        public bool Supervisor { get; set; }
        public bool Suporte { get; set; }
        public bool Status { get; set; }
        public bool Publica { get; set; }
        public bool AtivoMenu { get; set; }
    }
}
