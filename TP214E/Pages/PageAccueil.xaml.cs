using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageAccueil : Page
    {
        private DALCommandes dalCommandes;
        private DALAliments dalAliments;
        public PageAccueil()
        {
            InitializeComponent();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            dalAliments = new DALAliments();
            PageInventaire frmInventaire = new PageInventaire(dalAliments);

            NavigationService.Navigate(frmInventaire);
        }
        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            dalCommandes = new DALCommandes();

            PageCommandes frmCommandes = new PageCommandes(dalCommandes);

            NavigationService.Navigate(frmCommandes);
        }
    }
}
