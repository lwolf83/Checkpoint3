using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace C3Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGet_Click(object sender, RoutedEventArgs e)
        {
            UserFile userFile = ServerRequest.GetFile(FilePath.Text);
            DisplayResult(userFile, "Load");
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            UserFile userFile = ServerRequest.DeleteFile(FilePath.Text);
            DisplayResult(userFile, "Delete");
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            UserFile userFile = ServerRequest.CreateFile(FilePath.Text);
            DisplayResult(userFile, "Create");
        }

        private void DisplayResult(UserFile userFile, String Action)
        {
            string status = "";
            if (userFile.Exist)
            {
                status = "File exist : Yes - File size : " + userFile.FileSize + " o";
            }
            else
            {
                if(Action == "Delete")
                {
                    status = "The file has been deleted.";
                }
                else
                {
                    status = "File doesn't exist.";
                }
                
            }
            Status_TextBox.Content = status;
            Content_TextBlock.Text = userFile.Content;
        }








    }
}
