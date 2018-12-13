# Sitefinity add-on samples

This repository contains examples of Sitefinity add-ons. For more information on add-ons please go to the [official documentation](http://docs.sitefinity.com/sitefinity-cms-add-ons).

## How to install an add-on

1. Download the NuGet package (*.nupkg file)
2. Create a NuGet source [Documentation](https://docs.nuget.org/ndocs/hosting-packages/local-feeds) 
3. Install the NuGet package
4. Activate the Add-on.
   - Log in to Sitefinity backend
   - Go to "Administration" -> "Add-ons".
   - Click on the Add-on that you've added.
   - Click "Activate" (check the "Import sample content and pages" checkbox).
   
## Prerequisites

**Telerik.Sitefinity.All** NuGet package with version 9.2.6200 or higher must be installed on your project. If it is not installed, installing a NuGet package for one of the sample add-ons will install latest available version of Telerik.Sitefinity.All package.
 
 
## DevMagazine site

This sample add-on provides a starter kit template website. The DevMagazine site is an online magazine where you can read technical articles on IT topics. You can view the demo site on a variety of devices - desktop computers, tablets, and smartphones, as it is designed with using responsive web design methods. Each article on the site is associated to a certain issue that the article attempts to resolve. 

## OauthExternalAuthentication

OauthExternalAuthenticationAddon provides the OauthExternalAuthentication Sitefinity module which enables authentication via external login providers, such as Google, Facebook, Amazon and Twitter. After importing the add-on go to Administration -> Settings -> Advanced -> OAE and set api keys and api secrets for different providers. Then the sitefinity instance needs to be restarted.

## Conference

ConferenceAddon provides Conferences, Sessions and Speakers dynamic modules. It also adds a custom MVC widget for Sessions, which shows sessions filtered by conference and speaker.


## Setup a project used for producing an add-on

#### Requirements

 - Sitefinity license
 - .NET Framework 4
 - Visual Studio 2012
 - Microsoft SQL Server 2008R2 or later versions

#### Prerequisites

Clear the NuGet cache files. To do this:

1. In Windows Explorer, open the %localappdata%\NuGet\Cache folder.
2. Select all files and delete them.

You need to restore the database files to your SQL Server. To do this:

1. In SQL Server Management Studio, open the context menu of Databases and click Restore Database...
2. Select Device and click the browse button marked with three dots: [...] .
3. Click the Add button and navigate to SitefinityWebApp -> App_Data folder.
4. Select the *.bak file and click OK.
5. Click OK.

#### Installation instructions:

1. In Solution Explorer, navigate to SitefinityWebApp -> App_Data -> Sitefinity -> Configuration and select the DataConfig.config file.
2. Modify the connectionString value to match your server address.
3. Build the solution.

#### Login
To login to Sitefinity backend, use the following credentials:

**Username:** admin
**Password:** password
