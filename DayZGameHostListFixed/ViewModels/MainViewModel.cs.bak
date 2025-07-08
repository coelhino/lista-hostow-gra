using System.Collections.ObjectModel;
using DayZGameHostListFixed.Models;

namespace DayZGameHostListFixed.ViewModels;

public class MainViewModel
{
    public ObservableCollection<GameHost> Hosts { get; } = new()
    {
        new GameHost { Address = "192.168.0.101:2302" },
        new GameHost { Address = "dayz1.example.com:2302" },
        new GameHost { Address = "5.9.23.101:2502" },
        new GameHost { Address = "dzserver.local:2402" }
    };
}