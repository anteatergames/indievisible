using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndieVisible.Domain.Core.Models
{
    public class Entity
    {
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        [Column(Order = 1)]
        public Guid UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public Entity()
        {
            CreateDate = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            Entity compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}