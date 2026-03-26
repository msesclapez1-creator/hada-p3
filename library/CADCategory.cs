using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            // Usamos la misma conexión que configuró Manuel en el Web.config
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        // Este método lee todas las categorías para llenar luego el desplegable de la web
        public List<ENCategory> ReadAll()
        {
            List<ENCategory> lista = new List<ENCategory>();
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Categories", c);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ENCategory en = new ENCategory();
                    en.Id = int.Parse(dr["id"].ToString());
                    en.Name = dr["name"].ToString();
                    lista.Add(en);
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            return lista;
        }

        public bool Read(ENCategory en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM Categories WHERE id = @id", c);
                com.Parameters.AddWithValue("@id", en.Id);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Name = dr["name"].ToString();
                    result = true;
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }
    }
}