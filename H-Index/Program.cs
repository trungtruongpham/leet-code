// Problem Link: https://leetcode.com/problems/h-index/description/?envType=study-plan-v2&envId=top-interview-150

var result = HIndex(new[] { 3,0,6,1,5 });
Console.WriteLine(result);


int HIndex(int[] citations)
{
   if (citations.Length == 1 && citations[0] != 0)
   {
      return 1;
   }
   
   Array.Sort(citations);
   var hIndex = 0;

   for (var i = 0; i < citations.Length; i++)
   {
      if (citations[i] == 0)
      {
         continue;
      }
      
      if (citations[i] >= citations.Length - i)
      {
         hIndex = Math.Max(hIndex, citations.Length - i);
      }    
   }
   
   return hIndex;
}