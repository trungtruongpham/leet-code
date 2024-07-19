// Problem link: https://leetcode.com/problems/happy-number/description/?envType=study-plan-v2&envId=top-interview-150

var result = IsHappy(2);
Console.WriteLine(result);

bool IsHappy(int n)
{
    var hashSet = new HashSet<int>();

    while (hashSet.Add(n))
    {
        n = CalculateSquareNumbers(n);

        if (n == 1)
        {
            return true;
        }
    }
    
    return false;
}

int CalculateSquareNumbers(int n)
{
    var listNumbers = n.ToString();
    var sumOfNumbers = 0;

    foreach (var number in listNumbers)
    {
        sumOfNumbers += int.Parse(number.ToString()) * int.Parse(number.ToString());
    }
    
    return sumOfNumbers;
}