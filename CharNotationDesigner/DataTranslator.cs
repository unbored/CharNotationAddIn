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

        public DataTranslator()
        {
            charAdapter = new CharNotationDataSetTableAdapters.CharTableAdapter();
            strokeAdapter = new CharNotationDataSetTableAdapters.StrokeTableAdapter();
            pointAdapter = new CharNotationDataSetTableAdapters.PointTableAdapter();
            charTable = charAdapter.GetData();
            strokeTable = strokeAdapter.GetData();
            pointTable = pointAdapter.GetData();
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
    }
}
