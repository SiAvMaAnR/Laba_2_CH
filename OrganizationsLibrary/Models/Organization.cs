using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizations
{

    /// <summary>
    /// Организация
    /// </summary>
    public abstract class Organization
    {
        #region Конструктор
        /// <summary>
        /// Организация
        /// </summary>
        /// <param name="numberOfEmployees">Количество сотрудников</param>
        /// <param name="income">Прибыль</param>
        /// <param name="leader">Лидер организации</param>
        public Organization(int numberOfEmployees, double income, string leader)
        {
            NumberOfEmployees = numberOfEmployees;
            Income = income;
            Leader = leader;
        }

        #endregion

        #region Свойства
        /// <summary>
        /// Число сотрудников
        /// </summary>
        public int NumberOfEmployees { get; set; }

        /// <summary>
        /// Прибыль млн.р. в год
        /// </summary>
        public double Income { get; set; }

        /// <summary>
        /// Лидер организации
        /// </summary>
        public string Leader { get; set; }

        #endregion

        #region Методы
        /// <summary>
        /// Прибыль с одного сотрудника
        /// </summary>
        /// <returns>Млн.р</returns>
        public double ProfitPerEmployee() => Income / ((double)NumberOfEmployees);
        
        
        /// <summary>
        /// Прибыль за заданное время
        /// </summary>
        /// <param name="time">Время</param>
        /// <returns>Млн.р</returns>
        public double ProfitForTime(TimeSpan time) => Income * (time.TotalSeconds / TimeSpan.FromDays(365).TotalSeconds);
        
        
        /// <summary>
        /// Время которое понадобится на получение этой суммы организацией
        /// </summary>
        /// <param name="income">Необходимая прибыль в млн.р.</param>
        /// <returns>Время</returns>
        public TimeSpan TimeByProfit(double income) => TimeSpan.FromSeconds((income / Income) * TimeSpan.FromDays(365).TotalSeconds);

        #endregion

        /// <summary>
        /// Информация об организации в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Число сотрудников: {NumberOfEmployees} чел.\nПрибыль: {Income} млн.р.\nЛидер: {Leader}";
        
        /// <summary>
        /// Содержат ли свойства объекта заданную строку
        /// </summary>
        /// <param name="text">Искомая строка</param>
        public abstract bool IsContains(string text);
    }
}
