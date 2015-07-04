using System.ComponentModel.DataAnnotations;

namespace TextMatch.Models
{
    public class TextMatchInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(999, MinimumLength = 1)]
        public string Text { get; set; }

        [Required]
        [StringLength(999, MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string SubText { get; set; }
    }
}