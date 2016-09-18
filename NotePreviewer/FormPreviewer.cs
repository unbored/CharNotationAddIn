using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CharNotation
{
    public partial class FormPreviewer : Form
    {
        List<Char> lstChars = new List<Char>(); //减字列表
        public FormPreviewer()
        {
            InitializeComponent();

            DataTranslator translator = new DataTranslator();
            foreach (CharNotationDataSet.CharRow row in translator.CharTable)
            {
                lstChars.Add(translator.GetChar(row));
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
        }
    }
}
