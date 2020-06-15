using Microsoft.Win32;
using SerchApplicationManager.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;

namespace SerchApplicationManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<exclude> excludeList = new ObservableCollection<exclude>();
        ObservableCollection<statistics_apps> statistics_appsList = new ObservableCollection<statistics_apps>();
        ObservableCollection<apps> appsList = new ObservableCollection<apps>();
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SqlSugarHelper.Init("server=192.168.90.11;port=3306;database=companyapps;uid=companyapps;pwd=companyapps;SslMode=None;");
            LoadExclude();
            LoadStatistics();
        }

        /// <summary>
        /// 加载排除的名称列表
        /// </summary>
        private void LoadExclude()
        {
            using (var db = SqlSugarHelper.GetInstance())
            {
                var li = db.Queryable<exclude>().OrderBy("excludeappname asc").ToList();
                foreach (var item in li)
                {
                    excludeList.Add(item);
                }
                guolvList.ItemsSource = excludeList;
                guolvList.DisplayMemberPath = "excludeappname";
            }
        }

        /// <summary>
        /// 加载统计
        /// </summary>
        private void LoadStatistics()
        {
            using (var db = SqlSugarHelper.GetInstance())
            {
                var li = db.Queryable<statistics_apps>().OrderBy("count desc").ToList();
                foreach (var item in li)
                {
                    statistics_appsList.Add(item);
                }
                lvStatistics.ItemsSource = statistics_appsList;
                loadTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            }
        }

        /// <summary>
        /// 谁在用这个APP
        /// </summary>
        /// <param name="appName"></param>
        private void LoadWhoUsed(string appName)
        {
            appsList.Clear();
            using (var db = SqlSugarHelper.GetInstance())
            {
                var li = db.Queryable<apps>().Where(c => c.appname == appName).ToList();
                foreach (var item in li)
                {
                    appsList.Add(item);
                }
                whoUsed.ItemsSource = appsList;
            }
        }

        /// <summary>
        /// 添加模糊排除关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var guanjianzi = tbAppName.Text.Trim();

            if (guanjianzi.Length == 0) return;
            bool findFlag = false;

            foreach (var item in excludeList)
            {
                if (item.excludeappname == guanjianzi)
                {
                    findFlag = true;
                    break;
                }
            }

            if (!findFlag)
            {
                using (var db = SqlSugarHelper.GetInstance())
                {
                    try
                    {
                        var id = db.Insertable<exclude>(new exclude() { excludeappname = guanjianzi }).ExecuteReturnIdentity();
                        if (id > 0)
                        {
                            var exclude = db.Queryable<exclude>().Single(c => c.id == id);
                            if (exclude != null)
                            {
                                excludeList.Insert(0, exclude);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 删除模糊排除关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var exclude = guolvList.SelectedItem as exclude;
            if (exclude == null) return;
            var guanjianzi = exclude.excludeappname;
            var result = MessageBox.Show("确定删除已排除的关键字[" + guanjianzi + "]?", "删除确认", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                using (var db = SqlSugarHelper.GetInstance())
                {
                    var count = db.Deleteable<exclude>(exclude).ExecuteCommand();
                    if (count > 0)
                    {
                        excludeList.Remove(exclude);
                        //MessageBox.Show("已从排除的名称库中删除:[" + guanjianzi + "]关键字.");
                    }
                    else
                    {
                        MessageBox.Show("删除关键字失败,请联系管理员.");
                    }
                }
            }
        }

        private void lvStatistics_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = lvStatistics.SelectedItem as statistics_apps;
            if (selectedItem != null && selectedItem is statistics_apps)
            {
                LoadWhoUsed(selectedItem.appname);
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (var db = SqlSugarHelper.GetInstance())
            {
                var li = db.Queryable<statistics_apps>().OrderBy("count desc").ToList();
                statistics_appsList.Clear();
                foreach (var item in li)
                {
                    statistics_appsList.Add(item);
                }
                loadTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = lvStatistics.SelectedItem as statistics_apps;
            if (selectedItem != null && selectedItem is statistics_apps)
            {
                tbAppName.Text = selectedItem.appname;
            }
        }

        //public static void SaveAsExcel(DataTable dt1)
        //{
        //    SaveFileDialog sfd = new SaveFileDialog();
        //    sfd.Filter = "导出文件 (*.csv)|*.csv";
        //    sfd.FilterIndex = 0;
        //    sfd.RestoreDirectory = true;
        //    sfd.Title = "导出文件保存路径";
        //    sfd.ShowDialog();
        //    string strFilePath = sfd.FileName;
        //    StringBuilder strValue = new StringBuilder();


        //    StreamWriter sw = new StreamWriter(new FileStream(strFilePath, FileMode.CreateNew), Encoding.Default);

        //    // 输出表头
        //    BusiDetail bd = new BusiDetail(); 这里的BusiDetail是你执行导出操作所在的BusiDetail.xaml
        //    bd.WriteHeader(sw);


        //    foreach (DataRow dr in dt1.Rows)
        //    {
        //        strValue.Remove(0, strValue.Length);


        //        for (int i = 0; i <= dt1.Columns.Count - 1; i++)
        //        {
        //            strValue.Append(dr[i].ToString());
        //            strValue.Append(",");
        //        }
        //        strValue.Remove(strValue.Length - 1, 1);//移出掉最后一个,字符
        //        sw.WriteLine(strValue);
        //    }
        //    sw.Close();


        //    System.Windows.MessageBox.Show("导出文件成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
        //}


        ///// <summary>
        ///// 输出表头
        ///// </summary>
        ///// <param name="sw"></param>
        //private void WriteHeader(StreamWriter sw)
        //{
        //    string strHeader = "时间,中文名称,英文名称,地市名称";
        //    sw.WriteLine(strHeader);
        //}
    }
}
