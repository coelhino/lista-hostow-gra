using DayZGameHostListFixed.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DayZGameHostListFixed.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<GameHost> _hosts = new();
    public ObservableCollection<GameHost> Hosts
    {
        get => _hosts;
        set
        {
            _hosts = value;
            OnPropertyChanged();
        }
    }

    private bool sortByAddressAscending = true;
    private bool sortByPlayersDescending = true;

    public MainViewModel()
    {
        Hosts = new ObservableCollection<GameHost>
        {
            new GameHost { Address = "192.168.0.101:2302", Players = 34 },
            new GameHost { Address = "dayz1.example.com:2302", Players = 12 },
            new GameHost { Address = "5.9.23.101:2502", Players = 50 },
            new GameHost { Address = "dzserver.local:2402", Players = 25 },
            new GameHost { Address = "host1.dayz.net", Players = 7 },
            new GameHost { Address = "host2.dayz.net", Players = 16 },
            new GameHost { Address = "host3.dayz.net", Players = 3 },
            new GameHost { Address = "dayz-eu.example.org", Players = 27 },
            new GameHost { Address = "dayz-us.example.org", Players = 44 },
            new GameHost { Address = "server-france.net", Players = 38 },
            new GameHost { Address = "testzone.dev", Players = 4 },
            new GameHost { Address = "devhost.example", Players = 1 },
            new GameHost { Address = "prodserver.main", Players = 32 },
            new GameHost { Address = "sandbox.zone", Players = 22 },
            new GameHost { Address = "endgame.dayz", Players = 11 }
        };
    }

    public void SortujPoAdresie()
    {
        var sorted = sortByAddressAscending
            ? Hosts.OrderBy(h => h.Address)
            : Hosts.OrderByDescending(h => h.Address);
        ReplaceCollection(sorted);
        sortByAddressAscending = !sortByAddressAscending;
    }

    public void SortujPoGraczach()
    {
        var sorted = sortByPlayersDescending
            ? Hosts.OrderByDescending(h => h.Players)
            : Hosts.OrderBy(h => h.Players);
        ReplaceCollection(sorted);
        sortByPlayersDescending = !sortByPlayersDescending;
    }

    private void ReplaceCollection(IEnumerable<GameHost> sorted)
    {
        Hosts = new ObservableCollection<GameHost>(sorted);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}