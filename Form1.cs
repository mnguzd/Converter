using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Valutii
{
    public partial class Form1 : Form
    {
        ToolTip t = new ToolTip();
        bool DrawingDone = false;
        string site;
        double mdlDouble, usdDouble, eurDouble, gbpDouble, ronDouble, uahDouble;
        private string USD(string website)
        {            
            Match match = Regex.Match(website, "<Name>Доллар США</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return match.Groups[1].Value;
        }
        private string EUR(string website)
        {          
            Match match = Regex.Match(website, "<Name>Евро</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return match.Groups[1].Value;
        }
        private string UAH(string website)
        {
            Match match = Regex.Match(website, "<Name>Украинских гривен</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return (Convert.ToDouble(match.Groups[1].Value) / 10).ToString();
        }
        private string MDL(string website)
        {
            Match match = Regex.Match(website, "<Name>Молдавских леев</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return (Convert.ToDouble(match.Groups[1].Value) / 10).ToString();
        }
        private string RON(string website)
        {
            Match match = Regex.Match(website, "<Name>Румынский лей</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return match.Groups[1].Value;
        }
        private string GBP(string website)
        {
            Match match = Regex.Match(website, "<Name>Фунт стерлингов Соединенного королевства</Name><Value>(.*?)</Value>", RegexOptions.Singleline);
            return match.Groups[1].Value;
        }
        private void Draw(double MDL, double USD, double EUR, double GBP, double RON, double UAH,params Color[] colors)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(colors[0],10);
            int x1 = 95; int y1 = 292; int x2 = 95;
            g.DrawLine(pen, x1, y1, x2, 292 - (37 * Convert.ToInt32(Math.Round(MDL, MidpointRounding.AwayFromZero)) / 15));
            pen = new Pen(colors[1], 10);
            g.DrawLine(pen, 133, y1, 133, 292 - (37 * Convert.ToInt32(Math.Round(USD, MidpointRounding.AwayFromZero)) / 15));
            pen = new Pen(colors[2], 10);
            g.DrawLine(pen, 171, y1, 171, 292 - (37 * Convert.ToInt32(Math.Round(EUR, MidpointRounding.AwayFromZero)) / 15));
            pen = new Pen(colors[3], 10);
            g.DrawLine(pen, 209, y1, 209, 292 - (37 * Convert.ToInt32(Math.Round(GBP, MidpointRounding.AwayFromZero)) / 15));
            pen = new Pen(colors[4], 10);
            g.DrawLine(pen, 247, y1, 247, 292 - (37 * Convert.ToInt32(Math.Round(RON, MidpointRounding.AwayFromZero)) / 15));
            pen = new Pen(colors[5], 10);
            g.DrawLine(pen, 285, y1, 285, 292 - (37 * Convert.ToInt32(Math.Round(UAH, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
        }
        private async void DrawFirst(double MDL, double USD, double EUR, double GBP, double RON, double UAH, params Color[] colors)
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(colors[0], 10);
            int x1 = 95; int y1 = 292; int x2 = 95;
            for (double i = 0; i <= MDL; i++)
            {
                g.DrawLine(pen, x1, y1, x2, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, x1, y1, x2, 292 - (37 * Convert.ToInt32(Math.Round(MDL, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            pen = new Pen(colors[1], 10);
            for (double i=0; i<=USD; i++)
            {
                g.DrawLine(pen, 133, y1, 133, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, 133, y1, 133, 292 - (37 * Convert.ToInt32(Math.Round(USD, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            pen = new Pen(colors[2], 10);
            for (double i=0;i <= EUR; i++)
            {
                g.DrawLine(pen, 171, y1, 171, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, 171, y1, 171, 292 - (37 * Convert.ToInt32(Math.Round(EUR, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            pen = new Pen(colors[3], 10);
            for (double i = 0; i <= GBP; i++)
            {
                g.DrawLine(pen, 209, y1, 209, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, 209, y1, 209, 292 - (37 * Convert.ToInt32(Math.Round(GBP, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            pen = new Pen(colors[4], 10);
            for (double i = 0; i <= RON; i++)
            {
                g.DrawLine(pen, 247, y1, 247, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, 247, y1, 247,292 - (37 * Convert.ToInt32(Math.Round(RON, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            pen = new Pen(colors[5], 10);
            for (double i = 0; i <= UAH; i++)
            {
                g.DrawLine(pen, 285, y1, 285, 292 - (37 * Convert.ToInt32(Math.Round(i, MidpointRounding.AwayFromZero)) / 15));
                pictureBox1.Image = bitmap;
                await Task.Delay(1);
            }
            g.DrawLine(pen, 285, y1, 285, 292 - (37 * Convert.ToInt32(Math.Round(UAH, MidpointRounding.AwayFromZero)) / 15));
            pictureBox1.Image = bitmap;
            DrawingDone = true;

        }
        private void SizeMinus(PictureBox pictureBox)
        {
            pictureBox.Width -= 2;
            pictureBox.Height -= 2;
        }
        private void SizePlus(PictureBox pictureBox)
        {
            pictureBox.Width += 2;
            pictureBox.Height += 2;
        }       
        public Form1()
        {
            string website;
            using (System.Net.WebClient wc = new System.Net.WebClient())
                website = wc.DownloadString($"http://www.cbr.ru/scripts/XML_daily.asp");
            site = website;
            mdlDouble = Convert.ToDouble(MDL(site));
            usdDouble = Convert.ToDouble(USD(site));
            eurDouble = Convert.ToDouble(EUR(site));
            gbpDouble = Convert.ToDouble(GBP(site));
            ronDouble = Convert.ToDouble(RON(site));
            uahDouble = Convert.ToDouble(UAH(site));
            InitializeComponent();
            label2.Text = "MDL= " + MDL(website) + " ₽";
            label3.Text = "USD= " + USD(website) + " ₽";
            label4.Text = "EUR= " + EUR(website) + " ₽";
            label5.Text = "GBP= " + GBP(website) + " ₽";
            label6.Text = "RON= " + RON(website) + " ₽";
            label7.Text = "UAH= " + UAH(website) + " ₽";
            label8.Text = "";
            label9.Text = "Единица валюты к рублю:";
            label9.ForeColor = Color.FromArgb(55, 71, 104);
            label10.Text = "";
            AsyncLabel();
            DrawFirst( mdlDouble,
                       usdDouble,
                       eurDouble,
                       gbpDouble,
                       ronDouble,
                       uahDouble,
                       Color.FromArgb(204, 0, 255),
                       Color.FromArgb(51, 0, 204),
                       Color.FromArgb(0, 153, 255),
                       Color.FromArgb(102, 204, 102),
                       Color.FromArgb(204, 255, 51),
                       Color.FromArgb(255, 204, 51));
        }
        public async void AsyncLabel()
        {
            string wow = "Курс валют по рублю, "+ DateTime.Today.ToLongDateString()+" (Центральный банк России)";
            for (int i = 0; i < wow.Length; i++)
            {
                label8.Text += wow[i].ToString();
                await Task.Delay(20);
            }
        }
        private void label2_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label2.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label2_MouseEnter_1(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label2.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.Red,
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label3_MouseEnter(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label3.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.Red, Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label3_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label3.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label4.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.Red, 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label4_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label4.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label5_MouseEnter(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label5.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.Red, 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label5.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label6_MouseEnter(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label6.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.Red, 
                     Color.FromArgb(255, 204, 51)); 
            }
        }
        private void label6_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label6.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        private void label7_MouseEnter(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label7.ForeColor = Color.Red;
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204),
                     Color.FromArgb(0, 153, 255),
                     Color.FromArgb(102, 204, 102),
                     Color.FromArgb(204, 255, 51),
                     Color.Red);
            }
        }
        private void label7_MouseLeave(object sender, EventArgs e)
        {
            if (DrawingDone)
            {
                label7.ForeColor = Color.FromArgb(64, 64, 64);
                Draw(mdlDouble,
                     usdDouble,
                     eurDouble,
                     gbpDouble,
                     ronDouble,
                     uahDouble,
                     Color.FromArgb(204, 0, 255),
                     Color.FromArgb(51, 0, 204), 
                     Color.FromArgb(0, 153, 255), 
                     Color.FromArgb(102, 204, 102), 
                     Color.FromArgb(204, 255, 51), 
                     Color.FromArgb(255, 204, 51));
            }
        }
        public void ToolTipShow(PictureBox pictureBox) {
            t.InitialDelay = 200;
            t.SetToolTip(pictureBox, "Скопировать");
        }
        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            ToolTipShow(pictureBox2);
            Cursor = Cursors.Hand;
            SizePlus(pictureBox2);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox2);
            Cursor = Cursors.Default;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text.Substring(5, 7));
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label3.Text.Substring(5, 7));
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox3);
            SizePlus(pictureBox3);
        }
        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox3);
            Cursor = Cursors.Default;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label4.Text.Substring(5, 7));
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox4);
            SizePlus(pictureBox4);
        }
        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox4);
            Cursor = Cursors.Default;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label5.Text.Substring(5, 7));
        }
        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox5);
            SizePlus(pictureBox5);
        }
        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox5);
            Cursor = Cursors.Default;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label6.Text.Substring(5, 7));
        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox6);
            SizePlus(pictureBox6);
        }
        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox6);
            Cursor = Cursors.Default;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label7.Text.Substring(5, 7));
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * mdlDouble), 2).ToString();
                        break;
                    case 1:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * usdDouble), 2).ToString();
                        break;
                    case 2:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * eurDouble), 2).ToString();
                        break;
                    case 3:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * gbpDouble), 2).ToString();
                        break;
                    case 4:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * ronDouble), 2).ToString();
                        break;
                    case 5:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * uahDouble), 2).ToString();
                        break;
                }
            }
            else
            {
                label10.Text = "";
            }
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label10.Text);
        }
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox8);
            SizePlus(pictureBox8);
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox8);
            Cursor = Cursors.Default;
        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            ToolTipShow(pictureBox7);
            SizePlus(pictureBox7);
        }
        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            SizeMinus(pictureBox7);
            Cursor = Cursors.Default;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * mdlDouble),2).ToString();
                       break;
                    case 1:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * usdDouble),2).ToString();
                        break;
                    case 2:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * eurDouble),2).ToString();
                        break;
                    case 3:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * gbpDouble),2).ToString();
                        break;
                    case 4:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * ronDouble),2).ToString();
                        break;
                    case 5:
                        label10.Text = Math.Round((Convert.ToDouble(textBox1.Text) * uahDouble),2).ToString();
                        break;
                }
            }
            else
            {
                label10.Text = "";
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!double.TryParse(textBox1.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
