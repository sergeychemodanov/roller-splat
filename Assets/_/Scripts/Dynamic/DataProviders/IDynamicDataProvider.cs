using System.Collections.Generic;

namespace AwesomeCompany.RollerSplat.Dynamic
{
    public interface IDynamicDataProvider
    {
        List<Level> levels { get; }
    }
}