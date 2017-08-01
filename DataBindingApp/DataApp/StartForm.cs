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

            CategoriesComboBox.DataSource = _objectSource.GetCategories();
            CategoriesComboBox.DisplayMember = "CategoryName";
        }

       
    }
}
