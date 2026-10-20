namespace Cafeteria
{
    partial class FrmCardapio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            SuspendLayout();

            // FrmCardapio
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(245, 232, 212);
            ClientSize = new System.Drawing.Size(1000, 650);
            MinimumSize = new System.Drawing.Size(850, 550);
            Name = "FrmCardapio";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cardápio - Cafeteria Sr. Agnello";

            ResumeLayout(false);
        }

        #endregion
    }
}