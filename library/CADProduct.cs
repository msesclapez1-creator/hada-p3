using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        // Atributo privado para la cadena de conexión
        private string constring;

        // Constructor que inicializa la cadena de conexión
        public CADProduct()
        {
            // Lee la cadena de conexión "miconexion" del Web.config
            constring = ConfigurationManager.ConnectionStrings["miconexion"].ToString();
        }

        // --- MÉTODOS DE LA BASE DE DATOS ---

        public bool Create(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)", c);
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.Code);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                com.ExecuteNonQuery();
                c.Close();
                result = true;
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool Update(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("UPDATE Products SET name = @name, amount = @amount, price = @price, category = @category, creationDate = @creationDate WHERE code = @code", c);
                com.Parameters.AddWithValue("@name", en.Name);
                com.Parameters.AddWithValue("@code", en.Code);
                com.Parameters.AddWithValue("@amount", en.Amount);
                com.Parameters.AddWithValue("@price", en.Price);
                com.Parameters.AddWithValue("@category", en.Category);
                com.Parameters.AddWithValue("@creationDate", en.CreationDate);
                int rows = com.ExecuteNonQuery();
                if (rows > 0) result = true;
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool Delete(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Products WHERE code = @code", c);
                com.Parameters.AddWithValue("@code", en.Code);
                int rows = com.ExecuteNonQuery();
                if (rows > 0) result = true;
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool Read(ENProduct en)
        {
            bool result = false;
            try
            {
                // Conectamos a la BD usando la cadena
                SqlConnection c = new SqlConnection(constring);
                c.Open();

                // Preparamos la consulta SELECT buscando por el código
                SqlCommand com = new SqlCommand("SELECT * FROM Products WHERE code = @code", c);
                com.Parameters.AddWithValue("@code", en.Code);

                // Ejecutamos la lectura
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read()) // Si encuentra el producto...
                {
                    // ...rellenamos el resto de datos del objeto "en"
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    result = true; // Todo ha ido bien
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                // SELECT TOP 1 coge solo el primer registro, ordenado por su ID
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products ORDER BY id ASC", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    result = true;
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool ReadNext(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                // Busca el primer producto cuyo ID sea mayor al ID del producto actual
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE id > (SELECT id FROM Products WHERE code = @code) ORDER BY id ASC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    result = true;
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool result = false;
            try
            {
                SqlConnection c = new SqlConnection(constring);
                c.Open();
                // Busca el primer producto cuyo ID sea menor al ID del producto actual, ordenado al revés (DESC)
                SqlCommand com = new SqlCommand("SELECT TOP 1 * FROM Products WHERE id < (SELECT id FROM Products WHERE code = @code) ORDER BY id DESC", c);
                com.Parameters.AddWithValue("@code", en.Code);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Name = dr["name"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.Category = int.Parse(dr["category"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    result = true;
                }
                dr.Close();
                c.Close();
            }
            catch (SqlException ex)
            {
                result = false;
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
            }
            return result;
        }
    }
}