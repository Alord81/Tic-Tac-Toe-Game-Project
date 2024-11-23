using System;
using System.Drawing;
using System.Windows.Forms;
using Tic_Tac_Toe_Game_Project.Properties;

namespace Tic_Tac_Toe_Game_Project
{
    public partial class Form1 : Form
    {
        /*
         
            Hi Everyone :-)!
            
            My name is Abdullrahman,
            and this is my project for the Tic Tac Toe (or XO Game).
            It took me about 7 hours to complete—most of which was spent on the basic and imperfect design. But hey!
            This is just a warm-up and a simple exercise in preparation for the big projects ahead.

            Technologies Used:
             * C#.Net (I'm still learning it as of now)
        

         */
        public Form1()
        {
            InitializeComponent();
        }
        enum enPlayer
        {
            Player1,
            Player2
        }
        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }
        enPlayer PlayerTurn;
        struct stGameStatus
        {
            public byte PlayCount;
            public enWinner Winner;
            public bool GameOver;
        }
        stGameStatus GameStatus;

        void EndGame()
        {
            lbTurns.Text = "Game Over";


            switch(GameStatus.Winner)
            {
                case enWinner.Player1:
                    lbWinner.Text = "Player 1";
                    break;
                case enWinner.Player2:
                    lbWinner.Text = "Player 2";
                    break;
                default:
                    lbWinner.Text = "Draw";
                    break;
            }

            MessageBox.Show("Game Over!", "GameOver", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        bool CheckValues(PictureBox PB1, PictureBox PB2, PictureBox PB3)
        {
            if (PB1.Tag.ToString() != "?" && (PB1.Tag.ToString() == PB2.Tag.ToString()) && (PB1.Tag.ToString() == PB3.Tag.ToString() ))
            {
                PB1.BackColor = Color.Green;
                PB2.BackColor = Color.Green;
                PB3.BackColor = Color.Green;

                if (PB1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
            }

            GameStatus.GameOver = false;
            return false;
        }
        void CheckWinner()
        {
            if (CheckValues(pb1,pb2,pb3))
                return;
            if (CheckValues(pb4, pb5, pb6))
                return;
            if (CheckValues(pb7, pb8, pb9))
                return;



            if (CheckValues(pb1, pb4, pb7))
                return;
            if (CheckValues(pb2, pb5, pb8))
                return;
            if (CheckValues(pb3, pb6, pb9))
                return;




            if (CheckValues(pb1, pb5, pb9))
                return;
            if (CheckValues(pb3, pb5, pb7))
                return;
        }
        public void ChangeImag(PictureBox Pb)
        {
            if (GameStatus.GameOver == true)
            {
                MessageBox.Show("Game Over Bro!", "Game Over",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            if(Pb.Tag.ToString() == "?")
            {

                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        Pb.Image = Resources.cross;
                        PlayerTurn = enPlayer.Player2;
                        lbTurns.Text = "Player 2";
                        Pb.Tag = "X";
                        GameStatus.PlayCount++;
                        CheckWinner();

                        break;

                    case enPlayer.Player2:
                        Pb.Image = Resources.letter_o;
                        PlayerTurn = enPlayer.Player1;
                        lbTurns.Text = "Player 1";
                        GameStatus.PlayCount++;

                        Pb.Tag = "O";
                        CheckWinner();

                        break;  
                }
                

            }
            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.White;

            Pen Pen = new Pen(White);
            Pen.Width = 10;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            Pen.Width = 15;

            e.Graphics.DrawLine(Pen, 663, 65, 663, 560);
            e.Graphics.DrawLine(Pen, 918, 65, 918, 560);


            e.Graphics.DrawLine(Pen, 400, 240,1180,240);
            e.Graphics.DrawLine(Pen, 400, 392, 1180, 392);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);


        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);


        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ////SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);


        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //SelectTheSquare((PictureBox)sender);
            ChangeImag((PictureBox)sender);

        }

        void RestButton(PictureBox PB)
        {
            PB.Image = Resources.question_mark;
            PB.Tag = "?";
            PB.BackColor = Color.Transparent;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RestButton(pb1);
            RestButton(pb2);
            RestButton(pb3);
            RestButton(pb4);
            RestButton(pb5);
            RestButton(pb6);
            RestButton(pb7);
            RestButton(pb8);
            RestButton(pb9);

            PlayerTurn = enPlayer.Player1;
            lbTurns.Text = "Player1";
            lbWinner.Text = "In Progress";
            GameStatus.GameOver =false;
            GameStatus.PlayCount = 0;
            GameStatus.Winner = enWinner.GameInProgress;

        }

    }
}
