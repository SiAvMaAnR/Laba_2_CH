using System;

namespace Organizations
{
    /// <summary>
    /// Страховая компания
    /// </summary>
    [Serializable]
    public class InsuranceCompany : Organization
    {
        #region Поля и Свойства

        /// <summary>
        /// Сумма страховых выплат в год (в млн.р.)
        /// </summary>
        /// <returns>Млн. рублей</returns>
        private double amountOfInsurancePaymentsPerYear;
        public double AmountOfInsurancePaymentsPerYear
        {
            get { return amountOfInsurancePaymentsPerYear; }
            set { amountOfInsurancePaymentsPerYear = value; }
        }

        /// <summary>
        /// Сумма денежных поступлений в год (в млн.р.)
        /// </summary>
        /// <returns>Млн. рублей</returns>
        private double cashReceiptsPerYear;
        public double CashReceiptsPerYear 
        {
            get { return cashReceiptsPerYear; }
            set { cashReceiptsPerYear = value; }
        }

        /// <summary>
        /// Число застрахованных лиц
        /// </summary>
        private int numberOfInsuredPersons;
        public int NumberOfInsuredPersons
        {
            get
            {
                return numberOfInsuredPersons;
            }
            set
            {
                numberOfInsuredPersons = value;
            }
        }

        #endregion

        #region Конструктор
        /// <summary>
        /// Страховая компания
        /// </summary>
        /// <param name="numberOfEmployees">Кол-во сотрудников</param>
        /// <param name="income">Прибыль (млн.р)</param>
        /// <param name="leader">Глава страховой компании</param>
        /// <param name="amountOfInsurancePaymentsPerYear">Сумма страховых выплат (млн.р)</param>
        /// <param name="cashReceiptsPerYear">Сумма денежных поступлений (млн.р)</param>
        /// <param name="numberOfInsuredPersons">Застрахованных лиц</param>
        public InsuranceCompany(int numberOfEmployees, double income, string leader, double amountOfInsurancePaymentsPerYear, double cashReceiptsPerYear, int numberOfInsuredPersons)
        {
            this.NumberOfEmployees = numberOfEmployees;
            this.Income = income;
            this.Leader = leader;

            this.AmountOfInsurancePaymentsPerYear = amountOfInsurancePaymentsPerYear;
            this.CashReceiptsPerYear = cashReceiptsPerYear;
            this.NumberOfInsuredPersons = numberOfInsuredPersons;
        }

        public InsuranceCompany() { }
        #endregion

        #region Методы
        /// <summary>
        /// Эффективность страхования
        /// <list type="bullet">
        /// <item><b>Положительное</b> - Получает доход</item>
        /// <item><b>Отрицательное</b> - Терпит убытки</item>
        /// </list>
        /// </summary>
        /// <returns>Проценты</returns>
        public double GetInsuranceEffectiveness()
        {
            if (AmountOfInsurancePaymentsPerYear < CashReceiptsPerYear)
            {
                return (AmountOfInsurancePaymentsPerYear / CashReceiptsPerYear) * 100;
            }
            else
            {
                return -(CashReceiptsPerYear / AmountOfInsurancePaymentsPerYear) * 100;
            }
        }

        /// <summary>
        /// Средняя сумма страховых выплат на человека в год
        /// </summary>
        /// <returns>Рубли</returns>
        public double GetAverageInsurancePaymentsPerPersonPerYear() => (AmountOfInsurancePaymentsPerYear / NumberOfInsuredPersons) * 1000000;

        /// <summary>
        /// Ежемесячный страховой взнос
        /// </summary>
        /// <returns></returns>
        public double GetInsurancePremium() => (CashReceiptsPerYear / NumberOfInsuredPersons) * 1000000 / 12;
        #endregion

        /// <summary>
        /// Информация об организации в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString() => base.ToString() + $"Сумма страховых выплат: {AmountOfInsurancePaymentsPerYear} млн.р./год\nСумма денежных поступлений: {CashReceiptsPerYear} млн.р./год\nЗастрахованных лиц: {NumberOfInsuredPersons} чел.";
        
        public override bool IsContains(string text)
        {
            text = text.ToUpper();
            return (NumberOfEmployees.ToString().Contains(text)
                || Income.ToString().Contains(text)
                || Leader.Contains(text)
                || AmountOfInsurancePaymentsPerYear.ToString().Contains(text)
                || CashReceiptsPerYear.ToString().Contains(text)
                || NumberOfInsuredPersons.ToString().Contains(text));
        }
    }
}
