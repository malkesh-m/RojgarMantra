using System;
using System.Collections.Generic;
using System.Text;

namespace RojgarMantra.Data.Helpers
{
    public class ConfigSettings
    {
        public static ConfigSettings Current;

        public ConfigSettings()
        {
            Current = this;
        }

        public string DefaultConnection { get; set; }
    }
}
