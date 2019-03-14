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
    public partial class InsertForm : Form
    {
        UserService AuthService;
        public InsertForm(UserService service)
        {
            InitializeComponent();
            this.AuthService = service;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User user = new User();
                user.SetName(NameBox.Text);
                user.SetEmail(EmailBox.Text);
                user.SetPassword(PasswordBox.Text,ConfirmationBox.Text);

                AuthService.Add(user);
                MessageBox.Show("Saved.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
