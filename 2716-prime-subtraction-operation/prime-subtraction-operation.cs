public class Solution {
    public bool PrimeSubOperation(int[] nums) {
        // Step 1: Generate all primes less than 1000 using Sieve of Eratosthenes
        bool[] isPrime = new bool[1001];
        for(int i=0;i<=1000;i++) isPrime[i] = true;
        isPrime[0] = isPrime[1] = false;
        for(int p=2; p*p <=1000; p++) {
            if(isPrime[p]){
                for(int multiple = p*p; multiple <=1000; multiple += p){
                    isPrime[multiple] = false;
                }
            }
        }
        List<int> primes = new List<int>();
        for(int i=2;i<1000;i++) {
            if(isPrime[i]) primes.Add(i);
        }

        // Step 2: Initialize min_v
        int min_v = 0;

        // Step 3: Iterate through nums
        foreach(int num in nums){
            List<int> options = new List<int>();
            options.Add(num);
            foreach(int p in primes){
                if(p < num){
                    options.Add(num - p);
                }
            }
            options.Sort();
            // Find the smallest option > min_v
            bool found = false;
            int new_min_v = 0;
            foreach(int o in options){
                if(o > min_v){
                    new_min_v = o;
                    found = true;
                    break;
                }
            }
            if(!found){
                return false;
            }
            min_v = new_min_v;
        }

        // If all steps succeeded
        return true;
    }
}
