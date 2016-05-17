using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharNotationDesigner
{
    public partial class Form1 : Form
    {
        //公共变量
        BindingList<Char> bindingListChar;  //显示在左边的减字列表
        CharEditor charEditor;
        int currentListIndex;
        bool mouseDown; //记录鼠标是否按下

        public Form1()
        {
            InitializeComponent();
            //新建一个binding绑到listbox上
            bindingListChar = new BindingList<Char>();
            lstChar.DataSource = bindingListChar;
            lstChar.DisplayMember = "CharName";

            //准备编辑区域内容
            List<Stroke> basicStrokes = new List<Stroke>(); //基础笔画部件
            Stroke strokeTemp = new Stroke(strokeType.HENG);
            strokeTemp.Points.Add(new PointF(10.0f, 100.0f));
            strokeTemp.Points.Add(new PointF(90.0f, 100.0f));
            basicStrokes.Add(strokeTemp);
            strokeTemp = new Stroke(strokeType.SHU);
            strokeTemp.Points.Add(new PointF(100.0f, 10.0f));
            strokeTemp.Points.Add(new PointF(100.0f, 90.0f));
            basicStrokes.Add(strokeTemp);
            //将数据绑定到combo上。此处无需新建binding，因为该数据不会更新
            comboStrokes.DataSource = basicStrokes;
            comboStrokes.DisplayMember = "name";

            CharEditor.BasicStrokes = basicStrokes; //将笔画信息传入chareditor
            charEditor = new CharEditor();
            mouseDown = false;
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
                    DialogResult result = MessageBox.Show("减字尚未保存，是否离开？", "警告", System.Windows.Forms.MessageBoxButtons.YesNo);
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
            Char charCurrent = lstChar.SelectedItem as Char;
            //列表非空时必然会选择其中一项；但要避免出现空列表的情况
            if (charCurrent != null)    
            {
                txtName.Text = (charCurrent).Name;
                txtCharName.Text = (charCurrent).CharName;
                charEditor.Strokes = charCurrent.CloneStrokes();
                charEditor.ResetModifyStatus();
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
                if ((item as Char).Name == txtName.Text)
                {
                    toolTipWarning.Show("名称已存在", txtName, 1000);
                    return;
                }
                else if ((item as Char).CharName == txtCharName.Text)
                {
                    toolTipWarning.Show("名称已存在", txtCharName, 1000);
                    return;
                }
            }
            //新建减字
            Char charTemp = new Char();
            charTemp.CharName = txtCharName.Text;
            charTemp.Name = txtName.Text;
            charTemp.Strokes = charEditor.CloneStrokes();
            charEditor.ResetModifyStatus();
            bindingListChar.Add(charTemp);
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
            int index = bindingListChar.IndexOf(lstChar.SelectedItem as Char);
            if (index == -1)    //列表中不存在对应减字（列表为空）
                return;
            bindingListChar[index].Name = txtName.Text;
            bindingListChar[index].CharName = txtCharName.Text;
            bindingListChar[index].Strokes = charEditor.CloneStrokes();    //重新分配一份
            charEditor.ResetModifyStatus();
            bindingListChar.ResetBindings();    //bindingList内容已更改，以此通知listBox刷新
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
            bindingListChar.Remove(lstChar.SelectedItem as Char);
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
            }
            charEditor.AddStroke((comboStrokes.SelectedItem as Stroke).Type);
            picBoxEditor.Invalidate();  //重绘picbox
            //picBoxEditor.Refresh();
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
        /// 选择上一个笔画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrev_Click(object sender, EventArgs e)
        {
            charEditor.PreviousStroke();
            picBoxEditor.Invalidate();
        }
        /// <summary>
        /// 选择下一个笔画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            charEditor.NextStroke();
            picBoxEditor.Invalidate();
        }
        /// <summary>
        /// 按下鼠标按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBoxEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mouseDown = true;
                charEditor.SelectNearestPoint(e.Location);
                picBoxEditor.Invalidate();
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
            //绘制笔画骨骼
            charEditor.DrawBones(e.Graphics);
        }
    }
}
