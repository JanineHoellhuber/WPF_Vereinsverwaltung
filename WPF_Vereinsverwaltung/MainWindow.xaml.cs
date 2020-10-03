using System;
using System.Collections.Generic;
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
using WPF_Vereinsverwaltung.Model;

namespace WPF_Vereinsverwaltung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Mitglieder> _mitglieder;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository repo = Repository.GetInstance();
            _mitglieder = repo.GetAllMitglieder();
            lbxMitglieder.ItemsSource = _mitglieder;

            btnnew.Click += BtnNew_Click;
            btndelete.Click += BtnDelete_Click;
            btnEdit.Click += BtnEdit_Click;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Mitglieder selecedMitglied = lbxMitglieder.SelectedItem as Mitglieder;
            if (selecedMitglied == null)
            {
                MessageBox.Show("Sie müssen eine Mitglied ausgewählt haben!");
                return;
            }
            MitgliederWindow cdWindow = new MitgliederWindow(selecedMitglied);
            cdWindow.ShowDialog();

            Repository repository = Repository.GetInstance();
            _mitglieder = repository.GetAllMitglieder();
            lbxMitglieder.ItemsSource = _mitglieder;
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Mitglieder selecedMitglied = lbxMitglieder.SelectedItem as Mitglieder;
            if (selecedMitglied == null)
            {
                MessageBox.Show("Sie müssen eine Mitglied ausgewählt haben!");
                return;
            }



            Repository repository = Repository.GetInstance();
            repository.DeleteMitglieder(selecedMitglied);
            _mitglieder = repository.GetAllMitglieder();
            lbxMitglieder.ItemsSource = _mitglieder;
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            MitgliederWindow cdWindow = new MitgliederWindow(null);
            cdWindow.ShowDialog();

            Repository repository = Repository.GetInstance();
            _mitglieder = repository.GetAllMitglieder();
            lbxMitglieder.ItemsSource = _mitglieder;
        }
    }
}
