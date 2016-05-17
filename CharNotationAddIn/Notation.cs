using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Drawing;

namespace CharNotation
{
    enum charType { DAN, SHUANG, XIUSHI };
    struct Trans
    {
        public float scalex, scaley, offsetx, offsety;
        public Trans(float sx = 1.0f, float sy = 1.0f, float ox = 0.0f, float oy = 0.0f)
        {
            scalex = sx;
            scaley = sy;
            offsetx = ox;
            offsety = oy;
        }
        
        //======与Trans结构体相关的*运算符重载，先缩放后平移=====================
        public static PointF operator *(PointF p, Trans t)    //与点的变换
        {
            return new PointF(p.X * t.scalex + t.offsetx, 
                                p.Y * t.scaley + t.offsety);
        }
        public static List<PointF> operator *(List<PointF> p, Trans t)   //与点列表的变换
        {
            List<PointF> result = new List<PointF>();
            foreach (PointF i in p)
                result.Add(i * t);
            return result;
        }
        public static Stroke operator *(Stroke s, Trans t) //与笔画部件的变换
        {
            Stroke result = new Stroke(s);
            result.points *= t;
            return result;
        }
        public static List<Stroke> operator *(List<Stroke> s, Trans t) //与部件列表的变换
        {
            List<Stroke> result = new List<Stroke>();
            foreach (Stroke i in s)
                result.Add(i * t);
            return result;
        }
        //====================================================================
    }

    struct Notastring
    {
        public enum partName { LEFT, RIGHT, RIGHT1, RIGHT2, DECORATION };   //左手，右手，双弦1，双弦2，修饰
        public string[] parts;  //分部分存储
    }

    public class Notation
    {
        private charType type;   //指法类型：单弦、双弦、修饰
        private Notastring originstrings;
        private List<Stroke> drawable;

        public Notation()
        {
            type = charType.DAN;
            drawable = new List<Stroke>();
        }

        ~ Notation()
        {
            drawable.Clear();
        }

