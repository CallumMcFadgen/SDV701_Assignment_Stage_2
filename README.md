# SDV701 Assignment Stage 2
By Callum McFadgen

### Overview
This Github repo contains all of the resources required for my SDV701 Assignment Stage 2
<br />
<br />
This assignment was a multi-tier software development project using a fictional writing collective (The writers collective) as a use case for the 3 separate applications required. 
The 3 applications used the Client Server Model to share data and functionality, the different application types used were
<ul>
  <li>A .Net console application (Server)</li>
  <li>A .Net windows form application (Client)</li>
  <li>A Ionic/Angular Web application (Client)</li>
</ul>
<br />
The .Net console application provides an interface with a SQL Sever database, this interface is available to multiple Client applications and provides a range of REST APIs that can be accessed by Client application, to use a range of GET, POST, PUT and DELETE methods.
<br />
<br />
The .Net windows forms application provides a range of administration functions, allowing the user (the writers collective admin) to view authors, view, edit and delete books and view and delete orders.
<br />
<br />
The Angular application provides some simple customer functions, allowing the user (a member of the public) to view authors and their books and to create and dispatch orders for purchasing books.
<br />
<br />
All of these applications have been tested, demonstrated and have meet the assignment requirements.  They have been quite robust, with only one or two small bugs.

### Local installation
Some may be some additional configuration needed on a local device, such as connecting the selfhost to the database and giving the self-host permission to run from a local port.

If there are any issues use the following guidelines based on the Lab 3 documentation to trouble shoot the problem.
The SQL-Server database file twc_database.mdf in the database folder should have been extracted to your local device with the rest of the project folders, if not get a copy manually.

Open the project folder in Visual Studio and open the self host solution, open the Server Explorer Tab, right-click on Data Connections, select Add Connection.  Visual Studio may ask you to install missing packages, go through with the installation process, it will restart VS.

The data source should read Microsoft SQL Server Database File (SqlClient), change if necessary, then browse to the twc_database.mdf file, accept defaults and click OK.

The database should now be accessible from the Server Explorer.  Right-click on any of the tables and select Show Table Data to view the sample data in the database.

Before you can launch a service on your computer, you need to enable URL registration.  Run the Command Prompt as Administrator.  Type or paste the following line with the relevant computer and usernames to enable the selfhosts designated port.
 
```
netsh http add urlacl url=http://+:60064/ user=[computer-name\user-name]
```

Finally check in the App.config file that the file path for the AttachDbFilename in the connection strings matches the actual file path of the database file on the local device

```
<connectionStrings>
<add name="GalleryDatabase" providerName="System.Data.SqlClient"
connectionString="Data Source=(LocalDB)\MSSQLLocalDB;
AttachDbFilename=[Database filepath];
Database=GALLERY_DATA.MDF"/>
</connectionStrings>
```
