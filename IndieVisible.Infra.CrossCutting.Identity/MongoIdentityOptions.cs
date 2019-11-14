namespace IndieVisible.Infra.CrossCutting.Identity
{
	public class MongoIdentityOptions
    {
        public string ConnectionString { get; set; } = "mongodb://localhost/default";

        public string DatabaseName { get; set; } = "test";

        public string UsersCollection { get; set; } = "User";
		
	    public string RolesCollection { get; set; } = "Role";

	    public bool UseDefaultIdentity { get; set; } = true;
	}
}