﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace kNN
{
    class post
    {
        //public int min = 3;
        public Dictionary<string, double> analiz_vector;
        string[] words;
        public post(string link)
        {
            read(link);
            // counts();
            clean();
            print();

        }
        public void read(string link)
        {
            string text = File.ReadAllText(link, Encoding.UTF8);
            text = text.Replace(",", "");
            text = text.Replace(".", "");
            text = text.Replace("!", "");
            text = text.Replace("?", "");
            text = text.Replace("\"", "");
            text = text.Replace("'", "");
            text = text.Replace("-", "");
            words = text.Split(' ');

            //text = text.Replace(",", "");
            //Dictionary<string, int> analiz_vector = new Dictionary<string, int>();
            analiz_vector = new Dictionary<string, double>();

            string sw = ",a,about,above,above,across,after,afterwards,again,against,all,almost,alone,along,already,also,although,always,am,among,amongst,amoungst,amount,an,and,another,any,anyhow,anyone,anything,anyway,anywhere,are,around,as,at,back,be,became,because,become,becomes,becoming,been,before,beforehand,behind,being,below,beside,besides,between,beyond,bill,both,bottom,but,by,call,can,cannot,cant co,con,could,couldnt,cry,de,describe,detail,do,done,down,due,during,each,eg,eight,either,eleven,else,elsewhere,empty,enough,etc,even,ever,every,everyone,everything,everywhere,except,few,fifteen,fify,fill,find,fire,first,five,for,former,formerly,forty,found,four,from,front,full,further,get,give,go,had,has,hasnt,have,he,hence,her,here,hereafter,hereby,herein,hereupon,hers,herself,him,himself,his,how,however,hundred,ie,if,in,inc,indeed,interest,into,is,it,its,itself,keep,last,latter,latterly,least,less,ltd,made,many,may,me,meanwhile,might,mill,mine,more,moreover,most,mostly,move,much,must,my,myself,name,namely,neither,never,nevertheless,next,nine,no,nobody,none,noone,nor,not,nothing,now,nowhere,of,off,often,on,once,one,only,onto,or,other,others,otherwise,our,ours,ourselves,out,over,own,part,per,perhaps,please,put,rather,re,same,see,seem,seemed,seeming,seems,serious,several,she,should,show,side,since,sincere,six,sixty,so,some,somehow,someone,something,sometime,sometimes,somewhere,still,such,system,take,ten,than,that,the,their,them,themselves,then,thence,there,thereafter,thereby,therefore,therein,thereupon,these,they,thickv,thin,third,this,those,though,three,through,throughout,thru,thus,to,together,too,top,toward,towards,twelve,twenty,two,un,under,until,up,upon,us,very,via,was,we,well,were,what,whatever,when,whence,whenever,where,whereafter,whereas,whereby,wherein,whereupon,wherever,whether,which,while,whither,who,whoever,whole,whom,whose,why,will,with,within,without,would,yet,you,your,yours,yourself,yourselves";
            string[] stop_words = sw.Split(',');

            foreach (string word in words)
            {
                bool f = false;
                foreach (string s in stop_words)
                {
                    if (word == s)
                    {
                        f = true;
                        break;
                    }
                }
                if (!f)
                {
                    if (!analiz_vector.ContainsKey(word))
                    {
                        analiz_vector.Add(word, 1);
                    }
                    else
                    {
                        analiz_vector[word]++;
                    }
                }
            }
        }
        public void clean()
        {
            if (analiz_vector.Count > 0)
            {
                double min = 0;
                double max = 0;
                List<string> del = new List<string>();
                foreach (string k in analiz_vector.Keys)
                {
                    if (max == 0)
                    {
                        min = analiz_vector[k];
                        max = analiz_vector[k];
                    }
                    if (analiz_vector[k] < min)
                    {
                        min = analiz_vector[k];
                    }
                    else if (analiz_vector[k] > max)
                    {
                        max = analiz_vector[k];
                    }
                    //del.Add(k);
                }
                Dictionary<string, double> new_vector = new Dictionary<string, double>();
                foreach (string k in analiz_vector.Keys)
                {
                    new_vector.Add(k, (analiz_vector[k] - min) / (max - min));
                    if ((analiz_vector[k] - min) / (max - min) < 0.2)
                        del.Add(k);
                }
                analiz_vector = new_vector;
                foreach (string k in del)
                {
                    analiz_vector.Remove(k);
                }

            }
        }


        public void print()
        {
            foreach (string k in analiz_vector.Keys)
            {
                Console.WriteLine("{0}:\t{1}", analiz_vector[k], k);
            }
            Console.WriteLine("-----------------------------------------");
        }

    }
    class vector
    {
        public string name;
        public Dictionary<string, double> values = null;
        public vector(string name_)
        {
            name = name_;
            //values = value;
        }
        public void add(post p)
        {
            Dictionary<string, double> add_list = p.analiz_vector;
            if (values == null)
            {
                values = add_list;
            }
            else
            {
                foreach (string a in add_list.Keys)
                {
                    if (values.ContainsKey(a))
                    {
                        values[a] = (values[a] + add_list[a]) / 2;
                    }
                    else
                    {
                        values.Add(a, add_list[a]);
                    }
                }
            }
        }
    }
    class analizator
    {
        vector[] vectors;
        public analizator(vector[] vectors_)
        {
            vectors = vectors_;
        }
        public string audit(post p)
        {
            int i = -1;
            double n = 0;
            for (int j = 0; j < vectors.Length; j++)
            {
                double max = 0;
                foreach (string k in p.analiz_vector.Keys)
                {
                    if (vectors[j].values.ContainsKey(k))
                        max+= vectors[j].values[k];
                }
                if (max > n)
                {
                    n = max;
                    i = j;
                }
            }
            if (i > -1)
                return vectors[i].name;
            else
                return "Error";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            post p1 = new post(@"posts\1t1.txt");
            post p2 = new post(@"posts\2t1.txt");
            post p3 = new post(@"posts\3t1.txt");
            vector v1 = new vector("наука");
            v1.add(p1);
            v1.add(p2);
            v1.add(p3);


            post p21 = new post(@"posts\1t2.txt");
            post p22 = new post(@"posts\2t2.txt");
            post p23 = new post(@"posts\3t2.txt");

            vector v2 = new vector("sport");
            v2.add(p21);
            v2.add(p22);
            v2.add(p23);

            analizator a = new analizator(new vector[] { v1, v2 });
            post t1 = new post(@"posts\t1.txt");
            post t2 = new post(@"posts\t2.txt");

            Console.WriteLine(a.audit(t1));
            Console.WriteLine(a.audit(t2));

        }
    }
}
