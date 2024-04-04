## CREATING C# API

To create a C# API, you need to have the following installed on your machine with vscode or any other code editor of your choice.

- .NET Core SDK

- Visual Studio Code

- C# for Visual Studio Code (powered by OmniSharp)

- C# Extension

- C# XML Documentation Comments


## Steps to create a C# API

1. Open Visual Studio Code and create a new folder for your project.

2. Open the terminal and navigate to the folder you created.

3. Run the following command to create a new web API project:

```bash
dotnet new webapi --use-controllers -o TodoApi
```

4. Navigate to the project folder:

```bash
cd TodoApi
```

5.  Add Https certificate to the project:

```bash
dotnet dev-certs https --trust
```

6. Run the project:

```bash
dotnet run
```

7. Open a browser and navigate to https://localhost:5001/WeatherForecast to see the default weather forecast.

8. To stop the project, press `Ctrl + C` in the terminal.

9. To add a new controller, run the following command:

```bash
dotnet aspnet-codegenerator controller -name TodoItemsController -async -api -m TodoItem -dc TodoContext -outDir Controllers
```

10. Run the project again:

```bash
dotnet run
```

11. Open a browser and navigate to https://localhost:5001/api/TodoItems to see the new controller.

12. To stop the project, press `Ctrl + C` in the terminal.

13. To publish the project, run the following command:

```bash
dotnet publish -c Release
```

14. To run the published project, navigate to the project folder and run the following command:

```bash
dotnet bin/Release/net5.0/publish/TodoApi.dll
```

15. Open a browser and navigate to https://localhost:5001/api/TodoItems to see the published project.

16. To stop the published project, press `Ctrl + C` in the terminal.

17. To deploy the project to Azure, run the following command:

```bash
az webapp up --sku F1 --name <app-name>
```

## HOW TO HOST A C# API ON AWS

To host a C# API on AWS.

1.  SSH into your EC2 instance with Ubuntu

2.  Install .NET Core SDK

```bash
sudo apt-get update

sudo apt-get install -y apt-transport-https

sudo apt-get install -y wget

wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb

sudo dpkg -i packages-microsoft-prod.deb

sudo apt-get update

sudo apt-get install -y dotnet-sdk-5.0
```

3.  Install Appache2

```bash
sudo apt-get install -y apache2
```

4.  Install MySQL

```bash
sudo apt-get install -y mysql-server
```

5.  Install PHP

```bash
sudo apt-get install -y php libapache2-mod-php php-mysql
```

6.  Install PHPMyAdmin

```bash
sudo apt-get install -y phpmyadmin
```

7.  Install Git

```bash
sudo apt-get install -y git
```

8.  Clone your project from GitHub

```bash
git clone <project-url>
```

9.  Publish your project

```bash
dotnet publish -c Release
```

10. Copy the published project to the Apache2 directory

```bash
sudo cp -r bin/Release/net5.0/publish/* /var/www/html
```

11. Restart Apache2

```bash
sudo systemctl restart apache2
```

12. Open a browser and navigate to http://<ec2-public-ip> to see the project.

13. To stop the project, press `Ctrl + C` in the terminal.









