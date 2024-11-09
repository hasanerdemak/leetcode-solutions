public class Solution {
    public long MinEnd(int n, int x) {
        long num = x;
        long k = n - 1;
        int bit = 0;
        
        while(k > 0)
        {
            // Check if the current bit is free (not set in x)
            if( (x & (1L << bit)) == 0 )
            {
                // If the least significant bit of k is set, set this bit in num
                if( (k & 1) != 0 )
                {
                    num |= (1L << bit);
                }
                // Shift k to process the next bit
                k >>= 1;
            }
            // Move to the next bit position
            bit++;
        }
        
        return num;
    }
}