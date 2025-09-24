using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LoginForm
{
    public partial class Certificate : Form
    {
        public Certificate()
        {
            InitializeComponent();
        }

        private void lbl_date_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Certificate_Load(object sender, EventArgs e)
        {
            lbl_date.Text = DateTime.Now.ToString("dd-mm-yyy");
            lbl_name.Text = User.First_Name+" "+User.Last_Name;
        }

        private void but_print_Click(object sender, EventArgs e)
        {
            Certificate cer = new Certificate();
            Bitmap bmp = new Bitmap(cer.Width, cer.Height);
            cer.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = " Save the certificate as an image";
            saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
            saveDialog.FileName = "Certificate.png"; 

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
               
                var ext = System.IO.Path.GetExtension(saveDialog.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg")
                {
                    bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    bmp.Save(saveDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }

                MessageBox.Show("Certificate saved successfully ✅", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bmp.Dispose();
        }
            

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }
    }
}
