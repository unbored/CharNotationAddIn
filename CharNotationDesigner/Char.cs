using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CharNotationDesigner
{
    /// <summary>
    /// 主减字用于容纳其他减字的容器。
    /// </summary>
    struct Container
    {
        public PointF[] corners;    //指定了矩形框的两个顶点
        public bool restrictTop;    //指定了容器上方的限制
        public bool restrictBottom; //指定了容器下方的限制
    }

    class Char : ICloneable
    {

        protected string name;
        protected string charName;
        protected List<Stroke> strokes;
        protected Container rect;
        protected int segment;
        protected bool restrictTop;   //上方限制
        protected bool restrictBottom;    //下方限制
        protected bool isMain;    //是否为主减字
        protected bool isComplex; //是否为双弦减字
        /// <summary>
        /// 初始化一个减字，该减字名字为空。
        /// </summary>
        public Char()
        {
            name = "";
            charName = "";
            strokes = new List<Stroke>();
            rect.corners = new PointF[2];
            rect.corners[0] = new PointF(50, 50);
            rect.corners[1] = new PointF(150, 150);
            segment = 0;
            rect.restrictTop = false;
            rect.restrictBottom = false;
            restrictTop = false;
            restrictBottom = false;
            isMain = false;
            isComplex = false;
        }
        /// <summary>
        /// 复制构造函数，执行浅复制。
        /// </summary>
        /// <param name="c"></param>
        public Char(Char c)
        {
            name = c.name;
            charName = c.CharName;
            strokes = new List<Stroke>(c.Strokes);
            rect = c.rect;
            segment = c.segment;
            restrictTop = c.restrictTop;
            restrictBottom = c.restrictBottom;
            isMain = c.isMain;
            isComplex = c.isComplex;
        }
        ~Char()
        {
            strokes.Clear();
        }
        /// <summary>
        /// 设置减字代码名称。
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 设置减字文字名称。
        /// </summary>
        public string CharName
        {
            get { return charName; }
            set { charName = value; }
        }
        /// <summary>
        /// 获取笔画列表。
        /// </summary>
        public List<Stroke> Strokes
        {
            get { return strokes; }
        }
        /// <summary>
        /// 获取内容框。
        /// </summary>
        public Container Rect
        {
            get { return rect; }
        }
        /// <summary>
        /// 获取或设置该减字所占行数
        /// </summary>
        public int Segment
        {
            get { return segment; }
            set { segment = value; }
        }
        /// <summary>
        /// 获取或设置是否为主减字的标识。
        /// </summary>
        public bool IsMain
        {
            get { return isMain; }
            set { isMain = value; }
        }
        /// <summary>
        /// 获取或设置是否为双弦减字的标识。
        /// </summary>
        public bool IsComplex
        {
            get { return isComplex; }
            set { isComplex = value; }
        }
        public bool RestrictTop
        {
            get { return restrictTop; }
            set { restrictTop = value; }
        }
        public bool RestrictBottom
        {
            get { return restrictBottom; }
            set { restrictBottom = value; }
        }
        public bool RestrictTopRect
        {
            get { return rect.restrictTop; }
            set { rect.restrictTop = value; }
        }
        public bool RestrictBottomRect
        {
            get { return rect.restrictBottom; }
            set { rect.restrictBottom = value; }
        }
        /// <summary>
        /// 对笔画执行深复制。
        /// </summary>
        /// <returns></returns>
        List<Stroke> CloneStrokes()
        {
            List<Stroke> result = new List<Stroke>();
            strokes.ForEach(i => result.Add(i.Clone() as Stroke));
            return result;
        }
        /// <summary>
        /// 对内容框执行深复制。
        /// </summary>
        /// <returns></returns>
        Container CloneRect()
        {
            Container newRect = new Container();
            newRect.corners = new PointF[2];
            for (int i = 0; i < 2; i++)
            {
                newRect.corners[i].X = rect.corners[i].X;
                newRect.corners[i].Y = rect.corners[i].Y;
            }
            newRect.restrictTop = rect.restrictTop;
            newRect.restrictBottom = rect.restrictBottom;
            return newRect;
        }
        /// <summary>
        /// 执行深复制。
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Char result = new Char();
            result.name = String.Copy(name);
            result.charName = String.Copy(charName);
            result.strokes = CloneStrokes();
            result.rect = CloneRect();
            result.segment = segment;
            result.restrictTop = restrictTop;
            result.restrictBottom = restrictBottom;
            result.isMain = isMain;
            result.isComplex = isComplex;
            return result;
        }
    }
}
