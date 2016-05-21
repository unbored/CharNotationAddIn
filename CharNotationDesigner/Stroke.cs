using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CharNotationDesigner
{
    /// <summary>
    /// 笔画名称枚举。
    /// <para>笔画列表：横，无头横，竖，无头竖，撇，捺，无头捺，点，提，点提（氵专用），横折，横折钩，横折弯钩，横折撇，竖勾，竖弯钩</para>
    /// </summary>
    enum strokeType { 横, 无头横, 竖, 无头竖, 撇, 无头撇, 捺, 无头捺, 点, 提, 点提, 横折, 横折钩, 横折弯钩, 横折撇, 竖勾, 竖弯钩 };

    /// <summary>
    /// 笔画类。
    /// </summary>
    class Stroke : ICloneable
    {
        static float widththin, widththick;
        strokeType type;
        //string name;
        List<PointF> points;
        int selectedPointIndex;
        /// <summary>
        /// 默认构造函数，笔画为横，无点。
        /// </summary>
        public Stroke()
        {
            type = strokeType.横;
            //name = Enum.GetName(typeof(strokeType), type);
            points = new List<PointF>();
            selectedPointIndex = 0;
        }
        /// <summary>
        /// 复制构造函数，执行浅复制。
        /// <para>如需深复制请使用Clone()函数。</para>
        /// </summary>
        /// <param name="s"></param>
        public Stroke(Stroke s)
        {
            type = s.type;
            //name = Enum.GetName(typeof(strokeType), type);
            points = s.Points;
            selectedPointIndex = s.selectedPointIndex;
        }
        /// <summary>
        /// 根据笔画类型构造。
        /// </summary>
        /// <param name="t"></param>
        public Stroke(strokeType t)
        {
            type = t;
            //name = Enum.GetName(typeof(strokeType), type);
            points = new List<PointF>();
            selectedPointIndex = 0;
        }
        ~Stroke()
        {
            points.Clear();
        }
        /// <summary>
        /// 获取或设置笔画类型。
        /// </summary>
        public strokeType Type
        {
            get { return type; }
            set { type = value; Enum.GetName(typeof(strokeType), type); }
        }
        /// <summary>
        /// 获取笔画名称。
        /// <para>笔画名称通过类型自动生成。</para>
        /// </summary>
        //public string Name
        //{
        //    get { return name; }
        //}

        /// <summary>
        /// 获取节点列表。
        /// </summary>
        public List<PointF> Points
        {
            get { return points; }
        }
        /// <summary>
        /// 获取或设置当前选择点的索引。
        /// </summary>
        public int SelectedPointIndex
        {
            get { return selectedPointIndex; }
            set { selectedPointIndex = value; }
        }
        /// <summary>
        /// 对节点列表进行深复制。
        /// </summary>
        /// <returns></returns>
        List<PointF> ClonePoints()
        {
            List<PointF> result = new List<PointF>();
            points.ForEach(i => result.Add(new PointF(i.X, i.Y)));
            return result;
        }
        /// <summary>
        /// 执行深复制。
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Stroke result = new Stroke();
            result.type = type;
            //result.name = name;
            result.points = ClonePoints();
            result.selectedPointIndex = 0;
            return result;
        }
        #region ============================绘制函数==================================
        public static void setWidth(float thin, float thick)
        {
            widththin = thin;
            widththick = thick;
        }

        public void Draw(Graphics g)
        {
            switch (type)
            {
                case strokeType.横:
                    DrawHeng(g);
                    break;
                case strokeType.竖:
                    DrawShu(g);
                    break;
                case strokeType.撇:
                    DrawPie(g);
                    break;
                case strokeType.捺:
                    DrawNa(g);
                    break;
                case strokeType.点:
                    DrawDian(g);
                    break;
                //case strokeType.提:
                //    DrawTi(g);
                //    break;
                //case strokeType.点提:
                //    DrawDianti(g);
                //    break;
                //case strokeType.横折钩:
                //    /*widththick *= 1.2f;*/
                //    DrawHengzhegou(g);
                //    break;
                //case strokeType.横折:
                //    DrawHengzhe(g);
                //    break;
                //case strokeType.横折撇:
                //    DrawHengzhepie(g);
                //    break;
                //case strokeType.竖弯钩:
                //    widththick *= 0.8f;
                //    DrawShuwangou(g);
                //    break;
                //case strokeType.横折弯钩:
                //    widththick *= 0.8f;
                //    DrawHengzhewangou(g);
                //    break;
                //case strokeType.无头横:
                //    DrawHeng_n(g);
                //    break;
                //case strokeType.无头竖:
                //    DrawShu_n(g);
                //    break;
                case strokeType.无头撇:
                    DrawPie_n(g);
                    break;
                case strokeType.无头捺:
                    DrawNa_n(g);
                    break;

                default:
                    //DrawOthert(g);
                    break;
            }
        }
        //横
        private void DrawHeng(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            float distance = (float)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2)); //计算长度
            PointF[] pointLine = new PointF[4];
            //上方平横
            pointLine[0] = new PointF(points[0].X - widththin, points[0].Y - widththin / 2);
            pointLine[1] = new PointF(points[0].X + distance - widththick * 0.6f, pointLine[0].Y);

            //右方凸起
            pointLine[2] = new PointF(pointLine[1].X + widththick * 0.6f, pointLine[1].Y - widththick * 0.6f);
            pointLine[3] = new PointF(pointLine[2].X + widththick * 0.6f + widththin / 2, pointLine[2].Y + widththick * 0.6f + widththin / 2);
            path.AddLines(pointLine);

            //左下凸起
            PointF[] pointDraw = new PointF[3];
            pointDraw[0] = new PointF(pointLine[3].X - widththin / 2, pointLine[3].Y + widththin / 2);
            pointDraw[1] = new PointF(pointDraw[0].X - distance * 0.85f, pointDraw[0].Y); //凸起顶部
            pointDraw[2] = new PointF(points[0].X, pointDraw[0].Y + widththin * 0.4f);
            path.AddCurve(pointDraw, 0.2f);
            //对笔画进行旋转
            g.TranslateTransform(-points[0].X, -points[0].Y);
            if (points[1].X - points[0].X != 0)
            {
                float k = (float)(Math.Atan((points[1].Y - points[0].Y) / (points[1].X - points[0].X)) / Math.PI * 180);   //计算转角
                g.RotateTransform(k, MatrixOrder.Append);
            }
            g.TranslateTransform(points[0].X, points[0].Y, MatrixOrder.Append);

            g.FillPath(brush, path);
            g.ResetTransform(); //恢复原来位置
            path.Dispose();
            brush.Dispose();
        }
        //竖
        private void DrawShu(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            float distance = (float)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2)); //计算长度

            //竖头
            PointF[] pointLine = new PointF[4];
            pointLine[0] = new PointF(points[0].X - widththick / 2, points[0].Y - widththick * 0.6f - widththin / 2);
            pointLine[1] = new PointF(pointLine[0].X + widththick + widththin, pointLine[0].Y + widththick * 0.6f);
            pointLine[2] = new PointF(pointLine[1].X - widththin, pointLine[1].Y + widththin);
            pointLine[3] = new PointF(pointLine[2].X, points[0].Y + distance);
            path.AddLines(pointLine);

            PointF[] pointDraw = new PointF[4]; //竖末尾的弯头
            pointDraw[0] = pointLine[3];
            pointDraw[1] = new PointF(points[0].X, pointLine[3].Y + widththick * 0.5f);
            pointDraw[2] = new PointF(pointDraw[1].X - widththick / 2 + widththin / 2, pointDraw[1].Y + widththick * 0.1f);
            pointDraw[3] = new PointF(pointDraw[2].X - widththin / 2, pointDraw[2].Y - widththin / 2);
            path.AddCurve(pointDraw, 1.0f);

            //对笔画进行旋转
            g.TranslateTransform(-points[0].X, -points[0].Y);
            if (points[1].Y - points[0].Y != 0)
            {
                float k = (float)(Math.Atan((points[0].X - points[1].X) / (points[1].Y - points[0].Y)) / Math.PI * 180);   //计算转角
                g.RotateTransform(k, MatrixOrder.Append);
            }
            g.TranslateTransform(points[0].X, points[0].Y, MatrixOrder.Append);

            g.FillPath(brush, path);
            g.ResetTransform(); //恢复原来位置
            path.Dispose();
            brush.Dispose();
        }
        //撇
        private void DrawPie(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            double k = Math.Atan((points[0].X - points[1].X) / (points[1].Y - points[0].Y));   //计算撇的上半斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            //撇头
            PointF[] pointLine = new PointF[3];
            pointLine[0] = new PointF(points[0].X - widththick / 2, points[0].Y - widththick * 0.6f - widththin / 2);
            pointLine[1] = new PointF(pointLine[0].X + widththick + widththin, pointLine[0].Y + widththick * 0.6f);
            pointLine[2] = new PointF(pointLine[1].X - widththin, pointLine[1].Y + widththin);
            path.AddLines(pointLine);

            double k1 = Math.Atan((points[1].X - points[2].X) / (points[2].Y - points[1].Y));   //计算撇的下半斜角
            float sink1 = (float)Math.Sin(k);
            float cosk1 = (float)Math.Cos(k);

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = pointLine[2];
            pointCurve1[1] = new PointF(points[1].X + widththick / 2 * 0.7f * cosk, points[1].Y + widththick / 2 * 0.7f * sink);
            pointCurve1[2] = new PointF(points[2].X + widththin / 2 * cosk1, points[2].Y + widththin / 2 * sink1);  //撇的头是平的
            path.AddCurve(pointCurve1, 0.6f);

            PointF[] pointCurve2 = new PointF[3];   //左边曲线，倒序
            pointCurve2[0] = new PointF(points[2].X - widththin / 2 * cosk1, points[2].Y - widththin / 2 * sink1);
            pointCurve2[1] = new PointF(points[1].X - widththick / 2 * 0.7f * cosk, points[1].Y - widththick / 2 * 0.7f * sink);
            pointCurve2[2] = pointLine[0];
            path.AddCurve(pointCurve2, 0.6f);

            //按轮廓顺序加入
            //path.AddCurve(pointDraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //无头撇
        private void DrawPie_n(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            double k = Math.Atan((points[0].X - points[1].X) / (points[1].Y - points[0].Y));   //计算撇的上半斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            //撇头
            PointF[] pointLine = new PointF[3];
            pointLine[0] = new PointF(points[0].X - widththick / 2 / cosk, points[0].Y);
            pointLine[1] = points[0];
            pointLine[2] = new PointF(pointLine[1].X, pointLine[1].Y + widththick / 2 / sink);
            path.AddLines(pointLine);

            double k1 = Math.Atan((points[1].X - points[2].X) / (points[2].Y - points[1].Y));   //计算撇的下半斜角
            float sink1 = (float)Math.Sin(k);
            float cosk1 = (float)Math.Cos(k);

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = pointLine[2];
            pointCurve1[1] = new PointF(points[1].X + widththick / 2 * 0.7f * cosk, points[1].Y + widththick / 2 * 0.7f * sink);
            pointCurve1[2] = new PointF(points[2].X + widththin / 2 * cosk1, points[2].Y + widththin / 2 * sink1);  //撇的头是平的
            path.AddCurve(pointCurve1, 0.6f);

            PointF[] pointCurve2 = new PointF[3];   //左边曲线，倒序
            pointCurve2[0] = new PointF(points[2].X - widththin / 2 * cosk1, points[2].Y - widththin / 2 * sink1);
            pointCurve2[1] = new PointF(points[1].X - widththick / 2 * 0.7f * cosk, points[1].Y - widththick / 2 * 0.7f * sink);
            pointCurve2[2] = pointLine[0];
            path.AddCurve(pointCurve2, 0.6f);

            //按轮廓顺序加入
            //path.AddCurve(pointDraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //捺（不带横）
        private void DrawNa_n(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            double k = Math.Atan((points[0].X - points[2].X) / (points[2].Y - points[0].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = new PointF(points[0].X + widththin / 2, points[0].Y);
            pointCurve1[1] = new PointF(points[1].X + widththick / 2 * 0.8f * cosk, points[1].Y + widththick / 2 * 0.8f * sink);
            pointCurve1[2] = new PointF(points[2].X + widththick * 1.2f, points[2].Y - widththick * 0.4f);
            path.AddCurve(pointCurve1, 0.6f);

            PointF[] pointCurve2 = new PointF[3];   //下方曲线
            pointCurve2[0] = new PointF(pointCurve1[2].X, pointCurve1[2].Y + widththin / 2);
            pointCurve2[1] = points[2];
            pointCurve2[2] = new PointF(points[2].X - widththick * 0.5f, points[2].Y + widththick * 0.5f);
            path.AddCurve(pointCurve2, 0.7f);

            PointF[] pointCurve3 = new PointF[3];   //左边曲线
            pointCurve3[0] = pointCurve2[2];
            pointCurve3[1] = new PointF(points[1].X - widththick / 2 * 0.8f * cosk, points[1].Y - widththick / 2 * 0.8f * sink);
            pointCurve3[2] = new PointF(points[0].X - widththin * 0.5f, points[0].Y);
            path.AddCurve(pointCurve3);

            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //捺（带横）
        private void DrawNa(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();

            PointF[] pointLine = new PointF[5];
            //上方平横及转角
            pointLine[0] = new PointF(points[0].X - widththin, points[0].Y - widththin / 2);
            pointLine[1] = new PointF(points[1].X - widththick * 0.4f - widththin / 2, points[1].Y - widththin / 2);

            pointLine[2] = new PointF(pointLine[1].X + widththick * 0.4f, pointLine[1].Y - widththick * 0.4f);
            pointLine[3] = new PointF(pointLine[2].X + widththick * 0.5f, pointLine[2].Y + widththick * 0.4f);
            pointLine[4] = new PointF(pointLine[3].X - widththick * 0.5f + widththin, pointLine[3].Y + widththick * 0.6f - widththin);
            path.AddLines(pointLine);

            double k = Math.Atan((points[1].X - points[3].X) / (points[3].Y - points[1].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = pointLine[4];
            pointCurve1[1] = new PointF(points[2].X + widththick / 2 * 0.8f * cosk, points[2].Y + widththick / 2 * 0.8f * sink);
            pointCurve1[2] = new PointF(points[3].X + widththick * 1.2f, points[3].Y - widththick * 0.4f);
            path.AddCurve(pointCurve1, 0.6f);

            PointF[] pointCurve2 = new PointF[3];   //下方曲线
            pointCurve2[0] = new PointF(pointCurve1[2].X, pointCurve1[2].Y + widththin / 2);
            pointCurve2[1] = points[3];
            pointCurve2[2] = new PointF(points[3].X - widththick * 0.5f, points[3].Y + widththick * 0.5f);
            path.AddCurve(pointCurve2, 0.7f);

            PointF[] pointCurve3 = new PointF[3];   //左边曲线
            pointCurve3[0] = pointCurve2[2];
            pointCurve3[1] = new PointF(points[2].X - widththick / 2 * 0.8f * cosk, points[2].Y - widththick / 2 * 0.8f * sink);
            pointCurve3[2] = new PointF(points[1].X - widththin * 0.5f, points[1].Y + widththin * 0.5f);
            path.AddCurve(pointCurve3);
            //左下凸起
            PointF[] pointDraw = new PointF[3];
            pointDraw[0] = pointCurve3[2];
            pointDraw[1] = new PointF(pointDraw[0].X - (points[1].X - points[0].X) * 0.85f, points[0].Y + widththin / 2); //凸起顶部
            pointDraw[2] = new PointF(points[0].X, pointDraw[1].Y + widththin * 0.4f);
            path.AddCurve(pointDraw, 0.2f);

            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //点
        private void DrawDian(Graphics g)
        {
            double k = Math.Atan((points[3].X - points[0].X) / (points[3].Y - points[0].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);
            PointF[] pointCurve = new PointF[6];
            pointCurve[0] = points[0];
            pointCurve[1] = points[1];
            pointCurve[2] = points[2];
            pointCurve[3] = points[3];
            //pointCurve[4] = new PointF(points[2].X - widththick * 1.1f * cosk, points[2].Y + widththick * 1.1f * sink);
            pointCurve[4] = new PointF(points[1].X - widththick * 0.7f * cosk, points[1].Y + widththick * 0.7f * sink);
            pointCurve[5] = new PointF(points[0].X - widththin / 3 * cosk, points[0].Y + widththin / 3 * sink);

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointCurve);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();

        }
        //提
        private void DrawTi(Graphics g)
        {
            double k = Math.Atan((points[1].X - points[0].X) / (points[0].Y - points[1].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);
            //上方平横
            PointF[] pointline = new PointF[2];
            pointline[0] = new PointF(points[1].X, points[1].Y - widththin / 3);
            pointline[1] = new PointF(points[0].X - widththick / 2, points[0].Y - widththick);

            PointF[] pointCurve = new PointF[3];
            pointCurve[0] = pointline[1];
            pointCurve[1] = points[0];
            pointCurve[2] = points[1];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddLines(pointline);
            path.AddCurve(pointCurve, 0.1f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //点提（三点水的提）
        private void DrawDianti(Graphics g)
        {
            double k = Math.Atan((points[6].X - points[5].X) / (points[5].Y - points[6].Y));   //计算提的斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointCurve = new PointF[7];
            pointCurve[0] = points[0];
            pointCurve[1] = points[1];
            pointCurve[2] = points[2];
            pointCurve[3] = points[3];
            pointCurve[4] = points[4];
            pointCurve[5] = points[5];
            pointCurve[6] = points[6];

            PointF[] pointCurve2 = new PointF[3];

            float w = points[5].X - points[1].X;
            pointCurve2[0] = new PointF(points[6].X - widththin / 2 * cosk, points[6].Y - widththin / 2 * sink);
            pointCurve2[1] = new PointF(points[5].X - w * cosk, points[5].Y - w * sink);
            pointCurve2[2] = new PointF(points[0].X, points[0].Y - widththin / 2);

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointCurve, 0.5f);
            path.AddCurve(pointCurve2, 0.2f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折钩
        private void DrawHengzhegou(Graphics g)
        {
            PointF[] pointDraw = new PointF[3]; //横的一段
            pointDraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointDraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointDraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointDraw[0].X - widththin / 2, pointDraw[0].Y - widththin);

            PointF[] pointcurve1 = new PointF[4];   //弯头
            pointcurve1[0] = pointline[1];
            pointcurve1[1] = new PointF(pointcurve1[0].X + widththick / 2, pointcurve1[0].Y - widththick / 2);
            pointcurve1[2] = new PointF(points[1].X + widththin, points[1].Y);
            pointcurve1[3] = new PointF(points[1].X, points[1].Y + widththin * (float)Math.Cos(Math.PI / 6));

            PointF[] pointcurve2 = new PointF[7];   //右下曲线
            pointcurve2[0] = pointcurve1[3];
            pointcurve2[1] = points[2];
            pointcurve2[2] = points[3];
            pointcurve2[3] = points[4];
            pointcurve2[4] = points[5];
            pointcurve2[5] = new PointF(points[6].X, points[5].Y - widththick * 0.72f);
            pointcurve2[6] = new PointF(points[7].X, points[5].Y - widththick * 1.2f);

            PointF[] pointcurve3 = new PointF[7];   //左上曲线
            pointcurve3[0] = new PointF(pointcurve2[6].X, pointcurve2[6].Y - widththin / 2);
            pointcurve3[1] = new PointF(points[6].X, pointcurve2[5].Y - widththick / 2);
            pointcurve3[2] = new PointF(points[5].X, points[5].Y - widththick * 1.2f);  //勾底
            pointcurve3[3] = new PointF(points[4].X, points[4].Y - widththick * 1.2f);
            pointcurve3[4] = new PointF(points[3].X - widththick * 0.8f, points[3].Y - widththick * 0.9f);
            pointcurve3[5] = new PointF(points[2].X - widththick, points[2].Y);
            pointcurve3[6] = pointDraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointDraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointcurve2);
            path.AddCurve(pointcurve3);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折
        private void DrawHengzhe(Graphics g)
        {
            PointF[] pointDraw = new PointF[3]; //横的一段
            pointDraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointDraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointDraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointDraw[0].X - widththin / 2, pointDraw[0].Y - widththin);

            PointF[] pointcurve1 = new PointF[4];   //弯头
            pointcurve1[0] = pointline[1];
            pointcurve1[1] = new PointF(pointcurve1[0].X + widththick / 2, pointcurve1[0].Y - widththick / 2);
            pointcurve1[2] = new PointF(points[1].X + widththin, points[1].Y);
            pointcurve1[3] = new PointF(points[1].X, points[1].Y + widththin * (float)Math.Cos(Math.PI / 6));

            PointF[] pointDraw1 = new PointF[4]; //竖由6个点相互连接的线段组成
            pointDraw1[0] = pointcurve1[3];
            pointDraw1[1] = new PointF(points[2].X, points[2].Y - widththick * (float)Math.Sin(Math.PI / 12));
            pointDraw1[2] = new PointF(points[2].X - widththick, points[2].Y);
            pointDraw1[3] = pointDraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointDraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointDraw1, 0.1f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折撇
        private void DrawHengzhepie(Graphics g)
        {
            double k = Math.Atan((points[1].X - points[3].X) / (points[3].Y - points[1].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointDraw = new PointF[3]; //横的一段
            pointDraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointDraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointDraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointDraw[0].X - widththin / 2, pointDraw[0].Y - widththin);

            PointF[] pointcurve1 = new PointF[4];   //弯头
            pointcurve1[0] = pointline[1];
            pointcurve1[1] = new PointF(pointcurve1[0].X + widththick / 2, pointcurve1[0].Y - widththick / 2);
            pointcurve1[2] = new PointF(points[1].X + widththin, points[1].Y);
            pointcurve1[3] = new PointF(points[1].X, points[1].Y + widththin * (float)Math.Cos(Math.PI / 6));

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = pointcurve1[3];
            pointCurve1[1] = points[2];
            pointCurve1[2] = points[3];

            PointF[] pointCurve2 = new PointF[3];   //左边曲线，倒序
            pointCurve2[0] = new PointF(points[3].X - widththin / 3, points[3].Y - widththin / 3);  //撇的头是平的
            pointCurve2[1] = new PointF(points[2].X - widththick * 0.8f * cosk, points[2].Y - widththick * 0.8f * sink);
            pointCurve2[2] = pointDraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointDraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointCurve1);
            path.AddCurve(pointCurve2);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //竖弯钩
        private void DrawShuwangou(Graphics g)
        {
            PointF[] pointDraw = new PointF[4]; //竖由6个点相互连接的线段组成
            pointDraw[0] = new PointF(points[0].X, points[0].Y - widththick * (float)Math.Sin(Math.PI / 12) - widththin);
            pointDraw[1] = new PointF(points[0].X + widththick, points[0].Y - widththin);
            pointDraw[2] = new PointF(pointDraw[1].X + widththin * (float)Math.Cos(Math.PI / 12 + Math.PI / 6),
                                      pointDraw[1].Y + widththin * (float)Math.Sin(Math.PI / 12 + Math.PI / 6));
            pointDraw[3] = new PointF(points[0].X + widththick, pointDraw[1].Y + widththin);

            PointF[] pointcurve1 = new PointF[4];
            pointcurve1[0] = pointDraw[3];
            //pointcurve1[1] = new PointF(points[1].X + widththick, points[1].Y); //弧头
            pointcurve1[1] = new PointF(points[2].X + widththick * 0.9f, points[2].Y - widththick * 0.9f);  //弧中
            //pointcurve1[3] = new PointF(points[3].X, points[3].Y - widththick); //弧尾
            pointcurve1[2] = new PointF(points[4].X - widththick, points[4].Y - widththick);
            pointcurve1[3] = new PointF(points[6].X - widththin / 3, points[4].Y - widththick - (points[4].Y - points[0].Y) / 3);

            PointF[] pointcurve2 = new PointF[8];
            pointcurve2[0] = new PointF(pointcurve1[3].X + widththin / 3, pointcurve1[3].Y);
            pointcurve2[1] = new PointF(points[6].X, points[5].Y - (points[5].X - points[6].X));
            pointcurve2[2] = points[5];
            pointcurve2[3] = points[4];
            pointcurve2[4] = points[3];
            pointcurve2[5] = points[2];
            pointcurve2[6] = points[1];
            pointcurve2[7] = pointDraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointDraw);
            path.AddCurve(pointcurve1, 0.2f);
            path.AddCurve(pointcurve2, 0.3f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折弯钩
        private void DrawHengzhewangou(Graphics g)
        {
            PointF[] pointDraw = new PointF[3]; //横的一段
            pointDraw[0] = new PointF(points[1].X, points[1].Y);
            pointDraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointDraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointDraw[0].X - widththin / 2, pointDraw[0].Y - widththin);

            PointF[] pointcurve = new PointF[4];   //弯头
            pointcurve[0] = pointline[1];
            pointcurve[1] = new PointF(pointcurve[0].X + widththick / 2, pointcurve[0].Y - widththick / 2);
            pointcurve[2] = new PointF(points[1].X + widththick + widththin, points[1].Y);
            pointcurve[3] = new PointF(points[1].X + widththick, points[1].Y + widththin * (float)Math.Cos(Math.PI / 6));

            PointF[] pointcurve1 = new PointF[4];
            pointcurve1[0] = pointcurve[3];
            //pointcurve1[1] = new PointF(points[2].X + widththick, points[2].Y); //弧头
            pointcurve1[1] = new PointF(points[3].X + widththick * 0.9f, points[3].Y - widththick * 0.9f);  //弧中
            //pointcurve1[3] = new PointF(points[4].X, points[4].Y - widththick); //弧尾
            pointcurve1[2] = new PointF(points[5].X - widththick, points[5].Y - widththick);
            pointcurve1[3] = new PointF(points[7].X - widththin / 3, points[5].Y - widththick - (points[5].Y - points[0].Y) / 3);

            PointF[] pointcurve2 = new PointF[8];
            pointcurve2[0] = new PointF(pointcurve1[3].X + widththin / 3, pointcurve1[3].Y);
            pointcurve2[1] = new PointF(points[7].X, points[6].Y - (points[6].X - points[7].X));
            pointcurve2[2] = points[6];
            pointcurve2[3] = points[5];
            pointcurve2[4] = points[4];
            pointcurve2[5] = points[3];
            pointcurve2[6] = points[2];
            pointcurve2[7] = pointDraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointDraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve);
            path.AddCurve(pointcurve1, 0.2f);
            path.AddCurve(pointcurve2, 0.3f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //细线（横）
        private void DrawHeng_n(Graphics g)
        {
            PointF[] pointDraw = new PointF[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                pointDraw[i] = new PointF(points[i].X, points[i].Y - widththin / 2);
            }
            for (int i = 0; i < points.Count; i++)
            {
                pointDraw[points.Count * 2 - i - 1] = new PointF(points[i].X, points[i].Y + widththin / 2);
            }

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddLines(pointDraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //粗线（竖）
        private void DrawShu_n(Graphics g)
        {
            PointF[] pointDraw = new PointF[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                pointDraw[i] = new PointF(points[i].X - widththick / 2, points[i].Y);
            }
            for (int i = 0; i < points.Count; i++)
            {
                pointDraw[points.Count * 2 - i - 1] = new PointF(points[i].X + widththick / 2, points[i].Y);
            }

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddLines(pointDraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        #endregion
    }
}
