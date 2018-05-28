using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RemontWeb.Models
{
    public class DBRemontModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }      
        /// <summary>
        /// Время на ремонт
        /// </summary>
        public int Days { get; set; }
        /// <summary>
        /// Дата заполнения
        /// </summary>
        public DateTime Filled { get; set; }
        /// <summary>
        /// ФИО заказчика
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public Currency Currency { get; set; }
        /// <summary>
        /// Вид устройства
        /// </summary>
        public Apparat BrokenDevice { get; set; }
        /// <summary>
        /// Поломка
        /// </summary>
        public Collection<DBBreakage> Breakages { get; set; }
        /// <summary>
        /// Самостоятельное преобретение необходимых деталей
        /// </summary>
        public bool BuySomeDetailsYourself { get; set; }
        /// <summary>
        /// Дополнительные пожелания
        /// </summary>
        public string AdditionalRequests { get; set; }
    }

    public class DBBreakage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public DBBreakage Clone()
        {
            return new DBBreakage { Description = Description, BreakageType = BreakageType };
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