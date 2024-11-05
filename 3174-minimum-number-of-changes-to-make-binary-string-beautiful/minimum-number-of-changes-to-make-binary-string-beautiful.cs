public class Solution {
    public int MinChanges(string s) {
        int changes = 0;
        int n = s.Length;
        for(int i = 0; i < n; i += 2)
        {
            if(s[i] != s[i+1])
            {
                changes += 1;
            }
        }
        return changes;
    }
}