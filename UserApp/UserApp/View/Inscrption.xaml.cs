using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UserApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        bool testnom = false, testprenom = false, testtel = false, testdate = false, testemail = false, testpw = false, testsexe = false,testcin=false; 
        private MobileServiceCollection<Utilisateur, Utilisateur> utilisateurs;
        private IMobileServiceTable<Utilisateur> utilisateurtable = App.MobileService.GetTable<Utilisateur>();
        String chsexe = "";
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
                testnom = false;
            }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                testnom = true;
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
                testprenom = false;
            }
            else
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                testprenom = true;
            }
        }

        private void datenaissance_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            if (datenaissance.Date.Year + 12 < DateTime.Now.Year)
            {
                datenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testdate = true;
            }
            else
            {
                datenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testdate = false;
            }
        }

        private void txtprenom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void datenaissance_Tapped(object sender, TappedRoutedEventArgs e)
        {
            datenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtcin_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtcin.Text.All(Char.IsNumber);
            if (test == true && txtcin.Text.Length == 8)
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                testcin = true;
            }
            else
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                testcin = false;
            }
        }

        private void txttelephone_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txttelephone.Text.All(Char.IsNumber);
            if (test == false || txttelephone.Text.Length == 8)
            {
                txttelephone.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                testtel = true;
            }
            else
            {
                txttelephone.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                testtel = false;
            }
        }

        private void btnh_Checked(object sender, RoutedEventArgs e)
        {
            chsexe = "homme";
            testsexe = true;
        }

        private void btnf_Checked(object sender, RoutedEventArgs e)
        {
            chsexe = "femme";
            testsexe = true;
        }

        private void btnretour_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Connexion));
        }

        private void motedepasse_LostFocus(object sender, RoutedEventArgs e)
        {
            if (motedepasse.Password.Length >= 8)
            {
                motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                testpw = true;

            }
            else
            {
                motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                testpw = false;
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

        private void motedepasse_GotFocus(object sender, RoutedEventArgs e)
        {
            motedepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private void txtmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtmail.Text.Contains("@") == false || txtmail.Text.Contains(".") == false || txtmail.Text.Contains(" ") == true)
            {
                txtmail.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testemail = false;
            }
            else
            {
                txtmail.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testemail = true;
            }
        }
        private void txtmail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtmail.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
        }

        private async void btnenregistrer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool testbdemail = true;
                utilisateurs = await utilisateurtable.Where(Utilisateur => Utilisateur.mail==txtmail.Text).ToCollectionAsync();
                if (utilisateurs.Count()>0)
                {
                    testbdemail = false;
                    MessageDialog msg = new MessageDialog("cette adresse occupé");
                    msg.ShowAsync();
                }
                if (testnom && testprenom && testcin && testdate && testemail && testpw && testtel && testsexe && testbdemail)
                {
                    Utilisateur u = new Utilisateur { nom = txtnom.Text, prenom = txtprenom.Text, cin = int.Parse(txtcin.Text), dateNaissance = datenaissance.Date.DateTime, mail = txtmail.Text, motDePasse = motedepasse.Password, telephone = int.Parse(txttelephone.Text), sexe = chsexe };
                    await utilisateurtable.InsertAsync(u);
                    MessageDialog msg = new MessageDialog("vous etes bien inscrit");
                    msg.ShowAsync();
                    Frame.Navigate(typeof(Connexion));
                }
                else
                {
                    MessageDialog msg = new MessageDialog("vérifiez les champs");
                    msg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }
        }
    }
}
