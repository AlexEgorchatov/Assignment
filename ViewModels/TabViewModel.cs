using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Timers;

namespace Assignment.ViewModels
{
    public class TabViewModel : BindableBase
    {
        #region Private Fields

        private string _header;
        private double _headerWidth;
        private bool _isRefreshVisible;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _refreshCommand;
        private string _uri;
        private string _webAddress;

        #endregion

        #region Public Properties

        public string Header
        {
            get { return _header; }
            set { SetProperty(ref _header, value); }
        }

        public double HeaderWidth
        {
            get { return _headerWidth; }
            set { SetProperty(ref _headerWidth, value); }
        }

        public bool IsRefreshVisible
        {
            get { return _isRefreshVisible; }
            set { SetProperty(ref _isRefreshVisible, value); }
        }

        public DelegateCommand NavigateCommand
        {
            get
            {
                return _navigateCommand ?? (_navigateCommand = new DelegateCommand(() =>
                {
                    Uri = "https://" + WebAddress;
                }));
            }
        }

        public DelegateCommand RefreshCommand
        {
            get
            {
                return _refreshCommand ?? (_refreshCommand = new DelegateCommand(async () =>
                {
                    IsRefreshVisible = false;
                    NavigateCommand.Execute();
                    await Task.Delay(500);
                    IsRefreshVisible = true;
                }));
            }
        }

        public string Uri
        {
            get { return _uri; }
            set { SetProperty(ref _uri, value); }
        }

        public string WebAddress
        {
            get { return _webAddress; }
            set { SetProperty(ref _webAddress, value); }
        }

        #endregion

        #region Public Constructors

        public TabViewModel(double headerWidth)
        {
            Header = "New Tab";
            HeaderWidth = headerWidth;
            IsRefreshVisible = true;
        }

        #endregion
    }
}