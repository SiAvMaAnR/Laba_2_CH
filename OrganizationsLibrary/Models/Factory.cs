using System;

namespace Organizations
{
    /// <summary>
    /// Завод
    /// </summary>
    [Serializable]
    public class Factory : Organization
    {
        #region Конструктор
        /// <summary>
        /// Завод
        /// </summary>
        /// <param name="numberOfEmployees">Количество сотрудников</param>
        /// <param name="income">Доход</param>
        /// <param name="leader">Директор</param>
        /// <param name="tonsOfProductPerYear">Тонн продукта в год</param>
        /// <param name="productUnitsPerYear">Единиц продукта в год</param>
        /// <param name="percentageOfPollution">Степень загрязнение окружаюзей среды (0-100%)</param>
        public Factory(int numberOfEmployees, double income, string leader, double tonsOfProductPerYear, int productUnitsPerYear, double percentageOfPollution) :
                       base(numberOfEmployees, income, leader)
        {
            TonsOfProductPerYear = tonsOfProductPerYear;
            ProductUnitsPerYear = productUnitsPerYear;
            PercentageOfPollution = percentageOfPollution;
        }
        #endregion

        #region Приватные поля
        private double percentageOfPollution;
        #endregion

        #region Свойства
        /// <summary>
        /// Изготавливается тон продукта в год
        /// </summary>
        public double TonsOfProductPerYear { get; set; }


        /// <summary>
        /// Единиц продукта в год
        /// </summary>
        public int ProductUnitsPerYear { get; set; }


        /// <summary>
        /// Степень загрязнения окружающей среды
        /// </summary>
        public double PercentageOfPollution
        {
            get { return percentageOfPollution; }
            set
            {
                if (value > 1) percentageOfPollution = 1;
                else if (value < 0) percentageOfPollution = 0;
                else percentageOfPollution = value;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Средняя масса продукта в килограммах
        /// </summary>
        /// <returns>Килограммы</returns>
        public double GetAverageProductWeight() => TonsOfProductPerYear / ProductUnitsPerYear * 1000;

        /// <summary>
        /// Сколько едениц продукта в среднем производит один сотрудник 
        /// </summary>
        /// <returns>Ед.продукта</returns>
        public double GetProductUnitsPerEmploeeForYear() => ProductUnitsPerYear / NumberOfEmployees;

        /// <summary>
        /// Прибыль с одной еденицы продукта
        /// </summary>
        /// <returns>Рубли</returns>
        public double GetProfitPerProductUnit() => Income / ProductUnitsPerYear * 1000000;
        #endregion

        /// <summary>
        /// Информация об организации в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString() + $"\nПроизводит продукта в год: {TonsOfProductPerYear} т.\nПроизводит продукта в год: {ProductUnitsPerYear} ед.\nСтепень загрязнения окружающей среды: {string.Format("{0,00}", PercentageOfPollution*100)}%";
        
        
        public override bool IsContains(string text)
        {
            text = text.ToUpper();
            return (NumberOfEmployees.ToString().Contains(text)
                || Income.ToString().Contains(text)
                || Leader.Contains(text)
                || TonsOfProductPerYear.ToString().Contains(text)
                || ProductUnitsPerYear.ToString().Contains(text)
                || PercentageOfPollution.ToString().Contains(text));
        }
    }
}
