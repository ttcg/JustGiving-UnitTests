using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftAidCalculator.TestConsole
{
    public class Events
    {
        public decimal SupplementAmount(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.Running:
                    return 5m;
                case EventType.Swimming:
                    return 3m;
                default:
                    return 0m;
            }
        }
    }

    public enum EventType
    {
        Running = 1,
        Swimming,
        Others
    }
}
