using System;

namespace OtusHomeWork_2
{
    internal class Program
    {
        public enum LineNumber
        {
            firstLine,
            secondLine,
            thirdLine
        };
        static void Main(string[] args)
        {
            var size = GetSize(); // Запрос размерности 
            var indent = size - 1; // отступ
            var str = "";
            str = str.PadLeft(indent, ' '); // количество символов отступа 

            var text = GwtText(indent); // Запрос текста
            var lenght = text.Length; // количество символов введеного текста

            var width = 1 + indent + lenght + indent + 1; // ширина строки
            int[] rows = (int[])Enum.GetValues(typeof(LineNumber));

            Print(indent, text, width, rows); // Печать
        }
        static int GetSize()
        {
            var n = 0;
            while (n < 1 || n > 6)
            {
                Console.Write("Введите размерность таблицы: ");
                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    n = 0;
                }
            }
            return n;
        }
        static string GwtText(int indent)
        {
            var text = "";

            while (text == "" || text.Length + indent > 40)
            {
                Console.Write("Введите произвольный текст: ");
                text = Console.ReadLine();
            }
            return text;
        }

        static void Print(int indent, string text, int width, int[] rows)
        {
            var en = Enumerable.Repeat('+', width);
            var separator = string.Join("", en);
            var h = 0;

            for (int n = 0; n < rows.Length; n++)
            {
                switch (rows[n])
                {
                    case 0:
                        Console.WriteLine(separator);
                        FirstLine();
                        break;

                    case 1:
                        Console.WriteLine(separator);
                        SecondLine();
                        break;

                    case 2:
                        Console.WriteLine(separator);
                        ThirdLine();
                        Console.WriteLine(separator);
                        break;
                }

            }
            #region FirstLine
            void FirstLine()
            {
                EmptyLine();
                TextLine();
                EmptyLine();

                void EmptyLine()
                {
                    // Соберем строку с пропусками
                    string emptyLine = GetEmptyLine(width);
                    var q = 0;
                    while (indent > q)
                    {
                        Console.WriteLine(emptyLine);
                        q++;
                        h++;
                    }
                }

                void TextLine()
                {
                    // Соберем строку с текстом
                    string textLine = GetTextLine(indent, text);
                    Console.WriteLine(textLine);
                }

                static string GetEmptyLine(int l) // функция для сбора пустой строки
                {
                    var a = " ";
                    var res = " ";
                    for (int i = 1; i < l - 2; i++)
                        a += " ";
                    res = "+" + a + "+";
                    return res;
                }

                static string GetTextLine(int o, string text) // функция для сбора строки с текстом
                {
                    var b = text;
                    var res = "";

                    res = "+" + res.PadLeft(o, ' ') + b + res.PadLeft(o, ' ') + "+";
                    return res;
                }
            }
            #endregion
            #region SecondLine
            void SecondLine()
            {
                for (int i = 0; i < h + 1; i++)
                {
                    Console.Write("+");
                    for (int j = 0; j < width - 2; j++)
                    {
                        Console.Write((i + j) % 2 == 0 ? " " : "+");
                    }
                    Console.Write("+");
                    Console.WriteLine();
                }
            }
            #endregion
            #region ThirdLine
            void ThirdLine()
            {
                for (int i = 0; i < width - 2; i++)
                {
                    Console.Write("+");
                    for (int j = 0; j < width - 2; j++)
                    {
                        Console.Write(i == j || width - 2 - i - 1 == j ? "+" : " ");
                    }
                    Console.Write("+");
                    Console.WriteLine();
                }
            }
            #endregion

        }
    }
}
