# MovieStore

A movies store project developed with C# and .Net Core Framework. In development phase, N-Layered Architecture model was followed.
You can perform basic CRUD operations with this program. Also, this program has JWT Bearer system. 

Migration was used.

# Layers

- **Business :** It is the business layer of our project. Various business rules; Data controls, validations and authorization controls
- **DataAccess :** It is the layer that connects the project with the Database.
- **Entities:** Our tables in the database have been created as objects in our project. It also contains DTO objects.
- **WebAPI :** It is the Restful API Layer of the project. Known methods: Get, Post, Put, Delete

# Used Technologies

- .Net Core 6.0
- Restful API
- Mapping
- Fluent Validation
- Logger
- JWT Authentication
- Repository Design Pattern
- Middleware
