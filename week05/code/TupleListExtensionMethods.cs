using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cse212;

public static class TupleListExtensionMethods
{
    public static string AsString(this IEnumerable list)
    {
        return "<List>{" + string.Join(", ", list.Cast<ValueTuple<int, int>>()) + "}";
    }
}
