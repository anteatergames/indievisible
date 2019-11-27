using Microsoft.AspNetCore.Identity;

namespace IndieVisible.Infra.CrossCutting.Identity.Model
{
    public class Role : IdentityRole
    {
        //public ObjectId _id { get; set; }

        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
            NormalizedName = name.ToUpperInvariant();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}