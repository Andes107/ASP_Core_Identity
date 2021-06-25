# Project Problems Log

1. README Formatting
   - https://docs.github.com/en/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax#lists

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
