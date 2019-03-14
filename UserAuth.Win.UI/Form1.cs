using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuth.Service;

namespace UserAuth.Win.UI
{
    public partial class Form1 : Form
    {
        UserService service = new UserService();

        public Form1()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            InsertForm insertion = new InsertForm(service);
            insertion.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(service);
            search.ShowDialog();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveForm remove = new RemoveForm(service);
            remove.ShowDialog();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateForm update = new UpdateForm(service);
            update.ShowDialog();
        }
    }
}
