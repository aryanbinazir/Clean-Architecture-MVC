using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VilaBookingService.Domain.Entities
{
    public class VilaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Vila Number")]
        public int Vila_Number { get; set; }
        public string? SpecialDetails { get; set; }

        // Relations 
        [ForeignKey("Vila")]
        [Display(Name = "Vila ID")]
        public int VilaId { get; set; }
        [ValidateNever]
        public Vila Vila { get; set; }
        


    }
}
