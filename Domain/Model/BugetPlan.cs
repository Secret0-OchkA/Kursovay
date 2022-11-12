using Domain.ApiModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BugetPlan : BaseDbEntity
    {
        public int DeparmentId { get; set; }
        [Required]
        public virtual Department Department { get; set; } = null!;

        public decimal January { get; set; }
        public decimal February { get; set; }
        public decimal March { get; set; }
        public decimal April { get; set; }
        public decimal May { get; set; }
        public decimal June { get; set; }
        public decimal July { get; set; }
        public decimal August { get; set; }
        public decimal September { get; set; }
        public decimal October { get; set; }
        public decimal November { get; set; }
        public decimal December { get; set; }

        public static BugetPlanView ToView(BugetPlan entity) => new BugetPlanView(entity);
    }
}
