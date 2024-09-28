CREATE DATABASE [threelayerapplication]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'threelayerapplication', FILENAME = N'/var/opt/mssql/data/threelayerapplication.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'threelayerapplication_log', FILENAME = N'/var/opt/mssql/data/threelayerapplication_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 COLLATE SQL_Latin1_General_CP1_CI_AS
 WITH LEDGER = OFF
GO
ALTER DATABASE [threelayerapplication] SET COMPATIBILITY_LEVEL = 160
GO
ALTER DATABASE [threelayerapplication] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [threelayerapplication] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [threelayerapplication] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [threelayerapplication] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [threelayerapplication] SET ARITHABORT OFF 
GO
ALTER DATABASE [threelayerapplication] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [threelayerapplication] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [threelayerapplication] SET AUTO_CREATE_STATISTICS OFF
GO
ALTER DATABASE [threelayerapplication] SET AUTO_UPDATE_STATISTICS OFF 
GO
ALTER DATABASE [threelayerapplication] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [threelayerapplication] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [threelayerapplication] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [threelayerapplication] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [threelayerapplication] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [threelayerapplication] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [threelayerapplication] SET  DISABLE_BROKER 
GO
ALTER DATABASE [threelayerapplication] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [threelayerapplication] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [threelayerapplication] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [threelayerapplication] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [threelayerapplication] SET  READ_WRITE 
GO
ALTER DATABASE [threelayerapplication] SET RECOVERY FULL 
GO
ALTER DATABASE [threelayerapplication] SET  MULTI_USER 
GO
ALTER DATABASE [threelayerapplication] SET PAGE_VERIFY TORN_PAGE_DETECTION  
GO
ALTER DATABASE [threelayerapplication] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [threelayerapplication] SET DELAYED_DURABILITY = DISABLED 
GO
USE [threelayerapplication]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [threelayerapplication] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
