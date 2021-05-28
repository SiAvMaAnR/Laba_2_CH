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
    class ShowViewModel:BaseViewModel
    {
        private static ObservableCollection<InsuranceCompany> insuranceCompanies = new ObservableCollection<InsuranceCompany>();
        public static ObservableCollection<InsuranceCompany> InsuranceCompanies
        {
            get
            {
                return insuranceCompanies;
            }
            set
            {
                insuranceCompanies = value;
            }
        }

        private static ObservableCollection<OilAndGasCompany> oilAndGasCompanies = new ObservableCollection<OilAndGasCompany>();
        public static ObservableCollection<OilAndGasCompany> OilAndGasCompanies
        {
            get
            {
                return oilAndGasCompanies;
            }
            set
            {
                oilAndGasCompanies = value;
            }
        }

        private static ObservableCollection<Factory> factories = new ObservableCollection<Factory>();
        public static ObservableCollection<Factory> Factories
        {
            get
            {
                return factories;
            }
            set
            {
                factories = value;
            }
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

        

        public static void ListToCollections()
        {
            //InsuranceCompanies.Clear();
            //OilAndGasCompanies.Clear();
            //Factories.Clear();
            //foreach (var item in Organizations)
            //{
            //    if (item is InsuranceCompany)
            //        InsuranceCompanies.Add((InsuranceCompany)item);
            //    if (item is OilAndGasCompany)
            //        OilAndGasCompanies.Add((OilAndGasCompany)item);
            //    if (item is Factory)
            //        Factories.Add((Factory)item);
            //}

            //InsuranceCompanies = new ObservableCollection<InsuranceCompany>(Organizations.Where(x => (x is InsuranceCompany)).Select(x => (InsuranceCompany)x).ToList());
            //OilAndGasCompanies = new ObservableCollection<OilAndGasCompany>(Organizations.Where(x => (x is OilAndGasCompany)).Select(x => (OilAndGasCompany)x).ToList());
            //Factories = new ObservableCollection<Factory>(Organizations.Where(x => (x is Factory)).Select(x => (Factory)x).ToList());

            //InsuranceCompanies.Add(new InsuranceCompany(2, 2, "fdg", 3, 4, 5));
            //InsuranceCompanies.Add(new InsuranceCompany(2, 2, "fdg", 3, 4, 5));
            //OilAndGasCompanies.Add(new OilAndGasCompany(2, 2, "fdg", 3, 4, 5));
            //Factories.Add(new Factory(2, 2, "fdg", 3, 4, 5));
        }

        public static async void CollectionToList()
        {
            await Task.Run(() =>
            {
                Organizations.Clear();
                Organizations.AddRange(InsuranceCompanies);
                Organizations.AddRange(OilAndGasCompanies);
                Organizations.AddRange(Factories);
            });
        }

        
    }
}
