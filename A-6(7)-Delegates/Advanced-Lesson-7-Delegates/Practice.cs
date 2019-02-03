using System;
using System.Collections.Generic;

namespace Advanced_Lesson_7_Delegates
{
    public static class Practice
    {
        /// <summary>
        /// L7.P1. Переписать консольный калькулятор с использованием делегатов. 
        /// Используйте switch/case, чтоб определить какую математическую функцию.
        /// </summary>
        public static void L7P1_Calculator()
        {
            int number1 = 100;
            int number2 = 200;
            Del operation = null;
            switch (Console.ReadLine())
            {
                case "+":
                    {
                        operation = Add;
                        break;
                    }
                case "-":
                    {
                        operation = Substraction;
                        break;
                    }
                default:
                    break;
            }
            int result = operation(number1, number2);
        }
        delegate int Del(int n1, int n2);
        public static int Add(int n1, int n2)
        {
            return n1 + n2;
        }
        public static int Substraction(int n1, int n2)
        {
            return n1 - n2;
        }
        /// <summary>
        /// L7.P2. Создать расширяющий метод для коллекции строк.
        /// Метод должен принимать делегат форматирующей функции для строки.
        /// Метод должен проходить по всем элементам коллекции и применять данную форматирующую функцию к каждому элементу.
        /// Реализовать следующие форматирующие функции:
        /// Перевод строки в заглавные буквы.
        /// Замена пробелов на подчеркивание.
        /// Продемонстрировать работу расширяющего метода.
        /// </summary>
        public delegate string GetMessage(string str);

        public static void L7P2_StringFormater(this List<string> str,GetMessage _delegate)
        {
            for (int i = 0; i < str.Count; i++)
            {
                str[i]= _delegate?.Invoke(str[i]);
            }
            foreach (var i in str)
            {
                Console.WriteLine(i);
            }
        }
        public static string ToUpper_(string str)
        {
            return str.ToUpper();
        }
        public static string Replace_(string str)
        {
            return str.Replace(' ', '_');
        }
    }
}
