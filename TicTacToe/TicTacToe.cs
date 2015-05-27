using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool isXTurn = true;
        List<Button> buttons;

        public TicTacToe()
        {
            InitializeComponent();
            buttons = new List<Button>();
            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            buttons.Add(button7);
            buttons.Add(button8);
            buttons.Add(button9);
            newGame();
        }

        private void newGame()
        {
            foreach (Button b in buttons)
            {
                b.Text = "";
                b.Enabled = true;
            }
            isXTurn = true;
            richTextBox_moves.AppendText("N\n");
        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(richTextBox_moves.Text);
                sw.Close();
                fs.Close();
            }
        }

        private void executeTurn(Button b)
        {
            b.Text = isXTurn ? "X" : "O";
            b.Enabled = false;

            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            foreach (Button but in buttons)
            {
                sb.Append(but.Text == "X" ? 1 : 0);
            }
            sb.Append("}{");
            foreach (Button but in buttons)
            {
                sb.Append(but.Text == "O" ? 1 : 0);
            }
            sb.Append("}\n");
            richTextBox_moves.AppendText(sb.ToString());

            isXTurn = !isXTurn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[1]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[2]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[3]);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[4]);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[5]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[6]);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[7]);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            executeTurn(buttons[8]);
        }
    }
}
