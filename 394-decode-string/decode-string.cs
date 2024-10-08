public class Solution {
    public string DecodeString(string s) {
        var result = new StringBuilder();  // This will hold the current decoded string segment
        var numberStack = new Stack<int>();  // Stack to store the numbers (k) for repetition
        var strStack = new Stack<StringBuilder>();  // Stack to store string segments when encountering a '['
        var tempNumberSb = new StringBuilder();  // Temporary string builder to accumulate multi-digit numbers

        foreach (var c in s) {  // Iterate through each character in the input string
            if (char.IsDigit(c)) {
                // If the character is a digit, accumulate it to form the full number (handles multi-digit numbers)
                tempNumberSb.Append(c);
            } 
            else if (c == '[') {
                // When we encounter '[', we push the current result onto the stack and prepare for a new segment
                strStack.Push(result);
                result = new StringBuilder();  // Start a new segment for the current nested substring
                numberStack.Push(int.Parse(tempNumberSb.ToString()));  // Store the number k for the repeated segment
                tempNumberSb.Clear();  // Clear the temporary number accumulator
            } 
            else if (c == ']') {
                // When we encounter ']', we pop the last stored string segment and the corresponding repetition number
                var temp = strStack.Pop();  // Pop the string we need to append the repeated sequence to
                var multiplier = numberStack.Pop();  // Get the number of repetitions
                
                // Append the current result (repeated substring) 'multiplier' times to the previous string
                for (int i = 0; i < multiplier; i++) {
                    temp.Append(result);
                }
                result = temp;  // Set the result to the updated string with repeated parts appended
            } 
            else {
                // If the character is a letter, just append it to the current result
                result.Append(c);
            }
        }

        return result.ToString();  // Return the fully decoded string
    }
}
