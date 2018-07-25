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
            var numberString = "181445682966897848665963472661939865313976877194312684993521259486517527961396717561854825453963181134379574918373213732184697746668399631642622373684425326112585283946462323363991753895647177797691214784149215198715986947573668987188746878678399624533792551651335979847131975965677957755571358934665327487287312467771187981424785514785421781781976477326712674311994735947987383516699897916595433228294198759715959469578766739518475118771755787196238772345762941477359483456641194685333528329581113788599843621326313592354167846466415943566183192946217689936174884493199368681514958669615226362538622898367728662941275658917124167353496334664239539753835439929664552886538885727235662548783529353611441231681613535447417941911479391558481443933134283852879511395429489152435996669232681215627723723565872291296878528334773391626672491878762288953597499218397146685679387438634857358552943964839321464529237533868734473777756775687759355878519113426969197211824325893376812556798483325994128743242544899625215765851923959798197562831313891371735973761384464685316273343541852758525318144681364492173465174512856618292785483181956548813344752352933634979165667651165776587656468598791994573513652324764687515345959621493346623821965554755615219855842969932269414839446887613738174567989512857785566352285988991946436148652839391593178736624957214917527759574235133666461988355855613377789115472297915429318142824465141688559333787512328799783539285826471818279818457674417354335454395644435889386297695625378256613558911695145397779576526397241795181294322797687168326696497256684943829666672341162656479563522892141714998477865114944671225898297338685958644728534192317628618817551492975251364233974374724968483637518876583946828819994321129556511537619253381981544394112184655586964655164192552352534626295996968762388827294873362719636616182786976922445125551927969267591395292198155775434997827738862786341543524544822321112131815475829945625787561369956264826651461575948462782869972654343749617939132353399334744265286151177931594514857563664329299713436914721119746932159456287267887878779218815883191236858656959258484139254446341";
            var array = createArray(numberString);
            Console.WriteLine("In the value {0} \n", numberString);

            foreach (var item in returnOccurences(array).OrderBy(x => x.Key))
                Console.WriteLine("number : {0} is followed halfway by the same digit {1} times", item.Key, item.Value);

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
            int i = -1;
            var count = numbersList.Count; 
            Dictionary<int, int> occurances = new Dictionary<int, int>();
            List<int> firstList = AddNumbers(numbersList,0, count / 2);
            List<int> secondList = AddNumbers(numbersList, count / 2, count);

            CompareLists(firstList, secondList, occurances, i);
            CompareLists(secondList, firstList, occurances, i);

            return occurances;
        }

        public static void CompareLists(List<int> firstList, List<int> secondList, Dictionary<int, int> occurances, int i)
        {
            foreach (var firstListItem in firstList)
            {
                i++;
                for(int j = i; j < secondList.Count; j++)
                {
                    if (firstListItem == secondList[j])
                    {
                        AddOrIncreament(firstList, occurances, i);
                        break;
                    }
                    else
                        break;
                }
            }
        }

        public static void AddOrIncreament(List<int> numbersList, Dictionary<int, int> occurances, int i)
        {
            int value;

            // check contains and if so increment found value for key
            if (!occurances.TryGetValue(numbersList[i], out value))
                occurances.Add(numbersList[i], 1);
            else
                occurances[numbersList[i]] += 1; // go to value portion and update with ++ increament
        }

        private static List<int> AddNumbers(List<int> numbersList, int start, int end)
        {
            List<int> ints = new List<int>();

            for (int i = start; i < end; i++)
                ints.Add(numbersList.ElementAt(i));
            return ints;
        }
        private static bool IsFirstEqualToLast(List<int> numbersList, int lastElement, int count)
        {
            if ((numbersList.ElementAt(-1 + count/2)) == lastElement)
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
