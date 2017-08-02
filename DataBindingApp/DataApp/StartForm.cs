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

        public StartForm()
        {
            InitializeComponent();

            CategoriesComboBox.DisplayMember = "CategoryName";
            CategoriesComboBox.ValueMember = "CategoryID"; //gives back the id of the currently selected item
            CategoriesComboBox.DataSource = _objectSource.GetCategories();
        }

        private void CategoriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var categoryId = Convert.ToInt16( CategoriesComboBox.SelectedValue); // value of CategoryID
            var products = _objectSource.GetProducts(categoryId);
            ProductsListBox.DataSource = products;
            ProductsListBox.DisplayMember = "ProductName";

            NameTextBox.DataBindings.Add("Text", products, "ProductName"); //control's property, datasource, dataMember
            PriceTextBox.DataBindings.Add("Text", products, "UnitPrice");
            StockTextBox.DataBindings.Add("Text", products, "UnitsInStock");


        }
    }
}
