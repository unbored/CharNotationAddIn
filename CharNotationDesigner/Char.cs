using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CharNotationDesigner
{
    struct Container
    {
        public PointF[] corners;
        public bool restrictTop;
        public bool restrictBottom;
    }

    class Char : ICloneable
    {

        string name;
        string charName;
        protected List<Stroke> strokes;
        protected Container rect;
        protected bool restrictTop;   //上方限制
        protected bool restrictBottom;    //下方限制
        protected bool isMain;    //是否为主减字
        protected bool isComplex; //是否为双弦减字

        public Char()
        {
            name = "";
            charName = "";
            strokes = new List<Stroke>();
            rect.corners = new PointF[2];
            rect.corners[0] = new PointF(50, 50);
            rect.corners[1] = new PointF(150, 150);
            rect.restrictTop = false;
            rect.restrictBottom = false;
            restrictTop = false;
            restrictBottom = false;
            isMain = false;
            isComplex = false;
        }
        /// <summary>
        /// 拷贝构造函数，执行浅拷贝
        /// </summary>
        /// <param name="c"></param>
        public Char(Char c)
        {
            name = c.name;
            charName = c.CharName;
            strokes = new List<Stroke>(c.Strokes);
            rect = c.rect;
            restrictTop = c.restrictTop;
            restrictBottom = c.restrictBottom;
            isMain = c.isMain;
            isComplex = c.isComplex;
        }
        ~Char()
        {
            strokes.Clear();
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string CharName
        {
            get { return charName; }
            set { charName = value; }
        }
        public List<Stroke> Strokes
        {
            get { return strokes; }
            set 
            { 
                strokes.Clear();
                strokes = new List<Stroke>(value);
            }
        }
        public Container Rect
        {
            get { return rect; }
            set { rect = value; }
        }
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }
        public bool IsComplex
        {
            get { return isComplex; }
            set { isComplex = value; }
        }
        /// <summary>
        /// 对笔画执行深拷贝
        /// </summary>
        /// <returns></returns>
        public List<Stroke> CloneStrokes()
        {
            List<Stroke> result = new List<Stroke>();
            strokes.ForEach(i => result.Add(i.Clone() as Stroke));
            return result;
        }
        public Container CloneRect()
        {
            Container newRect = new Container();
            newRect.corners = rect.corners;
            newRect.restrictTop = rect.restrictTop;
            newRect.restrictBottom = rect.restrictBottom;
            return newRect;
        }
        /// <summary>
        /// 深拷贝
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Char result = new Char();
            result.name = name;
            result.charName = charName;
            result.strokes = CloneStrokes();
            result.restrictTop = restrictTop;
            result.restrictBottom = restrictBottom;
            result.isMain = isMain;
            result.isComplex = isComplex;
            for (int i = 0; i < 2; i++)
            {
                result.rect.corners[i].X = rect.corners[i].X;
                result.rect.corners[i].Y = rect.corners[i].Y;
            }
            result.rect.restrictTop = rect.restrictTop;
            result.rect.restrictBottom = rect.restrictBottom;
            return result;
        }
    }
}
