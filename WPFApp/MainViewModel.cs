using System;

namespace WPFApp
{
    public class MainViewModel
    {
        private readonly Action _trayIconLeftButtonClicked;
        private readonly Action _quitApplicationRequested;
        private readonly Action _hideWindowRequested;

        public MainViewModel(Action trayIconLeftButtonClicked, Action quitApplicationRequested, Action hideWindowRequested)
        {
            _trayIconLeftButtonClicked = trayIconLeftButtonClicked;
            _quitApplicationRequested = quitApplicationRequested;
            _hideWindowRequested = hideWindowRequested;
        }
        public DelegateCommand ShowWindowCommand => new DelegateCommand(x => _trayIconLeftButtonClicked());
        public DelegateCommand QuitCommand => new DelegateCommand(x => _quitApplicationRequested());
        public DelegateCommand HideWindowCommand => new DelegateCommand(x => _hideWindowRequested());
    }
}