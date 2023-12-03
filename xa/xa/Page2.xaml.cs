using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;




namespace xa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        private double ballX, ballY, ballSpeedX, ballSpeedY;
        private double paddleX, paddleWidth, paddleHeight;
       

        public Page2()
        {
            InitializeComponent();

            // Ініціалізуємо початкові значення для м'яча та ракетки
            ballX = 10;
            ballY = 10;
            ballSpeedX = 2;
            ballSpeedY = 2;

          paddleX = 10;
           
            paddleWidth = 50;
            paddleHeight = 50;

            var panGestureRecognizer = new PanGestureRecognizer();
            panGestureRecognizer.PanUpdated += OnPanUpdated;
            tennisPaddle.GestureRecognizers.Add(panGestureRecognizer);
            

            // Запускаємо ігровий цикл
            Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
            {
                UpdateGame();
                return true;
            });
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    // Початок руху пальця
                    break;

                case GestureStatus.Running:
                    // Постійне оновлення позначки X та Y під час руху пальця
                    double newTranslationX = tennisPaddle.TranslationX + e.TotalX;
                    double newTranslationY = tennisPaddle.TranslationY + e.TotalY;

                    // Перевірка, чи нові координати не виходять за межі гри
                    if (newTranslationX >= 0)
                    {
                        tennisPaddle.TranslationX = newTranslationX;
                    }

                    if (newTranslationY >= 0)
                    {
                        tennisPaddle.TranslationY = newTranslationY;
                    }
                    break;

                case GestureStatus.Completed:
                    // Завершення руху пальця
                    break;
            }
        }




        private void UpdateGame()
        {
            // Оновлення координат м'яча
            ballX += ballSpeedX;
            ballY += ballSpeedY;

            // Відбивання м'яча від стінок
            if (ballX < 0 || ballX > this.Width - 20) // Враховуємо ширину м'яча
            {
                ballSpeedX *= -1;
            }

            if (ballY < 0 || ballY > this.Height - 20) // Враховуємо висоту м'яча
            {
                ballSpeedY *= -1;
            }

            // Відбивання м'яча від ракетки
            if (ballY + 20 > tennisPaddle.TranslationY && ballY < tennisPaddle.TranslationY + paddleHeight)
            {
                if (ballX + 20 > paddleX && ballX < paddleX + paddleWidth)
                {
                    ballSpeedY *= -1;
                }
            }

            // Відображення елементів на екрані
            tennisBall.TranslationX = ballX;
            tennisBall.TranslationY = ballY;

            tennisPaddle.TranslationX = paddleX;
            tennisPaddle.TranslationY = this.Height - paddleHeight; // Розміщуємо ракетку внизу екрану
        }
    }
}