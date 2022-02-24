using SimpleContacts.Databases.ORMs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleContacts
{
    public partial class Form_ContactInfo : Form
    {
        #region constructors
        public Form_ContactInfo(ContactsORM contactsORM) : base()
        {
            InitializeComponent();
            _ContactsORM = contactsORM;
            TextBox_FirstName.Text = contactsORM.FirstName;
            TextBox_LastName.Text = contactsORM.LastName;
        }
        #endregion

        #region methods
        private void Button_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextBox_LastName.Text))
            {
                MessageBox.Show("Last Name is required");
                TextBox_LastName.Focus();
                return;
            }

            if (String.IsNullOrEmpty(TextBox_FirstName.Text))
            {
                MessageBox.Show("First Name is required");
                TextBox_FirstName.Focus();
                return;
            }

            _ContactsORM.FirstName = TextBox_FirstName.Text;
            _ContactsORM.LastName = TextBox_LastName.Text;

            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region variables
        private readonly ContactsORM _ContactsORM;
        #endregion
    }
}
