using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nascar.WinApp
{
    public delegate void FlagStateChanged(FlagState old_state, FlagState new_state, int lap_number);

    public enum FlagState
    {
        None = 0,
        Green = 1,
        Yellow = 2,
        Red = 3,
        White = 4,
        Checkered = 5,
        Warm = 7,
        Cold = 9
    }
}
