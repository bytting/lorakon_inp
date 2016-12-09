using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace lorakon
{
    [Serializable()]
    public class Settings
    {
        public bool UseStoredLaboratoryName;
        public string StoredLaboratoryName;
        
        public Settings()
        {
            UseStoredLaboratoryName = true;
            StoredLaboratoryName = "";
        }
    }
}
