namespace SimpleContacts
{
    partial class Form_Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Button_Add = new System.Windows.Forms.Button();
            this.ListBox_Contacts = new System.Windows.Forms.ListBox();
            this.Button_Edit = new System.Windows.Forms.Button();
            this.Button_Delete = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Add
            // 
            this.Button_Add.Location = new System.Drawing.Point(23, 305);
            this.Button_Add.Name = "Button_Add";
            this.Button_Add.Size = new System.Drawing.Size(75, 23);
            this.Button_Add.TabIndex = 0;
            this.Button_Add.Text = "Add";
            this.Button_Add.UseVisualStyleBackColor = true;
            this.Button_Add.Click += new System.EventHandler(this.Button_Add_Click);
            // 
            // ListBox_Contacts
            // 
            this.ListBox_Contacts.FormattingEnabled = true;
            this.ListBox_Contacts.ItemHeight = 15;
            this.ListBox_Contacts.Location = new System.Drawing.Point(8, 10);
            this.ListBox_Contacts.Name = "ListBox_Contacts";
            this.ListBox_Contacts.Size = new System.Drawing.Size(404, 289);
            this.ListBox_Contacts.TabIndex = 1;
            this.ListBox_Contacts.SelectedIndexChanged += new System.EventHandler(this.ListBox_Contacts_SelectedIndexChanged);
            // 
            // Button_Edit
            // 
            this.Button_Edit.Enabled = false;
            this.Button_Edit.Location = new System.Drawing.Point(119, 305);
            this.Button_Edit.Name = "Button_Edit";
            this.Button_Edit.Size = new System.Drawing.Size(75, 23);
            this.Button_Edit.TabIndex = 2;
            this.Button_Edit.Text = "Edit";
            this.Button_Edit.UseVisualStyleBackColor = true;
            this.Button_Edit.Click += new System.EventHandler(this.Button_Edit_Click);
            // 
            // Button_Delete
            // 
            this.Button_Delete.Enabled = false;
            this.Button_Delete.Location = new System.Drawing.Point(217, 305);
            this.Button_Delete.Name = "Button_Delete";
            this.Button_Delete.Size = new System.Drawing.Size(75, 23);
            this.Button_Delete.TabIndex = 3;
            this.Button_Delete.Text = "Delete";
            this.Button_Delete.UseVisualStyleBackColor = true;
            this.Button_Delete.Click += new System.EventHandler(this.Button_Delete_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(313, 306);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 4;
            this.Button_Close.Text = "Close";
            this.Button_Close.UseVisualStyleBackColor = true;
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 336);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Button_Delete);
            this.Controls.Add(this.Button_Edit);
            this.Controls.Add(this.ListBox_Contacts);
            this.Controls.Add(this.Button_Add);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Contacts";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Button_Add;
        private ListBox ListBox_Contacts;
        private Button Button_Edit;
        private Button Button_Delete;
        private Button Button_Close;
    }
}