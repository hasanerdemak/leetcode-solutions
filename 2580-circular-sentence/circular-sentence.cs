public class Solution {
    public bool IsCircularSentence(string sentence) {
        if (sentence[0] != sentence[^1]) return false;
        
        var words = sentence.Split();
        for (int i = 0; i < words.Length-1; i++) {
            var word1 = words[i];
            var word2 = words[i+1];
            if (word1[^1] != word2[0]) {
                return false;
            }
        }

        return true;
    }
}