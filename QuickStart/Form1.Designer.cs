namespace QuickStart
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
            this.myPropertyGrid1 = new MyPropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.myPropertyGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // myPropertyGrid1
            // 
            this.myPropertyGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.myPropertyGrid1.CommentsHeight = 70;
            this.myPropertyGrid1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.myPropertyGrid1.Location = new System.Drawing.Point(12, 12);
            this.myPropertyGrid1.Name = "myPropertyGrid1";
            this.myPropertyGrid1.Size = new System.Drawing.Size(268, 249);
            this.myPropertyGrid1.TabIndex = 0;
            this.myPropertyGrid1.Text = "myPropertyGrid1";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.myPropertyGrid1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myPropertyGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyPropertyGrid myPropertyGrid1;
    }
}