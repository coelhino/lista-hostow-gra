using System.Net.NetworkInformation;
using System.Threading.Tasks;

public class PingService
{
    public async Task<bool> PingHostAsync(string ip)
    {
        try
        {
            var ping = new Ping();
            var reply = await ping.SendPingAsync(ip, 1000);
            return reply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
    }
}