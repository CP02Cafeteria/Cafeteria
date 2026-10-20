namespace Cafeteria
{
    partial class FrmSplash
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
            lbl_Titulo = new System.Windows.Forms.Label();
            lbl_Carregando = new System.Windows.Forms.Label();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            btm_acessar = new System.Windows.Forms.Button();

            SuspendLayout();

            // lbl_Titulo
            lbl_Titulo.AutoSize = false;
            lbl_Titulo.Font = new System.Drawing.Font(
                "Georgia", 24F, System.Drawing.FontStyle.Bold);
            lbl_Titulo.ForeColor = System.Drawing.Color.SaddleBrown;
            lbl_Titulo.Location = new System.Drawing.Point(50, 65);
            lbl_Titulo.Name = "lbl_Titulo";
            lbl_Titulo.Size = new System.Drawing.Size(700, 60);
            lbl_Titulo.TabIndex = 0;
            lbl_Titulo.Text = "Cafeteria Sr. Agnello";
            lbl_Titulo.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            lbl_Titulo.Click += label1_Click;

            // lbl_Carregando
            lbl_Carregando.AutoSize = false;
            lbl_Carregando.Font = new System.Drawing.Font(
                "Arial", 12F, System.Drawing.FontStyle.Regular);
            lbl_Carregando.ForeColor = System.Drawing.Color.SaddleBrown;
            lbl_Carregando.Location = new System.Drawing.Point(150, 155);
            lbl_Carregando.Name = "lbl_Carregando";
            lbl_Carregando.Size = new System.Drawing.Size(500, 35);
            lbl_Carregando.TabIndex = 1;
            lbl_Carregando.Text = "Preparando seu café...";
            lbl_Carregando.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // progressBar1
            progressBar1.Location = new System.Drawing.Point(200, 215);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(400, 25);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;

            // btm_acessar
            btm_acessar.BackColor = System.Drawing.Color.Chocolate;
            btm_acessar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btm_acessar.FlatAppearance.BorderSize = 0;
            btm_acessar.Font = new System.Drawing.Font(
                "Arial", 10F, System.Drawing.FontStyle.Bold);
            btm_acessar.ForeColor = System.Drawing.Color.White;
            btm_acessar.Location = new System.Drawing.Point(325, 285);
            btm_acessar.Name = "btm_acessar";
            btm_acessar.Size = new System.Drawing.Size(150, 40);
            btm_acessar.TabIndex = 3;
            btm_acessar.Text = "Acessar menu";
            btm_acessar.UseVisualStyleBackColor = false;
            btm_acessar.Click += btm_acessar_Click;

            // FrmSplash
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.BurlyWood;
            ClientSize = new System.Drawing.Size(800, 400);
            Controls.Add(btm_acessar);
            Controls.Add(progressBar1);
            Controls.Add(lbl_Carregando);
            Controls.Add(lbl_Titulo);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmSplash";
            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Cafeteria Sr. Agnello";

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbl_Titulo;
        private System.Windows.Forms.Label lbl_Carregando;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btm_acessar;
    }
}