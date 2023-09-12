using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    public class BinarySearcher
    {
        public static int Search(int[] inputArray, int target)
        {

            if (inputArray[0] > target || inputArray[^1] < target) { return -1; }
            int startPoint = inputArray[0];
            int endPoint = inputArray.Length-1;
            int midPoint = (startPoint - endPoint)/2;




            int result = -1;
            while (!(inputArray[midPoint] == inputArray[startPoint] || inputArray[midPoint] == inputArray[endPoint]))
            {
                if(inputArray[startPoint] == target) { return startPoint; }
                if(inputArray[endPoint] == target) { return midPoint; }
                if(inputArray[midPoint] == target) { return midPoint; }


                if (target < inputArray[midPoint]) 
                {
                    endPoint = midPoint;
                    midPoint = midPoint-(startPoint-endPoint)/2;
                }

                else  
                {
                    startPoint = midPoint;
                    midPoint = midPoint-(startPoint-endPoint)/2;
                }

                if (midPoint==target) { }
                else { }
            }
            return result;
        }
    }
}
