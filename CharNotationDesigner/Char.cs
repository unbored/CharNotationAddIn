using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharNotationDesigner
{
    class Char
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

    }
}
