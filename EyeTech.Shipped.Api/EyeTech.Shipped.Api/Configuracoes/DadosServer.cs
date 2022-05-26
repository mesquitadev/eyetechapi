using System;
using System.IO;

namespace EyeTech.Shipped.Api.Configuracoes
{
    public class DadosServer
    {
        public string HostView { get; set; }
        private string ServerName { get; }
        public bool Producao { get; set; }
        public string Api { get; set; }
        public string PathRoot { get; set; }
        public string PathUpload { get; set; }
        public string Logo { get; set; }

        public DadosServer()
        {
            this.ServerName = Environment.MachineName;
            // this.VerificaServer();
            this.HostView = "";
            this.Api = "localhost://";
            this.PathRoot = Environment.CurrentDirectory;
            this.PathUpload = Path.Combine(PathRoot, "uploads");
            this.VerificaServer();
        }

        public void VerificaServer()
        {
            switch (Environment.MachineName)
            {
                case "PAIVA":
                    this.HostView = "";
                    this.Api = "localhost://";
                    this.PathRoot = Environment.CurrentDirectory;
                    this.PathUpload = Path.Combine(PathRoot, "uploads");
                    break;
            }
        }
    }
}
