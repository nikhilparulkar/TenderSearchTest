# TenderSearchTest
This Code is for TenderSearch Coding Challenge.

This code provides RestFul WebAPIs for Tender Search coding Challenge. The code is built on
1) ASP.NET core 2.1
2) EF CORE
3) SQL Server 2017
4) VS 2017 
5) Swagger Document/UI using Nswag

It expose 5 endpoint. Build the the project in VS 2017 (with net core 2.1 installed) . Click debug and It will open 
url http://localhost:49887/api/values. Now type in browser http://localhost:49887/swagger/index.html

It will openthe Swagger UI with list of all the web API as follows:

GET : /AccessToken : To retrieve a JWT access token by sending username(Email) and Password.
GET : /tenders     : To retrieve all the tenders associated with login (username/email). 
                      Inputs : username as Query parameter
                      Headers :  Authrization : JWT
POST : /tenders/add  : To Add new tender associated with login (username/email). 
                      Inputs : JSON Object for creating new tender. Please refer the code.
                      Headers :  Authrization : JWT
PUT : /tenders/modify  : To modify a tender associated with login (username/email). 
                      Inputs : JSON Object of exisitng tender. Please refer the code.
                      Headers :  Authrization : JWT
Delete : /tenders/delete  : To remove a tender associated with login (username/email). 
                      Inputs : JSON Object for deleting a tender. Please refer the code.
                      Headers :  Authrization :JWT
                      
 PLease refer the DB script in folder DB Scripts to Create and Inserts some dummy data.
 
 Authenticationa and Authrizzation is through JWT token ,which validate for 2 claim expiry and username (email).
 
 DI using exisitng framework from .Net Core.
 
 
 
 
                

