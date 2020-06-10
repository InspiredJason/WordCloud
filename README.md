# WordCloud
A Word Cloud demo that generates a word cloud from a given website.

This application a .Net Core 3.1 MVC web app with a SQL Server backend. The app makes use of bootstrap for responsiveness, jQuery validation and follows the Domain Driven Design and CQRS patterns.

# Prerequisites
1. Visual Studio 2019
2. SQL Server LocalDb

# Running the Application
1. Clone or download the source files
2. Open the solution in Visual Studio 2019
3. Build (F5) 

# Publishing the Website
For deployment of the project using Github, follow these steps:
1. Set up your app service (this is a .net core app, so you can deploy to linux) and sql db in Azure
2. Go to the deployment center on your app service and configure to use Github to deploy (you will need to authenticate using your Github credentials)
3. The deployment should begin
