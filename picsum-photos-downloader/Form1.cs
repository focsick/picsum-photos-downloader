using System.Drawing.Imaging;
using System.Net;
using System.Windows.Forms;

namespace picsum_photos_downloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // MessageBox.Show("кнопка нажата");
                // pictureBox1.ImageLocation = "https://picsum.photos/200/300";
                int width = int.Parse(textBox1.Text);
                int height = int.Parse(textBox2.Text);



                var request = WebRequest.Create($"https://picsum.photos/{width}/{height}");
                request.UseDefaultCredentials = true;
                request.Headers.Add("User-Agent: Other");

                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
                }
            }
            catch { MessageBox.Show("Ведите разрешение картинки))"); } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var folder = "images";
            // Directory.CreateDirectory(folder);
            saveFileDialog1.FileName = $"{DateTime.Now.ToString("yyyy MM dd HH-mm-ss")}.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            pictureBox1.Image.Save(filename, ImageFormat.Jpeg);
            MessageBox.Show("save");


        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}