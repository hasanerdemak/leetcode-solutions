public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>();
        
        foreach (int asteroid in asteroids) {
            bool exploded = false;  // Flag to track if the current asteroid explodes
            
            // Handle potential collisions (positive asteroids moving right vs. negative moving left)
            // Only check collisions if stack has positive asteroid and current one is negative
            while (stack.Count > 0 && stack.Peek() > 0 && asteroid < 0) {
                int top = stack.Peek();  // Peek the top asteroid in the stack
                
                if (top < Math.Abs(asteroid)) {  // If the top asteroid is smaller than the current one
                    stack.Pop();  // Remove the top asteroid (it explodes)
                } else if (top == Math.Abs(asteroid)) {  // If the top asteroid and current one are the same size
                    stack.Pop();  // Both asteroids explode
                    exploded = true;  // Mark the current asteroid as exploded
                    break;  // No need to check further as both explode
                } else {
                    // Current asteroid explodes as the top asteroid is larger
                    exploded = true;
                    break;  // Stop further checking as current asteroid explodes
                }
            }
            
            // If the current asteroid didn't explode in the collision process, Add it to the stack
            if (!exploded) {
                stack.Push(asteroid);  
            }
        }

        // Convert the remaining stack into the final result array (after reversing the stack)
        return stack.Reverse().ToArray();
    }
}
