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
    public sealed partial class Connexion : Page
    {
        private MobileServiceCollection<Utilisateur, Utilisateur> utilisateurs;
        private MobileServiceCollection<Utilisateur, Utilisateur> utilisateurs1;
        private IMobileServiceTable<Utilisateur> utilisateurtable = App.MobileService.GetTable<Utilisateur>();
        public Connexion()
        {
            this.InitializeComponent();
        }

        private void btninscrit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Inscrption));
        }

        private async void btncnx_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                utilisateurs = await utilisateurtable.Where(Utilisateur => Utilisateur.mail==txtemail.Text).ToCollectionAsync();
                if (utilisateurs.Count>0)
                {
                    utilisateurs1 = await utilisateurtable.Where(Utilisateur => Utilisateur.mail ==txtemail.Text && Utilisateur.motDePasse==motdepasse.Password).ToCollectionAsync();
                    if (utilisateurs1.Count()>0)
                    {
                        Frame.Navigate(typeof(Accueil));
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("mot de passe invalid");
                        msg.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog msg = new MessageDialog("verifier adresse email");
                    msg.ShowAsync();
                }
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur serveur");
                msg.ShowAsync();
            }
        }
    }
}
