# CLDV6211 POE Part 2 Lisha Naidoo ST10404816

## Table of Contents
- Description
- Navigation
- Controllers
- Models
- Views
- References
- List of Figures

## Description
This is an e-commerce website to act as an online store for KhumaloCraft Emporium started by James Khumalo. This will help him meet market demands, reach users around the world, and provide a seamless user experience. Through this website cloud computing is utilized to offer scalability, accessibility, and resources to meet KhumaloCraft Emporium’s digital needs (Kingsnorth, 2019).  
### Product
KhumaloCraft Emporium sells different types of handcrafted dishes. The categories include bowls, plates, cups and pots.

## Navigation
### Navigation Bar
Once entering the website, the user in introduced to the navigationbar that includes links for Products, About Us, Contact Us and Profile. If the user clicks on the logo image, they will be directed to the landing page (Mrzyglod, 2022).

## *Links*
+ **Products** : Here the user can view all products at KhumaloCraft Emporium and place an order on a product. A user will have to sign in or login to be able to pirchase products. (Mrzyglod, 2022).
+ **About Us** : Here the user will be presented with information about KhumaloCraft Emporium. (Mrzyglod, 2022).
+ **Contact Us** : Here the user will be presented with contact information. (Mrzyglod, 2022).
+ **Profile** : This is the users profile page and from here they can sign up or login. Once the user logs in, if they are a customer, they will be able to view order history. If they are an employee, they will be able to view all transactions made by all users as well as add new products or employees to the website. (Mrzyglod, 2022).

## Controllers
### [LoginController](Controllers/LoginController.cs)
+ **ActionResult Privacy(string email, string password)** : Function to log user in. (Mrzyglod, 2022).
+ **Error Message** : Displays error message. (David, S. 2023).

## Models
### [userTable](Models/userTable.cs)
+ **insert_User(userTable m)** : Inserts data into the userTable. (Mrzyglod, 2022).
### [transactionTable](Models/transactionTable.cs)
+ **insert_transaction(transactionTable p)** : Inserts data into the transactionTable. (Mrzyglod, 2022).
+ **List<transactionTable> GetAllTransactions()** : Retrieves data from transactionTable. (Mrzyglod, 2022).
### [productTableTable](Models/transactionTable.cs)
+ **insert_product(productTable p)** : Inserts data into productTable. (Mrzyglod, 2022).
+ **List<productTable> GetAllProducts()** : Retrieves data from productTable. (Mrzyglod, 2022).
### [ProductDisplayModel](Models/ProductDisplayModel.cs)
+ **List<ProductDisplayModel> SelectProducts()** : Displays products. (Mrzyglod, 2022).
### [TransactionDisplayModel](Models/TransactionDisplayModel.cs)
+ **List<TransactionDisplayModel> SelectTransaction()** : Displays transactions. (Mrzyglod, 2022).
### [LoginModel](Models/LoginModel.cs)  
+ **SelectUser(string email, string password)** : Log in user. (Mrzyglod, 2022).
  
## Views  

### [Layout](Views/Shared/_Layout.cshtml)
*Style*
+ **.navbar-nav a** : Navigation bar font, size and color. (see Bootstrap Navbar - Tutorial on the latest Bootstrap 5, 2021).
+ **.navbar-nav a:hover** : Increase navigation links size as cursor hovers over them. (see Bootstrap Navbar - Tutorial on the latest Bootstrap 5, 2021).
+ **.navbar-collapse** : Places links in naviagation at far right. (see Bootstrap Navbar - Tutorial on the latest Bootstrap 5, 2021).
+ **ul{} / ul li{} / ul li:not{}** : Displays lines between navigation links. (Stackoverflow, 2018).
+ **.logo-hover-state{} / .site-logo:hover .logo-regular-state{} / .site-logo:hover .logo-hover-state{}** : Changes navigation logo if user hovers over link. (GeneratePress, 2024).
+ *Body*
+ Navigation Bar Code. (Mrzyglod, 2022).

### [Products](Views/Home/Index.cshtml)
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.custom-image-size** : Image format. (W3Schools, 2024).
+ *Body*
+ Product card. (Bootsrap, 2024).
+ Product Images Script. (Bootsrap, 2024).
+ Images. (Flaticon, 2024).

### [About Us](Views/Home/AboutUs.cshtml) 
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.custom-image-size** : Image format. (W3Schools, 2024).
+ *Body*
+ Content. (W3Schools, 2024).
+ Images. (Flaticon, 2024).

### [Contact Us](Views/Home/ContactUs.cshtml) 
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.custom-image-size** : Image format. (W3Schools, 2024).
+ *Body*
+ Content. (W3Schools, 2024).
+ Images. (Flaticon, 2024).

