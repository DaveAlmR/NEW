using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserAuth.Domain;
using UserAuth.Service;

namespace UserAuth.Win.UI
{
    public partial class RemoveForm : Form
    {
        UserService AuthService;
        public RemoveForm(UserService service)
        {
            InitializeComponent();
            this.AuthService = service;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AuthService.Delete(EmailBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
