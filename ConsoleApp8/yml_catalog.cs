using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp8
{
    [Serializable]
    public class yml_catalog
    {
        [XmlAttribute]
        public string date { get; set; } = DateTime.Now.ToShortDateString();
        public shop shop { get; set; } = new shop();
    }



    [XmlRoot(ElementName = "shop")]
    [Serializable]
    public class shop
    {
        public string name { get; set; } = "Тринити";
        public string company { get; set; } = "ТОВ Тринити СБ";
        public string url { get; set; } = "http://ctb.com.ua";
       
        
        public List<currency> currencies { get; set; } = new List<currency>();
        public List<category> categories { get; set; } = new List<category>();

        public List<offer> offers { get; set; } = new List<offer>();

        public shop()
        {
            currencies.Add(new currency() { id = "UAH", rate = "1.00" });
            currencies.Add(new currency() { id = "USD", rate = "28" });
            currencies.Add(new currency() { id = "EUR", rate = "35" });
        }


    }

   // [XmlRoot(ElementName = "currency")]
    public class currency
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string rate { get; set; }
    }

    public class category
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlTextAttribute]
        public string Value { get; set; }

    }

    public class offer
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string available { get; set; } = "true";
                                                  
        public string url { get; set; }
        public string categoryId { get; set; }
        public string price { get; set; }
        public string currencyId { get; set; } = "UAH";
        [XmlElement("picture")]
        public List<string> picture { get; set; } = new List<string>();
        public string vendor { get; set; }
        public string name { get; set; }

        [XmlIgnore]
        public string description { get; set; }

        [XmlElement("description")]
        public System.Xml.XmlCDataSection descriptionCDATA
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(description);
            }
            set
            {
                description = value.Value;
            }
        }

        public string stock_quantity { get; set; }

        [XmlElement("param")]
        public List<param> p { get; set; } = new List<param>();

        
    }

    public class param
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlTextAttribute]
        public string Value { get; set; }

    }
}
