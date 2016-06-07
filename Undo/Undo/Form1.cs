using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Undo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Stack<Undo> undoAction = new Stack<Undo>();

        private void button1_Click(object sender, EventArgs e)
        {
            undoAction.Push(new Undo(button1));
            button1.BackColor = GetRandomColor();
            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            undoAction.Push(new Undo(button2));
            button2.BackColor = GetRandomColor();
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            undoAction.Push(new Undo(button3));
            button3.BackColor = GetRandomColor();
            UpdateList();
        }
        private void UpdateList()
        {
            listBox1.Items.Clear();
            foreach (var item in undoAction)
            {
                listBox1.Items.Add(item);
            }
        }

        private Color GetRandomColor()
        {
            Random randomGen = new Random();
            Color randomColor = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));
            return randomColor;
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (undoAction.Any())
            {
                undoAction.Pop().Execute();
                UpdateList();
            }
        }


    }
}
