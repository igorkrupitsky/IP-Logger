# IP Logger

Originally posted here:
https://www.codeproject.com/Articles/33418/IP-Logger

## Introduction
My Internet service provider gives me a static IP number but constantly changes it. This makes it difficult to remotely access my home PC from work. This simple program is designed to solve the problem of keeping track of your changing IP number.

## Using the Code
This program consists of two components:

An ASP page (IpLogger.aspx) that logs your current IP into a SQL database. This page will also show your current IP. The page has to be deployed to a publicly accessible server. The code behind IpLogger.aspx.vb page has a function called GetConnectionString() that points to the database where the IP log information is stored. The database can be created using this file: Schema.sql.
A Windows script file. The script will access the ASP page periodically. It has to be scheduled with Windows Scheduler on your home PC. The script file uses the following URL to save the IP: http://<myservername>/MyServer/IpLogger.aspx?server=server1&save=1.
To view your current IP address and the history, please open this page in your browser: http://<myservername>/MyServer/IpLogger.aspx?server=server1.
