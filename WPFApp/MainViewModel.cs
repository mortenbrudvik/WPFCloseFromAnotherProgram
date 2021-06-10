using System;

namespace WPFApp
{
    public class MainViewModel
    {
        private readonly Action _trayIconLeftButtonClicked;
        private readonly Action _quitApplicationRequested;

        public MainViewModel(Action trayIconLeftButtonClicked, Action quitApplicationRequested)
        {
            _trayIconLeftButtonClicked = trayIconLeftButtonClicked;
            _quitApplicationRequested = quitApplicationRequested;
        }
        public DelegateCommand ShowWindowCommand => new DelegateCommand(x => _trayIconLeftButtonClicked());
        public DelegateCommand QuitCommand => new DelegateCommand(x => _quitApplicationRequested());
    }
}