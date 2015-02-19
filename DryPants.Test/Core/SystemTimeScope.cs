using System;
using DryPants.Core;

namespace DryPants.Test.Core
{
    internal class SystemTimeScope : IDisposable
    {
        public SystemTimeScope()
        {
            SystemTime.Reset();
        }

        public void Dispose()
        {
            SystemTime.Reset();
        }
    }
}
