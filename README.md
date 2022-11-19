# General Information

This is an microservice template of how build an api with best practices, SOLID principles, Open Api standard. This template is based on project of [this course](https://www.udemy.com/course/arquitectura-aplicaciones-empresariales-con-net-core/)

# .Net version
- Version 7

# Dependencies

- Dapper
- WatchDog

# Setup
- After run WebApi project, [Script](./WatchDog_Setup.sql) to alter columns Watch Dog tables must be executed
- For the project MicroService.Template.Services.WebApi, the following secrets must be setting as user secrets. Refer this [site](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows).
	
1. ConnectionStrings:SQL_connection
2. Config:Secret
3. Config:OriginCors
4. Config:Issuer
5. Config:Audience
6. WatchDog:UserName
7. WatchDog:Password