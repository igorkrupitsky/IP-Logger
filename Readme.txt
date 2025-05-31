My Internet service provider gives me static IP number but constantly changes it.  
This makes it difficult to remotely access my home PC from work. This simple program 
is designed to solve the problem of keeping track of your changing IP number.  

This program consists of two components: 

1) An asp page (default.aspx) that logs your current IP into a SQL database.  
This page will also show your current IP.  The page has to be deployed to a publically accessible server.   
The codebehind IpLogger.aspx.vb page has a function called GetConnectionString() that  points to 
the database where the IP log information is stored. 
The database can be created using this file: Schema.sql

2) A windows script file.  The script will access the asp page periodically.  
It has to be scheduled with Windows Scheduler on your home PC. 
The script file is using this URL to save the IP:

http://<MyServerName>/IpLogger/Default.aspx?server=server1&save=1

To view your current IP address and the history, please open this page in your browser: 
http://<MyServerName>/IpLogger/Default.aspx?server=server1
