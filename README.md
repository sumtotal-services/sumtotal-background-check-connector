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

Stuart can see the progress of the background check from the disposition candidate page, as well as the status of all checks related to a requisition on the Checks tab of a requisition. Once a check is completed by the vendor, the basic results (Complete, Canceled, Expired, Failed, Started, Dispute or Suspended) is shared in the application. Stuart can also review the detailed results of the check included in the package directly in the vendor’s site.


### Connector Service Flow

There is a sync action in the UI to call packages from the vendor through the connector and into the Sumtotal connector configuration page. 

When you click on the sync action it will send a request from the SumTotal application to the connector service endpoint **(GetPackages)** and then the connector will send a request to the vendor. This returns all the available packages.

Once the recruiter assigns a required package to the selected candidate, the SumTotal Application will send an initiate check request to the connector service endpoint **(InitiateCheck)** which then creates a check order at the vendor side and returns an orderId.

When the check is completed, the vendor returns the status of the candidate check to the connector service through call back/webhook; then that status will be returned to the SumTotal Application through B2B call-back **(UpdateBackgroundCheck)** from the connector.


## Prerequisites
1. Sumtotal Recruiting Module License
2. [Visual Studio](https://visualstudio.microsoft.com/vs/ "Visual Studio")

## SetUp Guide

1. OAuth Configuration 
  - Login in as an Admin
  - Click on Administration in the header menu.
  - Navigate to Common Objects > Configuration > OAuth Configuration
  - Click 'Add' to create a new OAuth Client
  - Enter desired Client ID
  - Enter secure Client Secret
  - Select desired scopes: allapis (Access SumTotal Rest APIs)
  - Click Submit

2. Connector Configuration
  - Login in as an Admin
  - Click on Administration in the header menu.
  - Administration > Common Objects > Configuration > Connector Configuration
  - Click 'Add' to create a new connector
  - Provide the required fields, such as Client secret and host URL etc
  - Select the OAuth client you configured above in the OAuth Configuration section.
  - Click Save



## Code Structure

This framework contains different projects for middleware,external servcie contracts,model objects for mapping and for logging.

### master branch
This is the branch just contains basic middleware framework of the connector project.

### bgconnector-template branch
This is the base branch for custom type of background check, it includes all of master branch's stuff plus the custom background check contracts. Use this repo if you're building against a Vendor of type background check as this will get you up and running quicker.

### bgconnector-checkr-sample branch
This is the checkr branch for custom type background check. This branch helps you understrand what a custom connector would look like and how it would work; in this case we have a working example of checkr against custom type background check.

### SumTotal.Template.Connector.Middleware

This middleware project was built mainly to handle authentication between the SumTotal Application and connector service. We are using a basic HMAC authentication (which is just using HMAC hashing mechanism to encode the client secret key while making a request to the connector service.)

#### HmacConnectHandler.cs

A single authentication middleware component, which is responsible for handling authentication among connector services and the Sumtotal Application.

In Asp.net Core, authentication is configured via services that we added logic for in the startup.cs file while configuring services using the addauthentication method.

At the point of authorization, the app indicates the handler to be used. Select the handler with which the app will authorize by decorating methods with [Authorize] attribute.

#### HmacConnectOptions.cs

Contains the claims we are using in authentication as properties in this class and AuthenticationScheme name - here we named it 'HmacConnect'.

#### HmacConnectExtension.cs

An extension method for AuthenticationBuilder to use our basic HmacConnect AuthenticationScheme for basic authentication request.

### SumTotal.Template.Connector.Api

Adds contracts specific to the provider; contains all business logic and requests to the vendor.

### Controllers/

#### BackGroundCheckController.cs

This is the WebAPI controller and is very specific to the background check provider. It contains all business calls and callbacks specific to background checks.

### Filters/

#### SetSecurityHeaderAttribute.cs

A very simple Asp.Net MVC filter. In this filter, an authentication header will be appended to the response of every request coming from the application.

### Handlers/

#### SettingHandler.cs

This class will be used to get and modify the settings for vendors.

#### DefaultMapper.cs

A Mapper class used to map the request and response object fields from the connector to the vendor’s expected fields.

#### appsettings.json

ASP.NET Core’s settings file is called appsettings.json, instead of web.config. App configuration in ASP.NET Core is based on key-value pairs established by configuration providers. Configuration providers read configuration data into key-value pairs.

#### Startup.cs

This method gets called by the runtime, which is used to add services to DI container and to configure the HTTP request pipeline (such as routing).

#### Program.cs

ASP.NET Core Program class file is where you can create a host for the web application, this is the entry point of application.

### SumTotal.Template.Connector.Models

### Models/

#### Settings.cs

The model class that contains all the configurable setting keys used to connect application and external vendor key as properties, such as OAuthsetting keys of vendor and connector clientid and secret keys, etc.

### Logging Framework

##### Provide the file path to create the log file in appsettings.json --> Serilog --> WriteTo --> pathFormat

##### Provide the log levels to log in appsettings.json --> Serilog --> WriteTo --> restrictedToMinimumLevel 
1. Verbose: Verbose is the noisiest level, rarely (if ever) enabled for a production app.
2. Debug: Debug is used for internal system events that are not necessarily observable from the outside, but useful when determining how something happened.
3. Information: Information events describe things happening in the system that correspond to its responsibilities and functions. Generally, these are the observable actions the system can perform.
4. Warning: When service is degraded, endangered, or otherwise behaving outside of its expected parameters, warning level events are produced.
5. Error: When functionality is unavailable or expectations broken, an error event is produced.
6. Fatal: The most critical level; fatal events demand immediate attention.

### Logging steps:

1. Add "Microsoft.Extensions.Logging" and "Serilog" reference to the class
2. Declare logger object in the class
3. Assign logger object value using dependency injection in the constructor
4. Log the logs whereever needed using that object : _logger.LogDebug("Test logger message")
Change the method name according to the log type/level you want to log e.g.: LogDebug, LogError etc.



