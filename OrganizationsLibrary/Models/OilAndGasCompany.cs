using System;

namespace Organizations
{
    /// <summary>
    /// Нефтегазовая компания
    /// </summary>
    [Serializable]
    public class OilAndGasCompany : Organization
    {
        #region Конструктор
        /// <summary>
        /// Нефтегазовая компания
        /// </summary>
        /// <param name="numberOfEmployees">Количество сотрудников</param>
        /// <param name="income">Прибыль в млн.р.</param>
        /// <param name="leader">Глава</param>
        /// <param name="cubicMetersOfGasPerMinute">Производит куб.м. газа в минуту</param>
        /// <param name="numberOfWells">Кол-во скважин</param>
        /// <param name="costOfEquipment">Стоимость оборудования (в млн.)</param>
        public OilAndGasCompany(int numberOfEmployees, double income, string leader,
                                double cubicMetersOfGasPerMinute, int numberOfWells, double costOfEquipment) :
                                base(numberOfEmployees, income, leader)
        {
            CubicMetersOfGasPerMinute = cubicMetersOfGasPerMinute;
            NumberOfWells = numberOfWells;
            CostOfEquipment = costOfEquipment;
        }
        #endregion

        #region Константы
        /// <summary>
        /// Расход газа Россией за минуту
        /// </summary>
        const double RussiaGasConsumptionPerMinute = 857060.19;
        #endregion

        #region Свойства
        /// <summary>
        /// Производит N кубометров газа в минуту
        /// </summary>
        public double CubicMetersOfGasPerMinute { get; set; }

        /// <summary>
        /// Количество скважин
        /// </summary>
        public int NumberOfWells { get; set; }

        /// <summary>
        /// Стоимость оборудования (в миллионах)
        /// </summary>
        public double CostOfEquipment { get; set; }
        #endregion

        #region Методы

        /// <summary>
        /// Процент производства газа от потребления РФ
        /// </summary>
        /// <returns>Проценты</returns>
        public double GetShareOfRussianConsumption() => (CubicMetersOfGasPerMinute / RussiaGasConsumptionPerMinute) * 100;


        /// <summary>
        /// Производство газа с одной скважины за минуту
        /// </summary>
        /// <returns>Куб.метры</returns>
        public double GetGasProducePerWell() => CubicMetersOfGasPerMinute / NumberOfWells;


        /// <summary>
        /// Прибыль с одного кубического метра газа
        /// </summary>
        /// <returns>Рубли</returns>
        public double GetProfitPerGasCubicMeter() => ((Income / TimeSpan.FromDays(365).TotalMinutes) / CubicMetersOfGasPerMinute) * 1000000;
        #endregion

        /// <summary>
        /// Информация об организации в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString() + $"Производит газ: {CubicMetersOfGasPerMinute} куб.м./мин.\nКоличество скважин: {NumberOfWells} ед.\nСтоимость оборудования: {CostOfEquipment} млн.р.";
        
        public override bool IsContains(string text)
        {
            text = text.ToUpper();
            return (NumberOfEmployees.ToString().Contains(text)
                || Income.ToString().Contains(text)
                || Leader.Contains(text)
                || CubicMetersOfGasPerMinute.ToString().Contains(text)
                || NumberOfWells.ToString().Contains(text)
                || CostOfEquipment.ToString().Contains(text)); 
        }
    }
}
