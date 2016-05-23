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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbRef = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.chkRestrictTop = new System.Windows.Forms.CheckBox();
            this.chkRestrictBottom = new System.Windows.Forms.CheckBox();
            this.chkRectTop = new System.Windows.Forms.CheckBox();
            this.chkRectBottom = new System.Windows.Forms.CheckBox();
            this.lbSegment = new System.Windows.Forms.Label();
            this.numUDSegment = new System.Windows.Forms.NumericUpDown();
            this.lbChooseStroke = new System.Windows.Forms.Label();
            this.picBoxEditor = new System.Windows.Forms.PictureBox();
            this.toolTipWarning = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdateData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUDSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // lstChar
            // 
            this.lstChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstChar.FormattingEnabled = true;
            this.lstChar.ItemHeight = 12;
            this.lstChar.Location = new System.Drawing.Point(12, 43);
            this.lstChar.Name = "lstChar";
            this.lstChar.Size = new System.Drawing.Size(60, 328);
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
            this.toolTip1.SetToolTip(this.txtCharName, "减字的名称。\r\n方便辨识，并无代码意义。");
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
            this.comboStrokes.Size = new System.Drawing.Size(79, 20);
            this.comboStrokes.TabIndex = 4;
            this.toolTip1.SetToolTip(this.comboStrokes, "可用笔画列表。\r\n列表列出了可用的笔画。\r\n选择一个并点击右方的“添加”按钮\r\n可将该笔画添加进编辑框中。");
            // 
            // btnAddStroke
            // 
            this.btnAddStroke.Location = new System.Drawing.Point(284, 84);
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
            this.btnAddChar.Size = new System.Drawing.Size(68, 23);
            this.btnAddChar.TabIndex = 8;
            this.btnAddChar.Text = "添加减字";
            this.toolTip1.SetToolTip(this.btnAddChar, "将当前减字添加到库中");
            this.btnAddChar.UseVisualStyleBackColor = true;
            this.btnAddChar.Click += new System.EventHandler(this.btnAddChar_Click);
            // 
            // btnDelStroke
            // 
            this.btnDelStroke.Location = new System.Drawing.Point(199, 341);
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
            this.btnClearChar.Location = new System.Drawing.Point(275, 341);
            this.btnClearChar.Name = "btnClearChar";
            this.btnClearChar.Size = new System.Drawing.Size(68, 23);
            this.btnClearChar.TabIndex = 7;
            this.btnClearChar.Text = "清空笔画";
            this.toolTip1.SetToolTip(this.btnClearChar, "清空编辑框");
            this.btnClearChar.UseVisualStyleBackColor = true;
            this.btnClearChar.Click += new System.EventHandler(this.btnClearChar_Click);
            // 
            // btnDelChar
            // 
            this.btnDelChar.Location = new System.Drawing.Point(275, 377);
            this.btnDelChar.Name = "btnDelChar";
            this.btnDelChar.Size = new System.Drawing.Size(68, 23);
            this.btnDelChar.TabIndex = 10;
            this.btnDelChar.Text = "删除减字";
            this.toolTip1.SetToolTip(this.btnDelChar, "删除当前减字。\r\n警告：操作无法恢复！");
            this.btnDelChar.UseVisualStyleBackColor = true;
            this.btnDelChar.Click += new System.EventHandler(this.btnDelChar_Click);
            // 
            // btnModChar
            // 
            this.btnModChar.Location = new System.Drawing.Point(156, 377);
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
            this.toolTip1.SetToolTip(this.txtName, "程序当中的代码名称。\r\n用于在程序当中找到对应减字，建议只用ASCII字符。\r\n");
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(60, 21);
            this.txtSearch.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtSearch, "搜索列表当中的减字。\r\n按 Enter 键进行搜索。");
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
            this.toolTip1.SetToolTip(this.lbRef, "在编辑框背景中添加一个参考汉字，以便设计时参考。\r\n参考汉字将使用“方正清刻宋简体”字体。");
            // 
            // txtRef
            // 
            this.txtRef.Location = new System.Drawing.Point(138, 343);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(36, 21);
            this.txtRef.TabIndex = 16;
            this.toolTip1.SetToolTip(this.txtRef, "在编辑框背景中添加一个参考汉字，以便设计时参考。\r\n参考汉字将使用“方正清刻宋简体”字体。");
            this.txtRef.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRef_KeyPress);
            // 
            // chkRestrictTop
            // 
            this.chkRestrictTop.AutoSize = true;
            this.chkRestrictTop.Location = new System.Drawing.Point(289, 124);
            this.chkRestrictTop.Name = "chkRestrictTop";
            this.chkRestrictTop.Size = new System.Drawing.Size(60, 16);
            this.chkRestrictTop.TabIndex = 17;
            this.chkRestrictTop.Text = "上限制";
            this.toolTip1.SetToolTip(this.chkRestrictTop, "指示减字上边缘是否受限制。\r\n勾选此项，则当上方减字的下边缘存在限制时，\r\n组合减字将在当中额外添加一横行。");
            this.chkRestrictTop.UseVisualStyleBackColor = true;
            this.chkRestrictTop.CheckedChanged += new System.EventHandler(this.chkRestrictTop_CheckedChanged);
            // 
            // chkRestrictBottom
            // 
            this.chkRestrictBottom.AutoSize = true;
            this.chkRestrictBottom.Location = new System.Drawing.Point(289, 307);
            this.chkRestrictBottom.Name = "chkRestrictBottom";
            this.chkRestrictBottom.Size = new System.Drawing.Size(60, 16);
            this.chkRestrictBottom.TabIndex = 18;
            this.chkRestrictBottom.Text = "下限制";
            this.toolTip1.SetToolTip(this.chkRestrictBottom, "指示减字下边缘是否受限制。\r\n勾选此项，则当下方减字的上边缘存在限制时，\r\n组合减字将在当中额外添加一横行。\r\n");
            this.chkRestrictBottom.UseVisualStyleBackColor = true;
            this.chkRestrictBottom.CheckedChanged += new System.EventHandler(this.chkRestrictBottom_CheckedChanged);
            // 
            // chkRectTop
            // 
            this.chkRectTop.AutoSize = true;
            this.chkRectTop.Enabled = false;
            this.chkRectTop.Location = new System.Drawing.Point(289, 201);
            this.chkRectTop.Name = "chkRectTop";
            this.chkRectTop.Size = new System.Drawing.Size(60, 16);
            this.chkRectTop.TabIndex = 19;
            this.chkRectTop.Text = "上限制";
            this.toolTip1.SetToolTip(this.chkRectTop, "指示框内上边缘是否受限制。\r\n勾选此项，则当框内减字上边缘存在限制时，\r\n组合减字将在当中额外添加一横行。");
            this.chkRectTop.UseVisualStyleBackColor = true;
            this.chkRectTop.CheckedChanged += new System.EventHandler(this.chkRectTop_CheckedChanged);
            // 
            // chkRectBottom
            // 
            this.chkRectBottom.AutoSize = true;
            this.chkRectBottom.Enabled = false;
            this.chkRectBottom.Location = new System.Drawing.Point(289, 224);
            this.chkRectBottom.Name = "chkRectBottom";
            this.chkRectBottom.Size = new System.Drawing.Size(60, 16);
            this.chkRectBottom.TabIndex = 20;
            this.chkRectBottom.Text = "下限制";
            this.toolTip1.SetToolTip(this.chkRectBottom, "指示框内下边缘是否受限制。\r\n勾选此项，则当框内减字下边缘存在限制时，\r\n组合减字将在当中额外添加一横行。");
            this.chkRectBottom.UseVisualStyleBackColor = true;
            this.chkRectBottom.CheckedChanged += new System.EventHandler(this.chkRectBottom_CheckedChanged);
            // 
            // lbSegment
            // 
            this.lbSegment.AutoSize = true;
            this.lbSegment.Location = new System.Drawing.Point(242, 52);
            this.lbSegment.Name = "lbSegment";
            this.lbSegment.Size = new System.Drawing.Size(41, 12);
            this.lbSegment.TabIndex = 21;
            this.lbSegment.Text = "占行：";
            this.toolTip1.SetToolTip(this.lbSegment, "指示减字占多少行横行空间。\r\n该值用于分配笔画间距以使减字看起来更匀称。");
            // 
            // numUDSegment
            // 
            this.numUDSegment.Location = new System.Drawing.Point(289, 50);
            this.numUDSegment.Name = "numUDSegment";
            this.numUDSegment.Size = new System.Drawing.Size(54, 21);
            this.numUDSegment.TabIndex = 22;
            this.toolTip1.SetToolTip(this.numUDSegment, "指示减字占多少行横行空间。\r\n该值用于分配笔画间距以使减字看起来更匀称。\r\n");
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
            this.picBoxEditor.Location = new System.Drawing.Point(82, 124);
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
            // btnUpdateData
            // 
            this.btnUpdateData.Location = new System.Drawing.Point(12, 377);
            this.btnUpdateData.Name = "btnUpdateData";
            this.btnUpdateData.Size = new System.Drawing.Size(60, 23);
            this.btnUpdateData.TabIndex = 23;
            this.btnUpdateData.Text = "更新";
            this.toolTip1.SetToolTip(this.btnUpdateData, "将修改更新到数据库中。");
            this.btnUpdateData.UseVisualStyleBackColor = true;
            this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 409);
            this.Controls.Add(this.btnUpdateData);
            this.Controls.Add(this.numUDSegment);
            this.Controls.Add(this.lbSegment);
            this.Controls.Add(this.chkRectBottom);
            this.Controls.Add(this.chkRectTop);
            this.Controls.Add(this.chkRestrictBottom);
            this.Controls.Add(this.chkRestrictTop);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numUDSegment)).EndInit();
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
        private System.Windows.Forms.CheckBox chkRestrictTop;
        private System.Windows.Forms.CheckBox chkRestrictBottom;
        private System.Windows.Forms.CheckBox chkRectTop;
        private System.Windows.Forms.CheckBox chkRectBottom;
        private System.Windows.Forms.Label lbSegment;
        private System.Windows.Forms.NumericUpDown numUDSegment;
        private System.Windows.Forms.Button btnUpdateData;
    }
}

