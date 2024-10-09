public class RecentCounter {

    private Queue<int> _recentRequests;  // Queue to store the timestamps of recent requests

    public RecentCounter() {
        // Initialize the queue to store recent request timestamps
        _recentRequests = new Queue<int>();
    }
    
    public int Ping(int t) {
        // Add the new request timestamp to the queue
        _recentRequests.Enqueue(t);

        // Remove requests that occurred more than 3000 milliseconds before the current request
        // We only want requests in the range [t - 3000, t]
        while (_recentRequests.Peek() < t - 3000) {
            _recentRequests.Dequeue();  // Remove the oldest request that falls out of the time window
        }

        // Return the number of requests in the queue, i.e., the number of valid requests in the past 3000 milliseconds
        return _recentRequests.Count;
    }
}

/**
 * Your RecentCounter object will be instantiated and called as such:
 * RecentCounter obj = new RecentCounter();
 * int param_1 = obj.Ping(t);
 */