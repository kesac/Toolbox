using System;
using System.Collections.Generic;
using System.IO;
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

namespace Kesac.Toolbox.Desktop
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

        private void TextBox_Changed(object sender, TextChangedEventArgs e)
        {
            var left = TextBoxLeftSet.Text.Split("\n").Select(x => x.Trim()).Where(x => x.Length > 0);
            var right = TextBoxRightSet.Text.Split("\n").Select(x => x.Trim()).Where(x => x.Length > 0);

            var leftExclusive = left.Where(x => !right.Contains(x));
            var rightExclusive = right.Where(x => !left.Contains(x));
            var intersect = left.Intersect(right);

            TextBoxLeftExclusive.Text = String.Join("\n", leftExclusive);
            TextBoxRightExclusive.Text = String.Join("\n", rightExclusive);
            TextBoxIntersect.Text = String.Join("\n", intersect);

        }

        /*
        private void TabControlMainNavigation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridSetComparison.Visibility = Visibility.Collapsed;
            GridStringTransform.Visibility = Visibility.Collapsed;

            if (TabControlMainNavigation.SelectedIndex == 0)
            {
                GridSetComparison.Visibility = Visibility.Visible;
            }
            else if(TabControlMainNavigation.SelectedIndex == 1)
            {
                GridStringTransform.Visibility = Visibility.Visible;
            }
        }
        */
        private void OnButtonToolbox(object sender, RoutedEventArgs e)
        {
            GridSetComparison.Visibility = Visibility.Collapsed;
            GridStringTransform.Visibility = Visibility.Collapsed;

            if(sender == ButtonSetComparison)
            {
                GridSetComparison.Visibility = Visibility.Visible;
            }
            else if(sender == ButtonStringTransform)
            {
                GridStringTransform.Visibility = Visibility.Visible;
            }

        }


        private void OnButtonEditLabel(object sender, RoutedEventArgs e)
        {

        }

        private void OnButtonExportToClipboard(object sender, RoutedEventArgs e)
        {

        }

        private void OnButtonClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OnButtonMaximize(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void OnButtonMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnWindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
