public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visitedRooms = new HashSet<int>();   // To track visited rooms
        var stack = new Stack<int>();            // To simulate the room visiting order

        // Start by visiting room 0
        stack.Push(0);
        visitedRooms.Add(0);

        // While there are rooms to process
        while (stack.Count > 0) {
            int currentRoom = stack.Pop();
            // Get keys in the current room and try to visit the rooms
            foreach (var key in rooms[currentRoom]) {
                // If we haven't visited this room yet
                if (!visitedRooms.Contains(key)) {
                    visitedRooms.Add(key);   // Mark the room as visited
                    stack.Push(key);         // Add it to the stack to process its keys
                }
            }
        }

        // If we visited all rooms, return true
        return visitedRooms.Count == rooms.Count;
    }
}