using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace divide_and_conquer
{
    class Program
    {
        const string value_param_analiz = "yes";

        static public string rezult = null;

        public static void analiz_table(string[][,] data, int n)
        {
            Console.WriteLine("///////////////////////////////////////////////////////");
            Dictionary<string, int[]> my = new Dictionary<string, int[]>();
            Stack<string> p = new Stack<string>();

            for (int k = 0; k < data.Length; k++)
            {
                write_arr(data[k]);

                for (int z = 0; z < data[k].GetLength(1) - 1; z++)
                {
                    for (int i = 0; i < data[k].GetLength(0); i++)
                    {
                        //Console.WriteLine("--------{0}{1}{2}",k,i, z);

                        //Console.WriteLine(data[k][i, z]);
                        //Console.WriteLine("--------");
                        if (my.ContainsKey(data[k][i, z]))
                        {
                            Console.WriteLine("___" + data[k][i, z] +"||"+ data[k][i, data[k].GetLength(1) - 1]);
                            //  Console.WriteLine("{0}:{1}", data[k][i, z], my[data[k][i, z]]);
                            if (data[k][i, data[k].GetLength(1) - 1] == value_param_analiz)
                            {
                                Console.WriteLine("___+");
                                my[data[k][i, z]][1]++;
                            }
                            else
                                my[data[k][i, z]][0]++;
                        }
                        else
                        {
                            Console.WriteLine("___--"+ data[k][i, z] +"|||||"+ data[k][i, data[k].GetLength(1) - 1]);

                            if (data[k][i, data[k].GetLength(1) - 1] == value_param_analiz)
                                my.Add(data[k][i, z], new int[] { 0, 1, z });
                            else
                                my.Add(data[k][i, z], new int[] { 1, 0, z });

                            p.Push(data[k][i, z]);
                            //  Console.WriteLine(data[i, z]);
                        }
                    }
                }
            }
            //////

            int m = p.Count;
            double max = 0;
            string max_name = null;
            string[,,] new_table = new string[m, 0, 0];
            for (int i = 0; i < m; i++)
            {

                if (max < (double)my[p.Peek()][1] / (my[p.Peek()][0] + my[p.Peek()][1]))
                {
                    max = (double)my[p.Peek()][1] / (my[p.Peek()][0] + my[p.Peek()][1]);//my[p.Peek()][1];
                    max_name = p.Peek();
                    // max_coll = 
                }
                Console.WriteLine("{0}      \t {1} - ({2:f2})|{3} \t {4:f2} ", p.Peek(), write_arr(my[p.Peek()]), max, max_name, (double)my[p.Peek()][1] / (my[p.Peek()][0] + my[p.Peek()][1]));
                p.Pop();
            }
            Console.WriteLine(max + "***" + max_name);
            // Console.WriteLine(max_name + "-" + my[max_name][2]);
            // my[max_name][2] //номер стовпця 
            // my[max_name][1] //count yes 
            //max_name значення
           // if (max_name != null && my[max_name][1] > 0 && my[max_name][0] < my[max_name][1])
                // rezult += max_name + " ↑ Yes  (" + (int)(my[max_name][2] + 1) + ") ";

                //////
                /*

                количество вариантов в столбце||

                */

                //string[,,] new_data = new string[,,] { };
                //Console.WriteLine(rezult);
                //if (data.Length <1)
                  //  rezult += max_name + " ↑ Yes  (" + (int)(my[max_name][2] + 1) + ") ";
                for (int q = 0; q < data.Length; q++)
                {
                    if (my.Count > 0 && max_name != null)
                    {
                        if (n >= 0)
                            rezult += "{" + data[q][0, n] + "}-" + max_name + " ↑ Yes  (" + (int)(my[max_name][2] + 1) + ") |";
                        else
                            rezult += max_name + " ↑ Yes  (" + (int)(my[max_name][2] + 1) + ") ";
                        int k = 0;
                        string[][,] cnt = create_new_table(data[q], my[max_name][2], max_name, out k);
                        // if (k > 0)
                        {
                            // write_arr(data[q]);
                            analiz_table(cnt, my[max_name][2]);
                        }
                    }
                }
            //return new_data;
        }
        public static string[][,] create_new_table(string[,] data, int id_col, string value_max, out int count_variats)
        {
            Dictionary<string, int[]> my = new Dictionary<string, int[]>();
            Stack<string> p = new Stack<string>();
            for (int i = 0; i < data.GetLength(0); i++)
            {
                Console.WriteLine("!!!!!!!!{0}!!!!!!!!", data[i, data.GetLength(1) - 1]);
                if (my.ContainsKey(data[i, id_col]) && data[i, id_col] != value_max)
                {
                    // Console.WriteLine("{0}:{1}", data[i, z], my[data[i, z]]);
                    if (data[i, data.GetLength(1) - 1] == value_param_analiz)
                        my[data[i, id_col]][1]++;
                    else
                        my[data[i, id_col]][0]++;
                }
                else if (data[i, id_col] != value_max)
                {
                    if (data[i, data.GetLength(1) - 1] == value_param_analiz)
                        my.Add(data[i, id_col], new int[] { 0, 1, 0 });
                    else
                        my.Add(data[i, id_col], new int[] { 1, 0, 0 });
                    p.Push(data[i, id_col]);
                }
            }
            count_variats = my.Count;
            string[][,] new_data = new string[count_variats][,];

            for (int k = 0; k < count_variats; k++)
            {
                new_data[k] = new string[my[p.Peek()][1] + my[p.Peek()][0], data.GetLength(1)];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    if (data[i, id_col] == p.Peek() && data[i, id_col] != value_max)
                    {
                        for (int z = 0; z < data.GetLength(1); z++)
                        {
                            // if (z < id_col)
                            new_data[k][my[p.Peek()][2], z] = data[i, z];
                            //else if (z > id_col)
                            //  new_data[k][my[p.Peek()][2], z - 1] = data[i, z];
                        }
                        my[p.Peek()][2]++;
                    }
                }
                p.Pop();
            }
            //Console.WriteLine("==========================" + count_variats);
            //write_arr(data);
            //Console.WriteLine("==========================");
            //Console.WriteLine(new_data);
            // write_arr(new_data[0]);
            //write_arr(new_data[1]);
            //write_arr(new_data[2]);
            return new_data;
        }
        public static void write_arr(string[,] mas)
        {
            // Console.WriteLine(mas);
            Console.WriteLine("++++++++++++++");
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    Console.Write("{0} \t ", mas[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("++++++++++++++");
        }
        public static string write_arr(int[] mas)
        {
            string s = null;
            foreach (var item in mas)
            {
                s += "|" + item + "|";
            }
            return s;
        }
        static void Main(string[] args)
        {
            string[][,] data = new string[][,] {
                new string[,]{// {"0", "hot", "high", "false", "no"},
                 { "Sunny", "hot", "high", "false", "no" },
                 { "Sunny", "hot", "high", "true", "no" },
                 { "Overc", "hot", "high", "false", "yes" },
                 { "Rainy", "mild", "high", "false", "yes" },
                 { "Rainy", "cool", "normal", "false", "yes" },
                 { "Rainy", "cool", "normal", "true", "no" },
                 { "Overc", "cool", "normal", "true", "yes" },
                 { "Sunny", "mild", "high", "false", "no" },
                 { "Sunny", "cool", "normal", "false", "yes" },
                 { "Rainy", "mild", "normal", "false", "yes" },
                 { "Sunny", "mild", "normal", "true", "yes" },
                 { "Overc", "mild", "high", "true", "yes" },
                 { "Overc", "hot", "normal", "false", "yes" },
                 { "Rainy", "mild", "high", "true", "no" }
                }
            };
            string rez = null;
            //Console.WriteLine(data.GetLength(0));


            analiz_table(data, -1);
            //analiz_table(create_new_table(data[0], 0, "Overcast"));


            Console.WriteLine(rezult);
            /**/

        }
    }
}
