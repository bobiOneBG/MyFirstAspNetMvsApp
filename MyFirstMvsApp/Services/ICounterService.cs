namespace MyFirstMvsApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICounterService
    {
        int GetCount();
    }

    public class CounterService : ICounterService
    {
        private static int instances;
        public CounterService()
        {
            instances++;
        }
        public int GetCount()
        {
            return instances;
        }
    }
}
