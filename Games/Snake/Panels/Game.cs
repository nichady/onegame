using Snake.Library;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake.Panels
{
    internal sealed partial class Game : ContentPanel
    {
        private readonly List<Circle> snake = new List<Circle>();
        private Circle food = new Circle();
        private readonly Timer timer = new Timer();
        private int score;
        private Direction direction = Direction.None;

        internal Game()
        {
            InitializeComponent();
            Score = 0;

            timer.Interval = 1000/Settings.Speed;
            timer.Tick += UpdateScreen;
            timer.Start();

            StartGame();
        }

        private int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                scoreCount.Text = score.ToString();
            }
        }

        private void StartGame()
        {
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            snake.Add(head);

            GenerateFood();
        }
        private void GenerateFood()
        {
            int maxX = canvas.Width/Settings.Width;
            int maxY = canvas.Height/Settings.Height;

            Random random = new Random();
            food = new Circle();
            food.X = random.Next(0, maxX);
            food.Y = random.Next(0, maxY);
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if      ((Input.KeyPressed(Keys.Left)  || Input.KeyPressed(Keys.A)) && direction != Direction.Right) direction = Direction.Left;
            else if ((Input.KeyPressed(Keys.Right) || Input.KeyPressed(Keys.D)) && direction != Direction.Left)  direction = Direction.Right;
            else if ((Input.KeyPressed(Keys.Up)    || Input.KeyPressed(Keys.W)) && direction != Direction.Down)  direction = Direction.Up;
            else if ((Input.KeyPressed(Keys.Down)  || Input.KeyPressed(Keys.S)) && direction != Direction.Up)    direction = Direction.Down;
            MovePlayer();
            canvas.Invalidate();
        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < snake.Count; i++)
            {
                if (i == 0) e.Graphics.FillEllipse(Brushes.Red, new Rectangle(snake[i].X*Settings.Width, snake[i].Y*Settings.Height, Settings.Width, Settings.Height));
                else e.Graphics.FillEllipse(Brushes.Green, new Rectangle(snake[i].X*Settings.Width, snake[i].Y*Settings.Height, Settings.Width, Settings.Height));
                e.Graphics.FillRectangle(Brushes.Yellow, new Rectangle(food.X*Settings.Width, food.Y*Settings.Height, Settings.Width, Settings.Height));
            }
        }
        private void MovePlayer()
        {
            for (int i = snake.Count-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (direction)
                    {
                        case Direction.Left:
                            snake[0].X--;
                            break;
                        case Direction.Right:
                            snake[0].X++;
                            break;
                        case Direction.Up:
                            snake[0].Y--;
                            break;
                        case Direction.Down:
                            snake[0].Y++;
                            break;
                    }
                    int maxX = canvas.Width/Settings.Width;
                    int maxY = canvas.Height/Settings.Height;
                    if (snake[i].X < 0 || snake[i].X >= maxX || snake[i].Y < 0 || snake[i].Y >= maxY) {timer.Stop(); ((GameWindow)FindForm()).Panel = new End(Score);}
                    for (int j = 1; j < snake.Count; j++) if (snake[i].X == snake[j].X && snake[i].Y == snake[j].Y) {timer.Stop(); ((GameWindow)FindForm()).Panel = new End(Score);}
                    if (snake[0].X == food.X && snake[0].Y == food.Y) Eat();
                }
                else
                {
                    snake[i].X = snake[i-1].X;
                    snake[i].Y = snake[i-1].Y;
                }
            }
        }
        private void Eat()
        {
            Circle circle = new Circle();
            circle.X = snake[snake.Count-1].X;
            circle.Y = snake[snake.Count-1].Y;
            snake.Add(circle);

            Score += Settings.Points;

            GenerateFood();
        }
    }
}
