# Library
# Instruction how to use this API
To open this project you can use Visual Studio.
You can clone this repository in Visual Studio.
To connect to you database you need to change Connection String property to yours in file app.config. You need change Data Source to yours.
Then run this Api in Visual Studio.
After running this Api you will see Swagger page. Using this page you can test this Api 
On this page you can see all controllers CRUD actions:
1) Get all books (Get)
2) Create new book (Post)
3) Get book by Id (Get)
4) Get book by ISBN (Get)
5) Edit book information (Put)
6) Delete book (Delete)
Also you can see some Users actions:
1) Create user (Post)
2) Get jbw token (Post)
3) Authorize 
4) Check authorization   
To execute action you need to chose action, press button Try it out then press button Execute.
After you will see server response.
Bellow all the actions you can see 2 schemas(models):
1) Book - this model have all fields from Book table in database.
2) BookDTO (Book Data Transfer Object) - same as the book model, but not have Id field to prevent the user from changing this field
(this model is used in Create and Put actions)
3) Person - this model have all fields from Person table in database.
4) PersonDTO (Person Data Transfer Object) - same as the person model, but not have Id field to prevent the user from changing this field  
5) IndexViewModel, PageViewModel - this models helps with pagination. IndexViewModel contains all books on the page and it contains PageViewModel
object that contains data about page(has previous/next page, pageNumber, total count of pages) 

