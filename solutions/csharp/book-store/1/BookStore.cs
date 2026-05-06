public static class BookStore
{
    private static readonly decimal[] _discounts = new[] { 1m, .95m, .90m, .80m, .75m };
    private const decimal _basePrice = 8m;

    public static decimal Total(IEnumerable<int> books) =>
        BasketTotal(books.GroupBy(i => i).OrderByDescending(g => g.Count())
                    .SelectMany(g => g),
                    0);
    
    private static decimal BasketTotal(IEnumerable<int> books, decimal accumulativePrice)
    {
        if (books.Count() == 0) return accumulativePrice;
        var groups = books.Distinct();
        var cheapestPrice = Decimal.MaxValue;
        for (var i = 0; i < groups.Count(); i++)
        {
            var currentGroups = groups.Take(i + 1);
            var currentBooks = new List<int>(books);
            foreach (var book in currentGroups)
                currentBooks.Remove(book);
    
            var groupPrice = (i + 1) * _basePrice * _discounts[i];
            var currentPrice = BasketTotal(currentBooks, accumulativePrice + groupPrice);
            if (currentPrice < cheapestPrice)
                cheapestPrice = currentPrice;
        }
        return cheapestPrice;
    }
}