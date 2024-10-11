using DenemeUygulama.Araclar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DenemeUygulama
{
    public partial class FrmAnasayfa : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public FrmAnasayfa()
        {
            InitializeComponent();
            random = new Random();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmCari(), sender);
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(childForm);
            this.panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label2.Text = childForm.Text;

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(Renkler.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(Renkler.ColorList.Count);
            }
            tempIndex = index;
            string color = Renkler.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panel3.BackColor = color;
                    panel2.BackColor = Renkler.ChangeColorBrightness(color, -0.3);
                    Renkler.PrimaryColor = color;
                    Renkler.SecondaryColor = Renkler.ChangeColorBrightness(color, -0.3);
                    button5.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        private void Reset()
        {
            DisableButton();
            label2.Text = "ANA SAYFA";
            panel3.BackColor = Color.FromArgb(0, 150, 136);
            panel2.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            button5.Visible = false;
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmStok(), sender);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();   
            
        }

        private void btnDepo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FrmDepo(), sender);
        }
    }
}
