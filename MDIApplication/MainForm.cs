using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIApplication
{
    public partial class MainForm : Form
    {
        private int counter = 0; 

        public MainForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm childForm = new ChildForm();
            childForm.MdiParent = this;
            counter += 1;
            childForm.Show();
            childForm.Text = "New Document " + counter; 

        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;
                childForm.DocumentTextBox.SelectAll();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Rich text files |*.rtf";

            var dialogResult = dialog.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                var childForm = new ChildForm();
                childForm.DocumentTextBox.LoadFile(dialog.FileName);
                childForm.Text = dialog.FileName;
                childForm.Show();    
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                var childForm = (ChildForm)this.ActiveMdiChild;

                var dialog = new SaveFileDialog();
                //configure
                dialog.Filter = "Rich text files |*.rtf";
                dialog.AddExtension = true;

                var dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK){

                    childForm.DocumentTextBox.SaveFile(dialog.FileName);
                    childForm.Text = dialog.FileName;
                }
            }
        }
    }
}

