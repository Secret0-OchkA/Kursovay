
using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class BugetPlanView : BaseViewEntity
    {
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

        public BugetPlanView(BugetPlan bugetPlan) : base(bugetPlan)
        {
            this.January = bugetPlan.January;
            this.February = bugetPlan.February;
            this.March = bugetPlan.March;
            this.April = bugetPlan.April;
            this.May = bugetPlan.May;
            this.June = bugetPlan.June;
            this.July = bugetPlan.July;
            this.August = bugetPlan.August;
            this.September = bugetPlan.September;
            this.October = bugetPlan.October;
            this.November = bugetPlan.November;
            this.December = bugetPlan.December;
        }
    }
}
