using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;

namespace CharNotationAddIn
{
    public partial class Ribbon1
    {
        
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisDocument.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = true;
            Globals.ThisDocument.panel.Show();
        }
    }
}
