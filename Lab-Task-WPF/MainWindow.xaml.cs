using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_Task_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object myLock = new object();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void calculateFileSum(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            int fileSum = 0;
            int total;
            string strTotal="";

            while (!sr.EndOfStream)
            {
                fileSum += Convert.ToInt32(sr.ReadLine());
            }

            //only one Thread at a time allowed to run the following 
            lock (myLock)
            {
                //get total from textBoxAction
                Action a1 = delegate () { strTotal = this.totalTextBox.Text; };
                this.totalTextBox.Dispatcher.Invoke(a1); //Worker Thread block

                //Convert the total to an Int
                total = Convert.ToInt32(strTotal);

                //add file total to whole total
                total += fileSum;

                //Set total on the TextBox
                Action a2 = delegate () { strTotal = total.ToString(); };
                this.totalTextBox.Dispatcher.Invoke(a2); //Worker Thread block

            }

        }




        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {
            string s1 = this.file1TextBox.Text;
            string s2 = this.file2TextBox.Text;
            Action a1 = delegate () { calculateFileSum(s1); };
            Action a2 = delegate () { calculateFileSum(s2); };

            Task t1 = new Task(a1);
            Task t2 = new Task(a2);
            t1.Start();
            t2.Start();
        }
    }
}
