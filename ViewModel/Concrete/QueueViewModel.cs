using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Model.Concrete;
using Model.Interfaces;
using ViewModel.Interfaces;

namespace ViewModel.Concrete
{
    /// <summary>
    /// Provides functionality to represent model for presentation layer.
    /// </summary>
    /// <owner>Aleksey Beletsky</owner>
    /// <seealso cref="INotifyPropertyChanged" />
    public class QueueViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Holds the clear command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private ICommand clear;

        /// <summary>
        /// Holds the dequeue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private ICommand dequeue;

        /// <summary>
        /// Holds the enqueue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private ICommand enqueue;

        /// <summary>
        /// Holds the entered value.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private string enteredValue;

        /// <summary>
        /// Holds the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private IQueue<string> queue;

        /// <summary>
        /// Holds the available queue types.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private IEnumerable<string> queueTypes;

        /// <summary>
        /// Holds the selected queue type.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private string selectedQueueType;

        /// <summary>
        /// Holds the updated queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private string updatedQueue;

        /// <summary>
        /// Holds the view service for showing information for user.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private IViewService viewService;

        /// <summary>
        /// Gets the clear command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The clear command.
        /// </value>
        public ICommand ClearCommand
        {
            get
            {
                return this.clear ?? (this.clear = new CommandHandler(this.ClearQueue, this.viewService));
            }
        }

        /// <summary>
        /// Clears the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void ClearQueue()
        {
            this.Queue.Clear();
            this.NotifyProperties();
        }

        /// <summary>
        /// Performs the dequeue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void Dequeue()
        {
            this.EnteredValue = this.Queue.Dequeue();
            this.NotifyProperties();
        }

        /// <summary>
        /// Gets the dequeue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The dequeue command.
        /// </value>
        public ICommand DequeueCommand
        {
            get
            {
                return this.dequeue ?? (this.dequeue = new CommandHandler(this.Dequeue, this.viewService));
            }
        }

        /// <summary>
        /// Performs the enqueue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void Enqueue()
        {
            if (string.IsNullOrWhiteSpace(this.EnteredValue))
                throw new InvalidOperationException("You need to enter value.");

            this.Queue.Enqueue(this.EnteredValue);
            this.EnteredValue = string.Empty;
            this.NotifyProperties();
        }
        
        /// <summary>
        /// Gets or sets the entered value.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The entered value.
        /// </value>
        public string EnteredValue
        {
            get
            {
                return this.enteredValue;
            }
            set
            {
                if (this.enteredValue == value)
                    return;

                this.enteredValue = value;
                this.OnPropertyChanged(nameof(this.EnteredValue));
            }
        }

        /// <summary>
        /// Gets the enqueue command.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The enqueue command.
        /// </value>
        public ICommand EnqueueCommand
        {
            get
            {
                return this.enqueue ?? (this.enqueue = new CommandHandler(this.Enqueue, this.viewService));
            }
        }

        /// <summary>
        /// Initializes the available queue types list.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void IntitializeQueueTypesList()
        {
            this.queueTypes = new string[]
            {
                QueueThroughArray<string>.Name,
                QueueThroughLinkedList<string>.Name,
            };
        }

        /// <summary>
        /// Notifies the properties.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        private void NotifyProperties()
        {
            this.OnPropertyChanged(nameof(this.EnteredValue));
            this.OnPropertyChanged(nameof(this.UpdatedQueue));
        }

        /// <summary>
        /// Called when the property is changed.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the available queue types.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The available queue types.
        /// </value>
        public IEnumerable<string> QueueTypes => this.queueTypes;

        /// <summary>
        /// Gets or sets the updated queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The updated queue.
        /// </value>
        public string UpdatedQueue
        {
            get
            {
                return this.Queue.ToString();
            }
            set
            {
                if (this.updatedQueue == value)
                    return;

                this.updatedQueue = value;
                this.OnPropertyChanged(nameof(this.UpdatedQueue));
            }
        }

        /// <summary>
        /// Gets or sets the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The queue.
        /// </value>
        private IQueue<string> Queue
        {
            get
            {
                if (this.queue == null)
                    this.queue = new QueueThroughArray<string>();

                return this.queue;
            }
            set
            {
                if (this.queue == value)
                    return;

                this.queue = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueViewModel"/> class.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <param name="viewService">The view service.</param>
        public QueueViewModel(IViewService viewService)
        {
            if (viewService == null)
                throw new ArgumentNullException(nameof(viewService));

            this.viewService = viewService;
            this.IntitializeQueueTypesList();
        }

        /// <summary>
        /// Gets or sets the type of the selected queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <value>
        /// The type of the selected queue.
        /// </value>
        public string SelectedQueueType
        {
            get
            {
                if(this.selectedQueueType == null)
                    this.selectedQueueType = this.QueueTypes.FirstOrDefault();

                return this.selectedQueueType;
            }
            set
            {
                if (this.selectedQueueType == value)
                    return;

                this.selectedQueueType = value;
                this.Queue = this.SetNewQueueType();
                this.NotifyProperties();
            }
        }

        /// <summary>
        /// Sets the new type of the queue.
        /// </summary>
        /// <owner>Aleksey Beletsky</owner>
        /// <returns>The queue of the new type.</returns>
        private IQueue<string> SetNewQueueType()
        {
            if (this.SelectedQueueType.Equals(QueueThroughArray<string>.Name))
                return new QueueThroughArray<string>();
            else
                return new QueueThroughLinkedList<string>();
        }
    }
}