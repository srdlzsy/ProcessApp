
class Program
{
    static async Task Main(string[] args)
    {
        var processes = ProcessCollector.GetRunningProcesses();
        var webSocketClient = new WebSocketClient("ws://localhost:8080");
        await webSocketClient.SendProcessDataAsync(processes);
    }
}
