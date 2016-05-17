using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using CharNotation;

namespace CharNotationAddIn
{
    public partial class CharPreview : UserControl
    {
        public CharPreview()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            float charsize = (float)numericUpDown1.Value;   //磅为单位（1/72英寸）
            Graphics gs = imgChar.CreateGraphics();
            Metafile mf = new Metafile(Globals.ThisDocument.Path + "\\meta.emf", gs.GetHdc(), EmfType.EmfOnly);
            Graphics g = Graphics.FromImage(mf);
            Notation nota = Notation.processString(txtNotation.Text);
            nota.characterize(charsize * g.DpiY / 72);  //磅换成像素
            nota.draw(g, (float)UpDownThin.Value * 0.01f * charsize * g.DpiY / 72,
                         (float)UpDownThick.Value * 0.01f * charsize * g.DpiY / 72);
            g.Dispose();
            GraphicsUnit charunit = GraphicsUnit.Point;
            RectangleF charrect = mf.GetBounds(ref charunit);   //获得图像边界大小
            mf.Dispose();
            gs.Dispose();
            Word.InlineShape shape = Globals.ThisDocument.InlineShapes.AddPicture(Globals.ThisDocument.Path + "\\meta.emf");
            if (shape.Height > charsize)    //限定高度，超过则等比缩放
            {
                shape.Width = shape.Width / shape.Height * charsize;
                shape.Height = charsize;
            }
            Globals.ThisDocument.Application.Selection.Move(Word.WdUnits.wdCharacter, 1);   //光标往后移一格
            if(File.Exists(Globals.ThisDocument.Path + "\\meta.emf"))
            {
                File.Delete(Globals.ThisDocument.Path + "\\meta.emf");
            }
        }

        private void refreshChar()
        {
            Graphics gs = imgChar.CreateGraphics();
            gs.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Notation nota = Notation.processString(txtNotation.Text);
            nota.characterize(imgChar.Size.Height);
            nota.draw(gs, (float)UpDownThin.Value * 0.01f * imgChar.Size.Height,
                         (float)UpDownThick.Value * 0.01f * imgChar.Size.Height);
            gs.Dispose();
        }

        private void txtNotation_TextChanged(object sender, EventArgs e)
        {
            refreshChar();
        }

        private void UpDownThick_ValueChanged(object sender, EventArgs e)
        {
            refreshChar();
        }

        private void UpDownThin_ValueChanged(object sender, EventArgs e)
        {
            refreshChar();
        }

        private void imgChar_Paint(object sender, PaintEventArgs e)
        {
            refreshChar();
        }
    }
}
