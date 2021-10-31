# README #

This README would normally document whatever steps are necessary to get your application up and running.

### What is this repository for? ###

* This repository is used for assessment purpose only.

### Prerequisite
* Visual Studio Code
* MySQL Server 8.0.22 or above
* Nodejs
* Angular 8

### Run REST Api ###
Follow the steps below to run REST Api
* Change ConnectionString in file api/appsettings.Development.json to your connection with MySql account which has permission to create schema
* cd api
* dotnet restore
* dotnet build
* dotnet ef database update
* dotnet run


### Install and run client ###

* cd Client
* npm install
* npm build
* npm start
