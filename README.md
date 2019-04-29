# TenderSearchTest
This Code is for TenderSearch Coding Challenge.

This code provides RestFul WebAPIs for Tender Search coding Challenge. The code is built on
1) ASP.NET core 2.1
2) EF CORE
3) SQL Server 2017
4) VS 2017 

It expose 5 endpoint 

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
 
 
 
 
                

