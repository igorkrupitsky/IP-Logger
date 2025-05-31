
CREATE DATABASE IpLogger
GO

USE IpLogger
GO

CREATE TABLE [dbo].[IpLog] (
	[LogId] [int] IDENTITY (1, 1) NOT NULL PRIMARY KEY  CLUSTERED,
	[IpAddress] [varchar] (50) NOT NULL ,
	[ServerName] [varchar] (50) NULL ,
	[AccessTime] [datetime] NOT NULL DEFAULT (getdate())
) ON [PRIMARY]
GO

