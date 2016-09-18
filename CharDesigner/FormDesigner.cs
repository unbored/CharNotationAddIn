using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CharNotation
{
    public partial class FormDesigner : Form
    {
        //公共变量
        DataTranslator dataTranslator;  //用于与数据库交换数据
        List<Stroke> basicStrokes;
        CharEditor charEditor;
        int currentListIndex;
        bool mouseDown; //记录鼠标是否按下

        public FormDesigner()
        {
            InitializeComponent();

            //准备编辑区域内容
            basicStrokes = BasicStrokesInit(); //基础笔画部件
            //将数据绑定到combo上。此处无需新建binding，因为该数据不会更新
            comboStrokes.DataSource = basicStrokes;
            comboStrokes.DisplayMember = "type";

            //CharEditor.BasicStrokes = basicStrokes; //将笔画信息传入chareditor
            Stroke.setWidth(3, 15);
            charEditor = new CharEditor();
            mouseDown = false;

            dataTranslator = new DataTranslator();

            lstChar.DataSource = dataTranslator.CharTable;
            lstChar.DisplayMember = "char_name";
        }
        /// <summary>
        /// 减字列表选择条目变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //避免未保存的数据丢失，设置提醒
            if (charEditor.IsModified)
            {
                if (currentListIndex != lstChar.SelectedIndex)
                {
                    DialogResult result = MessageBox.Show("减字尚未保存，是否离开？", "警告", 
                        System.Windows.Forms.MessageBoxButtons.YesNo);
                    if (result == System.Windows.Forms.DialogResult.No)
                    {
                        lstChar.SelectedIndex = currentListIndex;
                        return;
                    }
                }
                else
                    return;
            }
            currentListIndex = lstChar.SelectedIndex;
            CharNotationDataSet.CharRow currentRow = null;
            if (lstChar.SelectedItem != null)
                currentRow = (CharNotationDataSet.CharRow)(lstChar.SelectedItem as DataRowView).Row;
            //Char charCurrent = lstChar.SelectedItem as Char;
            Char charCurrent = null;
            if (currentRow != null)
                charCurrent = dataTranslator.GetChar(currentRow);
            //列表非空时必然会选择其中一项；但要避免出现空列表的情况
            if (charCurrent != null)    
            {
                charEditor = new CharEditor(charCurrent.Clone() as Char);

                charEditor.ResetModifyStatus();

                txtName.Text = charEditor.Name;
                txtCharName.Text = charEditor.CharName;
                numUDSegment.Value = (Decimal)charEditor.Segment;
                chkMain.Checked = charEditor.IsMain;
                chkComplex.Checked = charEditor.IsComplex;
                chkRestrictTop.Checked = charEditor.RestrictTop;
                chkRestrictBottom.Checked = charEditor.RestrictBottom;
                chkRectTop.Checked = charEditor.RestrictTopRect;
                chkRectBottom.Checked = charEditor.RestrictBottomRect;

                picBoxEditor.Invalidate();  //重绘picbox
            }
        }
        /// <summary>
        /// 点击“添加减字”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddChar_Click(object sender, EventArgs e)
        {
            //未指定减字名称
            if (txtName.Text == "")
            {
                toolTipWarning.Show("名称还没起呢", txtName, 1000);
                return;
            }
            else if (txtCharName.Text == "")
            {
                toolTipWarning.Show("名称还没起呢", txtCharName, 1000);
                return;
            }
            //检查列表是否重复
            foreach (var item in lstChar.Items)
            {
                CharNotationDataSet.CharRow currentRow = (CharNotationDataSet.CharRow)(item as DataRowView).Row;
                if (currentRow.name.Trim() == txtName.Text)
                {
                    toolTipWarning.Show("名称已存在", txtName, 1000);
                    return;
                }
                else if (currentRow.char_name.Trim() == txtCharName.Text)
                {
                    toolTipWarning.Show("名称已存在", txtCharName, 1000);
                    return;
                }
            }
            //新建减字，必须使用深复制
            charEditor.CharName = txtCharName.Text;
            charEditor.Name = txtName.Text;
            charEditor.Segment = (int)numUDSegment.Value;
            charEditor.ResetModifyStatus();
            Char charTemp = charEditor.Clone() as Char;
            dataTranslator.AddChar(charTemp);
            lstChar.SelectedIndex = lstChar.FindStringExact(charEditor.CharName);
        }
        /// <summary>
        /// 点击“修改减字”按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModChar_Click(object sender, EventArgs e)
        {
            //未指定减字名称
            if (txtName.Text == "")
            {
                toolTipWarning.Show("名称还没起呢", txtName, 1000);
                return;
            }
            else if (txtCharName.Text == "")
            {
                toolTipWarning.Show("名称还没起呢", txtCharName, 1000);
                return;
            }
            //取得当前选择的减字位置
            //int index = bindingListChar.IndexOf(lstChar.SelectedItem as Char);
            //if (index == -1)    //列表中不存在对应减字（列表为空）
            //    return;
            CharNotationDataSet.CharRow currentRow = null;
            if (lstChar.SelectedItem != null)
                currentRow = (CharNotationDataSet.CharRow)(lstChar.SelectedItem as DataRowView).Row;
            charEditor.Name = txtName.Text;
            charEditor.CharName = txtCharName.Text;
            charEditor.Segment = (int)numUDSegment.Value;
            //bindingListChar[index] = charEditor.Clone() as Char;
            charEditor.ResetModifyStatus();
            dataTranslator.ModChar(currentRow, charEditor.Clone() as Char);
            lstChar.SelectedIndex = lstChar.FindStringExact(charEditor.CharName);
            //bindingListChar.ResetBindings();    //bindingList内容已更改，以此通知listBox刷新
        }
        /// <summary>
        /// 搜索列表当中的减字并将其选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                int index = lstChar.FindString(txtSearch.Text);
                if (index != ListBox.NoMatches)
                {
                    lstChar.SelectedIndex = index;
                    lstChar.Focus();
                    txtSearch.Text = "";
                }
                else
                    toolTipWarning.Show("没找到", txtSearch, 1000);
            }
        }
        /// <summary>
        /// 删除列表中的减字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelChar_Click(object sender, EventArgs e)
        {
            //避免误删除，先确认
            DialogResult result = MessageBox.Show("将删除列表中当前选定的减字（请看清楚），\n无法恢复，是否继续？", "警告", System.Windows.Forms.MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            CharNotationDataSet.CharRow currentRow = null;
            if (lstChar.SelectedItem != null)
                currentRow = (CharNotationDataSet.CharRow)(lstChar.SelectedItem as DataRowView).Row;
            dataTranslator.RemoveChar(currentRow);
            //bindingListChar.Remove(lstChar.SelectedItem as Char);
        }
        /// <summary>
        /// 添加笔画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStroke_Click(object sender, EventArgs e)
        {
            if (comboStrokes.SelectedItem == null)
            {
                toolTipWarning.Show("请先选择一个笔画", comboStrokes, 1000);
                return;
            }

            Stroke s = comboStrokes.SelectedItem as Stroke;
            charEditor.AddStroke(s);
            picBoxEditor.Invalidate();  //重绘picbox
        }
        /// <summary>
        /// 删除笔画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelStroke_Click(object sender, EventArgs e)
        {
            charEditor.RemoveStroke();
            picBoxEditor.Invalidate();  //重绘picbox
        }
        /// <summary>
        /// 清除所有笔画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearChar_Click(object sender, EventArgs e)
        {
            charEditor.ClearStrokes();
            picBoxEditor.Invalidate();
        }
        /// <summary>
        /// 按下鼠标按键
        /// 只在第一次检测到按下时执行临近点搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (!mouseDown)
                {
                    charEditor.SelectNearestPoint(e.Location);
                    picBoxEditor.Invalidate();
                    mouseDown = true;
                }
            }
        }
        /// <summary>
        /// 释放鼠标按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxEditor_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = false;
            }
        }
        /// <summary>
        /// 移动鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxEditor_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                charEditor.SetCurrentPointPos(e.Location);
                picBoxEditor.Invalidate();
            }
        }
        /// <summary>
        /// 重绘picbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxEditor_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //绘制背景（相当于刷新）
            charEditor.DrawBackground(e.Graphics);
            //绘制笔画
            charEditor.DrawStrokes(e.Graphics);
            //绘制笔画骨骼
            charEditor.DrawBones(e.Graphics);
        }

        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            chkComplex.Enabled = chkMain.Checked;
            charEditor.IsMain = chkMain.Checked;
            chkRectTop.Enabled = chkMain.Checked;
            chkRectBottom.Enabled = chkMain.Checked;
            picBoxEditor.Invalidate();
        }

        private void txtRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                charEditor.SetReference(txtRef.Text);
                picBoxEditor.Invalidate();
            }
        }
        private void chkComplex_CheckedChanged(object sender, EventArgs e)
        {
            charEditor.IsComplex = chkComplex.Checked;
            picBoxEditor.Invalidate();
        }

        private void chkRestrictTop_CheckedChanged(object sender, EventArgs e)
        {
            charEditor.RestrictTop = chkRestrictTop.Checked;
        }

        private void chkRestrictBottom_CheckedChanged(object sender, EventArgs e)
        {
            charEditor.RestrictBottom = chkRestrictBottom.Checked;
        }

        private void chkRectTop_CheckedChanged(object sender, EventArgs e)
        {
            charEditor.RestrictTopRect = chkRectTop.Checked;
        }

        private void chkRectBottom_CheckedChanged(object sender, EventArgs e)
        {
            charEditor.RestrictBottomRect = chkRectBottom.Checked;
        }

        /// <summary>
        /// 初始化基础笔画
        /// </summary>
        /// <returns></returns>
        private List<Stroke> BasicStrokesInit()
        {
            List<Stroke> result = new List<Stroke>();
            Stroke newStroke;

            newStroke = new Stroke(strokeType.横);
            newStroke.Points.Add(new PointF(10.0f, 100.0f));
            newStroke.Points.Add(new PointF(180.0f, 100.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.竖);
            newStroke.Points.Add(new PointF(100.0f, 20.0f));
            newStroke.Points.Add(new PointF(100.0f, 180.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.撇);
            newStroke.Points.Add(new PointF(100.0f, 20.0f));
            newStroke.Points.Add(new PointF(100.0f, 100.0f));
            newStroke.Points.Add(new PointF(50.0f, 190.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.无头撇);
            newStroke.Points.Add(new PointF(100.0f, 20.0f));
            newStroke.Points.Add(new PointF(100.0f, 100.0f));
            newStroke.Points.Add(new PointF(50.0f, 190.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.捺);
            newStroke.Points.Add(new PointF(70.0f, 20.0f));
            newStroke.Points.Add(new PointF(100.0f, 20.0f));
            newStroke.Points.Add(new PointF(120.0f, 120.0f));
            newStroke.Points.Add(new PointF(170.0f, 180.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.无头捺);
            newStroke.Points.Add(new PointF(100.0f, 20.0f));
            newStroke.Points.Add(new PointF(120.0f, 120.0f));
            newStroke.Points.Add(new PointF(170.0f, 180.0f));
            result.Add(newStroke);

            newStroke = new Stroke(strokeType.点);
            newStroke.Points.Add(new PointF(70.0f, 70.0f));
            newStroke.Points.Add(new PointF(100.0f, 100.0f));
            newStroke.Points.Add(new PointF(120.0f, 120.0f));
            newStroke.Points.Add(new PointF(120.0f, 180.0f));
            result.Add(newStroke);
            return result;
        }

        private void btnUpdateData_Click(object sender, EventArgs e)
        {
            dataTranslator.Update();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (charEditor.IsModified)
            {
                DialogResult result = MessageBox.Show("当前减字尚未保存，是否离开？", "警告",
                    System.Windows.Forms.MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;    //取消窗口关闭
                    return;
                }
            }
            if (dataTranslator.IsModified)
            {
                DialogResult result = MessageBox.Show("数据已修改而未更新，是否更新？", "警告",
                    System.Windows.Forms.MessageBoxButtons.YesNoCancel);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    dataTranslator.Update();
                else if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    e.Cancel = true;    //取消窗口关闭
                    return;
                }
            }
            currentListIndex = -1;  //列表被清除时将不会选择任何一项
        }
    }
}
