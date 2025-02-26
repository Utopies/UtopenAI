using Utopen_AI.CoreAI;

namespace Utopen_AI;

class Program
{
    static void Main()
    {
        int [] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = (Random.Shared.Next(Int32.MinValue, Int32.MaxValue) % 2 == 0)? nums[i] : -nums[i]; 
        }
    }
}

