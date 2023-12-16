using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 图表.ViewModels
{
    public class FlowDocumentViewModel : INotifyPropertyChanged
    {
        private string _name;
        //private YourSeriesType _series1; // 替换 YourSeriesType 为实际的类型
                                         // ... 其他属性的声明

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        //public YourSeriesType Series1
        //{
        //    get => _series1;
        //    set
        //    {
        //        _series1 = value;
        //        OnPropertyChanged();
        //    }
        //}

        // ... 其他属性的getter和setter

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
