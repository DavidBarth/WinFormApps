using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataApp
{
    public interface ISource
    {
        IList<Category> GetCategories();

        IList<Product> GetProducts(int categoryId);

        void DeleteProduct(BindingSource source, Product product);

        void AddProduct(BindingSource source, Product product);

        void Save();
       
    }
}
