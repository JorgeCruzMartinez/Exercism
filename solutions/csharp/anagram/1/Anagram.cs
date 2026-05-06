public class Anagram
{
    private readonly string baseWord;
    private readonly string sortedBase;
    public Anagram(string baseWord)
	{
        this.baseWord = baseWord.ToLower();
        this.sortedBase = String.Concat(this.baseWord.OrderBy(c => c));
    }
        
    public string[] FindAnagrams(string[] potentialMatches)
	{
        return potentialMatches
               .Where(candidate =>
				{
					string candidateLower = candidate.ToLower();
					// Słowo nie może być samo swoim anagramem

					if (candidateLower == baseWord)
						return false;

					// Sortujemy litery i porównujemy
					string sortedCandidate = String.Concat(candidateLower.OrderBy(c => c));
					return sortedCandidate == sortedBase;
				}).ToArray();
    }
}