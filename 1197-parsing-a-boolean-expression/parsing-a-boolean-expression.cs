public class Solution {
    public bool ParseBoolExpr(string expression) {
        // Stack to store characters from the expression as we process it.
        Stack<char> stack = new Stack<char>();

        // Iterate through each character in the expression.
        foreach (char c in expression) {
            if (c == ',') {
                // Skip commas, they are used as separators between subexpressions.
                continue;
            }
            else if (c != ')') {
                // If the current character is not ')', push it onto the stack.
                stack.Push(c);
            }
            else {
                // We've encountered a ')', which means we need to evaluate a subexpression.
                List<char> subExpr = new List<char>();
                
                // Pop elements from the stack until we find the matching '('.
                while (stack.Peek() != '(') {
                    subExpr.Add(stack.Pop());
                }
                // Pop the '(' off the stack.
                stack.Pop();
                
                // Pop the operator ('!', '&', or '|') that is just before the '('.
                char op = stack.Pop();
                
                // Variable to store the result of the subexpression.
                bool result = false;
                
                // Evaluate the subexpression based on the operator.
                if (op == '!') {
                    // NOT operation: invert the value. There should only be one subexpression.
                    result = subExpr[0] == 'f';  // If it's 'f', the result is true (NOT false).
                } else if (op == '&') {
                    // AND operation: return true only if all subexpressions are true.
                    result = !subExpr.Contains('f');  // If any 'f' exists, the result is false.
                } else if (op == '|') {
                    // OR operation: return true if any subexpression is true.
                    result = subExpr.Contains('t');  // If any 't' exists, the result is true.
                }
                
                // Push the result of the subexpression ('t' for true, 'f' for false) back onto the stack.
                stack.Push(result ? 't' : 'f');
            }
        }
        
        // After processing the entire expression, the final result will be the only element left in the stack.
        return stack.Pop() == 't';
    }
}
