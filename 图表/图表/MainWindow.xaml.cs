using Microsoft.Graph.Models.CallRecords;
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
using 图表.ViewModels;

namespace 图表
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 绑定ViewModel
            var dataContext = new MainWindowViewModel();
            this.DataContext = dataContext;
            DeviceInfo deviceInfo = new DeviceInfo();
            deviceInfo.AdditionalData.Add("Name", "abcdefghigklmn");

            var printPre = new PrintPreView("FlowDocument1.xaml", deviceInfo); 
            printPre.ShowDialog();

        }
    }

    
}
