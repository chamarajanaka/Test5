USE [Registration]
GO
/****** Object:  Table [dbo].[tblRegistration]    Script Date: 04/11/2014 10:08:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRegistration](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[DOB] [date] NULL,
	[GPA] [float] NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_tblRegistration] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[spGetRegistration]    Script Date: 04/11/2014 10:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spGetRegistration]

AS
BEGIN

SELECT Name,DOB,GPA,Active
FROM tblRegistration

END
GO
/****** Object:  StoredProcedure [dbo].[spAddRegistration]    Script Date: 04/11/2014 10:08:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spAddRegistration]

@Active bit,
@DOB date,
@GPA float,
@Name nvarchar(200)

AS
BEGIN

INSERT INTO tblRegistration (Name,DOB,GPA,Active)
VALUES (@Name,@DOB,@GPA,@Active)

END
GO
