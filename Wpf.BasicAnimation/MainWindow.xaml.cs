using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Wpf.BasicAnimation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = 160;
            widthAnimation.To = this.Width - 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(10);
            //widthAnimation.AutoReverse = true;
            widthAnimation.Completed += WidthAnimation_Completed;
            
            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = 40;
            heightAnimation.To = this.Height - 50;
            heightAnimation.Duration = TimeSpan.FromSeconds(5);
            heightAnimation.FillBehavior = FillBehavior.Stop;
            heightAnimation.AccelerationRatio = 0.3;
            heightAnimation.DecelerationRatio = 0.3;
            //heightAnimation.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(13));
            heightAnimation.RepeatBehavior = RepeatBehavior.Forever;

            myButton.BeginAnimation(Button.WidthProperty, widthAnimation);
            myButton.BeginAnimation(Button.HeightProperty, heightAnimation);
            myButton.Width = 20;
        }

        private void WidthAnimation_Completed(object? sender, EventArgs e)
        {
            myButton.BeginAnimation(Button.WidthProperty, null);
        }
    }
}
