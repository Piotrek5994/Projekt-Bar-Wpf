using Pioootrek.BarClass;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Pioootrek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        barClass c = new barClass();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            c.nazwa = txtboxnazwa.Text;
            c.adres = txtboxadres.Text;
            c.kodPocztowy = txtboxkodpocztowy.Text;
            c.miasto = txtboxmiasto.Text;
            c.telefon = txtboxtelefon.Text;
            c.email = txtboxemail.Text;

            bool success = c.Insert(c);
            if (success == true)
            {

                System.Windows.MessageBox.Show("Pomyslnie dodano nowego dostawce");

                Clear();
            }
            else
            {

                System.Windows.MessageBox.Show("Nie udalo sie dodac dostawcy");
            }

            DataTable dt = c.Select();
            dgvdostawcy.ItemsSource = dt.DefaultView;
        }
        public void Clear()
        {
            txtboxID.Text = "";
            txtboxnazwa.Text = "";
            txtboxadres.Text = "";
            txtboxkodpocztowy.Text = "";
            txtboxmiasto.Text = "";
            txtboxtelefon.Text = "";
            txtboxemail.Text = "";

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            c.ID = Convert.ToInt32(txtboxID.Text);
            bool success = c.Delete(c);

            if (success == true)
            {
                System.Windows.MessageBox.Show("Pomyślnie usunieto Dostawce");
                DataTable dt = c.Select();
                dgvdostawcy.ItemsSource = dt.DefaultView;
                Clear();
            }


            else
            {
                System.Windows.MessageBox.Show("Nie udało sie usunąć Dostawcy");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        private void txtboxSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string keyword = txtboxSearch.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Dostawcy WHERE Nazwa LIKE '%" + keyword + "%' OR Adres LIKE '%" + keyword + "%' OR KodPocztowy LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvdostawcy.ItemsSource = dt.DefaultView;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = c.Select();
            dgvdostawcy.ItemsSource = dt.DefaultView;
        }
        private void dgvdostawcy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.DataGrid gd = (System.Windows.Controls.DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtboxID.Text = row_selected["ID"].ToString();
                txtboxnazwa.Text = row_selected["Nazwa"].ToString();
                txtboxadres.Text = row_selected["Adres"].ToString();
                txtboxkodpocztowy.Text = row_selected["KodPocztowy"].ToString();
                txtboxmiasto.Text = row_selected["Miasto"].ToString();
                txtboxtelefon.Text = row_selected["Telefon"].ToString();
                txtboxemail.Text = row_selected["Email"].ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            this.Visibility = Visibility.Hidden;
            window1.Show();
        }
    }
}
