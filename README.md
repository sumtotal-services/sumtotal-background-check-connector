![Sumtotal](https://plsadaptive.s3.amazonaws.com/gmedia/jpg/_i_a6a0bc8dba67fd7c5a4a86c08c49ff20_sumtotal_logo.jpg)

# SumTotal External Provider Connector Service

## Introduction

This is a common platform to integrate various external service providers for Background Check service  into the SumTotal application.

This repository contains different branches : "master" branch (which is just having middleware) , "bgconnector-template" branch which contains the basic structure to implement bgcheck connector and "bgconnector-checkr-sample" branch which is actual implementation of backgroundcheck connector using Checkr vendor.

A detailed Connector Guidebook has been published under the "master" branch

## Getting Started

This project is built using ASP.NET CORE, WEBAPI and serilog

This solution provides basic template structure to integrate external providers into the SumTotal application which includes basic authentciation, vendor Configurations,handling callbacks and logging.

## Functionality

### BackgroundCheck Narrative Flow

Stuart Bailey is a recruiter. He wants to start a background check on a candidate as a part of the recruiting process. Before Stuart can initiate the background check, a system administrator needs to set up the connector and synchronize the available background check packages from the vendor.

Once synchronized, those packages will be available in the Checks Library. One or more of those packages will be assigned to the recruiting process and will be available for Stuart to initiate for a candidate when appropriate in the recruiting workflow. Stuart selects the package for the candidate, submits candidate details, and those details and the request is sent from the application, through the connector, to the background check vendor using B2B api callbacks.

Stuart can see the progress of the background check from the disposition candidate page, as well as the status of all checks related to a requisition on the Checks tab (under Check Tracking) of a requisition. Once a check is completed by the vendor, the basic results (Complete, Canceled, Expired, Failed, Started, Dispute or Suspended) is shared in the application. Stuart can also review the detailed results of the check included in the package directly in the vendor’s site.


### Connector Service Flow

There is a sync action to render packages from vendor through connector in Sumtotal connector configuration  page. when we click on sync action it will send a request from SumTotal application to connector service endpoint **(GetPackages)** and from there, connector will send request to the vendor and returns all the available packages.

Once the recruiter assigns required package to the selected candidate,It will send an initiate check request to the connector service endpoint **(InitiateCheck)** then it will create check order at vendor side and returns orderId.

Vendor will return status of the candidate check to the connector service through call back/webhook.Then that status will be return to sumtotal RestApi through  B2B call-back **(UpdateBackgroundCheck)** from connector.

## Prerequisites
1. Sumtotal Recruiting Module License
2. [Visual Studio](https://visualstudio.microsoft.com/vs/ "Visual Studio")

## SetUp Guide

1. OAuth Configuration 
  - Login in as an Admin
  - Administration > Common Objects > Configuration > OAuth Configuration
  - Click 'Add' to create a new OAuth Client
  - Enter desired Client ID
  - Enter secure Client Secret
  - Select desired scopes 
  - allapis (Access SumTotal Rest APIs)
  -  Add a redirect URL you wish to use (Used for 
  -  Submit
2. Connector Configuration
  - Login in as an Admin
  - Administration > Common Objects > Configuration > Connector Configuration
  - Click 'Add' to create a new  connector
  - Provide the required fields  such as Client secret and host URL etc.
  - The connector code can be hosted anywhere
  - Select the OAuth client which were created in the above  OAuth Configuration steps.
  - Save


## Code Structure

This framework contains different projects for middleware,external servcie contracts,model objects for mapping and for logging.

### master branch
This is the branch just contains basic middleware framework of the connector project.
### bgconnector-template branch
This is the base branch for custom type of background check, it includes all of master branch's stuff plus the custom background check contracts. Use this repo if you're building against a Vendor of type background check as this will get you up and running quicker.
### bgconnector-checkr-sample branch
This is the checkr branch for custom type background check. This branch helps you understrand what a custom connector would look like and how it would work; in this case we have a working example of checkr against custom type background check.
### SumTotal.Template.Connector.Middleware

This middleware project was built mainly to handle authentcation between Sumtotal application and connector service.Here we are using very basic HMAC authentication which is just using HMAC hashing mechanisam to encode cilent secret key while making request to the connector service.


#### HmacConnectHandler.cs

It is a single authentication middleware component, which is responsible for handling  authentication among connector services and Sumtotal application.

In Asp.net Core, authentication is configured via servces for that  we added a logic in startup.cs file while configuring services using addauthentication method.
So at the point of authorization, the app indicates the handler to be used. Select the handler with which the app will authorize by decorating methods with [Authorize] attribute.


#### HmacConnectOptions.cs

It just contains what are the claims we are using in authentication as properties in this class and AuthenticationScheme name ,here we named it as 'HmacConnect'.
 
#### HmacConnectExtension.cs

This is an extension method for AuthenticationBuilder to use our basic HmacConnect AuthenticationScheme for basic auth request.


### SumTotal.Template.Connector.Api

This Project is mainly to add contracts specific to the provider. It contains all business logic and requests to the vendor.

### Controllers/

#### BackGroundCheckController.cs

This is also WebAPI controller and very specific to background check provider.It contains all business calls and callbacks specific to background check.


### Filters/

#### SetSecurityHeaderAttribute.cs

This is very simple Asp.Net MVC filter.In this filter we are appending authentication header to the response of every request  whcih is coming from the application.

### Handlers/

#### SettingHandler.cs

This is a class which is used to to get and modify the settings for vendors.

#### DefaultMapper.cs

This is a Mapper class used to map the request and response object fields from connector to the vendor expected fields.

#### appsettings.json

First, ASP.NET Core settings file is called appsettings.json, instead of web.config.
App configuration in ASP.NET Core is based on key-value pairs established by configuration providers. Configuration providers read configuration data into key-value pairs.


#### Startup.cs

Global.asax is no more in ASP.NET Core application. Startup.cs file is a replacement of Global.asax file in ASP.NET Core.This method gets called by the runtime.
which is used to configure services for application ASP.net core has built-in support for Dependency Injection. We can add services to DI container using this method.

#### Program.cs

ASP.NET Core Program class file is a place where we can create a host for the web application and this is the entry point of application.

### SumTotal.Template.Connector.Models

### Models/

#### Settings.cs

This is the model class contains all the configurable setting keys which we used to connect application and external vendor key as properties 
such as outhsetting keys of vendor and connector clientid and secret keys etc.


### Logging Framework

##### Provide the file path to create the log file in appsettings.json --> Serilog --> WriteTo --> pathFormat

##### Provide the log levels to log in appsettings.json --> Serilog --> WriteTo --> restrictedToMinimumLevel 
1. Verbose : Verbose is the noisiest level, rarely (if ever) enabled for a production app.
2. Debug : Debug is used for internal system events that are not necessarily observable from the outside, but useful when determining how something happened.
3. Information : Information events describe things happening in the system that correspond to its responsibilities and functions. Generally these are the observable actions the system can perform.
4. Warning : When service is degraded, endangered, or may be behaving outside of its expected parameters, Warning level events are used.
5. Error : When functionality is unavailable or expectations broken, an Error event is used.
6. Fatal : The most critical level, Fatal events demand immediate attention.

### Logging steps :

1. Add  "Microsoft.Extensions.Logging" and "Serilog" reference to the class
2. Declare logger object in the class
3. Assign logger object value using dependency injection in the constructor
4. Log the logs whereever needed using that object : _logger.LogDebug("Test logger message")
Change the method name according to the log type/level you want to log e.g.: LogDebug, LogError etc.


