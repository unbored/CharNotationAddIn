using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Office.Tools.Word;
using Microsoft.VisualStudio.Tools.Applications.Runtime;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace CharNotationAddIn
{
    public partial class ThisDocument
    { 
        public CharPreview panel = new CharPreview();
        private void ThisDocument_Startup(object sender, System.EventArgs e)
        {
            this.ActionsPane.Controls.Add(panel);
            panel.Hide();
            this.Application.TaskPanes[Word.WdTaskPanes.wdTaskPaneDocumentActions].Visible = false;
        }

        private void ThisDocument_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO 设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisDocument_Startup);
            this.Shutdown += new System.EventHandler(ThisDocument_Shutdown);
        }

        #endregion
    }
}
