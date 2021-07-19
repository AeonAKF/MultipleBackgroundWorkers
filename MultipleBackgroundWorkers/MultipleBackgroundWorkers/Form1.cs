using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleBackgroundWorkers
{
    public partial class Form1 : Form
    {
        // Pause for window update
        private int intSleep = 150;
        private Random RandomNum = new Random(); // To randomly select RGB values

        #region BackgroundWorker_ProgressBar

        private int numberToCompute = 40;
        private int highestPercentageReached = 0;
        private BackgroundWorker backgroundWorker_ProgressBar = new BackgroundWorker();

        // This event handler is where the actual, 
        // potentially time-consuming work is done. 
        private void backgroundWorker_ProgressBar_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker? worker = sender as BackgroundWorker;

            // Assign the result of the computation 
            // to the Result property of the DoWorkEventArgs 
            // object. This is will be available to the  
            // RunWorkerCompleted eventhandler.
#pragma warning disable CS8605 // Unboxing a possibly null value.
#pragma warning disable CS8604 // Possible null reference argument.
            e.Result = backgroundWorker_ProgressBar_AsyncFunction((int)e.Argument, worker, e);
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8605 // Unboxing a possibly null value.
        }

        // This event handler deals with the results of the 
        // background operation. 
        private void backgroundWorker_ProgressBar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show("ProgressBar Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                MessageBox.Show("ProgressBar Canceled");
            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                MessageBox.Show("ProgressBar Finished");
            }

        }

        // This event handler updates the progress bar. 
        private void backgroundWorker_ProgressBar_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prgMain.Value = e.ProgressPercentage;
            this.lblPrgMain.Text = e.ProgressPercentage.ToString() + " %";
        }

        // This is the method that does the actual work. For this 
        // example, it computes a Fibonacci number and 
        // reports progress as it does its work. 
        long backgroundWorker_ProgressBar_AsyncFunction(int n, BackgroundWorker worker, DoWorkEventArgs e)
        {
            // The parameter n must be >= 0 and <= 91. 
            // Fib(n), with n > 91, overflows a long. 
            if ((n < 0) || (n > 91))
            {
                throw new ArgumentException("value must be >= 0 and <= 91", "n");
            }

            long result = 0;

            // Abort the operation if the user has canceled. 
            // Note that a call to CancelAsync may have set  
            // CancellationPending to true just after the 
            // last invocation of this method exits, so this  
            // code will not have the opportunity to set the  
            // DoWorkEventArgs.Cancel flag to true. This means 
            // that RunWorkerCompletedEventArgs.Cancelled will 
            // not be set to true in your RunWorkerCompleted 
            // event handler. This is a race condition. 

            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                if (n < 2)
                {
                    result = 1;
                }
                else
                {
                    result = backgroundWorker_ProgressBar_AsyncFunction(n - 1, worker, e) +
                             backgroundWorker_ProgressBar_AsyncFunction(n - 2, worker, e);
                }

                // Report progress as a percentage of the total task. 
                int percentComplete =
                    (int)((float)n / (float)numberToCompute * 100);
                if (percentComplete > highestPercentageReached)
                {
                    highestPercentageReached = percentComplete;
                    worker.ReportProgress(percentComplete);
                }
            }

            return result;
        }

        #endregion

        #region backgroundWorker_ImageLeft

        private BackgroundWorker backgroundWorker_ImageLeft = new BackgroundWorker();

        // This event handler is where the actual, 
        // potentially time-consuming work is done. 
        private void backgroundWorker_ImageLeft_DoWork(object sender, DoWorkEventArgs e)
        {
            // Run this thread while 1st thread is busy
            while (backgroundWorker_ProgressBar.IsBusy == true)
            {
                // Get the BackgroundWorker that raised this event.
                BackgroundWorker? worker = sender as BackgroundWorker;

                // Assign the result of the computation 
                // to the Result property of the DoWorkEventArgs 
                // object. This is will be available to the  
                // RunWorkerCompleted eventhandler.
#pragma warning disable CS8604 // Possible null reference argument.
                e.Result = backgroundWorker_ImageLeft_AsyncFunction(worker, e);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        // This event handler deals with the results of the 
        // background operation. 
        private void backgroundWorker_ImageLeft_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show("ImageLeft Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                MessageBox.Show("ImageLeft Canceled");
            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                MessageBox.Show("ImageLeft Finished");
            }

        }

        // This event handler updates the progress bar. 
        private void backgroundWorker_ImageLeft_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // If the job was being calculated as a percentage then here is where you would work that out.
            //this.lblImageLeft.Text = e.ProgressPercentage.ToString() + " %";
        }

        // This is the method that does the actual work. For this 
        // example, it computes a Fibonacci number and 
        // reports progress as it does its work. 
        Color backgroundWorker_ImageLeft_AsyncFunction(BackgroundWorker worker, DoWorkEventArgs e)
        {

            Color rtnColor = Color.FromArgb(255, RandomNum.Next(255), RandomNum.Next(255), RandomNum.Next(255));

            pbLeft.BackColor = rtnColor;

            Thread.Sleep(intSleep);

            return rtnColor;
        }

        #endregion

        #region backgroundWorker_ImageRight

        private BackgroundWorker backgroundWorker_ImageRight = new BackgroundWorker();

        // This event handler is where the actual, 
        // potentially time-consuming work is done. 
        private void backgroundWorker_ImageRight_DoWork(object sender, DoWorkEventArgs e)
        {
            // Run this thread while 1st thread is busy
            while (backgroundWorker_ProgressBar.IsBusy == true)
            {
                // Get the BackgroundWorker that raised this event.
                BackgroundWorker? worker = sender as BackgroundWorker;

                // Assign the result of the computation 
                // to the Result property of the DoWorkEventArgs 
                // object. This is will be available to the  
                // RunWorkerCompleted eventhandler.
#pragma warning disable CS8604 // Possible null reference argument.
                e.Result = backgroundWorker_ImageRight_AsyncFunction(worker, e);
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        // This event handler deals with the results of the 
        // background operation. 
        private void backgroundWorker_ImageRight_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MessageBox.Show("ImageRight Error: " + e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled  
                // the operation. 
                // Note that due to a race condition in  
                // the DoWork event handler, the Cancelled 
                // flag may not have been set, even though 
                // CancelAsync was called.
                MessageBox.Show("ImageRight Canceled");
            }
            else
            {
                // Finally, handle the case where the operation  
                // succeeded.
                MessageBox.Show("ImageRight Finished");
            }

        }

        // This event handler updates the progress bar. 
        private void backgroundWorker_ImageRight_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // If the job was being calculated as a percentage then here is where you would work that out.
            //this.lblImageRight.Text = e.ProgressPercentage.ToString() + " %";
        }

        // This is the method that does the actual work. For this 
        // example, it computes a Fibonacci number and 
        // reports progress as it does its work. 
        Color backgroundWorker_ImageRight_AsyncFunction(BackgroundWorker worker, DoWorkEventArgs e)
        {

            Color rtnColor = Color.FromArgb(255, RandomNum.Next(255), RandomNum.Next(255), RandomNum.Next(255));

            pbRight.BackColor = rtnColor;

            Thread.Sleep(intSleep);

            return rtnColor;
        }

        #endregion

        public Form1()
        {
            InitializeComponent();

            // Initialise backgroundWorker_ProgressBar
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ProgressBar.DoWork += new DoWorkEventHandler(backgroundWorker_ProgressBar_DoWork);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ProgressBar.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_ProgressBar_RunWorkerCompleted);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ProgressBar.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressBar_ProgressChanged);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ProgressBar.WorkerReportsProgress = true;
            backgroundWorker_ProgressBar.WorkerSupportsCancellation = true;

            // Initialise backgroundWorker_ImageLeft
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageLeft.DoWork += new DoWorkEventHandler(backgroundWorker_ImageLeft_DoWork);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageLeft.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_ImageLeft_RunWorkerCompleted);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageLeft.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ImageLeft_ProgressChanged);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageLeft.WorkerReportsProgress = true;
            backgroundWorker_ImageLeft.WorkerSupportsCancellation = true;

            // Initialise backgroundWorker_ImageRight
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageRight.DoWork += new DoWorkEventHandler(backgroundWorker_ImageRight_DoWork);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageRight.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_ImageRight_RunWorkerCompleted);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageRight.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ImageRight_ProgressChanged);
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            backgroundWorker_ImageRight.WorkerReportsProgress = true;
            backgroundWorker_ImageRight.WorkerSupportsCancellation = true;

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Start the asynchronous operation.
            backgroundWorker_ProgressBar.RunWorkerAsync(numberToCompute);
            backgroundWorker_ImageLeft.RunWorkerAsync();
            backgroundWorker_ImageRight.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation. 
            this.backgroundWorker_ProgressBar.CancelAsync();
            this.backgroundWorker_ImageLeft.CancelAsync();
            this.backgroundWorker_ImageRight.CancelAsync();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation. 
            this.backgroundWorker_ProgressBar.CancelAsync();
            this.backgroundWorker_ImageLeft.CancelAsync();
            this.backgroundWorker_ImageRight.CancelAsync();

            Application.Exit();
        }

    }
}
