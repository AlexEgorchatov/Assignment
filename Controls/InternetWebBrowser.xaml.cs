using System.Windows.Controls;

namespace Assignment.Controls
{
    /// <summary>
    /// Interaction logic for InternetWebBrowser.xaml
    /// </summary>
    public partial class InternetWebBrowser : UserControl
    {
        #region Public Properties

        public WebBrowser Browser => browser;

        #endregion

        #region Public Constructors

        public InternetWebBrowser()
        {
            InitializeComponent();
        }

        #endregion
    }
}