using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_mining_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            bool flag = false;
            //for (int z = 0; z < 4; z++)
            int z = 3;
            {
                Console.WriteLine("=========================================== {0}", z);
                int control = 0;
                string[] list = File.ReadAllLines(@"C:\Users\Дмитро\Desktop\FIT\4S\iris.data.txt");
                string[] words;
                int max = 50;
                //int k = 3;
                int[] c = { 0, 0, 0 };
                int[] l = { 0, 0, 0 };
                double[,] clas_1 = new double[max, 4];
                double[,] clas_2 = new double[max, 4];
                double[,] clas_3 = new double[max, 4];
                foreach (var item in list)
                {
                    string local;
                    local = item.Replace(',', '|');
                    local = local.Replace('.', ',');
                    words = local.Split('|');
                    for (int k = 0; k < 4; k++)
                    {

                        if (words[4] == "Iris-setosa")
                        {
                            clas_1[c[0], k] = double.Parse(words[k]);
                            if (k == 3)
                                c[0]++;
                        }
                        if (words[4] == "Iris-versicolor")
                        {
                            clas_2[c[1], k] = double.Parse(words[k]);
                            if (k == 3)
                                c[1]++;
                        }
                        if (words[4] == "Iris-virginica")
                        {
                            clas_3[c[2], k] = double.Parse(words[k]);
                            if (k == 3)
                                c[2]++;
                        }
                        //k = 4;
                    }


                }






                for (int i = 0; i < 50; i++)
                {
                    var one = clas_1[i, z];
                    for (int j = 0; j < 50; j++)
                    {
                        var two = clas_2[j, z];
                        if (one == two && one != 0)
                        {
                            flag = true;
                            clas_1[i, 0] = 0;
                            clas_2[j, 0] = 0;
                            clas_1[i, 1] = 0;
                            clas_2[j, 1] = 0;
                            clas_1[i, 2] = 0;
                            clas_2[j, 2] = 0;
                            clas_1[i, 3] = 0;
                            clas_2[j, 3] = 0;
                            control++;
                        }
                    }
                    if (flag)
                        l[1]++;
                    flag = false;
                    for (int j = 0; j < 50; j++)
                    {
                        var two = clas_3[j, z];
                        if (one == two && one != 0)
                        {
                            flag = true;
                            clas_1[i, 0] = 0;
                            clas_3[j, 0] = 0;
                            clas_1[i, 1] = 0;
                            clas_3[j, 1] = 0;
                            clas_1[i, 2] = 0;
                            clas_3[j, 2] = 0;
                            clas_1[i, 3] = 0;
                            clas_3[j, 3] = 0;
                            control++;
                        }
                    }
                    if (flag)
                        l[2]++;
                }
                for (int i = 0; i < 50; i++)
                {
                    var one = clas_2[i, z];
                    for (int j = 0; j < 50; j++)
                    {
                        var two = clas_3[j, z];
                        if (one == two && one != 0)
                        {
                            flag = true;
                            clas_3[j, 0] = 0;
                            clas_2[i, 0] = 0;
                            clas_3[j, 1] = 0;
                            clas_2[i, 1] = 0;
                            clas_3[j, 2] = 0;
                            clas_2[i, 2] = 0;
                            clas_3[j, 3] = 0;
                            clas_2[i, 3] = 0;
                            control++;
                        }
                    }
                    if (flag)
                        l[2]++;
                    flag = false;

                }
                for (int i = 0; i < max; i++)
                {
                    Console.WriteLine();
                    //  for (int j = 0; j < 4; j++)
                    {
                        Console.Write("{0} \t {1} \t {2} \t {3} \t || \t", clas_1[i, 0], clas_1[i, 1], clas_1[i, 2], clas_1[i, 3]);//, clas_2[i, j], clas_3[i, j]);
                        Console.Write("{0} \t {1} \t {2} \t {3} \t || \t", clas_2[i, 0], clas_2[i, 1], clas_2[i, 2], clas_2[i, 3]);//, clas_2[i, j], clas_3[i, j]);
                        Console.Write("{0} \t {1} \t {2} \t {3} ", clas_3[i, 0], clas_3[i, 1], clas_3[i, 2], clas_3[i, 3]);//, clas_2[i, j], clas_3[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("{0} \t {1} \t {2}", l[0], l[1], l[2]);
                Console.WriteLine("Control: {0}", control);
                Console.WriteLine("---------------------------------------------------------------------");

                // clas_1[i, 3]
                double[] list_1 = new double[50];//clas_1[i, 3];
                double[] list_2 = new double[50];//clas_1[i, 3];
                double[] list_3 = new double[50];//clas_1[i, 3];
                double[] l_max = { list_1.Max(), list_2.Max(), list_3.Max() };
                double[] l_min = { list_1.Max(), list_2.Max(), list_3.Max() };
                //{ list_1.Min(), list_2.Min(), list_3.Min() };
                for (int i = 0; i < 50; i++)
                {
                    if (clas_1[i, 3] > l_max[0])
                        l_max[0] = clas_1[i, 3];
                    if (clas_1[i, 3] < l_min[0] && clas_1[i, 3] !=0)
                        l_min[0] = clas_1[i, 3];

                    if (clas_2[i, 3] > l_max[1])
                        l_max[1] = clas_2[i, 3];
                    if (clas_2[i, 3] < l_min[1] && clas_2[i, 3] != 0)
                        l_min[1] = clas_2[i, 3];

                    if (clas_3[i, 3] > l_max[2])
                        l_max[2] = clas_3[i, 3];
                    if (clas_3[i, 3] < l_min[2] && clas_3[i, 3] != 0)
                        l_min[2] = clas_3[i, 3];
                }
               // double[] l_max = { list_1.Max(), list_2.Max(), list_3.Max() };
                //double[] l_min = { list_1.Min(), list_2.Min(), list_3.Min() };
                Console.WriteLine(l_max[0] + "|" + l_max[1] + "|" + l_max[2]);
                Console.WriteLine(l_min[0] + "|" + l_min[1] + "|" + l_min[2]);
                string[] read = File.ReadAllLines(@"C:\Users\Дмитро\Desktop\FIT\4S\iris.data.txt");
                int Error = 0;
                foreach (var item in read)
                {
                    string local;
                    local = item.Replace(',', '|');
                    local = local.Replace('.', ',');
                    words = local.Split('|');
                    if (double.Parse(words[z]) <= l_max[0])
                    {
                        Console.WriteLine(item + " | Iris-setosa");
                        if (words[4] != "Iris-setosa")
                        {
                            Error++;
                            Console.WriteLine(item + " | Iris-setosa /");
                        }

                    }
                    else if (double.Parse(words[z]) <= l_max[1])
                    {
                      //  Console.WriteLine(item + " | Iris-versicolor");
                        if (words[4] != "Iris-versicolor")
                        {
                            Console.WriteLine(item + " | Iris-versicolor");

                            Error++;
                        }

                    }
                    else if (double.Parse(words[z]) <= l_max[2])
                    {
                        Console.WriteLine(item + " | Iris-virginica");
                        if (words[4] != "Iris-virginica")
                        {
                            Error++;
                        }

                    }
                }
                Console.WriteLine(Error);

            }
            /* foreach (var one in clas_2)
             {
                 foreach (var two in clas_1)
                     if (one == two)
                     {
                         flag = true;
                     }
                 if (flag)
                     l[0]++;
                 flag = false;
                 foreach (var two in clas_3)
                     if (one == two)
                         flag = true;
                 if (flag)
                     l[2]++;
             }
             foreach (var one in clas_3)
             {
                 foreach (var two in clas_1)
                     if (one == two)
                         flag = true;
                 if (flag)
                     l[0]++;
                 flag = false;
                 foreach (var two in clas_2)
                     if (one == two)
                         flag = true;
                 if (flag)
                     l[1]++;
             }
             */



        }
    }
}