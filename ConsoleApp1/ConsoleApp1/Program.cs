using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static string number_in_words(double num) //Machen wie eine Funktion 
        {
            int num_prefix = Convert.ToInt32(Math.Truncate(num));           //Zahl vor dem Komma
            int num_postfix = Convert.ToInt32((num - num_prefix) * 100);    //Zahl nach dem Komma

            string[] array_num = new string[20] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] array_num_ten = new string[8] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            string[] array_string = new string[2] { "million", "thousand" };

            int number = num_prefix;

            int[] array_int = new int[3];

            array_int[0] = ((number % 1000000000) - (number % 1000000)) / 1000000;  
            array_int[1] = ((number % 1000000) - (number % 1000)) / 1000;           
            array_int[2] = number % 1000;                                           

            string result = "";
            int idx;

            if (number == 0) result = "null";
            else for (int i = 0; i < 3; i++)
                {
                    if (array_int[i] != 0) //Teilen einer ganzen Zahl in 3 Segmente mit 3 Ziffern
                    {
                        if (((array_int[i] - (array_int[i] % 100)) / 100) != 0) // Prüfen, ob eine Zahl Hunderte hat
                        {
                            idx = (((array_int[i] - (array_int[i] % 100)) / 100));
                            if (result.Length != 0) //wenn das Segment Null ist, ist kein Leerzeichen erforderlich
                                result += " ";
                            result += array_num[idx] + " hundred";
                        }
                        if (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 > 1) // Prüfen, ob eine Zahl Zehner hat
                        {
                            idx = ((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 - 2;
                            if (result.Length != 0)
                                result += " ";
                            result += array_num_ten[idx];
                        }
                        if (array_int[i] % 100 >= 10 && array_int[i] % 100 <= 19) // Prüfen, ob es Zahlen von 10 bis 19 gibt
                        {
                            if (result.Length != 0)
                                result += " ";
                            result +=array_num[array_int[i] % 100];
                        }
                        if ((array_int[i] % 100 < 10 || array_int[i] % 100 > 19) && (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 < 1)) // Prüfen, ob eine Zahl Einheiten hat
                        {
                            idx = array_int[i] % 10;
                            if (idx != 0)
                            {
                                if (result.Length != 0)
                                    result += " ";
                                result += array_num[idx];
                            }
                        }
                        if ((((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 > 1) && (array_int[i] % 10 != 0)) // Zehner durch strich mit Einheiten getrennt
                        {
                            result += "-" + array_num[array_int[i] % 10];
                        }
                    }
                    if ((i < 2) && (array_int[i] != 0))
                        result += " " + array_string[i];

                }

            result += " dollars"; //Die Zeile mit einer ganzen Zahl ist fertig.

            if (num_postfix > 0) //Wir beginnen mit der Verarbeitung von zwei Zeichen nach dem Komma
            {
                result += " and";

                if (num_postfix > 19) //Zehner
                {
                    idx = ((num_postfix % 100) - ((num_postfix % 100) % 10)) / 10 - 2;
                    result += " " + array_num_ten[idx];
                    idx = num_postfix % 10;
                }
                else
                    idx = num_postfix;

                if (idx != 0) //Einheiten
                {
                    if (num_postfix > 19)
                        result += "-";
                    else
                        result += " ";

                    result += array_num[idx];
                }
                result += " cents"; //Die Zahl nach dem Komma ist fertig
            }
            return(result);
        }
        static void Main(string[] args)
        {
            double _number = Math.Truncate(double.Parse(Console.ReadLine()) * 100) / 100; //Bestimmen wir die Nummer, schneiden wir zusätzliche Zeichen ab
            string answer = number_in_words(_number); //Rufen wir eine Funktion in Main
            Console.WriteLine(answer);
            Console.ReadLine();
        }
    }
}
