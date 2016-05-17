using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CharNotationDesigner
{
    class CharEditor
    {
        List<Stroke> strokes;
        int selectedStrokeIndex;
        Bitmap img;
        Bitmap imgBackground;
        static List<Stroke> basicStrokes = new List<Stroke>();
        bool modified;

        public CharEditor()
        {
            strokes = new List<Stroke>();
            img = new Bitmap(200, 200);
            imgBackground = new Bitmap(200, 200);
            SetReference("");   //相当于刷新一次全白图像
            selectedStrokeIndex = 0;
            modified = false;
        }
        public CharEditor(CharEditor t)
        {
            strokes = new List<Stroke>(t.strokes);
            img = new Bitmap(t.img);
            imgBackground = new Bitmap(t.imgBackground);
            selectedStrokeIndex = t.selectedStrokeIndex;
            modified = t.modified;
        }
        ~CharEditor()
        {
            strokes.Clear();
            img.Dispose();
            imgBackground.Dispose();
            //if (g != null)
            //    g.Dispose();
        }

        public Bitmap Img
        {
            get { return img; }
        }
        public bool IsModified
        {
            get { return modified; }
        }
        public List<Stroke> Strokes
        {
            get { return strokes; }
            set 
            { 
                strokes.Clear();
                strokes = new List<Stroke>(value);
                selectedStrokeIndex = 0;    //更新笔画后index归零
            }
        }
        public static List<Stroke> BasicStrokes
        {
            get { return basicStrokes; }
            set 
            {
                basicStrokes.Clear();
                basicStrokes = new List<Stroke>(value); 
            }
        }

        public void DrawBones(Graphics g)
        {
            //img.Dispose();
            //img = new Bitmap(imgBackground);    //复制一份底板
            //Graphics g = Graphics.FromImage(img);   //从img创建
            g.DrawImage(imgBackground, new Point(0, 0));

            if (strokes.Count == 0) //没有笔画
            {
                //g.Dispose();
                return;
            }

            Pen pen = new Pen(Brushes.LightSkyBlue);
            SolidBrush brush = new SolidBrush(Color.LightSkyBlue);
            pen.Width = 1.0f;
            Rectangle rectLarge = new Rectangle(new Point(0,0), new Size(5, 5));
            Rectangle rectsmall = new Rectangle(new Point(0,0), new Size(3, 3));
            PointF[] points;
            foreach (var s in strokes)  //画笔画
            {
                points = new PointF[s.Points.Count];
                s.Points.CopyTo(points);
                g.DrawLines(pen, points);
                foreach (var p in s.Points) //画节点
                {
                    g.FillRectangle(brush, p.X - 1, p.Y - 1, 3, 3);
                }
            }
            pen.Color = Color.Orange;
            brush.Color = Color.Orange;
            points = new PointF[strokes[selectedStrokeIndex].Points.Count];
            strokes[selectedStrokeIndex].Points.CopyTo(points);
            g.DrawLines(pen, points);
            foreach (var p in strokes[selectedStrokeIndex].Points) //画节点
            {
                g.FillRectangle(brush, p.X - 1, p.Y - 1, 3, 3);
            }
            PointF selectedPoint = strokes[selectedStrokeIndex].Points[strokes[selectedStrokeIndex].SelectedPointIndex];
            g.FillRectangle(brush, selectedPoint.X - 2, selectedPoint.Y - 2, 5, 5);
            pen.Dispose();
            brush.Dispose();
            //g.Dispose();
        }

        public void AddStroke(strokeType t)
        {
            Stroke s = basicStrokes.Find(p => p.Type == t);
            if (s != null)
            {
                strokes.Add(new Stroke(s));
                selectedStrokeIndex = strokes.Count - 1;    //选中最后加入的笔画
                modified = true;
                //DrawBones();
            }
        }

        public void RemoveStroke()
        {
            if (strokes.Count > 0)
                strokes.RemoveAt(selectedStrokeIndex);
            if (strokes.Count == 0)
                selectedStrokeIndex = -1;
            else if (selectedStrokeIndex > 0)
                selectedStrokeIndex--;
            modified = true;
            //DrawBones();
        }

        public void ClearStrokes()
        {
            strokes.Clear();
            selectedStrokeIndex = -1;
            modified = true;
            //DrawBones();
        }
        /// <summary>
        /// 指定用作参考的文字
        /// 使用华文中宋字体
        /// </summary>
        /// <param name="text"></param>
        public void SetReference(string text)
        {
            Font font = new Font("华文中宋", 160);
            Graphics g = Graphics.FromImage(imgBackground);   //从img创建
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.DrawString(text, font, Brushes.LightGray, -45, -27);
            g.Dispose();
        }

        public void PreviousStroke()
        {
            if (strokes.Count > 0)
                selectedStrokeIndex = (selectedStrokeIndex - 1 + strokes.Count) % strokes.Count;
            //DrawBones();
        }
        public void NextStroke()
        {
            if (strokes.Count > 0)
                selectedStrokeIndex = (selectedStrokeIndex + 1) % strokes.Count;
            //DrawBones();
        }

        public void SelectNearestPoint(Point p)
        {
            double minDist = Double.MaxValue;
            int index = strokes[selectedStrokeIndex].SelectedPointIndex;
            for (int i = 0; i < strokes[selectedStrokeIndex].Points.Count; i++)
            {
                PointF item = strokes[selectedStrokeIndex].Points[i];
                double distance = Math.Sqrt(Math.Pow(item.X - p.X, 2) + Math.Pow(item.Y - p.Y, 2));
                if (distance < minDist)
                {
                    minDist = distance;
                    index = i;
                }
            }
            strokes[selectedStrokeIndex].SelectedPointIndex = index;
            //DrawBones();
        }

        public void SetCurrentPointPos(Point p)
        {
            strokes[selectedStrokeIndex].Points[strokes[selectedStrokeIndex].SelectedPointIndex] = (PointF)p;
            modified = true;
            //DrawBones();
        }

        public void ResetModifyStatus()
        {
            modified = false;
        }
    }
}
