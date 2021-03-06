USE [master]
GO
/****** Object:  Database [GicDb]    Script Date: 3/19/2019 5:47:09 PM ******/
CREATE DATABASE [GicDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GicDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GicDb.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'GicDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\GicDb_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [GicDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GicDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GicDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GicDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GicDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GicDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GicDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [GicDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GicDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GicDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GicDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GicDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GicDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GicDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GicDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GicDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GicDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [GicDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GicDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GicDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GicDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GicDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GicDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GicDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GicDb] SET RECOVERY FULL 
GO
ALTER DATABASE [GicDb] SET  MULTI_USER 
GO
ALTER DATABASE [GicDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GicDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GicDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GicDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GicDb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'GicDb', N'ON'
GO
USE [GicDb]
GO
/****** Object:  Table [dbo].[Achievements]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Achievements](
	[AchievementGuid] [uniqueidentifier] NOT NULL,
	[AchievementIntId] [bigint] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[EmployeeName] [varchar](150) NOT NULL,
	[Comment] [varchar](1000) NOT NULL,
	[Imagedata] [varbinary](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[AchievementIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdminPolicies]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminPolicies](
	[AdminPoliciesGuid] [uniqueidentifier] NOT NULL,
	[AdminPoliciesIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[AdminPoliciesName] [nvarchar](500) NULL,
	[AdminPoliciesDetails] [varchar](5000) NULL,
	[LastModifiedDate] [datetime] NULL,
	[PoliciesFullDetails] [varchar](max) NULL,
 CONSTRAINT [PK_AdminPolicies] PRIMARY KEY CLUSTERED 
(
	[AdminPoliciesIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Announcements]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Announcements](
	[AnnouncementGuid] [uniqueidentifier] NOT NULL,
	[AnnouncementIntId] [bigint] NOT NULL,
	[Title] [varchar](100) NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[Expiry] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AnnouncementIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CommitteeEvents]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommitteeEvents](
	[EventGuid] [uniqueidentifier] NOT NULL,
	[EventIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](250) NULL,
	[CommiteeIntId] [bigint] NULL,
	[EventDescription] [nvarchar](2500) NULL,
 CONSTRAINT [PK_CommitteeEvents] PRIMARY KEY CLUSTERED 
(
	[EventIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CommitteeMembers]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommitteeMembers](
	[CommitteeMemberGuid] [uniqueidentifier] NOT NULL,
	[CommitteeMemberIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[CommiteeIntId] [bigint] NOT NULL,
	[MemberIntId] [bigint] NOT NULL,
 CONSTRAINT [PK_CommitteeMembers] PRIMARY KEY CLUSTERED 
(
	[CommitteeMemberIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Committees]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Committees](
	[CommiteeGuid] [uniqueidentifier] NOT NULL,
	[CommiteeIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[CommiteeName] [nvarchar](250) NULL,
	[CommitteeDetails] [varchar](1000) NULL,
 CONSTRAINT [PK_Committees] PRIMARY KEY CLUSTERED 
(
	[CommiteeIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Holidays]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Holidays](
	[HolidayId] [varchar](50) NOT NULL,
	[Occasion] [varchar](150) NOT NULL,
	[HolidayDate] [date] NOT NULL,
	[HolidayDay] [varchar](20) NOT NULL,
	[Optional] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[HolidayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ITPolicies]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ITPolicies](
	[ITPoliciesGuid] [uniqueidentifier] NOT NULL,
	[ITPoliciesIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[ITPoliciesName] [nvarchar](500) NULL,
	[ITPoliciesDetails] [varchar](5000) NULL,
	[LastModifiedDate] [datetime] NULL,
	[PoliciesFullDetails] [varchar](max) NULL,
 CONSTRAINT [PK_ITPolicies] PRIMARY KEY CLUSTERED 
(
	[ITPoliciesIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[JobOpenings]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[JobOpenings](
	[JobOpeningGuid] [uniqueidentifier] NOT NULL,
	[JobOpeningIntId] [int] IDENTITY(1,1) NOT NULL,
	[Jobcode] [varchar](20) NOT NULL,
	[Designation] [varchar](50) NOT NULL,
	[Skills] [varchar](200) NOT NULL,
	[Experience] [varchar](20) NOT NULL,
 CONSTRAINT [PK_JobOpenings] PRIMARY KEY CLUSTERED 
(
	[JobOpeningIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PoliciesProcedure]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PoliciesProcedure](
	[PoliciesProcedureGuid] [uniqueidentifier] NOT NULL,
	[PoliciesProcedureIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[PoliciesProcedureName] [nvarchar](500) NULL,
	[PoliciesProcedureDetails] [varchar](5000) NULL,
	[LastModifiedDate] [datetime] NULL,
	[PoliciesFullDetails] [varchar](5000) NULL,
 CONSTRAINT [PK_PoliciesProcedure] PRIMARY KEY CLUSTERED 
(
	[PoliciesProcedureIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectGuid] [uniqueidentifier] NOT NULL,
	[ProjectIntId] [bigint] NOT NULL,
	[Title] [varchar](150) NOT NULL,
	[Description] [varbinary](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProjectIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Team]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamGuid] [uniqueidentifier] NOT NULL,
	[TeamIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](250) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserGuid] [uniqueidentifier] NOT NULL,
	[EmployeeId] [bigint] NOT NULL,
	[Name] [varchar](250) NOT NULL,
	[EmailId] [varchar](250) NOT NULL,
	[SupervisorIntId] [bigint] NULL,
	[Designation] [varchar](250) NOT NULL,
	[Summary] [varchar](2500) NULL,
	[DateOfBirth] [date] NOT NULL,
	[DeskNo] [varchar](250) NOT NULL,
	[Extension] [bigint] NULL,
	[Team] [bigint] NOT NULL,
	[JoiningDate] [date] NOT NULL,
	[About] [varchar](5000) NULL,
	[Imagedata] [varbinary](max) NULL,
	[ContactNo] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 3/19/2019 5:47:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserRolesIntId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserRoleGuid] [uniqueidentifier] NULL,
	[UserRole] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRolesIntId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Holidays] ADD  DEFAULT ('0') FOR [Optional]
GO
ALTER TABLE [dbo].[CommitteeEvents]  WITH CHECK ADD FOREIGN KEY([CommiteeIntId])
REFERENCES [dbo].[Committees] ([CommiteeIntId])
GO
ALTER TABLE [dbo].[CommitteeMembers]  WITH CHECK ADD FOREIGN KEY([CommiteeIntId])
REFERENCES [dbo].[Committees] ([CommiteeIntId])
GO
ALTER TABLE [dbo].[CommitteeMembers]  WITH CHECK ADD FOREIGN KEY([MemberIntId])
REFERENCES [dbo].[User] ([UserIntId])
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD FOREIGN KEY([SupervisorIntId])
REFERENCES [dbo].[User] ([UserIntId])
GO
USE [master]
GO
ALTER DATABASE [GicDb] SET  READ_WRITE 
GO
