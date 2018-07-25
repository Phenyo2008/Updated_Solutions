using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_two
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberString = "3893445835429722678558456317563893861752455542588369533636585887178232467588827193173595918648538852463974393264428538856739259399322741844613957229674619566966921656443476317729968764183945899765294481327998956154956571467872487576314549468261122281384513266834769436913544431258253346374641589492728885222652146158261225296144835682556133922436438188211288458692217737145834468534829945993366314375465767468939773939978272968388546791547526366348163672162245585168892858977723516752284597322176349412485116173844733679871253985762643852151748396593275274582481295864991886985988427966155944392352248314629138972358467959614279553511247863869663526823326467571462371663396188951696286916979923587358992127741723727623235238531991996999181976664226274715591531566495345212849683589582225465555847312199122268773923175183128124556249916458878785361322713513153175157855597289482439449732469754748544437553251412476225415932478849961897299721228198262823515159848941742786272262236888514421279147329383465929358896761449135917829473321834267122759371247338155787774952626616791265889922959653887288735233291968146648533754958199821789499914763279869931218136266492627818972334549751282191883558361871277375851259751294611921756927694394977764633932938573132221389861617195291742156362494769521829599476753198422283287735888197584327719697758442462886311961723849326959213928195182293316227334998926839139915138472514686689887874559367524254175582135318545912361877139367538434683933333264146289842238921989275112323681356256979576948644489986951538689949884787173194457523474156229389465725473817651516136514446513436419126533875125645855223921197481833434658264655912731133356464193251635637423222227273192628825165993827511625956856754776849919858414375874943572889154281862749595896438581889424559988914658387293414662361364793844213298677236787998677166743945812899526292132465751582925131262933636228593134861363493849168168765261647652342891576445292462341171477487223253795935253493869317616741963486473";
            var array = createArray(numberString);
            Console.WriteLine("In the value {0} \n", numberString);

            foreach (var item in returnOccurences(array).OrderBy(x => x.Key))
                Console.WriteLine("number : {0} is followed by the same digit {1} times", item.Key, item.Value);

            Console.WriteLine("The sum is {0}", returnSum(returnOccurences(array)));
            Console.ReadLine();
        }
        public static int returnSum(Dictionary<int,int> occurances)
        {
            int sum = 0;
            if (occurances.Count == 1 && occurances.ElementAt(0).Value == 1)
                return occurances.ElementAt(0).Key;
            foreach (var item in occurances)
            {
                if (item.Value > 0)
                    sum += (item.Key * item.Value);
            }
            return sum;
        }
        public static Dictionary<int, int> returnOccurences(List<int> numbersList)
        {
           
            var lastNumber = numbersList.Count - 2;
            Dictionary<int, int> occurances = new Dictionary<int, int>();
            for(int i =  0; i <= lastNumber; i++ )
            {
                if (i == lastNumber)
                {
                    if (IsFirstEqualToLast(numbersList, numbersList[i + 1]))
                        AddOrIncreament(numbersList, occurances, i + 1);
                }
                if (numbersList[i] == numbersList[i + 1])
                    AddOrIncreament(numbersList, occurances, i);
            }
            return occurances;
        }

        public static void getstats(Dictionary<int,int> lookUp)
        {
            foreach (var item in lookUp)
            {
                if (item.Key != 2)
                {
                    Console.WriteLine("Get_Next_Line");
                }
            }
        }


        public static void AddOrIncreament(List<int> numbersList, Dictionary<int,int> occurances,int i)
        {
            int value;
            
            // check contains and if so increment found value for key
            if (!occurances.TryGetValue(numbersList[i], out value))    
                occurances.Add(numbersList[i], 1);
            else
                occurances[numbersList[i]] += 1; // go to value portion and update with ++ increament
        }

        private static bool IsFirstEqualToLast(List<int> numbersList, int lastElement)
        {
            if (numbersList.First() == lastElement)
                return true;
            else
                return false;
        }

        public static List<int> createArray(string stringNumber)
        {
            List<int> numbersList = new List<int>();
            foreach (var charc in stringNumber)
            {
                int temp;
                if (int.TryParse(charc.ToString(), out temp))
                    numbersList.Add(temp);
            }
            return numbersList;
        }
    }
}
