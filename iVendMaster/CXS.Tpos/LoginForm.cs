using CXS.Core.Entities;
using CXS.PosCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CXS.Core.Common;
using CXS.Core.Common.Interfaces;
using CXS.Core.Common.Logging;
using CXS.PosCommon.Security;
using CXS.Tpos.Runtime;

namespace CXS.Tpos
{
    public partial class LoginForm : Form
    {
        private User UserDetails;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Username/Password cannot be empty.", "Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            string userName = txtUserName.Text;
            var securePassword = BuildSecuredPassword();

            Authenticator authenticator = new Authenticator();
            TposBootstrapper.Init();

            var ivendContext = ServiceContainer.Instance.GetInstance<IIvendContext>() as TposContext;
            if (ivendContext != null)
            {
                ivendContext.SetUser(UserDetails);
                ivendContext.ResetLogger(LogActivity.Undefined);
            }

            if (authenticator.CheckStateAndGetUserDetails(userName, txtPassword.Text, out UserDetails))
            {
                var mainForm = ServiceContainer.Instance.GetInstance<MainForm>();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                // TODO: Text should come from the resource for globalization
                MessageBox.Show("Invalid Credentials. Login Unsuccessful", "Login Form", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private SecureString BuildSecuredPassword()
        {
            SecureString securePassword = new SecureString();

            foreach (char c in txtPassword.Text)
                securePassword.AppendChar(c);

            return securePassword;
        }
    }
}
