using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CharNotationDesigner
{
    class CharEditor : Char
    {
        static List<Stroke> basicStrokes = new List<Stroke>();
        int selectedStrokeIndex;   //指示当前选择的笔画下标
        int selectedRectIndex;
        //Bitmap img;
        Bitmap imgBackground;
        bool modified;  //指示减字是否有改动
        int selectedIndicesIndex;   //鼠标选择点时当前选择的编号

        public CharEditor()
        {
            imgBackground = new Bitmap(200, 200);
            SetReference("");   //相当于刷新一次全白图像
            selectedStrokeIndex = -1;
            selectedRectIndex = -1;
            modified = false;
            selectedIndicesIndex = -1;
        }
        public CharEditor(CharEditor t)
        {
            imgBackground = new Bitmap(t.imgBackground);
            selectedStrokeIndex = t.selectedStrokeIndex;
            selectedRectIndex = t.selectedRectIndex;
            modified = t.modified;
            selectedIndicesIndex = t.selectedIndicesIndex;
        }
        public CharEditor(Char t) : base(t)
        {
            imgBackground = new Bitmap(200, 200);
            SetReference("");   //相当于刷新一次全白图像
            selectedStrokeIndex = -1;
            selectedRectIndex = -1;
            modified = false;
            selectedIndicesIndex = -1;
        }
        ~CharEditor()
        {
            imgBackground.Dispose();
        }

        public bool IsModified
        {
            get { return modified; }
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
            g.DrawImage(imgBackground, new Point(0, 0));

            if (strokes.Count == 0) //没有笔画
            {
                return;
            }

            Pen pen = new Pen(Brushes.LightSkyBlue);
            pen.DashStyle = DashStyle.Solid;
            SolidBrush brush = new SolidBrush(Color.LightSkyBlue);
            pen.Width = 1.0f;
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
            if (isMain) //绘制矩形框
            {
                pen.DashStyle = DashStyle.Dash;
                pen.Color = Color.DarkOliveGreen;    //深绿色
                brush.Color = Color.DarkOliveGreen;
                float leftX = Math.Min(rect.corners[0].X, rect.corners[1].X);
                float leftY = Math.Min(rect.corners[0].Y, rect.corners[1].Y);
                float sizeX = Math.Abs(rect.corners[1].X - rect.corners[0].X);
                float sizeY = Math.Abs(rect.corners[1].Y - rect.corners[0].Y);
                g.DrawRectangle(pen, leftX, leftY, sizeX, sizeY);
                foreach (var p in rect.corners)
                {
                    g.FillRectangle(brush, p.X - 1, p.Y - 1, 3, 3);
                }
                if (selectedRectIndex >= 0)
                    g.FillRectangle(brush, rect.corners[selectedRectIndex].X - 2, rect.corners[selectedRectIndex].Y - 2, 5, 5);
                if (isComplex)
                {
                    //g.DrawLine(pen, leftX + sizeX / 2 - 5, leftY, leftX + sizeX / 2 - 5, leftY + sizeY);
                    //g.DrawLine(pen, leftX + sizeX / 2 + 5, leftY, leftX + sizeX / 2 + 5, leftY + sizeY);
                    g.DrawLine(pen, leftX + sizeX / 2, leftY, leftX + sizeX / 2, leftY + sizeY);
                }
            }

            if (selectedStrokeIndex >= 0 && selectedStrokeIndex < strokes.Count)
            {
                pen.DashStyle = DashStyle.Solid;
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
            }
            pen.Dispose();
            brush.Dispose();
        }

        public void AddStroke(strokeType t)
        {
            Stroke s = basicStrokes.Find(p => p.Type == t);
            if (s != null)
            {
                strokes.Add(s.Clone() as Stroke);
                selectedStrokeIndex = strokes.Count - 1;    //选中最后加入的笔画
                modified = true;
            }
        }

        public void RemoveStroke()
        {
            if (selectedStrokeIndex != -1 && selectedStrokeIndex != strokes.Count)
            {
                if (strokes.Count > 0)
                {
                    strokes.RemoveAt(selectedStrokeIndex);
                    selectedStrokeIndex = -1;
                }
                modified = true;
            }
        }

        public void ClearStrokes()
        {
            strokes.Clear();
            selectedStrokeIndex = -1;
            modified = true;
        }
        /// <summary>
        /// 指定用作参考的文字
        /// 使用华文中宋字体
        /// </summary>
        /// <param name="text"></param>
        public void SetReference(string text)
        {
            Font font = new Font("华文中宋", 155);
            Graphics g = Graphics.FromImage(imgBackground);   //从img创建
            g.Clear(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.DrawString(text, font, Brushes.LightGray, -40, -27);
            g.Dispose();
        }

        public void PreviousStroke()
        {
            if (strokes.Count > 0)
                selectedStrokeIndex = (selectedStrokeIndex - 1 + strokes.Count) % strokes.Count;
        }
        public void NextStroke()
        {
            if (strokes.Count > 0)
                selectedStrokeIndex = (selectedStrokeIndex + 1) % strokes.Count;
        }
        /// <summary>
        /// 记录下所有在固定范围内的点的坐标，并依次选取
        /// </summary>
        /// <param name="p"></param>
        public void SelectNearestPoint(Point p)
        {
            List<Point> indices = new List<Point>();    //借用Point结构来记录下标
            PointF item;
            double distance;
            //将所有在范围内的点记录下来
            for (int i = 0; i < strokes.Count; i++)
            {
                for (int j = 0; j < strokes[i].Points.Count; j++)
                {
                    item = strokes[i].Points[j];
                    distance = Math.Sqrt(Math.Pow(item.X - p.X, 2) + Math.Pow(item.Y - p.Y, 2));
                    if (distance < 10)   //此范围内的点均取
                    {
                        indices.Add(new Point(i, j));
                    }
                }
            }
            if (isMain) //主指法，还要控制内容框
            {
                item = rect.corners[0];
                distance = Math.Sqrt(Math.Pow(item.X - p.X, 2) + Math.Pow(item.Y - p.Y, 2));
                if (distance < 10)   //此范围内的点均取
                    indices.Add(new Point(strokes.Count, 0));
                item = rect.corners[1];
                distance = Math.Sqrt(Math.Pow(item.X - p.X, 2) + Math.Pow(item.Y - p.Y, 2));
                if (distance < 10)   //此范围内的点均取
                    indices.Add(new Point(strokes.Count, 1));
            }
            //没有找到任何点
            if (indices.Count == 0)
            {
                selectedStrokeIndex = -1;
                return;
            }
            //因点集合改变而超出范围则置0
            if (++selectedIndicesIndex >= indices.Count)
                selectedIndicesIndex = 0;

            selectedStrokeIndex = indices[selectedIndicesIndex].X;

            if (selectedStrokeIndex == strokes.Count)   //选中了内容框
            {
                selectedRectIndex = indices[selectedIndicesIndex].Y;
            }
            else
            {
                strokes[selectedStrokeIndex].SelectedPointIndex = indices[selectedIndicesIndex].Y;
                selectedRectIndex = -1;
            }
        }
        /// <summary>
        /// 设置当前选中的点的坐标
        /// </summary>
        /// <param name="p"></param>
        public void SetCurrentPointPos(Point p)
        {
            if (selectedStrokeIndex >= 0)
            {
                if (selectedStrokeIndex < strokes.Count)
                    strokes[selectedStrokeIndex].Points[strokes[selectedStrokeIndex].SelectedPointIndex] = new PointF(p.X, p.Y);
                else if (selectedStrokeIndex == strokes.Count)
                    rect.corners[selectedRectIndex] = new PointF(p.X, p.Y);
                modified = true;
            }
        }
        /// <summary>
        /// 将修改状态重置为未修改
        /// </summary>
        public void ResetModifyStatus()
        {
            modified = false;
        }

    }
}
