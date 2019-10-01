using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorAnyEF3.DbModel
{
    public interface ICIREntity
    {
        int EntityKey { get; set; }
        int CreatorCIRId { get; set; }
        int MasterCIRId { get; set; }
        bool IsActive { get; set; }
    }
}
