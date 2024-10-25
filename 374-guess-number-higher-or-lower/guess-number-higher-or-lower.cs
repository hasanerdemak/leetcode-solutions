/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution : GuessGame {
    public int GuessNumber(int n) {
        int low = 1;
        int high = n;

        while (low <= high) {
            int mid = low + (high - low) / 2; // Calculate the midpoint
            int result = guess(mid); // Call the guess API

            if (result == 0) {
                return mid; // Correct guess
            } else if (result == -1) {
                high = mid - 1; // Guess is too high, adjust the upper bound
            } else {
                low = mid + 1; // Guess is too low, adjust the lower bound
            }
        }

        return -1; // Just a safeguard, we should never reach here
    }
}