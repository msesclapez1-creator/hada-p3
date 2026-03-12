using library; // ESTA LÍNEA ES LA QUE QUITA EL ROJO DE ENProduct Y ENCategory
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Xml.Linq;

namespace proWeb
{
    public partial class _Default : Page
    {
        // Se ejecuta cada vez que se carga la página
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories(); // Solo cargamos el desplegable la primera vez
            }
        }

        // Método para rellenar el DropDownList de categorías
        private void LoadCategories()
        {
            ENCategory cat = new ENCategory();
            ddlCategory.DataSource = cat.ReadAll();
            ddlCategory.DataTextField = "Name"; // Lo que el usuario lee
            ddlCategory.DataValueField = "Id";   // El número que se guarda en BD
            ddlCategory.DataBind();
        }

        // --- BOTÓN CREATE ---
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                ENProduct en = new ENProduct(txtCode.Text, txtName.Text,
                    int.Parse(txtAmount.Text), float.Parse(txtPrice.Text),
                    int.Parse(ddlCategory.SelectedValue), DateTime.Now);

                if (en.Create()) lblMessage.Text = "Producto creado con éxito.";
                else lblMessage.Text = "No se pudo crear el producto.";
            }
            catch (Exception ex) { lblMessage.Text = "Error en datos: " + ex.Message; }
        }

        // --- BOTÓN READ ---
        protected void btnRead_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();
            en.Code = txtCode.Text;
            if (en.Read())
            {
                FillFields(en);
                lblMessage.Text = "Producto encontrado.";
            }
            else lblMessage.Text = "El producto no existe.";
        }

        // --- BOTÓN UPDATE ---
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct(txtCode.Text, txtName.Text,
                int.Parse(txtAmount.Text), float.Parse(txtPrice.Text),
                int.Parse(ddlCategory.SelectedValue), DateTime.Now);
            if (en.Update()) lblMessage.Text = "Producto actualizado.";
            else lblMessage.Text = "Error al actualizar.";
        }

        // --- BOTÓN DELETE ---
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();
            en.Code = txtCode.Text;
            if (en.Delete())
            {
                lblMessage.Text = "Producto borrado.";
                ClearFields();
            }
            else lblMessage.Text = "Error al borrar.";
        }

        // --- BOTONES DE NAVEGACIÓN ---
        protected void btnReadFirst_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();
            if (en.ReadFirst()) FillFields(en);
            else lblMessage.Text = "No hay productos.";
        }

        protected void btnReadNext_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();
            en.Code = txtCode.Text;
            if (en.ReadNext()) FillFields(en);
            else lblMessage.Text = "No hay más productos.";
        }

        protected void btnReadPrev_Click(object sender, EventArgs e)
        {
            ENProduct en = new ENProduct();
            en.Code = txtCode.Text;
            if (en.ReadPrev()) FillFields(en);
            else lblMessage.Text = "Este es el primer producto.";
        }

        // Función auxiliar para rellenar los TextBox
        private void FillFields(ENProduct en)
        {
            txtCode.Text = en.Code;
            txtName.Text = en.Name;
            txtAmount.Text = en.Amount.ToString();
            txtPrice.Text = en.Price.ToString();
            ddlCategory.SelectedValue = en.Category.ToString();
            txtDate.Text = en.CreationDate.ToString();
        }

        // Función auxiliar para limpiar los TextBox
        private void ClearFields()
        {
            txtCode.Text = txtName.Text = txtAmount.Text = txtPrice.Text = txtDate.Text = "";
        }
    }
}