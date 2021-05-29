using GalaSoft.MvvmLight.Command;
using Organizations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Laba2.Models
{
    public class MainViewModel : BaseViewModel
    {
        private Page Show;
        private Page Addition;


        private Page framePage;
        public Page FramePage
        {
            get { return framePage; }
            set
            {
                framePage = value;
                OnPropertyChanged(nameof(framePage));
            }
        }

        public MainViewModel()
        {
            //LoadDataToList();
            XmlToList();

            Show = new Pages.Show();
            Addition = new Pages.Additem();

            FramePage = Show;

        }

        public ICommand Show_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    FramePage = Show;
                });
            }
        }

        public ICommand Additem_Click
        {
            get
            {
                return new RelayCommand(() =>
                {
                    FramePage = Addition;
                });
            }
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            ShowViewModel.CollectionToList();
            ShowViewModel.ListToXml();
        }
    }
}
