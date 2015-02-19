using System;
using System.Globalization;
using System.Threading;

namespace DryPants.Test.Core
{
    class ThreadCultureScope : IDisposable
    {
        private readonly CultureInfo _currentCulture;

        public ThreadCultureScope(CultureInfo currentCulture)
        {
            _currentCulture = currentCulture;
        }

        public void Dispose()
        {
            Thread.CurrentThread.CurrentCulture = _currentCulture;
        }
    }
}
