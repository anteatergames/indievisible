using System;
using IndieVisible.Infra.CrossCutting.Identity.Model;
using IndieVisible.Infra.CrossCutting.Identity.Models;
using IndieVisible.Infra.CrossCutting.Identity.Stores;
using IndieVisible.Infra.Data.MongoDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace IndieVisible.Infra.CrossCutting.Identity
{
	public static class MongoIdentityExtensions
	{
	    public static IdentityBuilder AddIdentityMongoDbProvider<TUser>(this IServiceCollection services) where TUser : ApplicationUser
        {
	        return AddIdentityMongoDbProvider<TUser, Role>(services, x => { });
	    }

        public static IdentityBuilder AddIdentityMongoDbProvider<TUser>(this IServiceCollection services,
	        Action<MongoIdentityOptions> setupDatabaseAction) where TUser : ApplicationUser
        {
	        return AddIdentityMongoDbProvider<TUser, Role>(services, setupDatabaseAction);
	    }

        public static IdentityBuilder AddIdentityMongoDbProvider<TUser, TRole>(this IServiceCollection services,
			Action<MongoIdentityOptions> setupDatabaseAction) where TUser : ApplicationUser
            where TRole : Role
        {
            return AddIdentityMongoDbProvider<TUser, TRole>(services, x => { }, setupDatabaseAction);
        }

	    public static IdentityBuilder AddIdentityMongoDbProvider(this IServiceCollection services,
	        Action<IdentityOptions> setupIdentityAction, Action<MongoIdentityOptions> setupDatabaseAction)
	    {
	        return AddIdentityMongoDbProvider<ApplicationUser, Role>(services, setupIdentityAction, setupDatabaseAction);
	    }

	    public static IdentityBuilder AddIdentityMongoDbProvider<TUser>(this IServiceCollection services,
	        Action<IdentityOptions> setupIdentityAction, Action<MongoIdentityOptions> setupDatabaseAction) where TUser : ApplicationUser
        {
	        return AddIdentityMongoDbProvider<TUser, Role>(services, setupIdentityAction, setupDatabaseAction);
        }

	    public static IdentityBuilder AddIdentityMongoDbProvider<TUser, TRole>(this IServiceCollection services,
	        Action<IdentityOptions> setupIdentityAction, Action<MongoIdentityOptions> setupDatabaseAction) where TUser : ApplicationUser
            where TRole : Role
        {
            var dbOptions = new MongoIdentityOptions();
	        setupDatabaseAction(dbOptions);

	        var builder = services.AddIdentity<TUser, TRole>(setupIdentityAction ?? (x => { }));
	        
	        builder.AddRoleStore<RoleStore<TRole>>()
	        .AddUserStore<UserStore<TUser, TRole>>()
	        .AddUserManager<UserManager<TUser>>()
            .AddRoleManager<RoleManager<TRole>>()
	        .AddDefaultTokenProviders();


	        var userCollection =  MongoUtil.FromConnectionString<TUser>(dbOptions.ConnectionString, dbOptions.DatabaseName, dbOptions.UsersCollection);
	        var roleCollection = MongoUtil.FromConnectionString<TRole>(dbOptions.ConnectionString, dbOptions.DatabaseName, dbOptions.RolesCollection);

	        services.AddSingleton<IMongoCollection<TUser>>(x => userCollection);
	        services.AddSingleton<IMongoCollection<TRole>>(x => roleCollection);

	        // Identity Services
	        services.AddTransient<IUserStore<TUser>>(x => new UserStore<TUser, TRole>(userCollection, roleCollection, x.GetService<ILookupNormalizer>()));
	        services.AddTransient<IRoleStore<TRole>>(x => new RoleStore<TRole>(roleCollection));

            var all = userCollection.All();

            all.Wait();
            var todos = all.Result;


            return builder;
	    }
	}
}