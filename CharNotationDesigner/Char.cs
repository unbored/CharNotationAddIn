using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharNotationDesigner
{
    class Char : ICloneable
    {
        string name;
        string charName;
        List<Stroke> strokes;

        public Char()
        {
            name = "";
            charName = "";
            strokes = new List<Stroke>();
        }
        public Char(Char c)
        {
            name = c.name;
            charName = c.CharName;
            strokes = new List<Stroke>(c.Strokes);
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
        public List<Stroke> CloneStrokes()
        {
            List<Stroke> result = new List<Stroke>();
            strokes.ForEach(i => result.Add(i.Clone() as Stroke));
            return result;
        }

        public object Clone()
        {
            Char result = new Char();
            result.name = name;
            result.charName = charName;
            result.strokes = CloneStrokes();
            return result;
        }

    }
}
