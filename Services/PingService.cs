using System.Net.NetworkInformation;

namespace GameHostList.Services
{
    public class PingService
    {
        public async Task<bool> PingHostAsync(string ip)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(ip, 1000);
                return reply.Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}