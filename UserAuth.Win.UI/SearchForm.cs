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
using UserAuth.Domain;

namespace UserAuth.Win.UI
{
    public partial class SearchForm : Form
    {
        UserService AuthService;

        public SearchForm(UserService Service)
        {
            InitializeComponent();
            this.AuthService = Service;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                User user = AuthService.GetByEmail(EmailBox.Text);
                NameBox.Text = user.Name;
                PasswordBox.Text = user.Password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
