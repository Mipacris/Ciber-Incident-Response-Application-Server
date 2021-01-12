# Ciberperseu Incident Response Application/Server

## Table of Contents
* [General info](#general-info)
* [Technologies](#technologies)
* [Setup](#setup)
* [Things to be done](#things-to-be-done)

## General info
An incident response application and server for the event Ciberperseu! 

This application was created to help organization team's to easily manage the received incidents and further forward those incidents notifications to the incident response team. 

The application has a number of functionalities that makes it accessible and easy to use in a incident management and response scenario!

**Currently the application is in Portuguese only... In future updates there should be more language options...**
	
## Technologies
This Project is created with:
* C#
* Visual Studio 2019

Requirements:
* Windows OS
* Microsoft Outlook

	
## Setup

1. You can either use the project folder in Visual Studio 2019, compile it and run it or you can use the already compiled solutions in the project folder (the executable format).

2. You need to copy the **ciberperseu_cert.pfx** digital certificate to the Server **(C:/)** directory. In real use case, you should use your own organization digital certificate for security purposes.

3. You can open both server and the application and login as:

  Username: admin	 
  
  Password: admin
  
**Security Warning!** - This should be changed after inside the Admin Config by creating a new admin user and by deleting this default account.

## Things to be done

Primary:
* Configurations option - Where it is possible to choose the window size and the language

Secondary:
* The possibility to add multiple missons to one user;
* Administrator can remove missions from the board;
* Resize of reading window (outlook emails);
* Instead of sending emails, the possibility to forward emails instead (forward should contain the maximum number of peoples (group));
* Click button **Enter** to send a message in chat.
