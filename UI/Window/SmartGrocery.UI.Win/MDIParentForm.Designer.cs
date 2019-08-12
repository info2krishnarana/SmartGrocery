﻿namespace SmartGrocery.UI.Win
{
    partial class MDIParentForm
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
            this.menuMainMenu = new System.Windows.Forms.MenuStrip();
            this.masterSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.storeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMainMenu
            // 
            this.menuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterSetupToolStripMenuItem});
            this.menuMainMenu.Location = new System.Drawing.Point(0, 0);
            this.menuMainMenu.Name = "menuMainMenu";
            this.menuMainMenu.Size = new System.Drawing.Size(1061, 24);
            this.menuMainMenu.TabIndex = 4;
            this.menuMainMenu.Text = "menuStrip1";
            // 
            // masterSetupToolStripMenuItem
            // 
            this.masterSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mastersToolStripMenuItem,
            this.storeToolStripMenuItem,
            this.itemsToolStripMenuItem,
            this.itemToolStripMenuItem,
            this.employeeToolStripMenuItem});
            this.masterSetupToolStripMenuItem.Name = "masterSetupToolStripMenuItem";
            this.masterSetupToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.masterSetupToolStripMenuItem.Text = "Master Setup";
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mastersToolStripMenuItem.Text = "Masters";
            this.mastersToolStripMenuItem.Click += new System.EventHandler(this.addressToolStripMenuItem_Click);
            // 
            // storeToolStripMenuItem
            // 
            this.storeToolStripMenuItem.Name = "storeToolStripMenuItem";
            this.storeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.storeToolStripMenuItem.Text = "Store";
            this.storeToolStripMenuItem.Click += new System.EventHandler(this.storeToolStripMenuItem_Click);
            // 
            // itemsToolStripMenuItem
            // 
            this.itemsToolStripMenuItem.Name = "itemsToolStripMenuItem";
            this.itemsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.itemsToolStripMenuItem.Text = "Vender";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.employeeToolStripMenuItem.Text = "Employee";
            // 
            // MDIParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 474);
            this.Controls.Add(this.menuMainMenu);
            this.IsMdiContainer = true;
            this.Name = "MDIParentForm";
            this.Text = "Grocery";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMainMenu.ResumeLayout(false);
            this.menuMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.MenuStrip menuMainMenu;
        private System.Windows.Forms.ToolStripMenuItem masterSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem storeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
    }
}


