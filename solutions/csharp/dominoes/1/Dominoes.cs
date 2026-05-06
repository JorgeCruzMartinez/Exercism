using System.Text;

public static class Dominoes
{
    public class Domino
    {
        public int V1 { get; set; }
        public int V2 { get; set; }
        public int attachedSide { get; set; }

        public Domino((int v1, int v2) dominoSideValues)
        {
            V1 = dominoSideValues.v1;
            V2 = dominoSideValues.v2;
            attachedSide = 0;

        }

        public Domino Clone() => new Domino((V1, V2));

        public override string ToString() => String.Format("{0}{2}{4}{1}{3}", V1, V2, attachedSide == 1 ? "x" : "", attachedSide == 2 ? "x" : "", (attachedSide) == 0 ? "_" : ":");

        public String ToString(int tabCount) => String.Format("{0}{1}", new string('\t', tabCount), ToString());
    }

    public class DominoBag
    {
        public List<Domino> dominoList { get; set; }

        public DominoBag(List<Domino> dominoList) => this.dominoList = dominoList.ConvertAll(domino => domino.Clone());

        public string ToString()
        {
            var sb = new StringBuilder("[ ");
            foreach (var curDomino in dominoList)
            {
                sb.Append(curDomino.ToString(0) + " ");
            }

            sb.Append("]");
            return sb.ToString();
        }
    }

    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {

        if (dominoes == null || dominoes.Count() == 0)
            // empty list is considered chainable
            return true;

        var isChainFound = false;
        var dominoList = dominoes.Select(d => new Domino((d.Item1, d.Item2))).ToList();

        foreach (var curDomino in dominoList)
        {
            var dominoBag = new DominoBag(dominoList);
            isChainFound |= RecurMatch(0, null, curDomino, dominoBag);
        }
        return isChainFound;
    }

    public static bool RecurMatch(int recurLevel, int? topFreeDominoVal, Domino domino, DominoBag dominoBag)
    {

        // if it is the last domino in the bag
        if (dominoBag.dominoList.Count == 1)
        {
            if (domino == null)
                return false;
            else if (topFreeDominoVal == null)

                // single domino, both sides must match
                return (domino.V1 == domino.V2);
            else if (domino.V1 == topFreeDominoVal || domino.V2 == topFreeDominoVal)
                // must match with the unmatched end of the very first domino
                return true;
        }


        var isChainable = false;
        var listCopy = dominoBag.dominoList.ConvertAll(domino => domino.Clone());
        listCopy = RemoveDominoFromList(domino, listCopy);
        var newDominoBag = new DominoBag(listCopy);


        for (int i = newDominoBag.dominoList.Count - 1; i >= 0; i--)
        {
            var curDomino = listCopy[i];
            var isDominosMatching = IsAttachable(domino, curDomino);
            if (isDominosMatching)
            {
                AttachDominos(domino, curDomino);
                if (topFreeDominoVal == null)
                {
                    // set the unmatched end of the first domino
                    var detachedVal = domino.attachedSide == 1 ? domino.V2 : domino.V1;
                    topFreeDominoVal = detachedVal;

                }


                // recurse
                isChainable |= RecurMatch(recurLevel + 1, topFreeDominoVal, curDomino, newDominoBag);
            }
        }

        if (newDominoBag.dominoList.Count == 0)
        {
            // if we have reached the end of the dominos
            if (topFreeDominoVal == null)
                // there never were dominos to go through
                isChainable = false;
            else if (topFreeDominoVal == (domino.attachedSide == 1 ? domino.V2 : domino.V1))
                // the last matched domino's free end matches the first domino's free end
                isChainable = true;
        }

        return isChainable;
    }

    public static bool IsAttachable(Domino domino1, Domino domino2)
    {
        var caseA = (domino1.V1 == domino2.V1 && domino1.attachedSide != 1 && domino2.attachedSide != 1);
        var caseB = (domino1.V1 == domino2.V2 && domino1.attachedSide != 1 && domino2.attachedSide != 2);
        var caseC = (domino1.V2 == domino2.V1 && domino1.attachedSide != 2 && domino2.attachedSide != 1);
        var caseD = (domino1.V2 == domino2.V2 && domino1.attachedSide != 2 && domino2.attachedSide != 2);
        var isAttachable = (caseA || caseB || caseC || caseD);

        return isAttachable;
    }

    public static void AttachDominos(Domino domino1, Domino domino2)
    {

        if (domino1.V1 == domino2.V1 && domino1.attachedSide != 1 && domino2.attachedSide != 1)
        {
            domino1.attachedSide = 1;
            domino2.attachedSide = 1;
        }
        else if (domino1.V1 == domino2.V2 && domino1.attachedSide != 1 && domino2.attachedSide != 2)
        {
            domino1.attachedSide = 1;
            domino2.attachedSide = 2;
        }
        else if (domino1.V2 == domino2.V1 && domino1.attachedSide != 2 && domino2.attachedSide != 1)
        {
            domino1.attachedSide = 2;
            domino2.attachedSide = 1;
        }
        else if (domino1.V2 == domino2.V2 && domino1.attachedSide != 2 && domino2.attachedSide != 2)
        {
            domino1.attachedSide = 2;
            domino2.attachedSide = 2;
        }
    }

    public static List<Domino> RemoveDominoFromList(Domino domino, List<Domino> origList)
    {
        var updatedList = new List<Domino>();
        foreach (var curDomino in origList)
        {
            if (domino != null && ((domino.V1 == curDomino.V1 && domino.V2 == curDomino.V2)
                    || (domino.V1 == curDomino.V2 && domino.V2 == curDomino.V1)))
                domino = null;
            else
                updatedList.Add(curDomino);
        }

        return updatedList;
    }
}