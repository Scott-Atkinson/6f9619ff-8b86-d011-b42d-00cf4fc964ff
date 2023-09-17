using LongestIncreasingSubsequenceApp.Services.Interfaces;

namespace LongestIncreasingSubsequenceApp.Services.Services
{
    public class IncreasingSubsequenceService : IIncreasingSubsequenceService
    {
        
        public IncreasingSubsequenceService()
        {
        }
        public string GetIncreasingSubsequence(int[] sequence)
        {

            // Initialize variables to keep track of the longest subsequence and its length
            var longestSubsequence = new List<int>();
            var currentSubsequence = new List<int> { sequence[0] };

            for (var i = 1; i < sequence.Length; i++)
            {
                if (sequence[i] > sequence[i - 1])
                {
                    currentSubsequence.Add(sequence[i]);
                }
                else
                {
                    // Check if the current subsequence is longer than the longest one found so far
                    if (currentSubsequence.Count > longestSubsequence.Count)
                    {
                        longestSubsequence = new List<int>(currentSubsequence);
                    }
                    currentSubsequence = new List<int> { sequence[i] };
                }
            }

            // Check one more time after the loop ends to handle the case where the longest subsequence
            // ends at the last element
            if (currentSubsequence.Count > longestSubsequence.Count)
            {
                longestSubsequence = new List<int>(currentSubsequence);
            }

            // Convert the longest subsequence to a string
            var resultStr = string.Join(" ", longestSubsequence);
            return resultStr;

        }
    }
}
