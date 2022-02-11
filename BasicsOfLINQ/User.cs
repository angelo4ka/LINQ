using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOfLINQ
{
    /// <summary>
    /// Класс "Пользователь"
    /// </summary>
    class User
    {
        // Свойства класса
        public string Name { get; set; } // Имя
        public int Age { get; set; } // Возраст
        public List<string> Languages { get; set; } // Языки

        /// <summary>
        /// Конструктор
        /// </summary>
        public User()
        {
            // Для объекта "Языки" создаётся новый список
            Languages = new List<string>();
        }
    }
}
