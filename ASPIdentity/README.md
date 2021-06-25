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

5. UserManager properties
	- Users: Returns a IQueryable of registered users, IQueryable is IEnumerable

6. IdentityUser properties
	- Email: string
	- PasswordHash: string but only accepts hashed result through IPasswordHasher