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

        private ISource _currentSource;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            SourceToolStripComboBox.SelectedIndex = 0; //defaulted to Object

           // SetSource();
            BindCategories();

            
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

       


        private void AddButton_Click(object sender, EventArgs e)
        {
            var category = (Category)CategoriesToolStripComboBox.ComboBox.SelectedItem;
            AddProductForm addProductForm = new AddProductForm(category);
            var result =  addProductForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var product = addProductForm.Product;
                _productBindingSource.Add(product);
                addProductForm.Close();
            }
        }

        private void CategoriesToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BindProducts();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to delete Product?");
            if (result == DialogResult.OK)
            {
                var product = (Product)ProductsListBox.SelectedItem;
                _productBindingSource.Remove(product);
            }
        }

        private void SourceToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSource();
            BindCategories();
            BindProducts();
        }


        private void BindCategories()
        {
            _categoriesBindingSource.DataSource = _currentSource.GetCategories();
        }

        private void SetSource()
        {
            switch (SourceToolStripComboBox.SelectedIndex)
            {
                case 1:
                    if(_objectSource == null){
                        _objectSource = new ObjectSource();
                    }

                    break;

                default:
                    _currentSource = _objectSource;
                    break;
            }
        }

        private void BindProducts()
        {
            var categoryId = Convert.ToInt16(CategoriesToolStripComboBox.ComboBox.SelectedValue); // value of CategoryID
            _productBindingSource.DataSource = _currentSource.GetProducts(categoryId);
        }

       
    }
}
