using System.Collections.Generic;
using System.Linq;

namespace _03_design_hw
{
    public interface IStatsReader
    {
        string SourceFile { get; }
        IOrderedEnumerable<KeyValuePair<string, int>> Stats { get; set; }
    }
}
