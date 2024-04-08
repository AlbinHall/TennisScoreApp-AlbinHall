using System.Diagnostics;
using TennisScoreApp_AlbinHall.Models;

namespace TennisScoreApp_AlbinHall
{
    public partial class Form1 : Form
    {

        public TennisScore playerOneScore = new TennisScore();
        public TennisScore playerTwoScore = new TennisScore();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Player One";
            button2.Text = "Player Two";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalculateScore(playerOneScore, playerTwoScore);
            DisplayText();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            CalculateScore(playerTwoScore, playerOneScore);
            DisplayText();
        }

        public void CalculateScore(TennisScore playerScore, TennisScore opponent)
        {
            switch (playerScore.Score)
            {
                case 0:
                    playerScore.Score += 15;
                    break;
                case 15:
                    playerScore.Score += 15;
                    break;
                case 30:
                    playerScore.Score = 40;
                    break;
                case 40:
                    if (opponent.Score == 50)
                    {
                        playerScore.Score = 40;
                        opponent.Score = 40;
                    }
                    else if (opponent.Score < 40)
                    {
                        playerScore.Score = 0;
                        opponent.Score = 0;
                        playerScore.Gem += 1;
                    }
                    else if (opponent.Score == 40)
                    {
                        playerScore.Score = 50;
                    }
                    break;
                case 50:
                    playerScore.Score = 0;
                    opponent.Score = 0;
                    playerScore.Gem += 1;
                    break;
            }

            if (playerScore.Gem >= opponent.Gem + 2 && playerScore.Gem > 5)
            {
                playerScore.Set += 1;
                playerScore.Gem = 0;
                opponent.Gem = 0;
            }

            if (playerScore.Set == 2)
            {
                textBox3.Text = "Won the game";
            }

        }

        public string Score()
        {

            if (playerOneScore.Score == 40 && playerTwoScore.Score == 40)
            {
                return "Deuce";
            }
            if (playerOneScore.Score == 50)
            {
                return "Advantage Player One";
            }
            if (playerTwoScore.Score == 50)
            {
                return "Advantage Player Two";
            }

            string scorePlayerOne = ConvertScoreToTennisFormat(playerOneScore.Score, playerTwoScore.Score);
            string scorePlayerTwo = ConvertScoreToTennisFormat(playerTwoScore.Score, playerOneScore.Score);
     
            return $"                 {scorePlayerOne} - {scorePlayerTwo}";
        }

        private string ConvertScoreToTennisFormat(int playerScore, int opponentScore)
        {
            switch (playerScore)
            {
                case 0:
                    if (opponentScore > 0)
                    {
                        return "Love";
                    }
                    else
                    {
                        return "0";
                    }
                case 15: return "15";
                case 30: return "30";
                case 40: return "40";
                default: return "";
            }
        }

        public void DisplayText()
        {
            string currentScore = Score();
            textBox3.Text = "Game: " + playerOneScore.Gem.ToString();
            textBox4.Text = "Set: " + playerOneScore.Set.ToString();

            textBox9.Text = "Set: " + playerTwoScore.Set.ToString();
            textBox8.Text = "Game: " + playerTwoScore.Gem.ToString();
            textBox5.Text = currentScore;
        }



    }
}
