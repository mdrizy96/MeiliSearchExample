using System.ComponentModel.DataAnnotations;

namespace SearchUtils.Models.Dtos
{
    public class IndexForCreationDto
    {
        [Required] public string Uid { get; set; }
        public string PrimaryKey { get; set; }
    }
}