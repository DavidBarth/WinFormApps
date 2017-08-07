using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataApp
{
    public partial class StartForm : Form
    {
        private ObjectSource _objectSource = new ObjectSource();
        private BindingSource _categoriesBindingSource = new BindingSource();
        private BindingSource _productBindingSource = new BindingSource();

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            _categoriesBindingSource.DataSource = _objectSource.GetCategories();
            CategoriesToolStripComboBox.ComboBox.DisplayMember = "CategoryName";
            CategoriesToolStripComboBox.ComboBox.ValueMember = "CategoryID"; //gives back the id of the currently selected item
            CategoriesToolStripComboBox.ComboBox.DataSource = _categoriesBindingSource;

            ProductsListBox.DataSource = _productBindingSource;
            ProductsListBox.DisplayMember = "ProductName";
            DataGridView.DataSource = _productBindingSource;

            NameTextBox.DataBindings.Add("Text", _productBindingSource, "ProductName"); //control's property, datasource, dataMember
            PriceTextBox.DataBindings.Add("Text", _productBindingSource, "UnitPrice");
            StockTextBox.DataBindings.Add("Text", _productBindingSource, "UnitsInStock");
            QuantityTextBox.DataBindings.Add("Text", _productBindingSource, "QuantityPerUnit");
            OrderTextBox.DataBindings.Add("Text", _productBindingSource, "UnitsOnOrder");
            DiscontinuedCheckBox.DataBindings.Add("Checked", _productBindingSource, "Discontinued");
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var category = (Category)CategoriesToolStripComboBox.ComboBox.SelectedItem;
            AddProductForm addProductForm = new AddProductForm(category);
            var result =  addProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var product = addProductForm.Product;
                _objectSource.AddProduct(product);
                addProductForm.Close();
            }
        }

        private void CategoriesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryId = Convert.ToInt16(CategoriesToolStripComboBox.ComboBox.SelectedValue); // value of CategoryID
            _productBindingSource.DataSource = _objectSource.GetProducts(categoryId);
            
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete Product?");
            if (result == DialogResult.OK)
            {
                var product = (Product)ProductsListBox.SelectedItem;
                _objectSource.DeleteProduct(product);
            }
        }

       
    }
}
