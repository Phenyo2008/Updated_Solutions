using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine(GetTeamsFromCSV("TestFile.txt"));
            Console.ReadLine();

        }
        public static int getDifference(string line)
        {
            var list = new List<int>();
            int digit;
            var slitLine = line.Split(',');
            foreach (var item in slitLine)
                if ((int.TryParse(item.ToString(), out digit)))
                    list.Add(digit);
            var orderdeList = list.OrderBy(x => x).ToList();
            var difference = getDiff(orderdeList);
            return difference;
        }

        private static int getDiff(List<int> orderdeList)
        {
            int i = 0;
            var diff = 0;
            foreach (var item in orderdeList)
            {
                i++;
                for (int j = i; j < orderdeList.Count; j++ )
                    if (orderdeList[j] % item == 0)
                        diff = orderdeList[j] / item;
            }
            return diff;
        }

        public static int GetTeamsFromCSV(string filePath)
        {
            var array = new List<int>();
            var myFile = File.Open(filePath, FileMode.Open);
            using (StreamReader myStream = new StreamReader(myFile))
            {
                if (File.Exists(filePath))
                {
                    string line;
                    while ((line = myStream.ReadLine()) != null)
                    {
                        string trueLine = getTrueLine(line);
                        array.Add(getDifference(trueLine));
                    }
                }
            }
            return array.Sum();
        }

        private static string getTrueLine(string line)
        {
            int digit;
            string commaString = "";
            foreach (var item in line)
            {
                if ((int.TryParse(item.ToString(), out digit)))
                    commaString += item.ToString();
                else
                {
                    commaString += ",";
                }
            }

            return commaString;
        }


    }
}
