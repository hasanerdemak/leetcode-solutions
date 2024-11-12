using System;
using System.Linq;

public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        // Step 1: Sort items by price ascending
        Array.Sort(items, (a, b) => {
            if (a[0] != b[0])
                return a[0].CompareTo(b[0]);
            else
                return a[1].CompareTo(b[1]);
        });

        // Step 2: Group by unique price and find max beauty for each price
        int n = items.Length;
        // Using lists to store unique prices and corresponding max beauties
        var uniquePrices = new System.Collections.Generic.List<int>();
        var priceMaxBeauties = new System.Collections.Generic.List<int>();

        int currentPrice = items[0][0];
        int currentMaxBeauty = items[0][1];

        for(int i = 1; i < n; i++) {
            if(items[i][0] == currentPrice) {
                if(items[i][1] > currentMaxBeauty) {
                    currentMaxBeauty = items[i][1];
                }
            }
            else {
                uniquePrices.Add(currentPrice);
                priceMaxBeauties.Add(currentMaxBeauty);
                currentPrice = items[i][0];
                currentMaxBeauty = items[i][1];
            }
        }
        // Add the last group
        uniquePrices.Add(currentPrice);
        priceMaxBeauties.Add(currentMaxBeauty);

        // Step 3: Iterate through unique prices to compute max beauty up to each price
        int m = uniquePrices.Count;
        for(int i = 1; i < m; i++) {
            if(priceMaxBeauties[i] < priceMaxBeauties[i-1]) {
                priceMaxBeauties[i] = priceMaxBeauties[i-1];
            }
            else {
                // Keep the current max
                priceMaxBeauties[i] = priceMaxBeauties[i];
            }
        }

        // Step 4: Sort queries along with their original indices
        int q = queries.Length;
        var sortedQueries = queries
                            .Select((value, index) => new { Value = value, Index = index })
                            .OrderBy(x => x.Value)
                            .ToArray();

        // Step 5: Initialize answer array
        int[] answer = new int[q];
        int pricePointer = 0;
        int currentOverallMaxBeauty = 0;

        // Step 6: Iterate through sorted queries and assign answers
        for(int i = 0; i < q; i++) {
            int queryValue = sortedQueries[i].Value;
            // Move the pricePointer as long as the price is <= queryValue
            while(pricePointer < m && uniquePrices[pricePointer] <= queryValue) {
                if(priceMaxBeauties[pricePointer] > currentOverallMaxBeauty) {
                    currentOverallMaxBeauty = priceMaxBeauties[pricePointer];
                }
                pricePointer++;
            }
            // Assign the currentOverallMaxBeauty to the original query index
            answer[sortedQueries[i].Index] = currentOverallMaxBeauty;
        }

        return answer;
    }
}
