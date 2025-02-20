using Shared.Models.DTOs.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models.DTOs.Bases
{
    public class BaseDto : IBaseDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


    }
}
