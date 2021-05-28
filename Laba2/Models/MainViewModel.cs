using Organizations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Models
{
    public class MainViewModel : BaseViewModel
    {
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
            XmlToList();
            ListToCollections();
        }


        private static async void XmlToList()
        {
            Organizations = await XmlLoadAsync(Path);
        }


        private static void ListToCollections()
        {
            InsuranceCompanies = new ObservableCollection<InsuranceCompany>(Organizations.Where(x => (x is InsuranceCompany)).Select(x=>(InsuranceCompany)x).ToList());
            OilAndGasCompanies = new ObservableCollection<OilAndGasCompany>(Organizations.Where(x => (x is OilAndGasCompany)).Select(x=>(OilAndGasCompany)x).ToList());
            Factories = new ObservableCollection<Factory>(Organizations.Where(x => (x is Factory)).Select(x=>(Factory)x).ToList());
        }

        public async void ListToXml()
        {
            await XmlSaveAsync(Path, Organizations);
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

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            CollectionToList();
            ListToXml();
        }
    }
}
