using System;
using System.Windows;
using System.Windows.Controls;

namespace Assignment.Controls
{
    /// <summary>
    /// Interaction logic for InternetWebBrowser.xaml
    /// </summary>
    public partial class InternetWebBrowser : UserControl
    {
        #region Public Fields

        public static DependencyProperty UriProperty = DependencyProperty.Register("Uri", typeof(string), typeof(InternetWebBrowser), new PropertyMetadata("", new PropertyChangedCallback(OnUriPropertyChanged)));

        #endregion

        #region Public Properties

        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }

        #endregion

        #region Public Constructors

        public InternetWebBrowser()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public static void OnUriPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var browser = (d as InternetWebBrowser).browser;
            try
            {
                if (browser != null)
                {
                    string uri = e.NewValue as string;
                    browser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion
        }
}