using Prism.Commands;
using Prism.Mvvm;

namespace Assignment.ViewModels
{
    public class TabViewModel : BindableBase
    {
        #region Private Fields

        private string _header;
        private double _headerWidth;

        private DelegateCommand _navigateCommand;
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
        }

        #endregion
    }
}