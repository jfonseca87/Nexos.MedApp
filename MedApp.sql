USE [MedDB]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 15/06/2020 21:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[Name] [nvarchar](max) NOT NULL,
	[HospitalName] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NOT NULL,
	[DoctorId] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
	[CredentialNumber] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientDoctors]    Script Date: 15/06/2020 21:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientDoctors](
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_PatientDoctors] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC,
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 15/06/2020 21:18:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientId] [int] IDENTITY(1,1) NOT NULL,
	[SocialSecurityNumber] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[UpdateDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Doctors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreationDate]
GO
ALTER TABLE [dbo].[Doctors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [dbo].[Doctors] ADD  DEFAULT (N'') FOR [CredentialNumber]
GO
ALTER TABLE [dbo].[PatientDoctors] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreationDate]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [CreationDate]
GO
ALTER TABLE [dbo].[Patients] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [UpdateDate]
GO
ALTER TABLE [dbo].[PatientDoctors]  WITH CHECK ADD  CONSTRAINT [FK_PatientDoctors_Doctors_DoctorId] FOREIGN KEY([DoctorId])
REFERENCES [dbo].[Doctors] ([DoctorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientDoctors] CHECK CONSTRAINT [FK_PatientDoctors_Doctors_DoctorId]
GO
ALTER TABLE [dbo].[PatientDoctors]  WITH CHECK ADD  CONSTRAINT [FK_PatientDoctors_Patients_PatientId] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([PatientId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PatientDoctors] CHECK CONSTRAINT [FK_PatientDoctors_Patients_PatientId]
GO
