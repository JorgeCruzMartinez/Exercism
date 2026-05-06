public static class ProteinTranslation
{
    private static readonly Dictionary<string, string> CodonToProteinMap = new Dictionary<string, string>
    {
        { "AUG", "Methionine" },
        { "UUU", "Phenylalanine" },
        { "UUC", "Phenylalanine" },
        { "UUA", "Leucine" },
        { "UUG", "Leucine" },
        { "UCU", "Serine" },
        { "UCC", "Serine" },
        { "UCA", "Serine" },
        { "UCG", "Serine" },
        { "UAU", "Tyrosine" },
        { "UAC", "Tyrosine" },
        { "UGU", "Cysteine" },
        { "UGC", "Cysteine" },
        { "UGG", "Tryptophan" },
        { "UAA", "STOP" },
        { "UAG", "STOP" },
        { "UGA", "STOP" }
    };
    public static IEnumerable<string> Proteins(string rna)
    {
        var proteins = new List<string>();
        for (int i = 0; i < rna.Length; i += 3)
        {
            var codon = rna.Substring(i, 3);
            if (CodonToProteinMap.TryGetValue(codon, out var protein))
            {
                if (protein == "STOP")
                    break;
                proteins.Add(protein);
            }
            else
                throw new ArgumentException("Invalid codon encountered.");
        }
        return proteins;
    }
}