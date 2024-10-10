public class Solution {
    public string PredictPartyVictory(string senate) {
        var radQueue = new Queue<int>();  // Queue to store the indexes of Radiant senators
        var dirQueue = new Queue<int>();  // Queue to store the indexes of Dire senators
        var n = senate.Length;

        // Populate the initial queues with the positions of the Radiant and Dire senators
        for (int i = 0; i < n; i++) {
            var c = senate[i];
            if (c == 'R') radQueue.Enqueue(i);  // If Radiant, add to Radiant queue
            else dirQueue.Enqueue(i);  // If Dire, add to Dire queue
        }

        // Continue the rounds until one party has no senators left
        while (radQueue.Count > 0 && dirQueue.Count > 0) {
            // Compare the positions of the first Radiant and Dire senators
            if (radQueue.Peek() < dirQueue.Peek()) {
                // If Radiant senator is earlier, he bans the Dire senator
                radQueue.Enqueue(n++);  // Add this Radiant senator back for future rounds
            } else {
                // If Dire senator is earlier, he bans the Radiant senator
                dirQueue.Enqueue(n++);  // Add this Dire senator back for future rounds
            }

            // Both senators' turns have been processed, so remove them from the queue
            dirQueue.Dequeue();
            radQueue.Dequeue();
        }

        // If there are remaining Radiant senators, they win. Otherwise, Dire wins.
        return radQueue.Count > 0 ? "Radiant" : "Dire";
    }
}
