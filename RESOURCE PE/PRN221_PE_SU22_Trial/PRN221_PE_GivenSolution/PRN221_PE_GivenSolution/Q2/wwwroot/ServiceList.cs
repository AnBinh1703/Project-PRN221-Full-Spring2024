using Q2.Entity;
using System.Xml.Serialization;

namespace Q2
{
    [XmlRoot("ArrayOfService")]
    public class ServiceList
    {
        [XmlElement("Service")]
        public List<Service> Services { get; set; }
    }
}
