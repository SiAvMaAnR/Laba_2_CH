using Organizations;
using System.Collections.ObjectModel;

namespace Laba2.Models
{
    class SearchModel : BaseViewModel
    {
        private static ObservableCollection<InsuranceCompany> searchInsuranceCompanies = new ObservableCollection<InsuranceCompany>();
        public static ObservableCollection<InsuranceCompany> SearchInsuranceCompanies
        {
            get => searchInsuranceCompanies;
            set => searchInsuranceCompanies = value;
        }

        private static ObservableCollection<OilAndGasCompany> searchOilAndGasCompanies = new ObservableCollection<OilAndGasCompany>();
        public static ObservableCollection<OilAndGasCompany> SearchOilAndGasCompanies
        {
            get => searchOilAndGasCompanies;
            set => searchOilAndGasCompanies = value;
        }

        private static ObservableCollection<Factory> searchFactories = new ObservableCollection<Factory>();
        public static ObservableCollection<Factory> SearchFactories
        {
            get => searchFactories;
            set => searchFactories = value;
        }
    }
}
