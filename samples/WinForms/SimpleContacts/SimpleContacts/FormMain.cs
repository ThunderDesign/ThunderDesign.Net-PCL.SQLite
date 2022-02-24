using SimpleContacts.Database.Bridges;
using SimpleContacts.Databases.ORMs;
using ThunderDesign.Net.ToolBox.Extentions;

namespace SimpleContacts
{
    public partial class Form_Main : Form
    {
        #region constructors
        public Form_Main()
        {
            InitializeComponent();
            RefreshDisplay();
        }
        #endregion

        #region methods
        private void RefreshDisplay()
        {
            ListBox_Contacts.DataSource = null;
            ListBox_Contacts.DataSource = ContactsBridge.Instance.Values.ToList();
            ListBox_Contacts.DisplayMember = nameof(ContactsORM.FullName);
            ListBox_Contacts.ValueMember = nameof(ContactsORM.Id);
            ListBox_Contacts.ClearSelected();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox_Contacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ListBox lbSender)
            {
                Button_Edit.Enabled = lbSender.SelectedIndex != -1;
                Button_Delete.Enabled = lbSender.SelectedIndex != -1;
            }
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            ContactsORM addContacts = new();
            Form_ContactInfo formAdd = new(addContacts);
            if (formAdd.ShowDialog() == DialogResult.OK)
            {
                ContactsBridge.Instance.Add(addContacts);
                RefreshDisplay();
            }
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {
            ushort selectedId = ListBox_Contacts.SelectedIndex == -1 ? (ushort)0 : (ushort)ListBox_Contacts.SelectedValue;
            if (selectedId == 0)
            {
                MessageBox.Show("Please select a Contact to edit.");
                return;
            }

            if (!ContactsBridge.Instance.TryGetValue(selectedId, out ContactsORM origContacts))
            {
                MessageBox.Show("Error: Unable to locate Contact. Please try again.");
                return;
            }

            ContactsORM editContacts = new();
            editContacts.Mirror(origContacts);

            Form_ContactInfo formEdit = new(editContacts);
            if (formEdit.ShowDialog() == DialogResult.OK)
            {
                origContacts.Mirror(editContacts);
                RefreshDisplay();
            }
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            ushort selectedId = ListBox_Contacts.SelectedIndex == -1 ? (ushort)0 : (ushort)ListBox_Contacts.SelectedValue;
            if (selectedId == 0)
            {
                MessageBox.Show("Please select a Contact to delete.");
                return;
            }

            if (!ContactsBridge.Instance.ContainsKey(selectedId))
            {
                MessageBox.Show("Error: Unable to locate Contact. Please try again.");
                return;
            }

            if (MessageBox.Show($"Are you sure you would like to delete '{ContactsBridge.Instance.GetValueOrDefault(selectedId)?.FullName ?? ""}'", "Conformation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ContactsBridge.Instance.Remove(selectedId);
                RefreshDisplay();
            }
        }
        #endregion
    }
}