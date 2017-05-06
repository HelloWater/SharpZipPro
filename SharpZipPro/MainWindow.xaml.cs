using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

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
            FolderBrowserDialog m_Dialog = new FolderBrowserDialog();
            DialogResult result = m_Dialog.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string m_Dir = m_Dialog.SelectedPath.Trim();

            string[] sFileName = m_Dir.Split('\\');
            string sName = "";
            string sPath = "";
            int iCnt = sFileName.Length;
            sName = sFileName[iCnt-1];
            sPath = m_Dir.Substring(0, m_Dir.Length - sName.Length);

            if(sName.Length>0)
            {
                sName += ".zip";
                sName = sPath + sName;

                ZipFloClass Zc = new ZipFloClass();
                Zc.ZipFile(m_Dir, sName);

                System.Windows.MessageBox.Show("Zip Directory Finish!", "Zip");
            }
        }
        void OnClickUnZip(object sender, RoutedEventArgs e)
        {
//             string[] FileProperties = new string[2];
//             FileProperties[0] = ".\\ZipDir.zip"; //待压缩的文件
//             FileProperties[1] = ".\\ZipDir\\"; //解压后放置的目标目录
//             UnZipFloClass UnZc = new UnZipFloClass();
//             UnZc.unZipFile(FileProperties[0], FileProperties[1]);

            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Zip Files(*.zip)|*.zip"
            };
            var result = openFileDialog.ShowDialog();
            if(result == true)
            {
                string sFile = openFileDialog.FileName;
                string[]sPaths = sFile.Split('.');
                string sPath = sPaths[0];
                if(sFile.Length>0 && sPath.Length>0)
                {
                    UnZipFloClass UnZc = new UnZipFloClass();
                    UnZc.unZipFile(sFile,sPath);

                    System.Windows.MessageBox.Show("UnZip Directory Finish!", "UnZip");
                }
            }
        }
    }
}
