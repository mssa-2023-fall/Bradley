using System.Diagnostics.Metrics;

namespace ReviewPractice
{
    public class SortList
    {
        public static void Main(string[] args)
        {
  
        }
        public static List<int> Merge(SortedSet<int> Set1, SortedSet<int> Set2)
        {
            List<int> result = new List<int>();

            (SortedSet<int>OuterSet, SortedSet<int>InnerSet) = Set1.Count < Set2.Count ? (Set1, Set2) : (Set2, Set1);

            foreach (var OutItem in OuterSet)
            {
                foreach (var InItem in InnerSet)
                {
                    if (OutItem > InItem )
                    {
                        result.Add(InItem);
                    }
                }
               result.Add(OutItem);
            }
            return result;
        }
    }
   

}