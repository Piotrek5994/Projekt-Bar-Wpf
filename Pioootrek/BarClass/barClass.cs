using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace Pioootrek.BarClass
{
    internal class barClass
    {
        public int ID { get; set; }
        public string nazwa { get; set; }
        public string adres { get; set; }
        public string kodPocztowy { get; set; }
        public string miasto { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT * FROM Dostawcy";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        public bool Insert(barClass c)
        {

            bool isSuccess = false;


            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO dostawcy (Nazwa,Adres,KodPocztowy,Miasto,Telefon,Email) VALUES (@Nazwa, @Adres, @KodPocztowy, @Miasto, @Telefon, @Email)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Nazwa", c.nazwa);
                cmd.Parameters.AddWithValue("@Adres", c.adres);
                cmd.Parameters.AddWithValue("@KodPocztowy", c.kodPocztowy);
                cmd.Parameters.AddWithValue("@Miasto", c.miasto);
                cmd.Parameters.AddWithValue("@Telefon", c.telefon);
                cmd.Parameters.AddWithValue("@Email", c.email);



                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Delete(barClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string sql = "DELETE FROM Dostawcy WHERE ID=@ID";


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

                conn.Close();
            }
            return isSuccess;
        }
    }
}
