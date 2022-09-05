# CustomerService

This is an API application wich allows CRUD operations on a customer entity. The platform used in this app is .NET which allows the use of Swagger (an API developer tool which gives us control over the entire API lifecycle). I used Microsoft SQL server to make the database, which contains two tables - customer and car. The communication between the database and the API is achived with Entity Framework.

Q: Why use .NET?
A: .NET is a platform used fo developing high quality applications for any platform. It has a wide variety of tools, libraries, common APIs and it also supports multiple languages.

Q: Why use Entity Framwork (EF)?
A: Entity Framwork is actually anopen-source object-relational mapping(ORM) framwork for .NET applications witch allows for easier work with data without focusing on the tables and columns.

I also added a new "builder" in the Program.cs file so I can create the DataContext which takeс the information from the tables in the database. The customer controller is the one with which we interact using the CRUD operations and see the requested information.
