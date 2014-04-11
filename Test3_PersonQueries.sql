USE [PersonDB]
GO
/****** Object:  Table [dbo].[tblPerson]    Script Date: 04/10/2014 21:34:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPerson](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[FirstName] [nvarchar](200) NULL,
	[Gender] [nvarchar](10) NULL,
	[DOB] [date] NULL,
 CONSTRAINT [PK_tblPerson] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tblPerson] ON
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (1, N'Chamara', N'Janaka', N'Male', '1986-07-11')
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (2, N'Asanka', N'Bandara', N'Male', '1987-03-25')
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (3, N'Gihan', N'Madura', N'Male', '1990-10-15')
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (4, N'Menaka', N'Prashanthi', N'Female', '1967-11-11')
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (5, N'Nadini', N'Kumari', N'Female', '1995-04-03')
INSERT [dbo].[tblPerson] ([PersonID], [LastName], [FirstName], [Gender], [DOB]) VALUES (6, N'Sansa', N'Arya', N'Female', '2000-03-18')
SET IDENTITY_INSERT [dbo].[tblPerson] OFF

/****** Script for Select from SSMS  ******/
SELECT [PersonID]
      ,[LastName]
      ,[FirstName]
      ,[Gender]
      ,[DOB]
  FROM [PersonDB].[dbo].[tblPerson]
  WHERE Gender='Male' and DOB > '1987-02-25'
  
/****** Script for update records in SSMS  ******/
  
UPDATE [PersonDB].[dbo].[tblPerson]
   SET [LastName] = 'ChamaraCC'
      ,[FirstName] = 'JanakaJJ'
      ,[Gender] = 'Male'
      ,[DOB] = '1988-02-25'
 WHERE [PersonID] = 1
 
GO

UPDATE [PersonDB].[dbo].[tblPerson]
   SET [LastName] = 'AsankaAA'
      ,[FirstName] = 'BandaraBB'
      ,[Gender] = 'Male'
      ,[DOB] = '1988-12-23'
 WHERE [PersonID] = 2
