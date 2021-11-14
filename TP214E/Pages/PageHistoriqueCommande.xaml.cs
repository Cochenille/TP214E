using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TP214E.Data;

namespace TP214E.Pages
{
    /// <summary>
    /// Interaction logic for PageHistoriqueCommande.xaml
    /// </summary>
    public partial class PageHistoriqueCommande : Page
    {
        private CommandeDAL _dal;
        List<Commande> _commandes;
        List<Recette> _recettesDeCommande;

        public PageHistoriqueCommande(CommandeDAL dal)
        {
            _dal = dal;
            _commandes = new List<Commande>();
            _recettesDeCommande = new List<Recette>();

            InitializeComponent();
        }

        public void AuChargement(object sender, RoutedEventArgs e)
        {
            ChargerLesCommandes();
        }

        private void ChargerLesCommandes()
        {
            _commandes = _dal.RechercherToutesLesCommandes();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var elementDuMenu = (MenuItem)e.OriginalSource;
            Commande commandeSelectionne = (Commande)elementDuMenu.CommandParameter;
            AfficherRecetteDeLaCommande(commandeSelectionne);
        }

        public void AfficherRecetteDeLaCommande(Commande commandeSelectionne)
        {
            _recettesDeCommande = commandeSelectionne.Items;
        }

        private void ButtonRetour_Click(object sender, RoutedEventArgs e)
        {
            RetournerEnArriere();
        }

        private void RetournerEnArriere()
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
    }
}
