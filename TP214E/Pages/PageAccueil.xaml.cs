﻿using System;
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

namespace TP214E
{
    /// <summary>
    /// Logique d'interaction pour Accueil.xaml
    /// </summary>
    public partial class PageAccueil : Page
    {
        private DAL dal;
        private DALAliments dalAliments;
        public PageAccueil()
        {
            InitializeComponent();
            dal = new DAL();
        }

        private void BoutonInventaire_Click(object sender, RoutedEventArgs e)
        {
            dalAliments = new DALAliments();
            PageInventaire frmInventaire = new PageInventaire(dalAliments);

            this.NavigationService.Navigate(frmInventaire);
        }
        private void BoutonCommandes_Click(object sender, RoutedEventArgs e)
        {
            PageCommandes frmCommandes = new PageCommandes(dal);

            this.NavigationService.Navigate(frmCommandes);
        }
    }
}
