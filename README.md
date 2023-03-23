# General Information

This is an microservice template of how build an api with best practices, SOLID principles, Open Api standard. This template is based on project of [this course](https://www.udemy.com/course/arquitectura-Applicationes-empresariales-con-net-core/)

# .Net version
- Version 7

# Dependencies

- Dapper
- WatchDog

# Setup
1. For the project MicroService.Template.Services.WebApi, the following secrets must be setting as user secrets. Refer this [site](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).
	
1. ConnectionStrings:SQL_connection
2. Config:Secret
3. Config:OriginCors
4. Config:Issuer
5. Config:Audience
6. WatchDog:UserName
7. WatchDog:Password

2. Execute [Database Script](./Database_init.sql) to install Database
3. Insert user credentials into User table
4. Run WebApi project.
5. Run [Script](./WatchDog_Setup.sql) to alter columns Watch Dog tables on database created at step number 2