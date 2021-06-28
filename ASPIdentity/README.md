# Project Problems Log

1. README Formatting
   - https://docs.github.com/en/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax#lists
   - The README file should be placed at project root

2. Migration for IdentityDbContext
   - Install Microsoft.EntityFrameworkCore.Tools
   - Open Package Manager Console
   - Add-Migrations
   - Update-Database
   - https://docs.microsoft.com/en-us/ef/core/cli/powershell#installing-the-tools
   - https://stackoverflow.com/a/54762138
   - Migrations for non-dotnet core
   - https://stackoverflow.com/a/32993262

3. Expression Bodied Members
   - =>
   - Replace one line only
   - Suppose your method returns something, then it will be public A returnA() => new A();
   - Suppose the class constructor parameters meet all parameters, then it will be public A(int x, int y) => (x,y) = (x,y);
   - https://www.youtube.com/watch?v=SKUH8333fXY&t=194s&ab_channel=ExecuteAutomation

4. UserManager methods (instance or extension)
   - CreateAsync(TUser user, string password): Create user with given password
   - FindByIdAsync(string userId): returns TUser with that specified ID
   - UpdateAsync(TUser user): Updates the specified user in the backing store.
   - DeleteAsync(TUser user): Deletes the specified user from the backing store.
   - Task<TUser> FindByEmailAsync(string email): Returns a user by the email.
   - Task<TUser> GetUserAsync(ClaimsPrincipal principal): Get user through HttpContext.Users
   - Task<IdentityResult> AddClaimAsync(TUser user, Claim claim): Add claims 

5. UserManager properties
	- Users: Returns a IQueryable of registered users, IQueryable is IEnumerable

6. IdentityUser properties
	- Email: string
	- PasswordHash: string but only accepts hashed result through IPasswordHasher

9. C# version
	- Open powershell
	- Type csc -langversion:?
	- The default one should be the current version

10. Startup class
	- IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions)
	- This configures whatever options you passed
	- IServiceCollection AddTransient<TService, [DynamicallyAccessedMembersAttribute(DynamicallyAccessedMemberTypes.PublicConstructors)] TImplementation>(this IServiceCollection services)
	- Adds implementation of that interface
	- IServiceCollection ConfigureApplicationCookie(this IServiceCollection services, Action<CookieAuthenticationOptions> configure);
	- This configures cookies options
	- AuthorizationPolicyBuilder RequireRole(params string[] roles)
	- This is for policy requiring a role
	- inside AuthorizationOptions AddPolicy

11. PasswordValidator<TUser>
	- This class allows you to add extra conditions to password validation
	- Override Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
	- IdentityResult.Success is also an IdentityResult class
	- public static IdentityResult Failed(params IdentityError[] errors); is also a good stuff

12. Attributes in controller
	- using Microsoft.AspNetCore.Authorization;

13. SignInManager methods
	- Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure): Sign in

14. Tag helper assembly issue
	- @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
	- @addTagHelper *, ASPIdentity
	- You need the assembly name, not the custom namespace
	- https://stackoverflow.com/a/50845427

15. Null conditional operator
	- ?.
	- If the object is null, ignore the dot operator
	- else, continue the access

16. Claim
	- public Claim(string type, string value, string valueType): constructor of claim class
	- claims is a name-value pair
	- use ClaimValueTypes.String for valuetype

17. Extra sources
	- How signin-google works
	- https://stackoverflow.com/questions/52980581/how-signin-google-in-asp-net-core-authentication-is-linked-to-the-google-handler
	- How the cookies works
	- https://www.yogihosting.com/aspnet-core-cookie-authentication/
	- What is OAuth and OpenConnectId
	- https://www.youtube.com/watch?v=996OiexHze0&ab_channel=OktaDev