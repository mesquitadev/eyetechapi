using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EyeTech.Shipped.Domain.DbEntity.Ambiente;
using EyeTech.Shipped.Infra.Repository.Ambiente;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EyeTech.Shipped.Api
{
    public class WebSocketConnectionManager
    {
        public async Task Echo(HttpContext context, WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            PortariaRepository repo = new PortariaRepository();
            while (webSocket.State == WebSocketState.Open)
            {
                var response = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (response.MessageType == WebSocketMessageType.Close)
                {
                    await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disconect...",
                        CancellationToken.None);
                }
                else
                {
                    
                    var dados = JsonConvert.SerializeObject(repo.GetAll().OrderByDescending(x=> x.Entrada).Take(7));
                    
                    await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes(dados)),
                        WebSocketMessageType.Text, true, CancellationToken.None);
                    
                }
                
            }

            await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, webSocket.CloseStatusDescription, CancellationToken.None);
            
        }
    }
}
