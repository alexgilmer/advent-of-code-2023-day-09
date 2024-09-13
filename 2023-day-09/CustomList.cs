using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_day_09;

public class CustomList : List<long>
{
    private HashSet<long> _values;
    public int UniqueElements => _values.Count;

    public CustomList(IEnumerable<long> l) : base(l)
    {
        _values = new HashSet<long>(l);
    }

    public CustomList() : base()
    {
        _values = new();
    }

    new public void Add(long value)
    {
        base.Add(value);
        _values.Add(value);
    }

    public bool IsAllZeroes() => _values.Count == 1 && this[0] == 0;

    public override string ToString()
    {
        return $"[ {string.Join(", ", this)} ]";
    }
}
