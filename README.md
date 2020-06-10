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

# Source Control
You can use Github as your source control repository, then follow the steps below for deploying using Github.

# Deploying the Website
For deployment of the project using Github, follow these steps:
1. Set up your app service (this is a .net core app, so you can deploy to linux) and sql db in Azure
2. Remember to set your firewall rule to allow Azure Apps to access your sql db
3. Go to the deployment center on your app service and configure the deployment to use Github to deploy (you will need to authenticate using your Github credentials)
4. This creates an action in Github and a deployment should begin
5. Subsequent checkins should kick of further deployments
