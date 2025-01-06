using System;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class WebSocketClient
{
    private readonly Uri _serverUri;

    public WebSocketClient(string serverUrl)
    {
        _serverUri = new Uri(serverUrl);
    }

    public async Task SendProcessDataAsync(List<object> processList)
    {
        using (var client = new ClientWebSocket())
        {
              
            await client.ConnectAsync(_serverUri, CancellationToken.None);
            Console.WriteLine("WebSocket bağlantısı kuruldu.");

            var jsonData = JsonSerializer.Serialize(processList);
            var data = Encoding.UTF8.GetBytes(jsonData);

            await client.SendAsync(new ArraySegment<byte>(data), WebSocketMessageType.Text, true, CancellationToken.None);
            Console.WriteLine("Veri gönderildi.");
        }
    }
}
