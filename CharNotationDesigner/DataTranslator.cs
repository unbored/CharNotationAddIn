using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharNotationDesigner
{
    class DataTranslator
    {
        CharNotationDataSet.CharDataTable charTable;
        CharNotationDataSet.StrokeDataTable strokeTable;
        CharNotationDataSet.PointDataTable pointTable;
        CharNotationDataSetTableAdapters.CharTableAdapter charAdapter;
        CharNotationDataSetTableAdapters.StrokeTableAdapter strokeAdapter;
        CharNotationDataSetTableAdapters.PointTableAdapter pointAdapter;
        bool isModified;

        public DataTranslator()
        {
            charAdapter = new CharNotationDataSetTableAdapters.CharTableAdapter();
            strokeAdapter = new CharNotationDataSetTableAdapters.StrokeTableAdapter();
            pointAdapter = new CharNotationDataSetTableAdapters.PointTableAdapter();
            charTable = charAdapter.GetData();
            strokeTable = strokeAdapter.GetData();
            pointTable = pointAdapter.GetData();
            isModified = false;
        }
        ~DataTranslator()
        {
            charTable.Dispose();
            strokeTable.Dispose();
            pointTable.Dispose();
            charAdapter.Dispose();
            strokeAdapter.Dispose();
            pointAdapter.Dispose();
        }

        public CharNotationDataSet.CharDataTable CharTable
        {
            get { return charTable; }
        }
        public bool IsModified
        {
            get { return isModified; }
        }
        /// <summary>
        /// 获取当前选定行的减字
        /// </summary>
        /// <param name="charName"></param>
        /// <returns></returns>
        public Char GetChar(CharNotationDataSet.CharRow currentRow)
        {
            Char result = new Char();
            //找到当前减字，并将信息传入
            //CharNotationDataSet.CharRow currentRow = charTable.FindBychar_name(charName);
            //if (currentRow == null)
            //    return null;
            result.Name = currentRow.name.Trim();
            result.CharName = currentRow.char_name.Trim();
            result.RestrictTop = currentRow.restrict_top;
            result.RestrictBottom = currentRow.restrict_bottom;
            result.RestrictTopRect = currentRow.rect_resrict_top;
            result.RestrictBottomRect = currentRow.rect_restrict_bottom;
            result.Segment = currentRow.segment;
            result.IsMain = currentRow.is_main;
            result.IsComplex = currentRow.is_complex;

            //内容框
            CharNotationDataSet.PointRow rectPoint = pointTable.FindByIdstroke_idchar_name(0, -1, currentRow.char_name);
            result.Rect.corners[0].X = (float)rectPoint.x;
            result.Rect.corners[0].Y = (float)rectPoint.y;
            rectPoint = pointTable.FindByIdstroke_idchar_name(1, -1, currentRow.char_name);
            result.Rect.corners[1].X = (float)rectPoint.x;
            result.Rect.corners[1].Y = (float)rectPoint.y;

            //找到当前减字所属笔画，并将信息传入
            List<Stroke> strokes = new List<Stroke>();
            int strokeID = 0;
            while(true)
            {
                CharNotationDataSet.StrokeRow currentStroke = strokeTable.FindByIdchar_name(strokeID, currentRow.char_name);
                if (currentStroke == null)
                    break;          
                Stroke targetStroke = new Stroke((strokeType)currentStroke.type);
                //找到当前笔画所述点，并将信息传入
                List<System.Drawing.PointF> points = new List<System.Drawing.PointF>();
                int pointID = 0;
                while(true)
                {
                    CharNotationDataSet.PointRow currentPoint = pointTable.FindByIdstroke_idchar_name(pointID, strokeID, currentRow.char_name);
                    if (currentPoint == null)   //找不到对应点
                        break;
                    System.Drawing.PointF targetPoint = new System.Drawing.PointF();
                    targetPoint.X = (float)currentPoint.x;
                    targetPoint.Y = (float)currentPoint.y;
                    points.Add(targetPoint);    //将找到的点存入列表
                    pointID++;
                }
                targetStroke.Points = points;   //将点列表存入笔画
                strokes.Add(targetStroke);
                strokeID++;
            }
            result.Strokes = strokes;

            return result;
        }
        public void AddChar(Char newChar)
        {
            CharNotationDataSet.CharRow newCharRow;
            CharNotationDataSet.StrokeRow newStrokeRow;
            CharNotationDataSet.PointRow newPointRow;

            newCharRow = charTable.NewCharRow();
            newCharRow.name = newChar.Name;
            newCharRow.char_name = newChar.CharName;
            newCharRow.restrict_top = newChar.RestrictTop;
            newCharRow.restrict_bottom = newChar.RestrictBottom;
            newCharRow.rect_resrict_top = newChar.RestrictTopRect;
            newCharRow.rect_restrict_bottom = newChar.RestrictBottomRect;
            newCharRow.is_main = newChar.IsMain;
            newCharRow.is_complex = newChar.IsComplex;
            newCharRow.segment = newChar.Segment;
            charTable.AddCharRow(newCharRow);

            for (int s = 0; s < newChar.Strokes.Count; s++)
            {
                newStrokeRow = strokeTable.NewStrokeRow();
                newStrokeRow.Id = s;
                newStrokeRow.char_name = newChar.CharName;
                newStrokeRow.type = (int)newChar.Strokes[s].Type;
                strokeTable.AddStrokeRow(newStrokeRow);

                for (int p = 0; p < newChar.Strokes[s].Points.Count; p++)
                {
                    newPointRow = pointTable.NewPointRow();
                    newPointRow.Id = p;
                    newPointRow.stroke_id = s;
                    newPointRow.char_name = newChar.CharName;
                    newPointRow.x = newChar.Strokes[s].Points[p].X;
                    newPointRow.y = newChar.Strokes[s].Points[p].Y;
                    pointTable.AddPointRow(newPointRow);
                }
            }
            //内容框
            newPointRow = pointTable.NewPointRow();
            newPointRow.Id = 0;
            newPointRow.stroke_id = -1;
            newPointRow.char_name = newChar.CharName;
            newPointRow.x = newChar.Rect.corners[0].X;
            newPointRow.y = newChar.Rect.corners[0].Y;
            pointTable.AddPointRow(newPointRow);
            newPointRow = pointTable.NewPointRow();
            newPointRow.Id = 1;
            newPointRow.stroke_id = -1;
            newPointRow.char_name = newChar.CharName;
            newPointRow.x = newChar.Rect.corners[1].X;
            newPointRow.y = newChar.Rect.corners[1].Y;
            pointTable.AddPointRow(newPointRow);

            isModified = true;
        }
        public void RemoveChar(CharNotationDataSet.CharRow currentRow)
        {
            int strokeID = 0;
            while (true)
            {
                CharNotationDataSet.StrokeRow currentStroke = strokeTable.FindByIdchar_name(strokeID, currentRow.char_name);
                if (currentStroke == null)
                    break;
                int pointID = 0;
                while (true)
                {
                    CharNotationDataSet.PointRow currentPoint = pointTable.FindByIdstroke_idchar_name(pointID, strokeID, currentRow.char_name);
                    if (currentPoint == null)   //找不到对应点
                        break;
                    currentPoint.Delete();
                    pointID++;
                }
                currentStroke.Delete();
                strokeID++;
            }
            //删除内容框
            CharNotationDataSet.PointRow rectPoint = pointTable.FindByIdstroke_idchar_name(0, -1, currentRow.char_name);
            rectPoint.Delete();
            rectPoint = pointTable.FindByIdstroke_idchar_name(1, -1, currentRow.char_name);
            rectPoint.Delete();
            currentRow.Delete();

            isModified = true;
        }
        /// <summary>
        /// 修改减字。
        /// <para>实际上是移除对应减字后再添加一个同名的。</para>
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="currentChar"></param>
        public void ModChar(CharNotationDataSet.CharRow currentRow, Char currentChar)
        {
            RemoveChar(currentRow);
            AddChar(currentChar);

            isModified = true;
        }
        public void Update()
        {
            charAdapter.Update(charTable);
            strokeAdapter.Update(strokeTable);
            pointAdapter.Update(pointTable);

            isModified = false;
        }
    }
}
