using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelDeskProject.Models
{
    public class TravelRequest
    {
        [Key]
        [Required]
        public int RequestId { get; set; }

        public int EmpId { get; set; }


        [ForeignKey("ProjectId")]
        public Project? ProjectId { get; set; }


        [ForeignKey("TravelReasonId")]
        public ReasonForTravelling? TravelReasonId {  get; set; }


        [ForeignKey("BookingId")]
        public BookingType? BookingId { get; set; }

       
        public DateOnly BookingDate { get; set; }


        [ForeignKey("MealId")]
        public MealType? MealId { get; set; }
        public bool IsActive { get; set; }

        public int CreateBy { get; set; }
        public int? UpdateBy { get; set; } = null;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
    }
}
