using GalaSoft.MvvmLight.Command;
using Organizations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laba2.Models
{
    public class MainViewModel : BaseViewModel
    {
        private static ObservableCollection<InsuranceCompany> insuranceCompanies;
        public static ObservableCollection<InsuranceCompany> InsuranceCompanies
        {
            get => insuranceCompanies;
            set => insuranceCompanies = value;
        }

        private static ObservableCollection<OilAndGasCompany> oilAndGasCompanies;
        public static ObservableCollection<OilAndGasCompany> OilAndGasCompanies
        {
            get => oilAndGasCompanies;
            set => oilAndGasCompanies = value;
        }

        private static ObservableCollection<Factory> factories;
        public static ObservableCollection<Factory> Factories
        {
            get => factories;
            set => factories = value;
        }

        private string textSearch;
        public string TextSearch
        {
            get { return textSearch; }
            set
            {
                textSearch = value;
                OnPropertyChanged(nameof(textSearch));
            }
        }

        public MainViewModel()
        {
            InsuranceCompanies = new ObservableCollection<InsuranceCompany>();
            OilAndGasCompanies = new ObservableCollection<OilAndGasCompany>();
            Factories = new ObservableCollection<Factory>();
        }

        private static async void XmlToList()
        {
            Organizations = await XmlLoadAsync(Path);
        }

        public ICommand LoadedCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    XmlToList();
                    ListToCollections();
                });
            }
        }

        private static void ListToCollections()
        {
            InsuranceCompanies.Clear();
            OilAndGasCompanies.Clear();
            Factories.Clear();
            foreach (var item in Organizations)
            {
                if (item is InsuranceCompany)
                    InsuranceCompanies.Add((InsuranceCompany)item);
                if (item is OilAndGasCompany)
                    OilAndGasCompanies.Add((OilAndGasCompany)item);
                if (item is Factory)
                    Factories.Add((Factory)item);
            }
            //InsuranceCompanies = new ObservableCollection<InsuranceCompany>(Organizations.Where(x => (x is InsuranceCompany)).Select(x=>(InsuranceCompany)x).ToList());
            //OilAndGasCompanies = new ObservableCollection<OilAndGasCompany>(Organizations.Where(x => (x is OilAndGasCompany)).Select(x=>(OilAndGasCompany)x).ToList());
            //Factories = new ObservableCollection<Factory>(Organizations.Where(x => (x is Factory)).Select(x=>(Factory)x).ToList());
        }



        public async void CollectionToList()
        {
            await Task.Run(() =>
            {
                Organizations.Clear();
                Organizations.AddRange(InsuranceCompanies);
                Organizations.AddRange(OilAndGasCompanies);
                Organizations.AddRange(Factories);
            });
        }


        public async void ListToXml()
        {
            await XmlSaveAsync(Path, Organizations);
        }

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            CollectionToList();
            ListToXml();
        }
    }
}
