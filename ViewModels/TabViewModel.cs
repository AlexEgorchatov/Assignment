using Assignment.Controls;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using mshtml;

namespace Assignment.ViewModels
{
    public class TabViewModel : BindableBase
    {
        #region Private Fields

        private DelegateCommand _backCommand;
        private DelegateCommand _forwardCommand;
        private string _header;
        private double _headerWidth;
        private bool _isRefreshVisible;
        private DelegateCommand _navigateCommand;
        private DelegateCommand _refreshCommand;
        private string _webAddress;

        #endregion

        #region Public Properties

        public DelegateCommand BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new DelegateCommand(async () =>
                {
                    try
                    {
                        Browser.Browser.GoBack();
                    }
                    catch { }
                }, () => Browser.Browser.CanGoBack));
            }
        }

        public InternetWebBrowser Browser { get; }

        public DelegateCommand ForwardCommand
        {
            get
            {
                return _forwardCommand ?? (_forwardCommand = new DelegateCommand(async () =>
                {
                    try
                    {
                        Browser.Browser.GoForward();
                    }
                    catch { }
                }, () => Browser.Browser.CanGoForward));
            }
        }

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
                    try
                    {
                        Browser.Browser.Source = string.IsNullOrEmpty(WebAddress) ? null : new System.Uri("https://" + WebAddress);
                    }
                    catch { }
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
                    try
                    {
                        Browser.Browser.Source = string.IsNullOrEmpty(WebAddress) ? null : new System.Uri(WebAddress);
                    }
                    catch { }
                    await Task.Delay(500);//HTTP request imitation
                    IsRefreshVisible = true;
                }));
            }
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
            Browser = new InternetWebBrowser();
            Browser.Browser.Navigated += OnBrowserNavigated;
        }

        #endregion

        #region Private Methods

        private void OnBrowserNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            WebAddress = e.Uri == null ? "" : e.Uri.OriginalString;
            var doc = Browser.Browser.Document as HTMLDocument;
            Header = doc.title == "" ? Header : doc.title;
            ForwardCommand.RaiseCanExecuteChanged();
            BackCommand.RaiseCanExecuteChanged();
        }

        #endregion
    }
}