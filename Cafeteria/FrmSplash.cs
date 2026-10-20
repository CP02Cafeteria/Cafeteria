using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cafeteria
{
    public partial class FrmSplash : Form
    {
        private System.Windows.Forms.Timer timer;

        public FrmSplash()
        {
            InitializeComponent();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Style = ProgressBarStyle.Continuous;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 25;
            timer.Tick += Timer_Tick;

            Load += FrmSplash_Load;
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                timer.Stop();
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Clique no título da cafeteria
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            // Clique na barra de progresso
        }

        private void btm_acessar_Click(object sender, EventArgs e)
        {
            timer.Stop();
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();

            base.OnFormClosed(e);
        }
    }
}