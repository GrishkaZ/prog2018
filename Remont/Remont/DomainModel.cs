using System;
using System.Collections.Generic;

namespace Remont
{
    /// <summary>
    /// Информация о заказе
    /// </summary>
    public class OrderRequestDto
    {
        /// <summary>
        /// Время на работу
        /// </summary>
        public TimeOfRepair TimeOfRepair { get; set; }  
        /// <summary>
        /// ФИО заказчика
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Описание сломанного устройства
        /// </summary>
        public Device DescriptionOfBreakageDevice { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public Payment Price { get; set; }
        /// <summary>
        /// Дополнительные требования
        /// </summary>
        public AdditionalRequirements Repair { get; set; }
    }

    /// <summary>
    /// Описания cломанного устройстваустройства
    /// </summary>
    public class Device
    {
        /// <summary>
        /// Вид устройства
        /// </summary>
        public Apparat BrokenDevice { get; set; }
        /// <summary>
        /// Поломка
        /// </summary>
        public List<Breakage> Breakage { get; set; }
    }
    /// <summary>
    /// Описание поломки 
    /// </summary>
    public class Breakage
    {
        /// <summary>
        /// Вид повреждения
        /// </summary>
        public DamageType BreakageType { get; set; }
        /// <summary>
        /// Описание поломки
        /// </summary>
        public string Description { get; set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} ", Description, BreakageType);
        }

        public Breakage Clone()
        {
            return new Breakage { Description = Description, BreakageType = BreakageType };
        }
    }

    /// <summary>
    /// Деньги за ремонт
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// Валюта
        /// </summary>
        public Currency Currency { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
    }

    /// <summary>
    /// Дополнительные пожелания
    /// </summary>
    public class AdditionalRequirements
    {        
        /// <summary>
        /// Самостоятельное преобретение необходимых деталей
        /// </summary>
        public bool BuySomeDetailsYourself { get; set; }
        /// <summary>
        /// Дополнительные пожелания
        /// </summary>
        public string AdditionalRequests { get; set; }
    }

    /// <summary>
    /// Время на ремонт
    /// </summary>
    public class TimeOfRepair
    {
        int a;
        /// <summary>
        /// Время на ремонт
        /// </summary>
        public int Days
        {
            get
            {
                if (a <= 0)
                    return 30; // дней на ремонт по умолчанию
                return a;
            }
            set
            {
                a = value;
            }
        }

        /// <summary>
        /// Дата заполнения
        /// </summary>
        public DateTime Filled { get; set; }
        /// <summary>
        /// Дата окончания ремонта
        /// </summary>
         public DateTime RepairTime (DateTime Filled)
        {
            return Filled.AddDays(Days);
        }


    }



    /// <summary>
    /// Тип валюты
    /// </summary>
    public enum Currency
    {
        Rubles,
        Dollars,
        Euro,
        Bitcoins,
        Ethereum,
    }
    /// <summary>
    /// Тип устройства
    /// </summary>
    public enum Apparat
    {
        Утюг,
        Обогреватель,
        Пылесос,
        Микроволновка,
        Миксер,
        Телевизор,
        Чайник,
        Другое,
    }
    /// <summary>
    /// Тип повреждения
    /// </summary>
    public enum DamageType
    {
        Physical,
        Burned,
        Else
    }
}


