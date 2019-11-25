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

            while (!sr.EndOfStream)
            {
                fileSum += Convert.ToInt32(sr.ReadLine());
            }

            //Pm;y one Thread at a time allowed to run the following 
            lock (myLock)
            {

            }

        }
            

       

        private void calculateBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
