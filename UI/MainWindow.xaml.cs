using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string simplMmodelPath = Filename.Text;
            int lastDotIndex = simplMmodelPath.LastIndexOf('.');
            string newFile = simplMmodelPath.Substring(0, lastDotIndex) + "_full" + simplMmodelPath.Substring(lastDotIndex);
            CSPModel model = new CSPModel(simplMmodelPath, newFile);
            if (model.ToFullModel(MainProcessName.Text.Trim()))
            {
                using (new WaitCursor())
                {
                   
                     //model.Verify();
                }
            }
        }

        public void MainProcessName_GotFocus(object sender, RoutedEventArgs e)
        {
            MainProcessName.Text = "";
        }

        private void FileBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".csp";
            dlg.Filter = "CSP Files (*.csp) | *.csp";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                Filename.Text = filename;
            }
        }


    }

    public class WaitCursor : IDisposable
    {
        private Cursor _previousCursor;

        public WaitCursor()
        {
            _previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = Cursors.Wait;
        }

        #region IDisposable Members

        public void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }

        #endregion
    }



}
