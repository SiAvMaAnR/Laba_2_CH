using Organizations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laba2.Models
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public static string Path { get; } = @"data.xml";

        private static List<Organization> organizations = new List<Organization>();
        public static List<Organization> Organizations
        {
            get
            {
                return organizations;
            }
            set
            {
                organizations = value;
            }
        }

        private static ObservableCollection<InsuranceCompany> insuranceCompanies = new ObservableCollection<InsuranceCompany>();
        public static ObservableCollection<InsuranceCompany> InsuranceCompanies
        {
            get => insuranceCompanies;
            set => insuranceCompanies = value;
        }

        private static ObservableCollection<OilAndGasCompany> oilAndGasCompanies = new ObservableCollection<OilAndGasCompany>();
        public static ObservableCollection<OilAndGasCompany> OilAndGasCompanies
        {
            get => oilAndGasCompanies;
            set => oilAndGasCompanies = value;
        }

        private static ObservableCollection<Factory> factories = new ObservableCollection<Factory>();
        public static ObservableCollection<Factory> Factories
        {
            get => factories;
            set => factories = value;
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="list">Список</param>
        /// <returns></returns>
        public async Task<bool> XmlSaveAsync<T>(string path, List<Organization> list)
        {
            return await Task.Run(() =>
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {
                        serializer.Serialize(fs, list);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            });
        }

        /// <summary>
        /// Десерилизация
        /// </summary>
        public async Task<List<Organization>> XmlLoadAsync(string path)
        {
            return await Task.Run(() =>
            {
                try
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Organization>));
                    using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    {
                        return (List<Organization>)formatter.Deserialize(fs);
                    }
                }
                catch
                {
                    return default(List<Organization>);
                }
            }) ?? new List<Organization>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
