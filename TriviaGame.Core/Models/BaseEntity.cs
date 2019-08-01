using System.ComponentModel.DataAnnotations;

namespace TriviaGame.Core.Models
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
