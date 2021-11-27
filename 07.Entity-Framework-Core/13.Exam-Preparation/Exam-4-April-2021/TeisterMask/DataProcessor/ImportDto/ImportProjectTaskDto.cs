using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectTaskDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.Task_Name_Min_Length)]
        [MaxLength(GlobalConstants.Task_Name_Max_Length)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        public string ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        public string LabelType { get; set; }
    }
}
