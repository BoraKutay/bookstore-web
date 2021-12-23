# Bookstore .NET Core 

## Entities

- Product based MusicCD, Magazine and Book also new type of product can be added.
- Customer based for future (editor, admin, saler) can be added.
- These entities data transfer objects such ass (add,list update) in implemented in Bookstore.Web.Entities.Dtos.

![image](https://user-images.githubusercontent.com/27950192/147232870-041382d6-ab3d-48e7-807d-14ac26b2059f.png)
![image](https://user-images.githubusercontent.com/27950192/147232902-0dac7592-d21a-4341-9367-e3b506537c0c.png)
![image](https://user-images.githubusercontent.com/27950192/147232983-54d99c3c-8479-4062-9768-75c34813100e.png)

## Data
First, their interfaces were defined, then their implementations were made.  
![image](https://user-images.githubusercontent.com/27950192/147233734-5ed1f2f5-87e5-4f27-b5c4-e572bca98f7c.png)

![image](https://user-images.githubusercontent.com/27950192/147233802-1bc28d12-3d81-4a5f-90f2-9466a66b1fb4.png)

For mapping data EFCore.Metadata.Builders are used.  
![image](https://user-images.githubusercontent.com/27950192/147233301-c43c7ad5-6812-460b-bc8e-fed325830996.png)

In Data layer UoW and Repository pattern were used. 

Connection string defined in BookstoreWebContext class which is inherited EFCore.DbContext.


![image](https://user-images.githubusercontent.com/27950192/147232141-8a1e3e1d-9d76-4fcb-9a4a-e8f4ed1d52d0.png)

##Service

![image](https://user-images.githubusercontent.com/27950192/147233992-525b60b0-2864-4b4e-aae2-a7aa9bde4b55.png)
