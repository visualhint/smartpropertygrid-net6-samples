namespace PropertyGridShowRoom
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.leftText = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rightText = new System.Windows.Forms.TextBox();
            this.myPropertyGrid1 = new PropertyGridShowRoom.MyPropertyGrid();
            this.metaPropertyGrid1 = new PropertyGridShowRoom.MetaPropertyGrid();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPropertyGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.leftText);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(272, 141);
            this.panel1.TabIndex = 10;
            // 
            // leftText
            // 
            this.leftText.BackColor = System.Drawing.Color.LightBlue;
            this.leftText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.leftText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.leftText.Location = new System.Drawing.Point(9, 6);
            this.leftText.Multiline = true;
            this.leftText.Name = "leftText";
            this.leftText.Size = new System.Drawing.Size(256, 129);
            this.leftText.TabIndex = 8;
            this.leftText.TabStop = false;
            this.leftText.Text = resources.GetString("leftText.Text");
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rightText);
            this.panel2.Location = new System.Drawing.Point(299, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 141);
            this.panel2.TabIndex = 11;
            // 
            // rightText
            // 
            this.rightText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightText.BackColor = System.Drawing.Color.Ivory;
            this.rightText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rightText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rightText.Location = new System.Drawing.Point(8, 6);
            this.rightText.Multiline = true;
            this.rightText.Name = "rightText";
            this.rightText.Size = new System.Drawing.Size(290, 128);
            this.rightText.TabIndex = 9;
            this.rightText.TabStop = false;
            this.rightText.Text = resources.GetString("rightText.Text");
            // 
            // myPropertyGrid1
            // 
            this.myPropertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myPropertyGrid1.BackColor = System.Drawing.SystemColors.Control;
            this.myPropertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myPropertyGrid1.CommentsHeight = 50;
            this.myPropertyGrid1.CommentsVisibility = true;
            this.myPropertyGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.myPropertyGrid1.LabelColumnWidthRatio = 0.44D;
            this.myPropertyGrid1.Location = new System.Drawing.Point(299, 164);
            this.myPropertyGrid1.Name = "myPropertyGrid1";
            this.myPropertyGrid1.ReadOnlyForeColor = System.Drawing.Color.SteelBlue;
            this.myPropertyGrid1.ReadOnlyVisual = VisualHint.SmartPropertyGrid.PropertyGrid.ReadOnlyVisuals.ReadOnlyFeel;
            this.myPropertyGrid1.Size = new System.Drawing.Size(308, 429);
            this.myPropertyGrid1.TabIndex = 2;
            this.myPropertyGrid1.Text = "myPropertyGrid1";
            this.myPropertyGrid1.ToolbarVisibility = true;
            // 
            // metaPropertyGrid1
            // 
            this.metaPropertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metaPropertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metaPropertyGrid1.CommentsHeight = 50;
            this.metaPropertyGrid1.CommentsVisibility = true;
            this.metaPropertyGrid1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metaPropertyGrid1.LabelColumnWidthRatio = 0.43939393939393939D;
            this.metaPropertyGrid1.LabelColumnWidthRatio2 = 0;
            this.metaPropertyGrid1.Location = new System.Drawing.Point(12, 164);
            this.metaPropertyGrid1.Name = "metaPropertyGrid1";
            this.metaPropertyGrid1.PropertyLabelBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.metaPropertyGrid1.PropertyValueBackColor = System.Drawing.SystemColors.Window;
            this.metaPropertyGrid1.RightToLeft2 = false;
            this.metaPropertyGrid1.Size = new System.Drawing.Size(272, 431);
            this.metaPropertyGrid1.TabIndex = 1;
            this.metaPropertyGrid1.Text = "metaPropertyGrid1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 605);
            this.Controls.Add(this.metaPropertyGrid1);
            this.Controls.Add(this.myPropertyGrid1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(450, 600);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myPropertyGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metaPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private TextBox leftText;
        private Panel panel2;
        private TextBox rightText;
        private MyPropertyGrid myPropertyGrid1;
        private MetaPropertyGrid metaPropertyGrid1;
    }
}