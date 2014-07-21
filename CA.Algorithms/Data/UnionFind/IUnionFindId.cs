using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA.Algorithms.Data.UnionFind
{
    public interface IUnionFindId
    {
        int Id { get; set; }
        int LeaderId { get; set; }
    }
}
