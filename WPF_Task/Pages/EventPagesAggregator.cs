using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Task.Pages
{
    internal static class EventPagesAggregator
    {
        public static event Action GridDataUpdated;

        public static void NotifyDataUpdated()
        {
            GridDataUpdated.Invoke();
        }
    }
}
