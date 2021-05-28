﻿using Organizations;
using System;
using System.Collections.Generic;
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