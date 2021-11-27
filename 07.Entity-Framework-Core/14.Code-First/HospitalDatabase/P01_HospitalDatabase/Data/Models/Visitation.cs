using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        public int VisitationId { get; set; }
        
        public DateTime Date { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }
        
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
