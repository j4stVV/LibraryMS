namespace Lib.Domain.Entities
{
	public class RoleInitializer
	{
		public static void InitializeRoles(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			string[] roleNames = { "SuperUser", "User" };
			foreach (var roleName in roleNames)
			{
				if (!roleManager.RoleExistsAsync(roleName).Result)
				{
					var role = new IdentityRole(roleName);
					roleManager.CreateAsync(role).Wait();
				}
			}
		}
	}
}