### [Profile](Views/User/Profile.cshtml) 
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.container** : Background image format. (W3Schools, 2024).
+ **.button** : Button format. (W3Schools, 2024).
+ **.button:hover** : Button hover style. (W3Schools, 2024).
+ *Body*
+ Function to display page based on userType. (Mrzyglod, 2022).
+ Image: (De Clercq, 2024).

### [Log In](Views/Home/Privacy.cshtml) 
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.button** : Button format. (W3Schools, 2024).
+ **.button:hover** : Button hover style. (W3Schools, 2024).
+ *Body*
+ Takes in Name and Password and returns user to interface.

### [Sign Up](Views/User/About.cshtml) 
*Style*
+ **.parisienne-regular** : Heading font. (Googlefonts, 2024).
+ **h2, h3, p** : Content format. (W3Schools, 2024).
+ **.button** : Button format. (W3Schools, 2024).
+ **.button:hover** : Button hover style. (W3Schools, 2024).

## References
- Bootstrap. 2024. Card, 2024. [Online]. Available at: https://getbootstrap.com/docs/4.0/components/card/ [Accessed 23 May 2024].
- Bootstrap Navbar - Tutorial on the latest Bootstrap 5. 8 April 2021. YouTube video, added by Keep coding. [Online]. Available at: https://www.youtube.com/watch?v=G3tZUO2fAEU [Accessed 22 May 2024].
- David, S. 2023. Gamesino Technical Manual Final 4th Year Project, 17 April 2023. [Online]. Available at: https://showcase.itcarlow.ie/C00250105/TechinalManual.pdf [Accessed 22 May 2024].
- De Clercq, E. 2024. Espresso Cups, Artists and Objects, 2024. [Online]. Available at: https://artistsandobjects.com/product/espresso-cups/ [Accessed 25 May 2024].
- Drupal. 2024. README.md template, 13 March 2024. [Online]. Available at: https://www.drupal.org/docs/develop/managing-a-drupalorg-theme-module-or-distribution-project/documenting-your-project/readmemd-template [Accessed 22 May 2024].
- Flaticon.com. 2024. Icons, 2024. [Online]. Available at: https://www.flaticon.com/ [Accessed 20 May 2024].
- GeneratePress. 2024. Logo Hover, 5 March 2015. [Online]. Available at: https://generatepress.com/forums/topic/logo-hover/ [Accessed 22 May 2024].
- Github, 2024. Add Structured details to SqlException, 9 November 2017. [Online]. Available at: https://github.com/dotnet/efcore/issues/10248 [Accessed 25 May 2024].
- Googlefonts. 2024. Parisienne, 2024. [Online]. Available at: https://fonts.google.com/specimen/Parisienne/about [Accessed 22 May 2024].
- Istock.com. 2024. Photos, 2024. [Online]. Available at: https://www.istockphoto.com [Accessed 20 May 2024].
- Kingsnorth, S. 2019. Digital Marketing Strategy: An Integrated Approach to Online Marketing. London: Kogan Page Publishers.
- Mrzyglod, K. 2022. Azure for Developers - Second Edition: Implement rich Azure PaaS ecosystems using containers, serverless services, and storage solutions. 2nd ed. Birmingham: Packt.
- Stackoverflow. 1 December 2018. How do I include short vertical lines in between links in navbar? [Source code]. https://stackoverflow.com/questions/53567706/how-do-i-include-short-vertical-lines-in-between-links-in-navbar (Accessed 23 May 2024).
- W3Schools. 2024. W3.CSS Layout, 2024. [Online]. Available at: https://www.w3schools.com/w3css/w3css_layout.asp [Accessed 23 May 2024].

## List of Figures
- [Image1](wwwroot/Images/image1.jpeg)(Istock.com, 2024).
- [Image2](wwwroot/Images/image2.jpeg)(Istock.com, 2024).
- [Image3](wwwroot/Images/image3.jpeg)(Istock.com, 2024).
- [cell](wwwroot/Images/cell.png)(Flaticon.com, 2024).
- [clock](wwwroot/Images/clock.png)(Flaticon.com, 2024).
- [email](wwwroot/Images/email.png)(Flaticon.com, 2024).
- [landline](wwwroot/Images/landline.png)(Flaticon.com, 2024).
- [Location](wwwroot/Images/Location.png)(Flaticon.com, 2024).
- [Bowl](wwwroot/Images/Bowl.png)(Flaticon.com, 2024).
- [Cup](wwwroot/Images/Cup.png)(Flaticon.com, 2024).
- [Plate](wwwroot/Images/Plate.png)(Flaticon.com, 2024).
- [Pot](wwwroot/Images/Pot.png)(Flaticon.com, 2024).
- [Other](wwwroot/Images/Other.png)(Flaticon.com, 2024).

Ceramics, K. 2024. Handmade ceramic plates | Kari Ceramics. [Online]. Available at: https://za.pinterest.com/pin/889742470118421085/ [Accessed 23 May 2024].


