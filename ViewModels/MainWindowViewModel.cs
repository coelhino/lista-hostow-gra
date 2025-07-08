using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using GameHostList.Models;
using GameHostList.Services;

namespace GameHostList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<HostEntry> Hosts { get; } = new();
        public string NewName { get; set; } = string.Empty;
        public string NewIP { get; set; } = string.Empty;
        public int NewPort { get; set; } = 27015;

        public ReactiveCommand<Unit, Unit> AddHostCommand { get; }
        public ReactiveCommand<HostEntry, Unit> PingHostCommand { get; }

        private readonly PingService _pingService = new();

        public MainWindowViewModel()
        {
            AddHostCommand = ReactiveCommand.Create(AddHost);
            PingHostCommand = ReactiveCommand.CreateFromTask<HostEntry>(PingHostAsync);
        }

        private void AddHost()
        {
            Hosts.Add(new HostEntry
            {
                Name = NewName,
                IP = NewIP,
                Port = NewPort,
                IsOnline = false
            });
        }

        private async Task PingHostAsync(HostEntry host)
        {
            host.IsOnline = await _pingService.PingHostAsync(host.IP);
            this.RaisePropertyChanged(nameof(Hosts));
        }
    }
}