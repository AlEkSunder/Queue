using System;
using System.Windows;
using Queue.Concrete;
using ViewModel.Concrete;

namespace Queue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new QueueViewModel(new ViewService(this));
        }
    }
}
