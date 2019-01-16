using System.Collections.ObjectModel;
using System.Windows;

namespace DragDropAppToExplorerSample
{
    /// <summary>
    /// ファイル一覧クラス
    /// </summary>
    public class MyFileList
    {
        /// <summary>
        /// ファイルリスト
        /// </summary>
        public MyFileList() => FileNames = new ObservableCollection<string>();
        /// <summary>
        /// ファイル名コレクション
        /// </summary>
        public ObservableCollection<string> FileNames { get; private set; }
    }

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ドロップ時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Drop(object sender, DragEventArgs e)
        {
            var list = DataContext as MyFileList;
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files)
            {
                foreach (string s in files)
                {
                    list.FileNames.Add(s);
                }
            }
        }

        /// <summary>
        /// ドラッグ中のマウスオーバー検知時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effects = DragDropEffects.Copy;
            }   
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }
    }
}
