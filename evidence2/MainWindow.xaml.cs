using System.Collections.ObjectModel;
using System.Windows;

namespace EvidenceHracu
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Hrac> hraci = new ObservableCollection<Hrac>();

        public MainWindow()
        {
            InitializeComponent();
            dgHraci.ItemsSource = hraci;
        }

        private void Pridej_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJmeno.Text) ||
                string.IsNullOrWhiteSpace(txtTym.Text))
            {
                MessageBox.Show("Vyplň jméno a tým!");
                return;
            }

            if (!int.TryParse(txtVek.Text, out int vek) || vek <= 0)
            {
                MessageBox.Show("Špatný věk!");
                return;
            }

            if (!int.TryParse(txtGoly.Text, out int goly) || goly < 0)
            {
                MessageBox.Show("Špatné góly!");
                return;
            }

            hraci.Add(new Hrac
            {
                ID = hraci.Count + 1,
                Jmeno = txtJmeno.Text,
                Tym = txtTym.Text,
                Vek = vek,
                Pozice = txtPozice.Text,
                PocetGolu = goly,
                JeAktivni = chkAktivni.IsChecked == true
            });
        }

        private void Smaz_Click(object sender, RoutedEventArgs e)
        {
            if (dgHraci.SelectedItem is Hrac vybrany)
            {
                if (MessageBox.Show("Smazat?", "Potvrzení",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    hraci.Remove(vybrany);
                }
            }
        }
    }
}