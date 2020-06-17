# SDV701 Assignment Stage 2
By Callum McFadgen

### Overview
This Github repo contains all of the resources required for my SDV701 Assignment Stage 2
<br />
<br />
This assignment was a multi-tier software development project using a fictional writing collective (The writers collective) as a use case for the 3 separate applications required. 
The 3 applications used the Client Server Model to share data and functionality, the different application types used were
<ul>
  <li>A .Net console application providing REST API Routes (Server)</li>
  <li>A .Net windows form application (Client)</li>
  <li>A Ionic/Angular Web application (Client)</li>
</ul>
<br />
### Features
The .Net console application provides an interface with a SQL Sever database, this interface is available to multiple Client applications and provides a range of REST APIs that can be accessed, covering a the full range of GET, POST, PUT and DELETE methods.
<br />
The database is a small .mdf file containing a relational database with 3 tables (Author, Book and Book_Order) to support the assignment requirements, This data base is included in this repo in the database folder, including a copy of the create and insert SQL queries used to build and populate the database for development and testing.
