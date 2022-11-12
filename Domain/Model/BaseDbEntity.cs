using System.Text.Json.Serialization;

namespace Domain.Model
{
    public class BaseDbEntity
    {
        public int Id { get; set; }
        public DateTime createDate { get; set; } = DateTime.UtcNow;
        public DateTime modifyDate { get; set; } = DateTime.UtcNow;
    }
}
