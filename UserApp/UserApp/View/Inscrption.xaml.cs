using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UserApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Inscrption : Page
    {
        public Inscrption()
        {
            this.InitializeComponent();
        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtnom.Text.All(Char.IsLetter);
            if (test == false || txtnom.Text == "")
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }

        }

        private void txtnom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtprenom_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtprenom.Text.All(Char.IsLetter);
            if (test == false || txtprenom.Text == "")
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);

            }
        }

        private void datenaissance_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (datenaissance.Date.Year + 12 < DateTime.Now.Year)
            {
                datenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                datenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);

            }
        }

        private void txtprenom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void datenaissance_Tapped(object sender, TappedRoutedEventArgs e)
        {
            datenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtcin_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtcin.Text.All(Char.IsNumber);
            if (test == false || txtcin.Text.Length == 8)
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txttelephone_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txttelephone.Text.All(Char.IsNumber);
            if (test == false || txttelephone.Text.Length == 8)
            {
                txttelephone.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txttelephone.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void adresse_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = adresse.Text.All(Char.IsLetter);
            if (test == false || adresse.Text == "")
            {
                adresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                adresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void motedepasse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (motedepasse.Password +.Length <= 8)
            {
                motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtcin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void txttelephone_GotFocus(object sender, RoutedEventArgs e)
        {
            txttelephone.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void adresse_GotFocus(object sender, RoutedEventArgs e)
        {
            adresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void motedepasse_GotFocus(object sender, RoutedEventArgs e)
        {
            motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        }
    }
}
