using System;
using System.Windows;
using System.Windows.Threading;
using ViewModel.Interfaces;

namespace Queue.Concrete
{
    public class ViewService : IViewService
    {
        /// <summary>
        /// Provides the service.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="DataContext">The data context.</param>
        public void ProvideService(object DataContext)
        {
            if (DataContext is Exception)
                this.ShowMessageBox((DataContext as Exception).Message);
        }

        /// <summary>
        /// Shows the exception.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="exception">The exception with message to show.</param>
        private void ShowMessageBox(string message)
        {
            Action action = new Action(() =>
            {
                MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            });
            this.View?.Dispatcher.BeginInvoke(action, DispatcherPriority.Normal, null).Wait();
        }

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The view.
        /// </value>
        private DependencyObject View { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewService"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="view">The view.</param>
        public ViewService(DependencyObject view)
        {
            this.View = view;
        }
    }
}
