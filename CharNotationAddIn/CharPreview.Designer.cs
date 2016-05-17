namespace CharNotationAddIn
{
    partial class CharPreview
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtNotation = new System.Windows.Forms.TextBox();
            this.imgChar = new System.Windows.Forms.PictureBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UpDownThin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.UpDownThick = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.imgChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownThin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownThick)).BeginInit();
            this.SuspendLayout();
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInsert.Location = new System.Drawing.Point(136, 279);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 9;
            this.btnInsert.Text = "插入";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtNotation
            // 
            this.txtNotation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNotation.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtNotation.Location = new System.Drawing.Point(15, 219);
            this.txtNotation.Name = "txtNotation";
            this.txtNotation.Size = new System.Drawing.Size(196, 21);
            this.txtNotation.TabIndex = 8;
            this.txtNotation.TextChanged += new System.EventHandler(this.txtNotation_TextChanged);
            // 
            // imgChar
            // 
            this.imgChar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgChar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgChar.Location = new System.Drawing.Point(15, 13);
            this.imgChar.Name = "imgChar";
            this.imgChar.Size = new System.Drawing.Size(200, 200);
            this.imgChar.TabIndex = 7;
            this.imgChar.TabStop = false;
            this.imgChar.Paint += new System.Windows.Forms.PaintEventHandler(this.imgChar_Paint);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown1.Location = new System.Drawing.Point(50, 282);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(58, 21);
            this.numericUpDown1.TabIndex = 10;
            this.numericUpDown1.Value = new decimal(new int[] {
            28,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "字号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "细线宽";
            // 
            // UpDownThin
            // 
            this.UpDownThin.DecimalPlaces = 1;
            this.UpDownThin.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.UpDownThin.Location = new System.Drawing.Point(62, 254);
            this.UpDownThin.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.UpDownThin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownThin.Name = "UpDownThin";
            this.UpDownThin.Size = new System.Drawing.Size(46, 21);
            this.UpDownThin.TabIndex = 13;
            this.UpDownThin.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownThin.ValueChanged += new System.EventHandler(this.UpDownThin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "粗线宽";
            // 
            // UpDownThick
            // 
            this.UpDownThick.DecimalPlaces = 1;
            this.UpDownThick.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.UpDownThick.Location = new System.Drawing.Point(161, 254);
            this.UpDownThick.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.UpDownThick.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.UpDownThick.Name = "UpDownThick";
            this.UpDownThick.Size = new System.Drawing.Size(46, 21);
            this.UpDownThick.TabIndex = 13;
            this.UpDownThick.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.UpDownThick.ValueChanged += new System.EventHandler(this.UpDownThick_ValueChanged);
            // 
            // CharPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpDownThick);
            this.Controls.Add(this.UpDownThin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtNotation);
            this.Controls.Add(this.imgChar);
            this.Name = "CharPreview";
            this.Size = new System.Drawing.Size(230, 315);
            ((System.ComponentModel.ISupportInitialize)(this.imgChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownThin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownThick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtNotation;
        private System.Windows.Forms.PictureBox imgChar;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown UpDownThin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown UpDownThick;
    }
}
