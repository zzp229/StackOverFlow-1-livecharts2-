using System;
using System.Collections.Generic;
using System.IO.Packaging;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using Microsoft.Graph.Models.CallRecords;
using 图表.ViewModels;

namespace 图表
{
    /// <summary>
    /// PrintPreView.xaml 的交互逻辑
    /// </summary>
    public partial class PrintPreView : Window
    {
        public PrintPreView()
        {
            InitializeComponent();
        }

        public PrintPreView(string fileName, DeviceInfo data)
        {
            InitializeComponent();
            var flowDocument = (FlowDocument)Application.LoadComponent(new Uri(fileName, UriKind.RelativeOrAbsolute));
            //flowDocument.DataContext = data;
            var dataContext = new FlowDocumentViewModel();
            dataContext.Name = "abcdefghijk";
            flowDocument.DataContext = dataContext;
            Dispatcher.BeginInvoke(() =>
{
                MemoryStream ms = new MemoryStream();
                Package package = Package.Open(ms, FileMode.Create, FileAccess.ReadWrite);
                Uri DocumentUri = new Uri("pack://InMemoryDocument.xps");
                PackageStore.RemovePackage(DocumentUri);
                PackageStore.AddPackage(DocumentUri, package);
                XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);

                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);
                var paginator = (flowDocument as IDocumentPaginatorSource).DocumentPaginator;
                writer.Write(paginator);

                viewer.Document = xpsDocument.GetFixedDocumentSequence();

                xpsDocument.Close();
            }, DispatcherPriority.ApplicationIdle);

        }
    }
}
