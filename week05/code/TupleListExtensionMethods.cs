using System;
using System.Collections.Generic;
using System.Linq;

namespace cse212;

public static class TupleListExtensionMethods
{
    public static string AsString(this List<(int, int)> path)
    {
        return string.Join("" -> "", path.Select(p => $""({p.Item1},{p.Item2})""));
    }
}
