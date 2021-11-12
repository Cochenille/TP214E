using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Controls;
using TP214E.Data;

namespace TP214E
{
    public partial class PageInventaire : Page
    {
        private IMongoCollection<Aliment> aliments;
        private DALAliments dal;

        public PageInventaire(DALAliments dal)
        {
            InitializeComponent();

            this.dal = dal;
            aliments = dal.Aliments();

            RafraichirListeAliments();
        }

        private void boutonCreer_Click(object sender, RoutedEventArgs e)
        {
            CreerAliment();
            RafraichirListeAliments();
        }
        private void bouttonRetour_Click(object sender, RoutedEventArgs e)
        {
            RetournerALaPageDaccueil();
        }

        private void CreerAliment()
        {
            Aliment aliment = AssignerEntreesFormulaireVersAliment();

            dal.AjouterAliment(aliment);
        }
        private Aliment AssignerEntreesFormulaireVersAliment()
        {
            Aliment aliment = new Aliment();
            aliment.Nom = creer_nom_aliment.Text;
            aliment.Quantite = Convert.ToInt32(creer_quantite_aliment.Text);
            aliment.ExpireLe = Convert.ToDateTime(creer_date_expiration_aliment.Text);
            aliment.Unite = creer_nom_aliment.Text;
            return aliment;
        }

        private void SupprimerAlimentSelectionne()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;

            dal.RetirerAliment(alimentSelectionne);
        }

        private void boutonSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerAlimentSelectionne();
            RafraichirListeAliments();
        }

        private void ModifierAlimentSelectionne()
        {
            Aliment alimentSelectionne = (Aliment)liste_aliments.SelectedItem;
            Aliment aliment = AssignerEntreesFormulaireVersAliment();

            dal.ModifierAliment(aliment, alimentSelectionne._id);
        }

        private void boutonModifier_Click(object sender, RoutedEventArgs e)
        {
            ModifierAlimentSelectionne();
            RafraichirListeAliments();
        }

        private void RafraichirListeAliments()
        {
            liste_aliments.ItemsSource = aliments.Aggregate().ToList();
        }
        public void RetournerALaPageDaccueil()
        {
            PageAccueil pageAccueil = new PageAccueil();
            NavigationService.Navigate(pageAccueil);
        }


    }
}