        public static Notation processString(string s)  //将整个输入字符串分割好
        {
            Notation result = new Notation();
            string[] str = s.Split(':'); //根据':'分割出类型字串
            int position;
            if (str.Length == 1)    //没有':'，则类型字串不存在，默认单弦指法
            {
                result.type = charType.DAN;
                position = 0;
            }
            else
            {
                switch (str[0]) //检测类型
                {
                    case "S":   //双弦指法
                        result.type = charType.SHUANG;
                        break;
                    case "X":   //修饰指法
                        result.type = charType.XIUSHI;
                        break;
                    case "D":   //单弦指法
                    default:    //无法检测类型，默认单弦指法
                        result.type = charType.DAN;
                        break;
                }
                position = 1;
            }
            string[] partString = str[position].Split(','); //根据','分割出各部分

            //初始化
            result.originstrings.parts = new string[System.Enum.GetNames(typeof(Notastring.partName)).Length]; //根据枚举数量创建字符串数组
            for (int i = 0; i < result.originstrings.parts.Length; i++)
                result.originstrings.parts[i] = "";
            if (result.type == charType.XIUSHI && partString.Length > 0)  //纯修饰指法
            {
                result.originstrings.parts[(int)Notastring.partName.DECORATION] = partString[0];
            }
            else
            {
                //根据分割长度决定内容
                switch (partString.Length)
                {
                    case 1: //只有一段，主字

                        result.originstrings.parts[(int)Notastring.partName.RIGHT] = partString[0];
                        break;
                    case 2: //两段，左手+右手主字
                        result.originstrings.parts[(int)Notastring.partName.LEFT] = partString[0];
                        result.originstrings.parts[(int)Notastring.partName.RIGHT] = partString[1];
                        break;
                    case 3: //三段
                        if (result.type == charType.DAN)    //单弦指法，左手+右手+修饰
                        {
                            result.originstrings.parts[(int)Notastring.partName.LEFT] = partString[0];
                            result.originstrings.parts[(int)Notastring.partName.RIGHT] = partString[1];
                            result.originstrings.parts[(int)Notastring.partName.DECORATION] = partString[2];
                        }
                        else if (result.type == charType.SHUANG)    //双弦指法，右手+两弦
                        {
                            result.originstrings.parts[(int)Notastring.partName.RIGHT] = partString[0];
                            result.originstrings.parts[(int)Notastring.partName.RIGHT1] = partString[1];
                            result.originstrings.parts[(int)Notastring.partName.RIGHT2] = partString[2];
                        }
                        break;
                    case 4:
                        if (result.type == charType.SHUANG) //双弦指法，右手+两弦+修饰
                        {
                            result.originstrings.parts[(int)Notastring.partName.RIGHT] = partString[0];
                            result.originstrings.parts[(int)Notastring.partName.RIGHT1] = partString[1];
                            result.originstrings.parts[(int)Notastring.partName.RIGHT2] = partString[2];
                            result.originstrings.parts[(int)Notastring.partName.DECORATION] = partString[3];
                        }
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        //左手字符串处理
        private List<Stroke> charLeft()
        {
            List<Stroke> result = new List<Stroke>();
            string s = originstrings.parts[(int)Notastring.partName.LEFT];
            bool existnumber = true;
            if ( s != "")   //不为空
            {
                switch (s[0])
                {
                    case 'S':   //散音
                        result.AddRange(Stroke.sanyin());
                        existnumber = false;
                        break;
                    case 'J':   //就
                        result.AddRange(Stroke.jiu());
                        existnumber = false;
                        break;
                    case 'd':   //大指，有数字
                        result.AddRange(Stroke.dazhi());
                        break;
                    case 's':   //食指，有数字
                        result.AddRange(Stroke.shizhi());
                        break;
                    case 'z':   //中指，有数字
                        result.AddRange(Stroke.zhongzhi());
                        break;
                    case 'm':   //名指，有数字
                        result.AddRange(Stroke.mingzhi());
                        break;
                    case 'g':   //跪指，有数字
                        result.AddRange(Stroke.guizhi());
                        break;
                    default:
                        break;
                }
                if (existnumber && s.Length > 1)    //有数字，继续添加
                {
                    result *= new Trans(sx: 0.45f, ox: 0.03f);  //缩至左半边
                    List<Stroke> r1;
                    r1 = Stroke.number(s[1]);
                    if (s.Length > 2 && s[1] != 'w')    //有第二个数字且第一个不是徽外。忽略第二个数字后面的字符
                    {
                        r1 *= new Trans(sy: 0.5f);  //缩至上半边
                        r1.AddRange(Stroke.number(s[2]) * new Trans(sy: 0.5f, oy: 0.5f));   //第二个数字，缩至下半边
                    }
                    result.AddRange(r1 * new Trans(sx: 0.45f, ox: 0.48f));    //数字缩至右半边
                    r1.Clear();
                }
            }
            return result;
        }
        //主字字符串处理
        private List<Stroke> charRight()
        {
            List<Stroke> result = new List<Stroke>();
            if (type == charType.DAN)   //单弦指法。数字必须存在
            {
                string s = originstrings.parts[(int)Notastring.partName.RIGHT];
                if (s != "")
                {
                    int numberpos = 0;
                    Trans t = new Trans(sx: 1.0f);
                    if (s.Length > 1)   //指法+数字，至少两位
                    {
                        numberpos = 1;  //指定数字位置
                        if (s[0] == '=' && s.Length >= 4) //双字指法且信息完整
                        {
                            numberpos = 3;  //数字在第3位
                            switch (s.Substring(1, 2))  //取二三位
                            {
                                case "to":  //托
                                    result.AddRange(Stroke.tuo());
                                    t = new Trans(0.62f, 0.85f, 0.31f, 0.00f);
                                    break;
                                case "mt":  //抹挑
                                    break;

                                default:
                                    break;
                            }
                        }
                        else//单字指法
                        {
                            switch (s[0])
                            {
                                case 'p':   //劈
                                    result.AddRange(Stroke.pi());
                                    t = new Trans(0.75f, 0.70f, 0.20f, 0.29f);
                                    break;
                                case 'm':   //抹
                                    result.AddRange(Stroke.mo());
                                    t = new Trans(0.86f, 0.54f, 0.07f, 0.46f);
                                    break;
                                case 't':   //挑
                                    result.AddRange(Stroke.tiao());
                                    t = new Trans(0.71f, 0.85f, 0.15f, 0.00f);
                                    break;
                                case 'g':   //勾
                                    result.AddRange(Stroke.gou());
                                    t = new Trans(0.70f, 0.56f, 0.10f, 0.24f);
                                    break;
                                case 'T':   //踢
                                    result.AddRange(Stroke.ti());
                                    t = new Trans(0.65f, 0.48f, 0.16f, 0.37f);
                                    break;
                                //case 'd':
                                //    result.AddRange(Stroke.ti());
                                //    t = new Trans(0.60f, 0.48f, 0.20f, 0.37f);
                                //    break;
                                case 'y':   //罨
                                    result.AddRange(Stroke.yan());
                                    t = new Trans(1.00f, 0.54f, 0.00f, 0.46f);
                                    break;
                                case 'l':   //历
                                    result.AddRange(Stroke.li());
                                    t = new Trans(0.7f, 0.7f, 0.25f, 0.22f);
                                    break;
                                default:
                                    break;
                            }
                        }
                        List<Stroke> r1 = Stroke.number(s[numberpos]); //临时存放数字用
                        if (s[0] == 'l' && s.Length > 2) //历指法允许第二个数字
                        {
                            r1 *= new Trans(sy: 0.5f);   //上半
                            r1.AddRange(Stroke.number(s[numberpos + 1]) * new Trans(sy: 0.5f, oy: 0.5f)); //第二个数字，下半
                            t = new Trans(0.7f, 0.86f, 0.25f, 0.14f);
                        }
                        result.AddRange(r1 * t);
                        r1.Clear();
                    }
                    else if (s[0] == 'q') //搯起
                    {
                        result.AddRange(Stroke.qiaqi());
                    }
                }
            }
            else if (type == charType.SHUANG)
            {

            }
            return result;
        }
        //修饰字符串处理
        private List<Stroke> charDecoration()
        {
            List<Stroke> result = new List<Stroke>();
            string s = originstrings.parts[(int)Notastring.partName.DECORATION];
            if (s != "")
            {
                int charCount = 0;
                int charPos = 0;
                while (charPos < s.Length && charCount < 4) //只处理最多4个减字
                {
                    result *= new Trans(oy: -1.0f); //将已有减字向上移一个字
                    if (s[charPos] == '=')  //双字
                    {
                        charPos++;  //跳过=号
                        if (s.Length - charPos >= 2) //后面还有至少两个字符
                        {
                            switch (s.Substring(charPos, 2))
                            {
                                case "fk":   //分开
                                    result.AddRange(Stroke.fenkai());
                                    break;
                                case "sx":   //少息
                                    result.AddRange(Stroke.chuo());
                                    break;
                                case "ry":   //如一
                                    result.AddRange(Stroke.chuo());
                                    break;
                                default:
                                    break;
                            }
                            charPos += 2;   //双字移两格
                        }
                    }
                    else
                    {
                        switch (s[charPos])
                        {
                            case 's':   //上
                                result.AddRange(Stroke.shang());
                                break;
                            case 'X':   //下
                                result.AddRange(Stroke.xia());
                                break;
                            case 'j':   //进
                                result.AddRange(Stroke.jin());
                                break;
                            case 't':   //退
                                result.AddRange(Stroke.tui());
                                break;
                            case 'f':   //复
                                result.AddRange(Stroke.fu());
                                break;
                            case 'y':   //吟
                                result.AddRange(Stroke.yin());
                                break;
                            case 'n':   //猱
                                result.AddRange(Stroke.zhu());
                                break;
                            case 'z':   //撞
                                result.AddRange(Stroke.zhu());
                                break;
                            case 'd':   //逗
                                result.AddRange(Stroke.zhu());
                                break;
                            case 'S':   //散音
                                result.AddRange(Stroke.sanyin());
                                break;
                            case 'J':   //就
                                result.AddRange(Stroke.jiu());
                                break;
                            default:    //数字（十：x，外：w，半：b)
                                result.AddRange(Stroke.number(s[charPos]));
                                break;
                        }
                        charPos++;  //单字移一格
                    }
                    charCount++;    //字符计数
                }
                if(charCount < 2)   //单个减字
                {
                    result *= new Trans(0.5f, 0.5f, 0.0f, 0.5f);
                    foreach (Stroke st in result)
                        st.scale *= 0.5f;
                }
                else    //两个及以上
                {
                    result *= new Trans(oy: -1.0f);
                    result *= new Trans(1.0f / charCount, 1.0f / charCount, 0, 1.0f);
                    foreach (Stroke st in result)
                        st.scale *= 1.0f / charCount;
                }
            }
            return result;
        }

        public void characterize(float size)
        {
            if (type == charType.DAN)
            {
                List<Stroke> left = charLeft();
                List<Stroke> right = charRight();
                List<Stroke> decoration = new List<Stroke>();
                string strDeco = originstrings.parts[(int)Notastring.partName.DECORATION];
                if (strDeco != "")
                {
                    Trans td = new Trans(1.0f);
                    Trans tr = new Trans(1.0f);
                    switch (strDeco[0])
                    {
                        case 'c':   //绰
                            decoration.AddRange(Stroke.chuo());
                            td = new Trans(0.7f, 0.27f, 0.13f, 0.0f);
                            tr = new Trans(sy: 0.85f, oy: 0.15f);
                            break;
                        case 'z':   //注
                            decoration.AddRange(Stroke.zhu());
                            td = new Trans(sx: 0.28f);
                            tr = new Trans(sx: 0.75f, ox: 0.25f);
                            break;
                        default:
                            break;
                    }
                    right *= tr;
                    right.AddRange(decoration * td);
                }
                foreach (Stroke s in left)
                {
                    float scale = 0.9f;
                    if (left.Count > 0)
                        scale -= (float)Math.Pow(1.1, left.Count) / 10; //笔画越多，缩放越小（不宜超过40笔）
                    s.scale *= scale;
                }
                foreach (Stroke s in right)
                {
                    float scale = 1.0f;
                    if (right.Count > 0)
                        scale -= (float)Math.Pow(1.02, right.Count) / 10; //笔画越多，缩放越小（不宜超过40笔）
                    s.scale *= scale;
                }
                if (left.Count > 0)
                {
                    drawable.AddRange(left * new Trans(sy: 0.35f));
                    drawable.AddRange(right * new Trans(sy: 0.67f, oy: 0.33f));
                }
                else
                {
                    drawable.AddRange(right);
                }
            }
            else if (type == charType.SHUANG)
            {

            }
            else if (type == charType.XIUSHI)
            {
                drawable.AddRange(charDecoration());
            }
            drawable *= new Trans(size, size);
        }

        public void draw(Graphics g, float widththin = 3.0f, float widththick = 8.0f)
        {
            g.Clear(Color.White);
            foreach (Stroke s in drawable)
            {
                s.setWidth(widththin, widththick);
                s.draw(g);
            }
        }

        public static List<Notation> readNotation()
        {
            List<Notation> result = new List<Notation>();
            StreamReader strfile = new StreamReader("notation.txt");
            string filestring = strfile.ReadToEnd();  //整个文件读入字符串
            char[] ch = new char[] { ';', ' ' };    //设定分隔符
            string[] originString = filestring.Split(ch, StringSplitOptions.RemoveEmptyEntries);  //根据分隔符分割字符串，忽略空字符串
            foreach (string s in originString)
            {
                Notation n = processString(s);
                if (n != null)  //指法有效
                    result.Add(n);
            }
            return result;
        }
    }
}
