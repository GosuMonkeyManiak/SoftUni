namespace SoftJail.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonerDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }
        
        [Required]
        [RegularExpression(@"^[T][h][e]\s[A-Z][a-z]+$")]
        public string Nickname { get; set; }

        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }
        
        public string ReleaseDate { get; set; }
        
        public decimal? Bail { get; set; }

        public int CellId { get; set; }

        public ImportPrisonerMailDto[] Mails { get; set; }

    }
}
