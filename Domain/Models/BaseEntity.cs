using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public interface IEntity
    {
        
    }
    
    public class BaseEntity<TKey>: IEntity
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? EditedDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}