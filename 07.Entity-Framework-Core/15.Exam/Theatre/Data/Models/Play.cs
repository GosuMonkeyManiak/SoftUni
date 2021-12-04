namespace Theatre.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Play
    {
        public Play()
        {
            Tickets = new HashSet<Ticket>();
            Casts = new HashSet<Cast>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }
        
        [MaxLength(10)]
        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [MaxLength(700)]
        public string Description { get; set; }

        [Required]
        [MaxLength(30)]
        public string Screenwriter { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Cast> Casts { get; set; }
    }
}
