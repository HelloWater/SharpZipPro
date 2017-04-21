using System;
using System.Collections.Generic;
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

namespace SharpZipPro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "SharpZipUnZip";
        }

        void OnClickZip(object sender, RoutedEventArgs e)
        {
            string[] FileProperties = new string[2];
            FileProperties[0] = ".\\ZipDir\\"; //待压缩的文件目录
            FileProperties[1] = ".\\ZipDir.zip"; //压缩后的目标文件
            ZipFloClass Zc = new ZipFloClass();
            Zc.ZipFile(FileProperties[0],FileProperties[1]);

            System.Windows.MessageBox.Show("Zip Directory Finish!", "Zip");
        }
        void OnClickUnZip(object sender, RoutedEventArgs e)
        {
            string[] FileProperties = new string[2];
            FileProperties[0] = ".\\ZipDir.zip"; //待压缩的文件
            FileProperties[1] = ".\\ZipDir\\"; //解压后放置的目标目录
            UnZipFloClass UnZc = new UnZipFloClass();
            UnZc.unZipFile(FileProperties[0], FileProperties[1]);

            System.Windows.MessageBox.Show("UnZip Directory Finish!", "UnZip");
        }
    }
}
