Homework Version 1.0.0 4/26/2017

General
---------
 Homework is a web-based application that helps user administration.


Programming Language and Framework
----------------------------------
 1. Miacrosoft Visual Studio Express for Web
 2. MVC and Web API
 3. C#, Java scripts, HTML5, CSS3, JQuery, Jquery UI


Installation and Excutation
---------------------------
 1. Create database by excuting file homwork.sql
 2. Unzip the zipped file
 3. Load the solution into Visual Studio 
 4. Build the solution
 5. Get localhost port by starting the solution and it will be in web address as localhost:xxxx
 6. Stop the application and Open file UserController.cs in folder Controllers
 7. Replace all occurences of port number 56441 by port number found in step 5
 8. Build the solution again and start it. The Broswer will load the page.


Database Connection
-------------------
 You don't need to make any change to database connetion. But in case you need to connect to another dasebase you can change it.
 1. Open file Web.config
 2. Locate <connectionStrings> and change data source (serve name) and catalog (database name)

Usage Notes
-----------
 1. The first page will show all users.
 2. Sort users by clicking table column name
 3. Search users by typing partial or entire name and clicking button Filter
 4. Click "Create User" to add a new user
 5. In dialog type user info and click button Save
 6. All fields are required. Wraning will show up if
	a. any fields are empty
        b. wrong email format
        c. duplicate userID
 7. Click button Cancel may give up and go back to home page

=============================================================================================================

Contact IT Support
------------------
Phone: (XXX)XXX-XXXX
Email: xxx@dnn.com
Web: www.xxx.com


Copyright
---------
Copyright © 2017 by DNN Corp.  All Rights Reserved.
This code released under the terms of the DNN Public License (MS-PL, http://opensource.org/licenses/dnn.html.)
