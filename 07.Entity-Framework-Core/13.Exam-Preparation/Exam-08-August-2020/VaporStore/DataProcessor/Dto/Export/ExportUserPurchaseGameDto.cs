using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class ExportUserPurchaseGameDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Price")]
        public string Price { get; set; }
    }
}
