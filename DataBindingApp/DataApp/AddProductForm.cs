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
    public partial class AddProductForm : Form
    {
        private Category _category;
        
        
        public Product Product
        {
            get
            {
                return  new Product(
                0,
                NameTextBox.Text,
                _category.CategoryID,
                QuantityTextBox.Text,
                Convert.ToDecimal(PriceTextBox.Text),
                Convert.ToInt16(StockTextBox.Text),
                Convert.ToInt16(OrderTextBox.Text),
                DiscontinuedCheckBox.Checked);
            }
        }

        public AddProductForm(Category category)
        {
            InitializeComponent();
            _category = category;
            CategoryTextBox.Text = category.CategoryName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
