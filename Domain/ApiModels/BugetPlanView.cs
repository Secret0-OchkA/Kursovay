
using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

namespace Domain.ApiModel
{
    public class BugetPlanView : BaseViewEntity
    {
        public decimal January { get; set; } = 0;
        public decimal February { get; set; } = 0;
        public decimal March { get; set; } = 0;
        public decimal April { get; set; } = 0;
        public decimal May { get; set; } = 0;
        public decimal June { get; set; } = 0;
        public decimal July { get; set; } = 0;
        public decimal August { get; set; } = 0;
        public decimal September { get; set; } = 0;
        public decimal October { get; set; } = 0;
        public decimal November { get; set; } = 0;
        public decimal December { get; set; } = 0;

        public BugetPlanView() {}

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
