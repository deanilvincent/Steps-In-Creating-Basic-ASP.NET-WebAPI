# Steps in Creating Basic ASP.NET Web Service API

This basic steps will teach you how to create and implement basic Asp.net Web Service API.

What is Web APIs(Application Programming Interface) means?

![capture1](https://cloud.githubusercontent.com/assets/10904957/23101928/23bc84c8-f6da-11e6-9a36-25509c0146b4.PNG)

Readmore: https://en.wikipedia.org/wiki/Application_programming_interface

Since our focus is the .Net Framework, we will use ASP.NET Web API implementation. 

What is ASP.NET Web API?

![capture2](https://cloud.githubusercontent.com/assets/10904957/23101965/0b4f4348-f6db-11e6-9b9c-96f85d34d20a.PNG)

To get started on ASP.NET web api, read more here: https://www.asp.net/web-api

Note: This steps are based on the way how I create ASP.NET Web API using Visual Studio. You can use whatever steps that you want but make sure it will end up the same outputs.

### Step 1.0 - Creating the project

1.1 Open the Visual Studio

1.2 File -> Project (Ctrl+Shift+N)

1.3 When the dialog box open, choose Templates -> Visual C# -> Web. We name our project as "MyWebAPI"
![capture3](https://cloud.githubusercontent.com/assets/10904957/23102044/ae5d64b0-f6dc-11e6-9c0f-b97c07fac23a.PNG)

1.4 Another dialog box will appear and just choose Web API
![capture4](https://cloud.githubusercontent.com/assets/10904957/23102065/25fe559c-f6dd-11e6-95b0-a19b62483297.PNG)

1.5 Welcome page will appear
![capture5](https://cloud.githubusercontent.com/assets/10904957/23102104/cec6ed10-f6dd-11e6-9b94-6fb8f7529c29.PNG)

### Step 2.0 - Updating our Web.config for DB connection

2.1 Open the Solution Explorer and locate the Web.config file 

![capture6](https://cloud.githubusercontent.com/assets/10904957/23102140/870d6732-f6de-11e6-9745-f8b99e6ed3be.PNG)

Like in basic ASP.NET web app, the connection snippet is the same with ASP.NET Web API.

2.2 Put connection string
```html
<connectionStrings>
  <add name="MySampDBContext" connectionString="Data source=YOUR_DB_CONNECTION;Initial Catalog=YOUR_DB_NAME; Integrated Security=True" providerName="System.Data.SqlClient"/>
</connectionStrings>
```

### Step 3.0 - Creating your class model

3.1 Right click the Model folder, choose Add and choose "Class..." In this example, we name our model class as "UserDetailCredentials"
![capture7](https://cloud.githubusercontent.com/assets/10904957/23102221/4e3b296a-f6e0-11e6-86e0-c72f5d4203ec.PNG)

3.2 Adding property inside the class
```C#
public class UserDetailCredentials
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}
```
3.3 Rebuild the solution (Ctrl+Shift+B)

### Step 4.0 - Creating your MVC & API Controllers
In this tutorial, since we want to track what are the details that will appear on our API, let us use the MVC Controller with views, using Entity Framework. Let this serve us our UI to make this easier.

#### Creating MVC Controller with views, using Entity Framework
4.1 Right click the Controllers folder, choose Add and Choose "Controller..."

4.2 Dialog controller will open, choose the MVC 5 Controller with views, using Entity Framework.
![capture8](https://cloud.githubusercontent.com/assets/10904957/23102404/6e19d292-f6e3-11e6-8afa-7dbdb8a48fcc.PNG)

4.3 Adding Controller. Choose your model, Check the "Use async controller actions" and the Data Context Class("name" that we included in the connection string). Click Add

![capture10](https://cloud.githubusercontent.com/assets/10904957/23102444/3c7da08c-f6e4-11e6-9a49-9eb59c603f1f.PNG)

Now we have our MVC controller and our UI pages, we can now create our API controller.

![capture11](https://cloud.githubusercontent.com/assets/10904957/23102468/acb36a76-f6e4-11e6-906f-78d9ba068f0c.PNG)

![capture12](https://cloud.githubusercontent.com/assets/10904957/23102469/acb8686e-f6e4-11e6-8e7c-164942265fde.PNG)

4.5 Rebuild the solution.

#### Creating API Controller
4.6 Right click the Controllers folder, choose Add and Choose "Controller..."

4.7 Dialog controller will open, choose the Web API 2 Controller with actions, using Entity Framework.
![capture9](https://cloud.githubusercontent.com/assets/10904957/23102524/c5047bd2-f6e5-11e6-8a99-c64bb6671a3d.PNG)

4.8 Adding Controller. Choose your model, Check the "Use async controller actions" and the Data Context Class("name" that we included in the connection string) and we name our api controller as "UserDetailCredentialsAPIController". Click Add

![capture13](https://cloud.githubusercontent.com/assets/10904957/23102554/091da49c-f6e6-11e6-96d3-c3c67f461d49.PNG)

Now we have controller class with actions for our api.

![capture14](https://cloud.githubusercontent.com/assets/10904957/23102577/9c0ed0fa-f6e6-11e6-92a7-f67ad0c2250b.PNG)

Here's the summary of the default api contorller that we created.

![capture16](https://cloud.githubusercontent.com/assets/10904957/23102640/e52e594e-f6e7-11e6-9e38-e0058ee7e562.PNG)

#### 5.0 Enabling Migrations and updating the database
Now we already prepared everything, it's time to enable migrations and update the database.

5.1 Open Package Manager Console 

5.2 Type in "Enable-Migrations" (without quotes) and click Enter

![capture17](https://cloud.githubusercontent.com/assets/10904957/23102707/3356440a-f6e9-11e6-99c7-675d0d5271f4.PNG)

5.3 Adding migration by typing in "Add-Migration (YourMigrationName)" (without quotes) and press Enter

![capture18](https://cloud.githubusercontent.com/assets/10904957/23102730/aead53d2-f6e9-11e6-8abb-d44ff364f37d.PNG)

The preview of your migration will appear. When you are done inspecting, you can now proceed to update the database.

5.4 Updating the database by simply typing "update-database" and press the Enter

![capture19](https://cloud.githubusercontent.com/assets/10904957/23102761/30e2fa8c-f6ea-11e6-8590-69a9159da83b.PNG)


#### 6.0 Running the whole project

6.1 Build and Start running the project.

#### Add sample details

6.2 Create a new set of details

![capture20](https://cloud.githubusercontent.com/assets/10904957/23102817/02e98b9a-f6eb-11e6-9475-42fc4afaa723.PNG)

#### Accessing the api page
Now we have set of details, let's us now view our custom API page.

In order to access the api, by default, you need to set the uri to api follow by your api controller name

````html
 http://yourhost/api/yourapicontrollername
```
6.3 Go the api link

#### JSON Format using Microsoft Edge

![capture21](https://cloud.githubusercontent.com/assets/10904957/23102872/372b7cc8-f6ec-11e6-98a3-84afd02351ee.PNG)

#### XML Format using Google Chrome

![capture22](https://cloud.githubusercontent.com/assets/10904957/23102886/6774d992-f6ec-11e6-95d9-165034e05736.PNG)

We can see see all the details because we are accessing the index get request of our api.
