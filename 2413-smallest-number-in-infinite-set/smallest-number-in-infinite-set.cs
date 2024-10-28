public class SmallestInfiniteSet {
    PriorityQueue<int, int> heap = new PriorityQueue<int, int>();
    HashSet<int> removedItems = new HashSet<int>();

    public SmallestInfiniteSet() {
       for (int i = 1; i <= 1000; i++)
       {
           heap.Enqueue(i, i);
       }
    }
    
    public int PopSmallest() {  
        int min = heap.Dequeue();
        removedItems.Add(min);
        return min;
    }
    
    public void AddBack(int num) {
        int min = heap.Peek();
        if (min > num) {
            heap.Enqueue(num, num);
            removedItems.Remove(min);  
        } else if (min < num) {
            if (removedItems.Contains(num))
            {
                heap.Enqueue(num, num);
                removedItems.Remove(min);
            }
        }
    }
}

/**
 * Your SmallestInfiniteSet object will be instantiated and called as such:
 * SmallestInfiniteSet obj = new SmallestInfiniteSet();
 * int param_1 = obj.PopSmallest();
 * obj.AddBack(num);
 */