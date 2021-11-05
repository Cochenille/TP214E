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
using System.Text.RegularExpressions;
using MongoDB.Bson;

namespace TP214E.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageAliment : Page
    {
        private static readonly Regex _regex = new Regex("^[0-9]+$");

        AlimentDAL _dal;
        Aliment _aliment;

        public PageAliment(AlimentDAL dal, Aliment aliment)
        {
            _dal = dal;
            _aliment = aliment;
            InitializeComponent();
            RemplissageFormulaire();
        }

        public void FermerPage(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        public void EnvoyerInformationsAliment(object sender, RoutedEventArgs e)
        {
            if (VerifierChampsFormulaire())
            {
                Aliment aliment = ObtenirInformationAliment();
                if (VerificationCasEnvoie())
                {
                    CreerAliment(aliment);
                }
                else
                {
                    aliment.Id = ObjectId.Parse(lblId.Text);
                    ModifierAliment(aliment);
                }
            }
            
        }

        private bool VerificationCasEnvoie()
        {
            return (_aliment == null);
        }

        private void CreerAliment(Aliment aliment)
        {
            _dal.CreerAliment(aliment);
            FermerPage(null, null);
        }

        private void ModifierAliment(Aliment aliment)
        {
            _dal.ModifierAliment(aliment);
            FermerPage(null, null);
        }

        private Aliment ObtenirInformationAliment()
        {
            Aliment nouvelAliment = new Aliment(txtNom.Text, Int32.Parse(txtQuatite.Text),
                txtUnite.Text, DateTime.Parse(dpkDate.Text));

            return nouvelAliment;
        }

        private void RemplissageFormulaire()
        {
            if (_aliment != null)
            {
                lblId.Text = _aliment.Id.ToString();
                txtNom.Text = _aliment.Nom;
                txtQuatite.Text = _aliment.Quantite.ToString();
                txtUnite.Text = _aliment.Unite;
                dpkDate.Text = _aliment.ExpireLe.ToString();
            }
        }

        public bool VerifierChampsFormulaire()
        {
            return (VerificationChampNom() && VerificationChampQuantite() &&
                VerificationChampUnite() && VerificationChampDate());
        }

        public static bool SontDesNombre(string text)
        {
            bool estUnNombre = _regex.IsMatch(text);
            return estUnNombre;
        }

        public void PreviewQuatiteTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !SontDesNombre(e.Text);
        }

        private bool VerificationChampDate()
        {
            if (VerifierSiChaineEstVide(dpkDate.Text))
            {
                if (DateTime.Parse(dpkDate.Text) > DateTime.Today)
                {
                    erreurDate.Text = "";
                    return true;
                }
                else
                {
                    erreurDate.Text = "La date que vous avez entré est invalide.";
                    return false;
                }
            }
            else
            {
                erreurDate.Text = "Ce champ est vide.";
                return false;
            }
        }

        public bool VerificationChampUnite()
        {
            if (VerifierSiChaineEstVide(txtUnite.Text))
            {
                erreurUnite.Text = "";
                return true;
            }
            else
            {
                erreurUnite.Text = "Ce champ est vide.";
                return false;
            }
        }

        public bool VerificationChampQuantite()
        {
            if (VerifierSiChaineEstVide(txtQuatite.Text))
            {
                if (SontDesNombre(txtQuatite.Text))
                {
                    erreurQuantite.Text = "";
                    return true;
                }
                else
                {
                    erreurQuantite.Text = "Ce champ doit comporter que des nombres.";
                    return false;
                }
            }
            else
            {
                erreurQuantite.Text = "Ce champ est vide.";
                return false;
            }
        }

        public bool VerificationChampNom()
        {
            if (VerifierSiChaineEstVide(txtNom.Text))
            {
                erreurNom.Text = "";
                return true;
            }
            else
            {
                erreurNom.Text = "Ce champ est vide.";
                return false;
            }
        }

        private bool VerifierSiChaineEstVide(string text)
        {
            return (text != "");
        }
    }
    
}
