using Prism.Mvvm;

namespace Assignment.ViewModels
{
    public class TabViewModel : BindableBase
    {
        #region Private Fields

        private string _header;
        private double _headerWidth;

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