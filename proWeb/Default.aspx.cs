using library;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace proWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            ENCategory cat = new ENCategory();
            ddlCategory.DataSource = cat.ReadAll();
            ddlCategory.DataTextField = "Name";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
        }

        // --- BOTÓN CREATE ---
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            // Validamos que no haya campos vacíos (Esto será parte de tu commit 6)
            if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblMessage.Text = "Error: Código y Nombre son obligatorios.";
                return;
            }

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

        // --- BOTÓN CLEAR ---
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            lblMessage.Text = "Campos limpios.";
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

        private void FillFields(ENProduct en)
        {
            txtCode.Text = en.Code;
            txtName.Text = en.Name;
            txtAmount.Text = en.Amount.ToString();
            txtPrice.Text = en.Price.ToString();
            ddlCategory.SelectedValue = en.Category.ToString();
            txtDate.Text = en.CreationDate.ToString();
        }

        private void ClearFields()
        {
            txtCode.Text = txtName.Text = txtAmount.Text = txtPrice.Text = txtDate.Text = "";
        }
    }
}