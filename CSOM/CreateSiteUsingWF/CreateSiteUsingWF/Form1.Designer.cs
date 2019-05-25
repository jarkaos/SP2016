namespace CreateSiteUsingWF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Create = new System.Windows.Forms.Button();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_AddItems = new System.Windows.Forms.Button();
            this.button_CreateList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Create
            // 
            this.button_Create.Location = new System.Drawing.Point(74, 107);
            this.button_Create.Name = "button_Create";
            this.button_Create.Size = new System.Drawing.Size(75, 23);
            this.button_Create.TabIndex = 0;
            this.button_Create.Text = "Create site";
            this.button_Create.UseVisualStyleBackColor = true;
            this.button_Create.Click += new System.EventHandler(this.button_Create_Click);
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(278, 189);
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.Size = new System.Drawing.Size(224, 20);
            this.textBox_Title.TabIndex = 1;
            // 
            // textBox_Url
            // 
            this.textBox_Url.Location = new System.Drawing.Point(278, 246);
            this.textBox_Url.Name = "textBox_Url";
            this.textBox_Url.Size = new System.Drawing.Size(224, 20);
            this.textBox_Url.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Link Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Link URL";
            // 
            // button_AddItems
            // 
            this.button_AddItems.Location = new System.Drawing.Point(278, 310);
            this.button_AddItems.Name = "button_AddItems";
            this.button_AddItems.Size = new System.Drawing.Size(182, 23);
            this.button_AddItems.TabIndex = 5;
            this.button_AddItems.Text = "Add items to quicklaunch";
            this.button_AddItems.UseVisualStyleBackColor = true;
            this.button_AddItems.Click += new System.EventHandler(this.button_AddItems_Click);
            // 
            // button_CreateList
            // 
            this.button_CreateList.Location = new System.Drawing.Point(325, 107);
            this.button_CreateList.Name = "button_CreateList";
            this.button_CreateList.Size = new System.Drawing.Size(75, 23);
            this.button_CreateList.TabIndex = 6;
            this.button_CreateList.Text = "Create a list";
            this.button_CreateList.UseVisualStyleBackColor = true;
            this.button_CreateList.Click += new System.EventHandler(this.button_CreateList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 494);
            this.Controls.Add(this.button_CreateList);
            this.Controls.Add(this.button_AddItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Url);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.button_Create);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Create;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox_Url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_AddItems;
        private System.Windows.Forms.Button button_CreateList;
    }
}

