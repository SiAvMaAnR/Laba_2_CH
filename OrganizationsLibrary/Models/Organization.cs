using System;
using System.Xml.Serialization;

namespace Organizations
{
    /// <summary>
    /// Организация
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Factory))]
    [XmlInclude(typeof(InsuranceCompany))]
    [XmlInclude(typeof(OilAndGasCompany))]
    public abstract class Organization
    {

        #region Поля и Свойства
        /// <summary>
        /// Число сотрудников
        /// </summary>
        private int numberOfEmployees;
        public int NumberOfEmployees
        {
            get => numberOfEmployees;
            set => numberOfEmployees = value;
        }

        /// <summary>
        /// Прибыль млн.р. в год
        /// </summary>
        private double income;
        public double Income
        {
            get => income;
            set => income = value;
        }

        /// <summary>
        /// Лидер организации
        /// </summary>
        private string leader;
        public string Leader
        {
            get => leader;
            set => leader = value;
        }
        #endregion

        #region Конструктор
        /// <summary>
        /// Организация
        /// </summary>
        /// <param name="numberOfEmployees">Количество сотрудников</param>
        /// <param name="income">Прибыль</param>
        /// <param name="leader">Лидер организации</param>
        //public Organization(int numberOfEmployees, double income, string leader)
        //{
        //    this.NumberOfEmployees = numberOfEmployees;
        //    this.Income = income;
        //    this.Leader = leader;
        //}
        public Organization() { }
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
