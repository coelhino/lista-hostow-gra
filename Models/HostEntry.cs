namespace GameHostList.Models
{
    public class HostEntry
    {
        public string Name { get; set; } = string.Empty;
        public string IP { get; set; } = string.Empty;
        public int Port { get; set; }
        public bool IsOnline { get; set; }
    }
}