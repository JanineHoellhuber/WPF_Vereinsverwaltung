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
using System.Windows.Shapes;
using WPF_Vereinsverwaltung.Model;

namespace WPF_Vereinsverwaltung
{
    /// <summary>
    /// Interaction logic for MitgliederWindow.xaml
    /// </summary>
    public partial class MitgliederWindow : Window
    {
        private Mitglieder _mitglieder;
        public MitgliederWindow(Mitglieder mitglieder)
        {
            InitializeComponent();
            Loaded += MitgliederWindow_Loaded;
            _mitglieder = mitglieder;
        }

        private void MitgliederWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            if (_mitglieder == null)
            {
                DataContext = new Mitglieder() { Firstname = "Bitte Vorname eigeben", Lastname = "Bitte Nachname eingeben", Birthdate = Convert.ToDateTime("Bitte Datum eingeben bsp.: 09.11.1970"), AchievementBadge = "Bitte Abzeichen eingeben" };
            }
            else
            {
                DataContext = _mitglieder;
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            if (_mitglieder == null)
            {
                Repository.GetInstance().AddMitglied(DataContext as Mitglieder);
            }

            Close();

        }
    }
}
