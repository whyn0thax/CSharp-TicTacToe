using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tic_tac_Toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isAI = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button9.BackColor = Color.White;
            timer1.Start();
        }
        public enum Player
        {
            X, O
        }

        Player currentPlayer; 

        List<Button> buttons; 
        Random rand = new Random(); 
        int playerWins = 0; 
        int computerWins = 0;
        int nooneWins = 0;
        
        private void loadbuttons()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9};
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadbuttons();
            var button = (Button)sender; 
            currentPlayer = Player.X; 
            button.Text = currentPlayer.ToString(); 
            button.Enabled = false; 
            button.BackColor = Color.Cyan; 
            buttons.Remove(button);  

            Check();
            isAI = true;
            
            AImove();
        }
        private void Check()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
               || button6.Text == "X" && button5.Text == "X" && button4.Text == "X"
               || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
               || button1.Text == "X" && button6.Text == "X" && button9.Text == "X"
               || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
               || button3.Text == "X" && button4.Text == "X" && button7.Text == "X"
               || button1.Text == "X" && button5.Text == "X" && button7.Text == "X"
               || button3.Text == "X" && button5.Text == "X" && button9.Text == "X")
            {
                 
                MessageBox.Show("Player Wins", "Game");
                playerWins++;
                label1.Text = ("Player Wins: " + playerWins.ToString());
                restartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
               || button6.Text == "O" && button5.Text == "O" && button4.Text == "O"
               || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
               || button1.Text == "O" && button6.Text == "O" && button9.Text == "O"
               || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
               || button3.Text == "O" && button4.Text == "O" && button7.Text == "O"
               || button1.Text == "O" && button5.Text == "O" && button7.Text == "O"
               || button3.Text == "O" && button5.Text == "O" && button9.Text == "O")
                {
                
                MessageBox.Show("Computer Wins", "Game");
                computerWins++;
                label2.Text = ("AI Wins: " + computerWins.ToString());
                restartGame();
                
            }
            else if (button2.Text == "X" && button5.Text == "X" && button6.Text == "X" 
                && button9.Text == "X" && button7.Text == "X" || button1.Text == "X" 
                && button3.Text == "X" && button4.Text == "X" && button8.Text == "X"
                || button6.Text == "X" && button2.Text == "X" && button3.Text == "X" && button7.Text == "X" 
                )
            {
                MessageBox.Show("Noone Wins", "Game");
                nooneWins++;
                restartGame();
            }
        }
        private void AImove()
        {
            if (isAI == true)
            {
                int index2 = 0;

                do
                {
                    index2 = rand.Next(buttons.Count);
                } while (buttons[index2].Enabled == false);
                
                buttons[index2].Enabled = false;
                currentPlayer = Player.O;
                buttons[index2].Text = currentPlayer.ToString();
                buttons[index2].BackColor = Color.DarkSalmon;
                buttons.RemoveAt(index2);
                Check();
                isAI = false;
            }
        }

        private void restartGame()
        {
            loadbuttons();

            button1.Enabled = true;
            button1.Text = "";
            button1.BackColor = Color.White;
            button2.Enabled = true;
            button2.Text = "";
            button2.BackColor = Color.White;
            button3.Enabled = true;
            button3.Text = "";
            button3.BackColor = Color.White;
            button4.Enabled = true;
            button4.Text = "";
            button4.BackColor = Color.White;
            button5.Enabled = true;
            button5.Text = "";
            button5.BackColor = Color.White;
            button6.Enabled = true;
            button6.Text = "";
            button6.BackColor = Color.White;
            button7.Enabled = true;
            button7.Text = "";
            button7.BackColor = Color.White;
            button8.Enabled = true;
            button8.Text = "";
            button8.BackColor = Color.White;
            button9.Enabled = true;
            button9.Text = "";
            button9.BackColor = Color.White;       
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            restartGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isAI == true)
            {
                label3.BackColor = Color.DarkSalmon;
            }
            else if (isAI == false)
            {
                label3.BackColor = Color.Cyan;
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("𝕙𝕦𝕞𝕒𝕟 (𝕠𝕣 𝕟𝕠𝕥)#9974", "Made By ");
        }
    }
}
