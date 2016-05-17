using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CharNotation
{
    //笔画名称：横，竖，撇，捺，点，提，点提（氵专用），横折，横折钩，横折弯钩，横折撇，竖勾，竖弯钩，无头横，无头竖
    enum strokeType { HENG, SHU, PIE, NA, DIAN, TI, DIANTI, HENGZHE, HENGZHEGOU, HENGZHEWANGOU, HENGZHEPIE, SHUGOU, SHUWANGOU, OTHER_n, OTHER_t };

    class Stroke
    {
        public strokeType type;
        public List<PointF> points;
        private float widththin, widththick;
        public float scale;
        public bool existHeng;

        public Stroke()
        {
            type = strokeType.HENG;
            points = new List<PointF>();
            scale = 1.0f;
            existHeng = false;
        }

        public Stroke(Stroke _s)
        {
            type = _s.type;
            points = new List<PointF>(_s.points);
            scale = _s.scale;
            existHeng = _s.existHeng;
        }

        ~ Stroke()
        {
            points.Clear();
        }

        #region ================================左手=================================
        //艹
        public static List<Stroke> sanyin()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.03f, 0.55f));
            s1.points.Add(new PointF(0.95f, 0.55f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.34f, 0.15f));
            s1.points.Add(new PointF(0.34f, 0.97f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.63f, 0.15f));
            s1.points.Add(new PointF(0.63f, 0.97f));
            result.Add(s1);
            return result;
        }
        //尤
        public static List<Stroke> jiu()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.04f, 0.34f));
            s1.points.Add(new PointF(0.94f, 0.34f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.38f, 0.09f));
            s1.points.Add(new PointF(0.28f, 0.72f));
            s1.points.Add(new PointF(0.02f, 0.96f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHUWANGOU;
            s1.points.Add(new PointF(0.52f, 0.38f));
            s1.points.Add(new PointF(0.52f, 0.78f));    //弧头
            s1.points.Add(new PointF(0.54f, 0.90f));    //弧中
            s1.points.Add(new PointF(0.66f, 0.94f));    //弧尾
            s1.points.Add(new PointF(0.92f, 0.92f));    //勾底
            s1.points.Add(new PointF(0.95f, 0.84f));    //弯底
            s1.points.Add(new PointF(0.89f, 0.65f));    //勾尖
            result.Add(s1);
            return result;
        }
        //大
        public static List<Stroke> dazhi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.06f, 0.42f));
            s1.points.Add(new PointF(0.98f, 0.42f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.41f, 0.10f));
            s1.points.Add(new PointF(0.34f, 0.66f));
            s1.points.Add(new PointF(0.02f, 0.93f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.55f, 0.56f));
            s1.points.Add(new PointF(0.74f, 0.62f));
            s1.points.Add(new PointF(0.89f, 0.75f));
            s1.points.Add(new PointF(0.85f, 0.94f));
            result.Add(s1);
            return result;
        }
        //人
        public static List<Stroke> shizhi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.75f, 0.05f));
            s1.points.Add(new PointF(0.36f, 0.32f));
            s1.points.Add(new PointF(0.02f, 0.57f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.48f, 0.33f));
            s1.points.Add(new PointF(0.48f, 0.98f));
            result.Add(s1);
            return result;
        }
        //中
        public static List<Stroke> zhongzhi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.15f, 0.30f));
            s1.points.Add(new PointF(0.15f, 0.66f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.16f, 0.30f));
            s1.points.Add(new PointF(0.86f, 0.30f));
            s1.points.Add(new PointF(0.86f, 0.65f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.18f, 0.57f));
            s1.points.Add(new PointF(0.80f, 0.57f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.46f, 0.10f));
            s1.points.Add(new PointF(0.46f, 0.97f));
            result.Add(s1);
            return result;
        }
        //夕
        public static List<Stroke> mingzhi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.39f, 0.12f));
            s1.points.Add(new PointF(0.30f, 0.30f));
            s1.points.Add(new PointF(0.05f, 0.62f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHEPIE;
            s1.points.Add(new PointF(0.38f, 0.28f));
            s1.points.Add(new PointF(0.84f, 0.28f));
            s1.points.Add(new PointF(0.55f, 0.73f));
            s1.points.Add(new PointF(0.02f, 1.00f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.32f, 0.40f));
            s1.points.Add(new PointF(0.45f, 0.47f));
            s1.points.Add(new PointF(0.51f, 0.54f));
            s1.points.Add(new PointF(0.47f, 0.64f));
            result.Add(s1);
            return result;
        }
        //足
        public static List<Stroke> guizhi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.29f, 0.09f));
            s1.points.Add(new PointF(0.29f, 0.40f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.30f, 0.09f));
            s1.points.Add(new PointF(0.78f, 0.09f));
            s1.points.Add(new PointF(0.78f, 0.38f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.30f, 0.33f));
            s1.points.Add(new PointF(0.74f, 0.33f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.52f, 0.46f));
            s1.points.Add(new PointF(0.52f, 0.84f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.52f, 0.59f));
            s1.points.Add(new PointF(0.90f, 0.59f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.26f, 0.51f));
            s1.points.Add(new PointF(0.26f, 0.88f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.TI;
            s1.points.Add(new PointF(0.14f, 0.98f));
            s1.points.Add(new PointF(0.94f, 0.79f));
            result.Add(s1);
            return result;
        }
        #endregion

        #region ==============================主字=================================
        //厂
        public static List<Stroke> li()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.2f, 0.12f));
            s1.points.Add(new PointF(0.93f, 0.12f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.15f, 0.12f));
            s1.points.Add(new PointF(0.13f, 0.7f));
            s1.points.Add(new PointF(0.02f, 0.97f));
            result.Add(s1);
            return result;
        }
        //乇
        public static List<Stroke> tuo()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.scale *= 0.8f;
            s1.points.Add(new PointF(0.25f, 0.09f));
            s1.points.Add(new PointF(0.16f, 0.14f));
            s1.points.Add(new PointF(0.00f, 0.21f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.scale *= 0.8f;
            s1.points.Add(new PointF(0.02f, 0.57f));
            s1.points.Add(new PointF(0.35f, 0.50f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHUWANGOU;
            s1.points.Add(new PointF(0.15f, 0.19f));
            s1.points.Add(new PointF(0.15f, 0.79f));    //弧头
            s1.points.Add(new PointF(0.17f, 0.92f));    //弧中
            s1.points.Add(new PointF(0.26f, 0.95f));    //弧尾
            s1.points.Add(new PointF(0.94f, 0.94f));    //勾底
            s1.points.Add(new PointF(0.98f, 0.87f));    //弯底
            s1.points.Add(new PointF(0.94f, 0.71f));    //勾尖
            result.Add(s1);
            return result;
        }
        //尸
        public static List<Stroke> pi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.19f, 0.10f));
            s1.points.Add(new PointF(0.86f, 0.10f));
            s1.points.Add(new PointF(0.86f, 0.27f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.18f, 0.22f));
            s1.points.Add(new PointF(0.80f, 0.22f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.12f, 0.10f));
            s1.points.Add(new PointF(0.11f, 0.64f));
            s1.points.Add(new PointF(0.01f, 0.96f));
            result.Add(s1);
            return result;
        }
        //木
        public static List<Stroke> mo()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.07f, 0.21f));
            s1.points.Add(new PointF(0.96f, 0.21f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.49f, 0.08f));
            s1.points.Add(new PointF(0.49f, 0.47f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.34f, 0.25f));
            s1.points.Add(new PointF(0.22f, 0.39f));
            s1.points.Add(new PointF(0.02f, 0.53f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.NA;
            s1.existHeng = false;
            s1.points.Add(new PointF(0.50f, 0.21f));    //横头
            s1.points.Add(new PointF(0.56f, 0.21f));    //折笔
            s1.points.Add(new PointF(0.67f, 0.38f));    //中
            s1.points.Add(new PointF(0.75f, 0.44f));    //中
            s1.points.Add(new PointF(0.85f, 0.50f));    //底
            s1.points.Add(new PointF(0.90f, 0.45f));    //底半
            s1.points.Add(new PointF(0.98f, 0.43f));    //尖
            result.Add(s1);
            return result;
        }
        //竖弯钩
        public static List<Stroke> tiao()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHUWANGOU;
            s1.points.Add(new PointF(0.04f, 0.10f));
            s1.points.Add(new PointF(0.04f, 0.79f));    //弧头
            s1.points.Add(new PointF(0.07f, 0.92f));    //弧中
            s1.points.Add(new PointF(0.24f, 0.96f));    //弧尾
            s1.points.Add(new PointF(0.90f, 0.94f));    //勾底
            s1.points.Add(new PointF(0.96f, 0.85f));    //弯底
            s1.points.Add(new PointF(0.90f, 0.57f));    //勾尖
            result.Add(s1);
            return result;
        }
        //勹
        public static List<Stroke> gou()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.28f, 0.10f));
            s1.points.Add(new PointF(0.17f, 0.24f));
            s1.points.Add(new PointF(0.01f, 0.47f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHEGOU;
            s1.points.Add(new PointF(0.26f, 0.15f));    //横头
            s1.points.Add(new PointF(0.89f, 0.15f));     //折点
            s1.points.Add(new PointF(0.88f, 0.70f));     //弧头
            s1.points.Add(new PointF(0.85f, 0.92f));    //弧中
            s1.points.Add(new PointF(0.75f, 0.98f));    //弧尾
            s1.points.Add(new PointF(0.69f, 0.98f));    //勾底
            s1.points.Add(new PointF(0.65f, 0.91f));    //勾中
            s1.points.Add(new PointF(0.54f, 0.86f));    //勾尖
            result.Add(s1);
            return result;
        }
        //易
        public static List<Stroke> ti()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.26f, 0.09f));
            s1.points.Add(new PointF(0.26f, 0.33f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.30f, 0.09f));
            s1.points.Add(new PointF(0.75f, 0.09f));
            s1.points.Add(new PointF(0.75f, 0.33f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.40f, 0.23f));
            s1.points.Add(new PointF(0.27f, 0.35f));
            s1.points.Add(new PointF(0.04f, 0.56f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHEGOU;
            s1.points.Add(new PointF(0.38f, 0.34f));    //横头
            s1.points.Add(new PointF(0.91f, 0.34f));     //折点
            s1.points.Add(new PointF(0.90f, 0.77f));     //弧头
            s1.points.Add(new PointF(0.86f, 0.93f));    //弧中
            s1.points.Add(new PointF(0.76f, 0.97f));    //弧尾
            s1.points.Add(new PointF(0.72f, 0.97f));    //勾底
            s1.points.Add(new PointF(0.68f, 0.92f));    //勾中
            s1.points.Add(new PointF(0.57f, 0.89f));    //勾尖
            result.Add(s1);
            return result;
        }
        //搯起
        public static List<Stroke> qiaqi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.65f, 0.10f));
            s1.points.Add(new PointF(0.51f, 0.11f));
            s1.points.Add(new PointF(0.29f, 0.17f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.22f, 0.19f));
            s1.points.Add(new PointF(0.17f, 0.28f));
            s1.points.Add(new PointF(0.07f, 0.45f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.44f, 0.20f));
            s1.points.Add(new PointF(0.52f, 0.26f));
            s1.points.Add(new PointF(0.56f, 0.32f));
            s1.points.Add(new PointF(0.51f, 0.41f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.68f, 0.17f));
            s1.points.Add(new PointF(0.80f, 0.23f));
            s1.points.Add(new PointF(0.88f, 0.30f));
            s1.points.Add(new PointF(0.84f, 0.44f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.22f, 0.44f));
            s1.points.Add(new PointF(0.76f, 0.44f));
            s1.points.Add(new PointF(0.76f, 0.70f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.21f, 0.63f));
            s1.points.Add(new PointF(0.73f, 0.63f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHUWANGOU;
            s1.points.Add(new PointF(0.17f, 0.44f));
            s1.points.Add(new PointF(0.17f, 0.86f));    //弧头
            s1.points.Add(new PointF(0.19f, 0.93f));    //弧中
            s1.points.Add(new PointF(0.29f, 0.95f));    //弧尾
            s1.points.Add(new PointF(0.88f, 0.94f));    //勾底
            s1.points.Add(new PointF(0.94f, 0.88f));    //弯底
            s1.points.Add(new PointF(0.88f, 0.73f));    //勾尖
            result.Add(s1);
            return result;
        }
        //罨
        public static List<Stroke> yan()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.17f, 0.09f));
            s1.points.Add(new PointF(0.17f, 0.47f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.17f, 0.09f));
            s1.points.Add(new PointF(0.84f, 0.09f));
            s1.points.Add(new PointF(0.84f, 0.47f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.47f, 0.14f));
            s1.points.Add(new PointF(0.39f, 0.27f));
            s1.points.Add(new PointF(0.23f, 0.39f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.51f, 0.19f));
            s1.points.Add(new PointF(0.62f, 0.23f));
            s1.points.Add(new PointF(0.74f, 0.32f));
            s1.points.Add(new PointF(0.73f, 0.42f));
            result.Add(s1);
            return result;
        }
        #endregion

        //==============================数字==================================
        public static List<Stroke> number(char c)   //输入徽位数字字符（十：x，外：w，半：b)
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1;
            switch (c)
            {
                case '1':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.03f, 0.49f));
                    s1.points.Add(new PointF(0.95f, 0.49f));
                    result.Add(s1);
                    break;

                case '2':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.scale *= 0.9f;
                    s1.points.Add(new PointF(0.15f, 0.26f));
                    s1.points.Add(new PointF(0.86f, 0.26f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.05f, 0.86f));
                    s1.points.Add(new PointF(0.96f, 0.86f));
                    result.Add(s1);
                    break;

                case '3':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.scale *= 0.98f;
                    s1.points.Add(new PointF(0.12f, 0.22f));
                    s1.points.Add(new PointF(0.93f, 0.22f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.scale *= 0.95f;
                    s1.points.Add(new PointF(0.18f, 0.53f));
                    s1.points.Add(new PointF(0.87f, 0.53f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.05f, 0.86f));
                    s1.points.Add(new PointF(0.98f, 0.86f));
                    result.Add(s1);
                    break;

                case '4':
                    s1 = new Stroke();
                    s1.type = strokeType.SHU;
                    s1.points.Add(new PointF(0.15f, 0.15f));
                    s1.points.Add(new PointF(0.15f, 0.95f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENGZHE;
                    s1.points.Add(new PointF(0.15f, 0.15f));
                    s1.points.Add(new PointF(0.88f, 0.15f));
                    s1.points.Add(new PointF(0.88f, 0.95f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.OTHER_t;
                    s1.points.Add(new PointF(0.38f, 0.14f));
                    s1.points.Add(new PointF(0.38f, 0.82f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.OTHER_t;
                    s1.points.Add(new PointF(0.61f, 0.14f));
                    s1.points.Add(new PointF(0.61f, 0.82f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.OTHER_n;
                    s1.points.Add(new PointF(0.15f, 0.82f));
                    s1.points.Add(new PointF(0.84f, 0.82f));
                    result.Add(s1);
                    break;

                case '5':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.06f, 0.14f));
                    s1.points.Add(new PointF(0.90f, 0.14f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.OTHER_t;
                    s1.points.Add(new PointF(0.43f, 0.13f));
                    s1.points.Add(new PointF(0.31f, 0.86f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENGZHE;
                    s1.points.Add(new PointF(0.12f, 0.44f));
                    s1.points.Add(new PointF(0.72f, 0.44f));
                    s1.points.Add(new PointF(0.70f, 0.86f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.01f, 0.87f));
                    s1.points.Add(new PointF(0.97f, 0.87f));
                    result.Add(s1);
                    break;

                case '6':
                    s1 = new Stroke();
                    //s1.type = strokeType.DIAN;
                    //s1.points.Add(new PointF(0.35f, 0.03f));
                    //s1.points.Add(new PointF(0.46f, 0.08f));
                    //s1.points.Add(new PointF(0.56f, 0.17f));
                    //s1.points.Add(new PointF(0.55f, 0.25f));
                    //s1.points.Add(new PointF(0.48f, 0.27f));
                    s1.type = strokeType.SHU;
                    s1.points.Add(new PointF(0.46f, 0.10f));
                    s1.points.Add(new PointF(0.46f, 0.35f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.04f, 0.36f));
                    s1.points.Add(new PointF(0.96f, 0.36f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.PIE;
                    s1.scale *= 0.8f;
                    s1.points.Add(new PointF(0.34f, 0.53f));
                    s1.points.Add(new PointF(0.21f, 0.69f));
                    s1.points.Add(new PointF(0.02f, 0.93f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.DIAN;
                    s1.points.Add(new PointF(0.55f, 0.45f));
                    s1.points.Add(new PointF(0.70f, 0.57f));
                    s1.points.Add(new PointF(0.85f, 0.74f));
                    s1.points.Add(new PointF(0.86f, 0.92f));
                    result.Add(s1);
                    break;

                case '7':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.03f, 0.55f));
                    s1.points.Add(new PointF(0.94f, 0.32f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.SHUWANGOU;
                    s1.points.Add(new PointF(0.32f, 0.11f));
                    s1.points.Add(new PointF(0.32f, 0.50f));    //弧头
                    s1.points.Add(new PointF(0.34f, 0.89f));    //弧中
                    s1.points.Add(new PointF(0.50f, 0.92f));    //弧尾
                    s1.points.Add(new PointF(0.87f, 0.90f));    //勾底
                    s1.points.Add(new PointF(0.93f, 0.82f));    //弯底
                    s1.points.Add(new PointF(0.87f, 0.48f));    //勾尖
                    result.Add(s1);
                    break;

                case '8':
                    s1 = new Stroke();
                    s1.type = strokeType.PIE;
                    s1.points.Add(new PointF(0.32f, 0.38f));
                    s1.points.Add(new PointF(0.23f, 0.63f));
                    s1.points.Add(new PointF(0.02f, 0.92f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.NA;
                    s1.existHeng = true;
                    s1.points.Add(new PointF(0.43f, 0.10f));    //横头
                    s1.points.Add(new PointF(0.57f, 0.10f));    //折笔
                    s1.points.Add(new PointF(0.62f, 0.50f));    //中
                    s1.points.Add(new PointF(0.68f, 0.71f));    //中
                    s1.points.Add(new PointF(0.80f, 0.91f));    //底
                    s1.points.Add(new PointF(0.89f, 0.88f));    //底半
                    s1.points.Add(new PointF(0.96f, 0.88f));    //尖
                    result.Add(s1);
                    break;

                case '9':
                    s1 = new Stroke();
                    s1.type = strokeType.PIE;
                    s1.points.Add(new PointF(0.36f, 0.09f));
                    s1.points.Add(new PointF(0.29f, 0.65f));
                    s1.points.Add(new PointF(0.04f, 0.94f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENGZHEWANGOU;
                    s1.points.Add(new PointF(0.08f, 0.31f));
                    s1.points.Add(new PointF(0.60f, 0.31f));
                    s1.points.Add(new PointF(0.59f, 0.76f));    //弧头
                    s1.points.Add(new PointF(0.61f, 0.89f));    //弧中
                    s1.points.Add(new PointF(0.72f, 0.92f));    //弧尾
                    s1.points.Add(new PointF(0.90f, 0.90f));    //勾底
                    s1.points.Add(new PointF(0.96f, 0.82f));    //弯底
                    s1.points.Add(new PointF(0.90f, 0.62f));    //勾尖
                    result.Add(s1);
                    break;

                case 'x':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.06f, 0.42f));
                    s1.points.Add(new PointF(0.96f, 0.42f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.SHU;
                    s1.points.Add(new PointF(0.49f, 0.10f));
                    s1.points.Add(new PointF(0.49f, 0.97f));
                    result.Add(s1);
                    break;

                case 'b':
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.scale *= 0.9f;
                    s1.points.Add(new PointF(0.13f, 0.31f));
                    s1.points.Add(new PointF(0.91f, 0.31f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.HENG;
                    s1.points.Add(new PointF(0.05f, 0.67f));
                    s1.points.Add(new PointF(0.98f, 0.67f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.SHU;
                    s1.points.Add(new PointF(0.49f, 0.10f));
                    s1.points.Add(new PointF(0.49f, 0.95f));
                    result.Add(s1);
                    break;

                case 'w':
                    s1 = new Stroke();
                    s1.type = strokeType.SHU;
                    s1.points.Add(new PointF(0.37f, 0.10f));
                    s1.points.Add(new PointF(0.37f, 0.95f));
                    result.Add(s1);
                    s1 = new Stroke();
                    s1.type = strokeType.NA;
                    s1.existHeng = false;
                    s1.points.Add(new PointF(0.04f, 0.20f));    //横头
                    s1.points.Add(new PointF(0.04f, 0.21f));    //折笔
                    s1.points.Add(new PointF(0.38f, 0.64f));    //中
                    s1.points.Add(new PointF(0.65f, 0.78f));    //中
                    s1.points.Add(new PointF(0.81f, 0.83f));    //底
                    s1.points.Add(new PointF(0.87f, 0.73f));    //底半
                    s1.points.Add(new PointF(0.98f, 0.66f));    //尖
                    result.Add(s1);
                    break;

                default:
                    break;
            }
            return result;
        }


        #region =============================主字修饰==================================
        //绰
        public static List<Stroke> chuo()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.50f, 0.00f));
            s1.points.Add(new PointF(0.50f, 1.00f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.50f, 0.50f));
            s1.points.Add(new PointF(1.00f, 0.50f));
            result.Add(s1);
            return result;
        }
        //注
        public static List<Stroke> zhu()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.29f, 0.06f));
            s1.points.Add(new PointF(0.53f, 0.09f));
            s1.points.Add(new PointF(0.86f, 0.16f));
            s1.points.Add(new PointF(0.71f, 0.26f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.04f, 0.29f));
            s1.points.Add(new PointF(0.29f, 0.32f));
            s1.points.Add(new PointF(0.58f, 0.39f));
            s1.points.Add(new PointF(0.44f, 0.48f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIANTI;
            s1.points.Add(new PointF(0.01f, 0.65f));
            s1.points.Add(new PointF(0.36f, 0.69f));
            s1.points.Add(new PointF(0.27f, 0.88f));
            s1.points.Add(new PointF(0.48f, 0.95f));
            s1.points.Add(new PointF(0.62f, 0.90f));
            s1.points.Add(new PointF(0.59f, 0.65f));
            s1.points.Add(new PointF(0.98f, 0.30f));
            result.Add(s1);

            return result;
        }
        #endregion

        #region ============================纯修饰===================================
        //上
        public static List<Stroke> shang()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.49f, 0.13f));
            s1.points.Add(new PointF(0.49f, 0.88f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.50f, 0.38f));
            s1.points.Add(new PointF(0.91f, 0.38f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.06f, 0.89f));
            s1.points.Add(new PointF(0.97f, 0.89f));
            result.Add(s1);
            return result;
        }
        //下
        public static List<Stroke> xia()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.05f, 0.16f));
            s1.points.Add(new PointF(0.96f, 0.16f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.46f, 0.19f));
            s1.points.Add(new PointF(0.46f, 0.96f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.51f, 0.37f));
            s1.points.Add(new PointF(0.66f, 0.42f));
            s1.points.Add(new PointF(0.82f, 0.53f));
            s1.points.Add(new PointF(0.79f, 0.63f));
            result.Add(s1);
            return result;
        }
        //进
        public static List<Stroke> jin()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.23f, 0.09f));
            s1.points.Add(new PointF(0.15f, 0.28f));
            s1.points.Add(new PointF(0.04f, 0.48f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.21f, 0.27f));
            s1.points.Add(new PointF(0.21f, 0.98f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.DIAN;
            s1.points.Add(new PointF(0.45f, 0.01f));
            s1.points.Add(new PointF(0.53f, 0.05f));
            s1.points.Add(new PointF(0.61f, 0.13f));
            s1.points.Add(new PointF(0.57f, 0.22f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.22f, 0.26f));
            s1.points.Add(new PointF(0.90f, 0.26f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.scale *= 0.9f;
            s1.points.Add(new PointF(0.22f, 0.46f));
            s1.points.Add(new PointF(0.87f, 0.46f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.scale *= 0.9f;
            s1.points.Add(new PointF(0.22f, 0.65f));
            s1.points.Add(new PointF(0.87f, 0.65f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.22f, 0.86f));
            s1.points.Add(new PointF(0.92f, 0.86f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_t;
            s1.points.Add(new PointF(0.55f, 0.26f));
            s1.points.Add(new PointF(0.55f, 0.84f));
            result.Add(s1);
            return result;
        }
        //退
        public static List<Stroke> tui()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.24f, 0.13f));
            s1.points.Add(new PointF(0.74f, 0.13f));
            s1.points.Add(new PointF(0.74f, 0.50f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.24f, 0.29f));
            s1.points.Add(new PointF(0.70f, 0.29f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.24f, 0.46f));
            s1.points.Add(new PointF(0.70f, 0.46f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.24f, 0.13f));
            s1.points.Add(new PointF(0.24f, 0.89f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.TI;
            s1.points.Add(new PointF(0.21f, 0.98f));
            s1.points.Add(new PointF(0.52f, 0.77f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.71f, 0.55f));
            s1.points.Add(new PointF(0.67f, 0.57f));
            s1.points.Add(new PointF(0.55f, 0.66f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.NA;
            s1.points.Add(new PointF(0.41f, 0.47f));
            s1.points.Add(new PointF(0.41f, 0.47f));
            s1.points.Add(new PointF(0.54f, 0.74f));
            s1.points.Add(new PointF(0.71f, 0.87f));
            s1.points.Add(new PointF(0.83f, 0.92f));
            s1.points.Add(new PointF(0.89f, 0.87f));
            s1.points.Add(new PointF(0.97f, 0.85f));
            result.Add(s1);
            return result;
        }
        //复
        public static List<Stroke> fu()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.30f, 0.20f));
            s1.points.Add(new PointF(0.21f, 0.34f));
            s1.points.Add(new PointF(0.04f, 0.56f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.29f, 0.31f));
            s1.points.Add(new PointF(0.92f, 0.31f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.29f, 0.49f));
            s1.points.Add(new PointF(0.29f, 0.92f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENGZHE;
            s1.points.Add(new PointF(0.29f, 0.49f));
            s1.points.Add(new PointF(0.79f, 0.49f));
            s1.points.Add(new PointF(0.79f, 0.89f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.29f, 0.65f));
            s1.points.Add(new PointF(0.75f, 0.65f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.OTHER_n;
            s1.points.Add(new PointF(0.29f, 0.81f));
            s1.points.Add(new PointF(0.75f, 0.81f));
            result.Add(s1);
            return result;
        }
        //吟
        public static List<Stroke> yin()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.14f, 0.18f));
            s1.points.Add(new PointF(0.85f, 0.18f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.04f, 0.51f));
            s1.points.Add(new PointF(0.96f, 0.51f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.49f, 0.54f));
            s1.points.Add(new PointF(0.49f, 0.95f));
            result.Add(s1);
            return result;
        }


        public static List<Stroke> fenkai()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.28f, 0.17f));
            s1.points.Add(new PointF(0.20f, 0.28f));
            s1.points.Add(new PointF(0.02f, 0.43f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.NA;
            s1.existHeng = true;
            s1.points.Add(new PointF(0.41f, 0.06f));
            s1.points.Add(new PointF(0.57f, 0.06f));
            s1.points.Add(new PointF(0.65f, 0.24f));
            s1.points.Add(new PointF(0.73f, 0.32f));
            s1.points.Add(new PointF(0.83f, 0.40f));
            s1.points.Add(new PointF(0.89f, 0.36f));
            s1.points.Add(new PointF(0.96f, 0.35f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.25f, 0.41f));
            s1.points.Add(new PointF(0.77f, 0.41f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.14f, 0.64f));
            s1.points.Add(new PointF(0.85f, 0.64f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.PIE;
            s1.points.Add(new PointF(0.34f, 0.44f));
            s1.points.Add(new PointF(0.32f, 0.79f));
            s1.points.Add(new PointF(0.14f, 0.97f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.60f, 0.43f));
            s1.points.Add(new PointF(0.60f, 0.97f));
            result.Add(s1);
            return result;
        }

        public static List<Stroke> shaoxi()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.14f, 0.18f));
            s1.points.Add(new PointF(0.85f, 0.18f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.HENG;
            s1.points.Add(new PointF(0.04f, 0.51f));
            s1.points.Add(new PointF(0.96f, 0.51f));
            result.Add(s1);
            s1 = new Stroke();
            s1.type = strokeType.SHU;
            s1.points.Add(new PointF(0.49f, 0.54f));
            s1.points.Add(new PointF(0.49f, 0.95f));
            result.Add(s1);
            return result;
        }

        #endregion

        #region ============================绘制函数==================================
        public void setWidth(float thin, float thick)
        {
            widththin = thin * scale;
            widththick = thick * scale;
            if (widththick < widththin * 1.5f)
                widththick = widththin * 1.5f;
        }

        public void draw(Graphics g)
        {
            switch (type)
            {
                case strokeType.HENG:
                    drawHeng(g);
                    break;
                case strokeType.SHU:
                    drawShu(g);
                    break;
                case strokeType.PIE:
                    drawPie(g);
                    break;
                case strokeType.NA:
                    drawNa(g);
                    break;
                case strokeType.DIAN:
                    drawDian(g);
                    break;
                case strokeType.TI:
                    drawTi(g);
                    break;
                case strokeType.DIANTI:
                    drawDianti(g);
                    break;
                case strokeType.HENGZHEGOU:
                    /*widththick *= 1.2f;*/
                    drawHengzhegou(g);
                    break;
                case strokeType.HENGZHE:
                    drawHengzhe(g);
                    break;
                case strokeType.HENGZHEPIE:
                    drawHengzhepie(g);
                    break;
                case strokeType.SHUWANGOU:
                    widththick *= 0.8f;
                    drawShuwangou(g);
                    break;
                case strokeType.HENGZHEWANGOU:
                    widththick *= 0.8f;
                    drawHengzhewangou(g);
                    break;
                case strokeType.OTHER_n:
                    drawOthern(g);
                    break;
                case strokeType.OTHER_t:
                default:
                    drawOthert(g);
                    break;
            }
        }
        //横
        private void drawHeng(Graphics g)
        {
            float k = (float)(Math.Atan((points[1].Y - points[0].Y) / (points[1].X - points[0].X)) / Math.PI * 180);   //计算转角
            float distance = (float)Math.Sqrt(Math.Pow(points[1].X - points[0].X, 2) + Math.Pow(points[1].Y - points[0].Y, 2)); //计算长度
            //上方平横
            PointF[] pointline = new PointF[2];
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(points[0].X + distance - widththick * 1.8f, points[0].Y - widththin);
            //右方、左下凸起
            PointF[] pointdraw = new PointF[5];
            pointdraw[0] = pointline[1];
            pointdraw[1] = new PointF(pointdraw[0].X + widththick * 0.65f, pointdraw[0].Y - widththick * 0.8f); //凸起顶部
            pointdraw[2] = new PointF(points[0].X + distance, points[0].Y); //右下角
            pointdraw[3] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[4] = new PointF(points[0].X, points[0].Y + widththin/4);

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            path.AddLines(pointline);
            path.AddCurve(pointdraw, 0.2f);
            //对笔画进行旋转
            g.TranslateTransform(-points[0].X, -points[0].Y);
            g.RotateTransform(k, MatrixOrder.Append);
            g.TranslateTransform(points[0].X, points[0].Y, MatrixOrder.Append);

            g.FillPath(brush, path);
            g.ResetTransform(); //恢复原来位置
            path.Dispose();
            brush.Dispose();
        }
        //竖
        private void drawShu(Graphics g)
        {
            PointF[] pointdraw = new PointF[4]; //竖由6个点相互连接的线段组成
            pointdraw[0] = new PointF(points[0].X - widththick / 2, points[0].Y - widththick * (float)Math.Sin(Math.PI / 12) - widththin);
            pointdraw[1] = new PointF(points[0].X + widththick / 2, points[0].Y - widththin);
            pointdraw[2] = new PointF(pointdraw[1].X + widththin * (float)Math.Cos(Math.PI / 12 + Math.PI / 6),
                                      pointdraw[1].Y + widththin * (float)Math.Sin(Math.PI / 12 + Math.PI / 6));
            pointdraw[3] = new PointF(pointdraw[1].X, pointdraw[1].Y + widththin);

            PointF[] pointdraw1 = new PointF[4]; //竖由6个点相互连接的线段组成
            pointdraw1[0] = pointdraw[3];
            pointdraw1[1] = new PointF(points[1].X + widththick / 2, points[1].Y - widththick * (float)Math.Sin(Math.PI / 12));
            pointdraw1[2] = new PointF(points[1].X - widththick / 2, points[1].Y);
            pointdraw1[3] = pointdraw[0];
            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            path.AddCurve(pointdraw);
            path.AddCurve(pointdraw1, 0.1f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //撇
        private void drawPie(Graphics g)
        {
            double k = Math.Atan((points[0].X - points[2].X) / (points[2].Y - points[0].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointdraw = new PointF[4]; //竖由6个点相互连接的线段组成
            pointdraw[0] = new PointF(points[0].X, points[0].Y - widththick * (float)Math.Sin(Math.PI / 6) - widththin);
            pointdraw[1] = new PointF(points[0].X + widththick, points[0].Y - widththin);
            pointdraw[2] = new PointF(pointdraw[1].X + widththin * (float)Math.Cos(Math.PI / 6 + Math.PI / 6),
                                      pointdraw[1].Y + widththin * (float)Math.Sin(Math.PI / 6 + Math.PI / 6));
            pointdraw[3] = new PointF(points[0].X + widththick, pointdraw[1].Y + widththin);

            PointF[] pointCurve1 = new PointF[3];   //右边曲线
            pointCurve1[0] = pointdraw[3];
            pointCurve1[1] = new PointF(points[1].X + widththick * 0.8f * cosk, points[1].Y + widththick * 0.8f * sink);
            pointCurve1[2] = new PointF(points[2].X + widththin / 3, points[2].Y + widththin / 3);  //撇的头是平的

            PointF[] pointCurve2 = new PointF[3];   //左边曲线，倒序
            pointCurve2[0] = points[2];
            pointCurve2[1] = points[1];
            pointCurve2[2] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddCurve(pointCurve1);
            path.AddCurve(pointCurve2);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //捺（带横或不带）
        private void drawNa(Graphics g)
        {
            double k = Math.Atan((points[6].X - points[2].X) / (points[6].Y - points[2].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);
            float distance = (float)Math.Sqrt(Math.Pow(points[4].X - points[6].X, 2) + Math.Pow(points[4].Y - points[6].Y, 2)); //计算捺的大小

            PointF[] pointdraw = new PointF[3]; //横的一段
            pointdraw[0] = points[1];
            pointdraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointdraw[0].X - widththin / 4, pointdraw[0].Y - widththin);

            PointF[] pointcurve1 = new PointF[4];   //弯头
            pointcurve1[0] = pointline[1];
            pointcurve1[1] = new PointF(pointcurve1[0].X + widththin, pointcurve1[0].Y - widththin);
            pointcurve1[2] = new PointF(points[1].X + widththin * 2, points[1].Y);
            pointcurve1[3] = new PointF(points[1].X + widththin, points[1].Y + widththin / 2 * (float)Math.Cos(Math.PI / 6));

            PointF[] pointcurve2 = new PointF[3];
            if (existHeng)
                pointcurve2[0] = pointcurve1[3];
            else
                pointcurve2[0] = new PointF(points[1].X + widththin, points[1].Y);
            pointcurve2[1] = new PointF(points[2].X + distance * 0.5f * cosk, points[2].Y - distance * 0.5f * sink);
            //pointcurve2[2] = new PointF(points[3].X + widththick * 1.2f * cosk, points[3].Y - widththick * 1.2f * sink);
            //pointcurve2[3] = new PointF(points[4].X + widththick * 1.5f * cosk, points[4].Y - widththick * 1.5f * sink);
            //pointcurve2[4] = new PointF(points[5].X + widththick * 0.55f * cosk, points[5].Y - widththick * 0.55f * sink);
            pointcurve2[2] = new PointF(points[6].X, points[6].Y - widththin / 3);

            PointF[] pointcurve3 = new PointF[6];
            pointcurve3[0] = points[6];
            pointcurve3[1] = points[5];
            pointcurve3[2] = points[4];
            pointcurve3[3] = points[3];
            pointcurve3[4] = points[2];
            pointcurve3[5] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            if (existHeng)
            {
                path.AddCurve(pointdraw);
                path.AddLines(pointline);
                path.AddCurve(pointcurve1);
            }
            path.AddCurve(pointcurve2, 0.7f);
            path.AddCurve(pointcurve3, 0.3f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //点
        private void drawDian(Graphics g)
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
        private void drawTi(Graphics g)
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
        private void drawDianti(Graphics g)
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
        private void drawHengzhegou(Graphics g)
        {
            PointF[] pointdraw = new PointF[3]; //横的一段
            pointdraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointdraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointdraw[0].X - widththin / 2, pointdraw[0].Y - widththin);

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
            pointcurve3[6] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointcurve2);
            path.AddCurve(pointcurve3);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折
        private void drawHengzhe(Graphics g)
        {
            PointF[] pointdraw = new PointF[3]; //横的一段
            pointdraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointdraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointdraw[0].X - widththin / 2, pointdraw[0].Y - widththin);

            PointF[] pointcurve1 = new PointF[4];   //弯头
            pointcurve1[0] = pointline[1];
            pointcurve1[1] = new PointF(pointcurve1[0].X + widththick / 2, pointcurve1[0].Y - widththick / 2);
            pointcurve1[2] = new PointF(points[1].X + widththin, points[1].Y);
            pointcurve1[3] = new PointF(points[1].X, points[1].Y + widththin * (float)Math.Cos(Math.PI / 6));

            PointF[] pointdraw1 = new PointF[4]; //竖由6个点相互连接的线段组成
            pointdraw1[0] = pointcurve1[3];
            pointdraw1[1] = new PointF(points[2].X, points[2].Y - widththick * (float)Math.Sin(Math.PI / 12));
            pointdraw1[2] = new PointF(points[2].X - widththick, points[2].Y);
            pointdraw1[3] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointdraw1, 0.1f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折撇
        private void drawHengzhepie(Graphics g)
        {
            double k = Math.Atan((points[1].X - points[3].X) / (points[3].Y - points[1].Y));   //计算点的总体斜角
            float sink = (float)Math.Sin(k);
            float cosk = (float)Math.Cos(k);

            PointF[] pointdraw = new PointF[3]; //横的一段
            pointdraw[0] = new PointF(points[1].X - widththick, points[1].Y);
            pointdraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointdraw[0].X - widththin / 2, pointdraw[0].Y - widththin);

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
            pointCurve2[2] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve1);
            path.AddCurve(pointCurve1);
            path.AddCurve(pointCurve2);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //竖弯钩
        private void drawShuwangou(Graphics g)
        {
            PointF[] pointdraw = new PointF[4]; //竖由6个点相互连接的线段组成
            pointdraw[0] = new PointF(points[0].X, points[0].Y - widththick * (float)Math.Sin(Math.PI / 12) - widththin);
            pointdraw[1] = new PointF(points[0].X + widththick, points[0].Y - widththin);
            pointdraw[2] = new PointF(pointdraw[1].X + widththin * (float)Math.Cos(Math.PI / 12 + Math.PI / 6),
                                      pointdraw[1].Y + widththin * (float)Math.Sin(Math.PI / 12 + Math.PI / 6));
            pointdraw[3] = new PointF(points[0].X + widththick, pointdraw[1].Y + widththin);

            PointF[] pointcurve1 = new PointF[4];
            pointcurve1[0] = pointdraw[3];
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
            pointcurve2[7] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddCurve(pointcurve1, 0.2f);
            path.AddCurve(pointcurve2, 0.3f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //横折弯钩
        private void drawHengzhewangou(Graphics g)
        {
            PointF[] pointdraw = new PointF[3]; //横的一段
            pointdraw[0] = new PointF(points[1].X, points[1].Y);
            pointdraw[1] = new PointF(points[0].X + widththin * 2, points[0].Y);
            pointdraw[2] = new PointF(points[0].X, points[0].Y + widththin / 4);

            PointF[] pointline = new PointF[2]; //横的一段
            pointline[0] = new PointF(points[0].X - widththin, points[0].Y - widththin);
            pointline[1] = new PointF(pointdraw[0].X - widththin / 2, pointdraw[0].Y - widththin);

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
            pointcurve2[7] = pointdraw[0];

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddCurve(pointdraw);
            path.AddLines(pointline);
            path.AddCurve(pointcurve);
            path.AddCurve(pointcurve1, 0.2f);
            path.AddCurve(pointcurve2, 0.3f);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //细线（横）
        private void drawOthern(Graphics g)
        {
            PointF[] pointdraw = new PointF[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                pointdraw[i] = new PointF(points[i].X, points[i].Y - widththin / 2);
            }
            for (int i = 0; i < points.Count; i++)
            {
                pointdraw[points.Count * 2 - i - 1] = new PointF(points[i].X, points[i].Y + widththin / 2);
            }

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddLines(pointdraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        //粗线（竖）
        private void drawOthert(Graphics g)
        {
            PointF[] pointdraw = new PointF[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                pointdraw[i] = new PointF(points[i].X - widththick / 2, points[i].Y);
            }
            for (int i = 0; i < points.Count; i++)
            {
                pointdraw[points.Count * 2 - i - 1] = new PointF(points[i].X + widththick / 2, points[i].Y);
            }

            SolidBrush brush = new SolidBrush(Color.Black);
            GraphicsPath path = new GraphicsPath();
            //按轮廓顺序加入
            path.AddLines(pointdraw);
            g.FillPath(brush, path);
            path.Dispose();
            brush.Dispose();
        }
        #endregion
    }
}
