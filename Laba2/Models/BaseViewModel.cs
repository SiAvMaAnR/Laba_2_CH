using Organizations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
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

        public static async void XmlToList()
        {
            Organizations = await XmlLoadAsync(Path);
        }

        public static async void ListToXml()
        {
            await XmlSaveAsync(Path, Organizations);
        }

        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="path">Путь</param>
        /// <param name="list">Список</param>
        /// <returns></returns>
        public static async Task<bool> XmlSaveAsync(string path, List<Organization> list)
        {
            return await Task.Run(() =>
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Organization>));
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
        public static async Task<List<Organization>> XmlLoadAsync(string path)
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
