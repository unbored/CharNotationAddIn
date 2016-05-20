namespace CharNotationDesigner
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lstChar = new System.Windows.Forms.ListBox();
            this.lbCharName = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.chkMain = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbName = new System.Windows.Forms.Label();
            this.chkComplex = new System.Windows.Forms.CheckBox();
            this.comboStrokes = new System.Windows.Forms.ComboBox();
            this.btnAddStroke = new System.Windows.Forms.Button();
            this.btnAddChar = new System.Windows.Forms.Button();
            this.btnDelStroke = new System.Windows.Forms.Button();
            this.btnClearChar = new System.Windows.Forms.Button();
            this.btnDelChar = new System.Windows.Forms.Button();
            this.btnModChar = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbChooseStroke = new System.Windows.Forms.Label();
            this.picBoxEditor = new System.Windows.Forms.PictureBox();
            this.toolTipWarning = new System.Windows.Forms.ToolTip(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbRef = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // lstChar
            // 
            this.lstChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstChar.FormattingEnabled = true;
            this.lstChar.ItemHeight = 12;
            this.lstChar.Location = new System.Drawing.Point(12, 36);
            this.lstChar.Name = "lstChar";
            this.lstChar.Size = new System.Drawing.Size(60, 364);
            this.lstChar.Sorted = true;
            this.lstChar.TabIndex = 12;
            this.toolTip1.SetToolTip(this.lstChar, "指法减字列表。\r\n该列表显示存在数据库当中的减字部件。");
            this.lstChar.SelectedIndexChanged += new System.EventHandler(this.lstChar_SelectedIndexChanged);
            // 
            // lbCharName
            // 
            this.lbCharName.AutoSize = true;
            this.lbCharName.Location = new System.Drawing.Point(203, 16);
            this.lbCharName.Name = "lbCharName";
            this.lbCharName.Size = new System.Drawing.Size(53, 12);
            this.lbCharName.TabIndex = 1;
            this.lbCharName.Text = "减字名称";
            this.toolTip1.SetToolTip(this.lbCharName, "减字的名称。\r\n方便辨识，并无代码意义。");
            // 
            // txtCharName
            // 
            this.txtCharName.Location = new System.Drawing.Point(262, 13);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(59, 21);
            this.txtCharName.TabIndex = 1;
            // 
            // chkMain
            // 
            this.chkMain.AutoSize = true;
            this.chkMain.Location = new System.Drawing.Point(80, 51);
            this.chkMain.Name = "chkMain";
            this.chkMain.Size = new System.Drawing.Size(60, 16);
            this.chkMain.TabIndex = 2;
            this.chkMain.Text = "主指法";
            this.toolTip1.SetToolTip(this.chkMain, "是否主指法。\r\n主指法指的是与弦号一起使用的右手指法，如勾、蠲、轮等。");
            this.chkMain.UseVisualStyleBackColor = true;
            this.chkMain.CheckedChanged += new System.EventHandler(this.chkMain_CheckedChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(78, 16);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(53, 12);
            this.lbName.TabIndex = 4;
            this.lbName.Text = "代码名称";
            this.toolTip1.SetToolTip(this.lbName, "程序当中的代码名称。\r\n用于在程序当中找到对应减字，建议只用ASCII字符。");
            // 
            // chkComplex
            // 
            this.chkComplex.AutoSize = true;
            this.chkComplex.Enabled = false;
            this.chkComplex.Location = new System.Drawing.Point(146, 51);
            this.chkComplex.Name = "chkComplex";
            this.chkComplex.Size = new System.Drawing.Size(72, 16);
            this.chkComplex.TabIndex = 3;
            this.chkComplex.Text = "双弦指法";
            this.toolTip1.SetToolTip(this.chkComplex, "是否双弦指法。\r\n双弦指法指的是需要标记两根弦的指法，如撮、泼等。\r\n双弦指法必然是主指法。");
            this.chkComplex.UseVisualStyleBackColor = true;
            this.chkComplex.CheckedChanged += new System.EventHandler(this.chkComplex_CheckedChanged);
            // 
            // comboStrokes
            // 
            this.comboStrokes.FormattingEnabled = true;
            this.comboStrokes.Items.AddRange(new object[] {
            "横",
            "斜横",
            "无头横",
            "竖",
            "无头竖",
            "撇",
            "捺",
            "无头捺",
            "点",
            "提",
            "点提",
            "横折",
            "横折钩",
            "横折弯钩",
            "横折撇",
            "竖勾",
            "竖弯钩"});
            this.comboStrokes.Location = new System.Drawing.Point(199, 86);
            this.comboStrokes.Name = "comboStrokes";
            this.comboStrokes.Size = new System.Drawing.Size(57, 20);
            this.comboStrokes.TabIndex = 4;
            this.toolTip1.SetToolTip(this.comboStrokes, "可用笔画列表。\r\n列表列出了可用的笔画。\r\n选择一个并点击右方的“添加”按钮\r\n可将该笔画添加进编辑框中。");
            // 
            // btnAddStroke
            // 
            this.btnAddStroke.Location = new System.Drawing.Point(262, 84);
            this.btnAddStroke.Name = "btnAddStroke";
            this.btnAddStroke.Size = new System.Drawing.Size(59, 23);
            this.btnAddStroke.TabIndex = 5;
            this.btnAddStroke.Text = "添加";
            this.toolTip1.SetToolTip(this.btnAddStroke, "将所选笔画添加到编辑框中");
            this.btnAddStroke.UseVisualStyleBackColor = true;
            this.btnAddStroke.Click += new System.EventHandler(this.btnAddStroke_Click);
            // 
            // btnAddChar
            // 
            this.btnAddChar.Location = new System.Drawing.Point(82, 377);
            this.btnAddChar.Name = "btnAddChar";
            this.btnAddChar.Size = new System.Drawing.Size(82, 23);
            this.btnAddChar.TabIndex = 8;
            this.btnAddChar.Text = "<< 添加减字";
            this.toolTip1.SetToolTip(this.btnAddChar, "将当前减字添加到库中");
            this.btnAddChar.UseVisualStyleBackColor = true;
            this.btnAddChar.Click += new System.EventHandler(this.btnAddChar_Click);
            // 
            // btnDelStroke
            // 
            this.btnDelStroke.Location = new System.Drawing.Point(189, 341);
            this.btnDelStroke.Name = "btnDelStroke";
            this.btnDelStroke.Size = new System.Drawing.Size(64, 23);
            this.btnDelStroke.TabIndex = 6;
            this.btnDelStroke.Text = "删除笔画";
            this.toolTip1.SetToolTip(this.btnDelStroke, "删除选定的笔画");
            this.btnDelStroke.UseVisualStyleBackColor = true;
            this.btnDelStroke.Click += new System.EventHandler(this.btnDelStroke_Click);
            // 
            // btnClearChar
            // 
            this.btnClearChar.Location = new System.Drawing.Point(256, 341);
            this.btnClearChar.Name = "btnClearChar";
            this.btnClearChar.Size = new System.Drawing.Size(65, 23);
            this.btnClearChar.TabIndex = 7;
            this.btnClearChar.Text = "清空笔画";
            this.toolTip1.SetToolTip(this.btnClearChar, "清空编辑框");
            this.btnClearChar.UseVisualStyleBackColor = true;
            this.btnClearChar.Click += new System.EventHandler(this.btnClearChar_Click);
            // 
            // btnDelChar
            // 
            this.btnDelChar.Location = new System.Drawing.Point(253, 377);
            this.btnDelChar.Name = "btnDelChar";
            this.btnDelChar.Size = new System.Drawing.Size(68, 23);
            this.btnDelChar.TabIndex = 10;
            this.btnDelChar.Text = "删除减字";
            this.toolTip1.SetToolTip(this.btnDelChar, "删除当前减字。\r\n警告：该操作无法恢复！");
            this.btnDelChar.UseVisualStyleBackColor = true;
            this.btnDelChar.Click += new System.EventHandler(this.btnDelChar_Click);
            // 
            // btnModChar
            // 
            this.btnModChar.Location = new System.Drawing.Point(179, 377);
            this.btnModChar.Name = "btnModChar";
            this.btnModChar.Size = new System.Drawing.Size(68, 23);
            this.btnModChar.TabIndex = 9;
            this.btnModChar.Text = "修改减字";
            this.toolTip1.SetToolTip(this.btnModChar, "修改当前选择的减字");
            this.btnModChar.UseVisualStyleBackColor = true;
            this.btnModChar.Click += new System.EventHandler(this.btnModChar_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(138, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(59, 21);
            this.txtName.TabIndex = 0;
            // 
            // lbChooseStroke
            // 
            this.lbChooseStroke.AutoSize = true;
            this.lbChooseStroke.Location = new System.Drawing.Point(80, 89);
            this.lbChooseStroke.Name = "lbChooseStroke";
            this.lbChooseStroke.Size = new System.Drawing.Size(113, 12);
            this.lbChooseStroke.TabIndex = 7;
            this.lbChooseStroke.Text = "选择一个笔画添加：";
            // 
            // picBoxEditor
            // 
            this.picBoxEditor.Location = new System.Drawing.Point(103, 124);
            this.picBoxEditor.Name = "picBoxEditor";
            this.picBoxEditor.Size = new System.Drawing.Size(200, 200);
            this.picBoxEditor.TabIndex = 14;
            this.picBoxEditor.TabStop = false;
            this.picBoxEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxEditor_Paint);
            this.picBoxEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxEditor_MouseDown);
            this.picBoxEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxEditor_MouseMove);
            this.picBoxEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxEditor_MouseUp);
            // 
            // toolTipWarning
            // 
            this.toolTipWarning.IsBalloon = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(60, 21);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lbRef
            // 
            this.lbRef.AutoSize = true;
            this.lbRef.Location = new System.Drawing.Point(80, 346);
            this.lbRef.Name = "lbRef";
            this.lbRef.Size = new System.Drawing.Size(65, 12);
            this.lbRef.TabIndex = 15;
            this.lbRef.Text = "参考汉字：";
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(138, 343);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(36, 21);
            this.txtRef.TabIndex = 16;
            this.txtRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRef_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 409);
            this.Controls.Add(this.txtRef);
            this.Controls.Add(this.lbRef);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnModChar);
            this.Controls.Add(this.picBoxEditor);
            this.Controls.Add(this.btnDelChar);
            this.Controls.Add(this.btnClearChar);
            this.Controls.Add(this.btnDelStroke);
            this.Controls.Add(this.btnAddChar);
            this.Controls.Add(this.btnAddStroke);
            this.Controls.Add(this.comboStrokes);
            this.Controls.Add(this.lbChooseStroke);
            this.Controls.Add(this.chkComplex);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.chkMain);
            this.Controls.Add(this.txtCharName);
            this.Controls.Add(this.lbCharName);
            this.Controls.Add(this.lstChar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "减字设计器";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstChar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbCharName;
        private System.Windows.Forms.TextBox txtCharName;
        private System.Windows.Forms.CheckBox chkMain;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkComplex;
        private System.Windows.Forms.Label lbChooseStroke;
        private System.Windows.Forms.ComboBox comboStrokes;
        private System.Windows.Forms.Button btnAddStroke;
        private System.Windows.Forms.Button btnAddChar;
        private System.Windows.Forms.Button btnDelStroke;
        private System.Windows.Forms.Button btnClearChar;
        private System.Windows.Forms.Button btnDelChar;
        private System.Windows.Forms.PictureBox picBoxEditor;
        private System.Windows.Forms.Button btnModChar;
        private System.Windows.Forms.ToolTip toolTipWarning;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbRef;
        private System.Windows.Forms.TextBox txtRef;
    }
}

