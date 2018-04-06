using System;
using System.Collections.Generic;

namespace HeshTable
{ 
    public class HashTable
    {
         class Pair
        {
            /// <summary>
            /// Ключ
            /// </summary>
            public object Key { get; set; }
            /// <summary>
            /// Значение
            /// </summary>
            public object Value { get; set; }
        }
        List<List<Pair>> list;
        /// <summary>
        /// Конструктор контейнера
        /// summary>
        /// size">Размер хэ-таблицы
        public HashTable(int size)
        {
            list = new List<List<Pair>>();
            for(int i =0; i<size; i++)
            {
                list.Add(new List<Pair>());
            }               
        }
        /// 
        /// Метод складывающий пару ключь-значение в таблицу
        /// 
        /// key">
        /// value">
        public  void PutPair(object key, object value)
        {
            var bucketNumber = GetBucketNumber(key);
            foreach (var el in list[bucketNumber])
            {
                if(Equals(el.Key, key))
                {
                    el.Value = value;
                    return;
                }
            }
            list[bucketNumber].Add(new Pair { Key = key, Value = value });
        }
        /// <summary>
        /// Поиск значения по ключу
        /// summary>
        /// key">Ключь
        /// <returns>Значение, null если ключ отсутствуетreturns>
        public  object GetValueByKey(object key)
        {
            var bucketNumber = GetBucketNumber(key);
            foreach (var el in list[bucketNumber])
            {
                if (Equals(el.Key, key))
                {  
                    return el.Value;
                }
            }
            return null;
        }
        int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }     
    }
}
