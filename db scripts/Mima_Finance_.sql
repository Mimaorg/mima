USE [master]
GO
/****** Object:  Database [Mima_Finance_]    Script Date: 12/5/2020 3:59:44 PM ******/
CREATE DATABASE [Mima_Finance_]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Mima_Finance_', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Mima_Finance_.mdf' , SIZE = 11264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Mima_Finance__log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Mima_Finance__log.ldf' , SIZE = 2816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Mima_Finance_] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Mima_Finance_].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Mima_Finance_] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Mima_Finance_] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Mima_Finance_] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Mima_Finance_] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Mima_Finance_] SET ARITHABORT OFF 
GO
ALTER DATABASE [Mima_Finance_] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Mima_Finance_] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Mima_Finance_] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Mima_Finance_] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Mima_Finance_] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Mima_Finance_] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Mima_Finance_] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Mima_Finance_] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Mima_Finance_] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Mima_Finance_] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Mima_Finance_] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Mima_Finance_] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Mima_Finance_] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Mima_Finance_] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Mima_Finance_] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Mima_Finance_] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Mima_Finance_] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Mima_Finance_] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Mima_Finance_] SET  MULTI_USER 
GO
ALTER DATABASE [Mima_Finance_] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Mima_Finance_] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Mima_Finance_] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Mima_Finance_] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Mima_Finance_] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Mima_Finance_]
GO
/****** Object:  User [NT AUTHORITY\SYSTEM]    Script Date: 12/5/2020 3:59:45 PM ******/
CREATE USER [NT AUTHORITY\SYSTEM] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\SYSTEM]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_ParseString]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[fn_ParseString]
(
@CSVString  varchar(8000) ,
@Delimiter  varchar(10)
)
returns @tbl table (s varchar(1000))
as
begin
declare @i int ,
    @j int
    select  @i = 1
    while @i <= len(@CSVString)
    begin
        select  @j = charindex(@Delimiter, @CSVString, @i)
        if @j = 0
        begin
            select  @j = len(@CSVString) + 1
        end
        insert  @tbl select substring(@CSVString, @i, @j - @i)
        select  @i = @j + len(@Delimiter)
    end
    return
end

GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accounts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bankId] [int] NULL,
	[accountNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bank] [varchar](50) NULL,
 CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bank_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bank_Details](
	[Bank_ID] [int] IDENTITY(1,1) NOT NULL,
	[Bank] [varchar](50) NULL,
	[Org] [varchar](100) NULL,
	[Branch] [varchar](100) NULL,
	[Account] [bigint] NULL,
 CONSTRAINT [PK_Bank_Details] PRIMARY KEY CLUSTERED 
(
	[Bank_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bankPaymentVoucher]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bankPaymentVoucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vnumber] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[ChequeNo] [varchar](50) NULL,
	[Bank] [varchar](50) NULL,
	[Org] [varchar](100) NULL,
	[Branch] [varchar](50) NULL,
	[Account] [varchar](50) NULL,
	[PaidTo] [varchar](500) NULL,
	[Control] [varchar](500) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Rupees] [varchar](500) NULL,
	[filterDate] [varchar](50) NULL,
	[createAT] [datetime] NULL,
	[isPending] [bit] NULL,
	[isCancel] [bit] NULL,
	[pdcDate] [datetime] NULL,
 CONSTRAINT [PK_bankPaymentVoucher_OLD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bankPaymentVoucher_OLD]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bankPaymentVoucher_OLD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vnumber] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[ChequeNo] [varchar](50) NULL,
	[Bank] [varchar](50) NULL,
	[Org] [varchar](100) NULL,
	[Branch] [varchar](50) NULL,
	[Account] [varchar](50) NULL,
	[PaidTo] [varchar](500) NULL,
	[Control] [varchar](500) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Rupees] [varchar](500) NULL,
	[filterDate] [varchar](50) NULL,
	[createAT] [datetime] NULL,
	[isPending] [bit] NULL,
	[isCancel] [bit] NULL,
	[pdcDate] [datetime] NULL,
 CONSTRAINT [PK_bankPaymentVoucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BankReceiptVoucher]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BankReceiptVoucher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VNumber] [int] NULL,
	[Date] [datetime] NULL,
	[ChequeNo] [varchar](50) NULL,
	[Bank] [varchar](50) NULL,
	[Org] [varchar](100) NULL,
	[Branch] [varchar](50) NULL,
	[Account] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Received_From] [varchar](50) NULL,
	[A/C_Description] [varchar](50) NULL,
	[Amount] [int] NULL,
	[Rupees] [varchar](500) NULL,
	[Narration] [varchar](500) NULL,
 CONSTRAINT [PK_BankReceiptVoucher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Billing]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Billing](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bill_id] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Control] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Date] [date] NULL,
	[imgPath] [varchar](500) NULL,
	[base64] [varchar](max) NULL,
	[createAt] [datetime] NULL,
	[isCancell] [bit] NULL,
	[isPending] [bit] NULL,
	[isProjectbill] [bit] NULL,
 CONSTRAINT [PK_Billing_OLD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Billing_OLD]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Billing_OLD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bill_id] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Control] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Date] [date] NULL,
	[imgPath] [varchar](500) NULL,
	[base64] [varchar](max) NULL,
	[createAt] [datetime] NULL,
	[isCancell] [bit] NULL,
	[isPending] [bit] NULL,
 CONSTRAINT [PK_Billing] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Billing_UnVerified]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Billing_UnVerified](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bill_id] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Control] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Date] [date] NULL,
	[imgPath] [varchar](500) NULL,
	[base64] [varchar](max) NULL,
	[createAt] [datetime] NULL,
	[isCancell] [bit] NULL,
	[isPending] [bit] NULL,
 CONSTRAINT [PK_Billing_UnVerified] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[Branch](
	[BankID] [int] NOT NULL,
	[BarnchName] [varchar](100) NULL,
	[BankAddress] [varchar](100) NULL,
	[BranchName] [varchar](50) NULL,
	[BranchCode] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Calendar]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Calendar](
	[Date_ID] [int] IDENTITY(1,1) NOT NULL,
	[Datekey] [int] NOT NULL,
	[Date] [date] NULL,
	[MonthYear] [varchar](30) NULL,
	[DayOfYear] [smallint] NULL,
	[DayNo] [tinyint] NULL,
	[DateName] [varchar](50) NULL,
	[BusinessDayNo] [int] NULL,
	[DayOfWeek] [tinyint] NULL,
	[WeekDayName] [varchar](10) NULL,
	[WeekNo] [tinyint] NULL,
	[WeekOfMonth] [tinyint] NULL,
	[DOWInMonth] [tinyint] NULL,
	[WeekOfYear] [tinyint] NULL,
	[ISOWeekOfYear] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[MonthName] [varchar](10) NULL,
	[QuarterNo] [tinyint] NULL,
	[QuarterName] [varchar](6) NULL,
	[Year] [int] NULL,
	[FirstDayofWeek] [date] NULL,
	[LastDayofWeek] [date] NULL,
	[FirstDayOfMonth] [date] NULL,
	[LastDayOfMonth] [date] NULL,
	[FirstDayOfQuarter] [date] NULL,
	[LastDayOfQuarter] [date] NULL,
	[FirstDayOfYear] [date] NULL,
	[LastDayOfYear] [date] NULL,
	[FirstDayOfNextMonth] [date] NULL,
	[FirstDayOfNextYear] [date] NULL,
	[IsWeekend] [tinyint] NULL,
	[IsHoliday] [tinyint] NULL,
	[HolidayDescription] [varchar](800) NULL,
	[CreatedBy] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ModifiedDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Date_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cashPaymentVoucher]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cashPaymentVoucher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vnumber] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[PaidTo] [varchar](500) NULL,
	[Control] [varchar](500) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Rupees] [varchar](500) NULL,
	[filterDate] [varchar](50) NULL,
	[createAT] [datetime] NULL,
	[isPending] [bit] NULL,
	[isCancel] [bit] NULL,
 CONSTRAINT [PK_cashPaymentVoucher_OLD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cashPaymentVoucher_OLD]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cashPaymentVoucher_OLD](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Vnumber] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[PaidTo] [varchar](500) NULL,
	[Control] [varchar](500) NULL,
	[Category] [varchar](50) NULL,
	[Amount] [bigint] NULL,
	[Description] [varchar](500) NULL,
	[Rupees] [varchar](500) NULL,
	[filterDate] [varchar](50) NULL,
	[createAT] [datetime] NULL,
	[isPending] [bit] NULL,
	[isCancel] [bit] NULL,
 CONSTRAINT [PK_cashPaymentVoucher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CashReceiptVoucher]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CashReceiptVoucher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VNumber] [int] NULL,
	[Date] [datetime] NULL,
	[Received_From] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[A/C_Description] [varchar](100) NULL,
	[Amount] [int] NULL,
	[Rupees] [varchar](500) NULL,
	[Narration] [varchar](500) NULL,
 CONSTRAINT [PK_CashReceiptVoucher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [varchar](100) NULL,
	[ClientRef] [varchar](100) NULL,
	[ClientCity] [varchar](100) NULL,
	[ClientPhone] [varchar](50) NULL,
	[ClientAddress] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Company]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Control_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Control_Details](
	[Control_ID] [int] IDENTITY(1,1) NOT NULL,
	[Control] [varchar](100) NULL,
 CONSTRAINT [PK_Control_Details] PRIMARY KEY CLUSTERED 
(
	[Control_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Daily_Cash]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Daily_Cash](
	[Payment_Date] [datetime] NULL,
	[Supplier_Other] [varchar](50) NULL,
	[Payment_Against] [varchar](50) NULL,
	[Comapny] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[Expense] [varchar](50) NULL,
	[Bank_Cash] [varchar](50) NULL,
	[Bill_Amount] [money] NULL,
	[Tax_Rate] [varchar](50) NULL,
	[Tax] [money] NULL,
	[Amount] [money] NULL,
	[Ref_Inst_Nos] [varchar](50) NULL,
	[Ref_V_Type] [varchar](50) NULL,
	[Remarks] [varchar](200) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DataEntryV1]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataEntryV1](
	[category] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Bill_No] [int] NULL,
	[Date] [datetime] NULL,
	[Particulars] [varchar](5000) NULL,
	[Project] [varchar](100) NULL,
	[Ref] [varchar](50) NULL,
	[Bank] [varchar](100) NULL,
	[Bill] [bigint] NULL,
	[Payment] [bigint] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DataEntryV2]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DataEntryV2](
	[category] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Bill_No] [int] NULL,
	[Date] [datetime] NULL,
	[Particulars] [varchar](5000) NULL,
	[Project] [varchar](100) NULL,
	[Ref] [varchar](50) NULL,
	[Bank] [varchar](100) NULL,
	[Bill] [bigint] NULL,
	[Payment] [bigint] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Expense](
	[ExpID] [int] NOT NULL,
	[Exp] [varchar](100) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[passwordq] [varchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Market_Data]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Market_Data](
	[Category] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Bill no] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Particulars] [varchar](1000) NULL,
	[Project ] [varchar](50) NULL,
	[Ref] [varchar](50) NULL,
	[Bank] [varchar](50) NULL,
	[Bills] [varchar](50) NULL,
	[Payment] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Paid_to_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Paid_to_Details](
	[Paid_to_ID] [int] IDENTITY(1,1) NOT NULL,
	[Paid_to] [varchar](100) NULL,
 CONSTRAINT [PK_Paid_to_Details] PRIMARY KEY CLUSTERED 
(
	[Paid_to_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payable]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payable](
	[id] [int] IDENTITY(10,1) NOT NULL,
	[Payment_Date] [datetime] NULL,
	[Supplier_Other] [varchar](50) NULL,
	[Payment_Against] [varchar](50) NULL,
	[Comapny] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[Expense] [varchar](50) NULL,
	[Bank_Cash] [varchar](50) NULL,
	[Bill_Amount] [money] NULL,
	[Tax_Rate] [varchar](50) NULL,
	[Tax] [money] NULL,
	[Amount] [money] NULL,
	[Ref_Inst_Nos] [varchar](50) NULL,
	[Ref_V_Type] [varchar](50) NULL,
	[Remarks] [varchar](200) NULL,
	[isActive] [bit] NULL,
	[createAt] [datetime] NULL,
	[updateAT] [datetime] NULL,
 CONSTRAINT [PK_payable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recievable]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recievable](
	[id] [int] IDENTITY(500,1) NOT NULL,
	[name] [varchar](50) NULL,
	[GlCode] [varchar](50) NULL,
	[number_Instrument] [varchar](50) NULL,
	[Date_Instrument] [varchar](50) NULL,
	[bank_Instrument] [varchar](50) NULL,
	[company] [varchar](50) NULL,
	[department] [varchar](50) NULL,
	[invoice_amount] [bigint] NULL,
	[rate] [varchar](50) NULL,
	[tax] [int] NULL,
	[wst] [int] NULL,
	[totalAmount] [bigint] NULL,
	[bank_cash_ToBeDepositedvarchar] [varchar](50) NULL,
	[date_ToBeDeposited] [varchar](50) NULL,
	[comments] [varchar](1000) NULL,
	[isActive] [bit] NULL,
	[creatAt] [datetime] NULL,
	[updateAt] [datetime] NULL,
 CONSTRAINT [PK_Recievable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] NOT NULL,
	[SupplierName] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[User_ID] [int] IDENTITY(1,1) NOT NULL,
	[User_Name] [varchar](50) NULL,
	[User_Role] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AddBanks]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[AddBanks]  (
   @Banks varchar(50) 
  
 
    )
 
AS  
  
INSERT INTO Bank (Bank)
VALUES (@Banks);




GO
/****** Object:  StoredProcedure [dbo].[Bank_Payment_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE [dbo].[Bank_Payment_Details] '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Bank_Payment_Details]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[ChequeNo]
      ,[Bank]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
	  ,[filterDate]

FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending


GO
/****** Object:  StoredProcedure [dbo].[Bank_Payment_Details_Chart]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[Bank_Payment_Details_Chart]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
--select b.Bank,SUM(Amount) Volume
--from [dbo].[bankPaymentVoucher] a
--inner join [dbo].[Bank] b on a.Bank  = b.id
--WHERE [filterDate] BETWEEN @S_Date AND @E_Date
--AND   [isPending] = @isPending
--Group by b.Bank

select [Bank], SUM(Amount) Volume
from [dbo].[bankPaymentVoucher]  
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND [isPending] = @isPending
group by Bank



GO
/****** Object:  StoredProcedure [dbo].[Cash_Payment_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE [dbo].[Cash_Payment_Details] '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Cash_Payment_Details]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
	  ,[filterDate]
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending


GO
/****** Object:  StoredProcedure [dbo].[Controller_Volum_Chart]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE [dbo].[Bank_Payment_Details] '2020-06-01' , '2020-06-20', 1
CREATE PROCEDURE [dbo].[Controller_Volum_Chart]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
select [Control], SUM(Amount) Volume
from [dbo].[bankPaymentVoucher] 
WHERE [filterDate] BETWEEN  @S_Date AND @E_Date 
AND   [isPending] = @isPending
Group by [Control]


GO
/****** Object:  StoredProcedure [dbo].[CountOfBilling]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[CountOfBilling]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       count(Amount)
FROM  [Mima_Finance_].[dbo].Billing
WHERE createAt BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending

GO
/****** Object:  StoredProcedure [dbo].[sp_AddBanks]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_AddBanks]  (
   @Banks varchar(50) 
  
 
    )
 
AS  
  
INSERT INTO Bank (Bank)
VALUES (@Banks);





GO
/****** Object:  StoredProcedure [dbo].[sp_Cancel]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[sp_Cancel]  (
   @id int ,
   @tableName varchar(50)
  
 
    )
 
AS  
  
IF @tableName='cashPaymentVoucher'

      update cashPaymentVoucher set isCancel = 1 where id =@id  

 ELSE   
     update bankPaymentVoucher set isCancel = 1 where id =@id


GO
/****** Object:  StoredProcedure [dbo].[sp_Mima_Finance__Category]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_Mima_Finance__Category]
as 

select * from Category

GO
/****** Object:  StoredProcedure [dbo].[sp_PendingRecord]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_PendingRecord]
AS
  SELECT *
FROM bankPaymentVoucher
INNER JOIN Bank ON Bank.id=bankPaymentVoucher.Bank
where bankPaymentVoucher.isPending=1



GO
/****** Object:  StoredProcedure [dbo].[sp_pendingToSubmit]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_pendingToSubmit]  (
   @id int ,
   @tableName varchar(50)
  
 
    )
 
AS  
  
IF @tableName='cashPaymentVoucher'

      update cashPaymentVoucher set isPending = 0 where id =@id  

 ELSE   
     update bankPaymentVoucher set isPending = 0 where id =@id

GO
/****** Object:  StoredProcedure [dbo].[spPopulateDateDimension]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*-------------------------------------------------------------------------------------------------------+
       ¦ Company         ¦                                                                               ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Procedure       ¦  spPopulateDateDimension                                                             ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Description     ¦                                                                                      ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Created By      ¦  Hamdan                                                                        ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Date Created    ¦  Saturday, 18 Dec 2019 04:00:00:000                                                  ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Modified By     ¦                                                                                      ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Date Modified   ¦                                                                                      ¦
       ¦-----------------+--------------------------------------------------------------------------------------¦
       ¦ Details         ¦                                                                                      ¦
       +-------------------------------------------------------------------------------------------------------*/
	   
CREATE PROCEDURE [dbo].[spPopulateDateDimension]
AS
BEGIN
--SET DATEFIRST
  DECLARE  @Start_Date DATE = '2006-01-01',
           @End_Date   DATE ='2025-12-31';

  ;WITH 
  t1(n) AS (SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL
            SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1 UNION ALL SELECT 1), -- 10
  t2(n) AS (SELECT 1 FROM t1 CROSS JOIN t1 AS b), -- 10*10
  t3(n) AS (SELECT 1 FROM t2 CROSS JOIN t2 AS b), -- 100*100
  t4    AS (SELECT DATEADD(DAY, ROW_NUMBER() OVER (ORDER BY n) - 1, @Start_Date) AS [Date] FROM t3)

  INSERT INTO      Calendar(Datekey,[Date],MonthYear,[DayOfYear] ,DayNo ,[DateName],BusinessDayNo ,DayOfWeek,WeekDayName ,WeekNo ,WeekOfMonth,DOWInMonth,WeekOfYear,ISOWeekOfYear,Month,[MonthName]           
                                 ,QuarterNo,QuarterName ,Year ,FirstDayOfWeek,LastDayOfWeek,FirstDayOfMonth,LastDayOfMonth,FirstDayOfQuarter ,LastDayOfQuarter,FirstDayOfYear,LastDayOfYear,FirstDayOfNextMonth   
                                 ,FirstDayOfNextYear,IsWeekend,IsHoliday,HolidayDescription,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate  )
  SELECT              
				   Datekey                                = REPLACE(CAST(d.[Date]  AS DATE),'-','')
				  ,[Date]                                 = d.[Date]
				  ,MonthYear					          = DATENAME(MONTH,    d.[Date])+'-'+CAST(YEAR(d.[Date]) AS VARCHAR(4))
				  ,[DayOfYear]                            = DATEPART(DAYOFYEAR, d.[Date])
				  ,DayNo                                  = DATEPART(DAY, d.[Date])
				  ,[DateName]					          = ''
				  ,BusinessDayNo                          = ''
				  ,WeekdayNo                              = DATEPART(DW, d.[Date])
				  ,WeekDayName                            = DATENAME(DW,d.[Date])
				  ,WeekNo                                 = CONVERT(TINYINT, ROW_NUMBER() OVER (PARTITION BY CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, 0, d.[Date]), 0)), DATEPART(WEEKDAY,  d.[Date]) ORDER BY d.[Date]))
				  ,WeekOfMonth                            = DENSE_RANK() OVER (PARTITION BY  DATEPART(YEAR, d.[Date]),  DATEPART(MONTH, d.[Date]) ORDER BY  DATEPART(WEEK, d.[Date]))
				  ,DOWInMonth                             = CONVERT(TINYINT, ROW_NUMBER() OVER (PARTITION BY CONVERT(DATE, DATEADD(MONTH, DATEDIFF(MONTH, 0, d.[Date]), 0)), DATEPART(WEEKDAY,  d.[Date]) ORDER BY d.[Date]))
				  ,WeekOfYear                             = DATEPART(WEEK,     d.[Date])
				  ,ISOWeekOfYear                          = DATEPART(ISO_WEEK, d.[Date])
				  ,MonthNo                                = DATEPART(MONTH,    d.[Date])
				  ,[MonthName]                            = DATENAME(MONTH,    d.[Date])
				  ,QuarterNo                              = DATEPART(QUARTER,  d.[Date])
                  ,QuarterName                            = CASE DATEPART(QUARTER, d.[Date]) WHEN 1 THEN 'First' WHEN 2 THEN 'Second' WHEN 3 THEN 'Third' WHEN 4 THEN 'Fourth' END
				  ,YearNo                                 = DATEPART(YEAR,     d.[Date])
				  ,FirstDayOfWeek                         = DATEADD(dd, -(DATEPART(dw, d.[Date])-1), d.[Date])
				  ,LastDayOfWeek                          = DATEADD(dd, 7-(DATEPART(dw, d.[Date])), d.[Date])
				  ,FirstDayOfMonth                        = DATEADD(MONTH, DATEDIFF(MONTH, 0, d.[Date]), 0)
                  ,LastDayOfMonth                         = DATEADD (dd, -1, DATEADD(MONTH, DATEDIFF(MONTH, 0, d.[Date])+1, 0))
                  ,FirstDayOfQuarter                      = DATEADD(QUARTER, DATEDIFF(QUARTER, 0, d.[Date]), 0)
                  ,LastDayOfQuarter                       = DATEADD (dd, -1, DATEADD(QUARTER, DATEDIFF(QUARTER, 0, d.[Date])+1, 0))
                  ,FirstDayOfYear                         = DATEADD(YEAR, DATEDIFF(QUARTER, 0, d.[Date]), 0)
                  ,LastDayOfYear                          = DATEADD (dd, -1, DATEADD(YEAR, DATEDIFF(YEAR, 0, d.[Date])+1, 0))
                  ,FirstDayOfNextMonth                    = DATEADD(MONTH, DATEDIFF(MONTH, 0, d.[Date])+1, 0)
                  ,FirstDayOfNextYear                     = DATEADD(YEAR, DATEDIFF(YEAR, 0, d.[Date])+1, 0)
                  ,IsWeekend                              = CASE WHEN DATEPART(DW, d.[Date]) IN (1,7) THEN 1 ELSE 0 END
                  ,IsHoliday                              = 0
                  ,HolidayDescription                     = ''
                  ,CreatedBy                              = 'sys'
                  ,CreatedDate                            = GETDATE()
                  ,ModifiedBy                             = 'sys'
                  ,ModifiedDate                           = GETDATE()
  FROM             t4       d
  WHERE            d.[Date] <= @End_Date
  --AND NOT EXISTS  (SELECT 1 FROM ATI.D_CalendarNEW dd WHERE dd.[Date] = d.[Date])
  ORDER BY        d.[Date];  

  --EXEC            ATI.spPopulateD_Holiday;

  --UPDATE          d
  --SET             d.IsHoliday                  = 1,
  --                d.HolidayDescription         = h.HolidayDesc
  --FROM            ATI.D_CalendarNEW    d
  --INNER JOIN      ATI.D_Holiday         h ON h.[Date] = d.[Date]

  --UPDATE          d
  --SET        	    d.BusinessDayNo              = CASE WHEN DayOfWeek IN (7,1) OR IsHoliday = 1 THEN 0 ELSE 1 END
  --FROM            ATI.D_CalendarNEW    d

END;



GO
/****** Object:  StoredProcedure [dbo].[SumOfAmountBilling]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[SumOfAmountBilling]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       SUM(Amount)
FROM  [Mima_Finance_].[dbo].Billing
WHERE createAt BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending

GO
/****** Object:  StoredProcedure [dbo].[Total_Bank_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Bank_Details '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Bank_Details]
  @S_Date DateTime
, @E_Date Datetime
,@isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Bank_Pending_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Bank_Pending_Details '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Bank_Pending_Details]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Bank_Pending_Units]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE Total_Bank_Pending_Units '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Bank_Pending_Units]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       COUNT([Vnumber])
FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] =@isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Bank_Units]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Bank_Units '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Bank_Units]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       COUNT([Vnumber])
FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Bank_Volume]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE Total_Bank_Volume '2020-05-01' , '2020-05-20'
Create PROCEDURE [dbo].[Total_Bank_Volume]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       SUM(Amount)
FROM  [Mima_Finance_].[dbo].[bankPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending





GO
/****** Object:  StoredProcedure [dbo].[Total_Cash_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Cash_Details '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Cash_Details]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Cash_Pending_Details]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Cash_Pending_Details '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Cash_Pending_Details]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       [Vnumber]
      ,[Date]
      ,[PaidTo]
      ,[Control]
      ,[Amount] 
	  ,[Description]
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending



GO
/****** Object:  StoredProcedure [dbo].[Total_Cash_Pending_Units]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Cash_Pending_Units '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Cash_Pending_Units]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       COUNT([Vnumber])
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending




GO
/****** Object:  StoredProcedure [dbo].[Total_Cash_Units]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXECUTE Total_Cash_Units '2020-05-01' , '2020-05-20'
CREATE PROCEDURE [dbo].[Total_Cash_Units]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       COUNT([Vnumber])
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending




GO
/****** Object:  StoredProcedure [dbo].[Total_Cash_Volume]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--EXECUTE Total_Cash_Volume '2020-05-01' , '2020-05-20'
create PROCEDURE [dbo].[Total_Cash_Volume]
  @S_Date DateTime
, @E_Date Datetime
, @isPending bit
AS
SELECT
       SUM([Amount])
FROM  [Mima_Finance_].[dbo].[cashPaymentVoucher]
WHERE [filterDate] BETWEEN @S_Date AND @E_Date
AND   [isPending] = @isPending


GO
/****** Object:  StoredProcedure [dbo].[Usp_DataEntry]    Script Date: 12/5/2020 3:59:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure  [dbo].[Usp_DataEntry]
AS
BEGIN

--INSERT INTO [dbo].[Paid_to_Details] (Paid_to) 
--SELECT DISTINCT Name FROM Mima_Finance_.[dbo].[DataEntryV1]
-- --------------------------------------------------------------------------------------------------------------
--INSERT INTO [dbo].[Control_Details] ([Control]) 
--SELECT DISTINCT Project FROM Mima_Finance_.[dbo].[DataEntryV1]
-- --------------------------------------------------------------------------------------------------------------
--INSERT INTO [dbo].[bankPaymentVoucher] (Vnumber, [PaidTo], [Date], [Description], [Control], Category, Bank, Amount) 
--SELECT                                  Bill_No, Name,     [Date], Particulars,   Project,   Category,  Bank,  Payment
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf in('BPV')

-- --------------------------------------------------------------------------------------------------------------
--INSERT INTO [dbo].[cashPaymentVoucher] (Vnumber, [PaidTo], [Date], [Description], [Control], Category, Amount) 
-- SELECT                                 Bill_No, Name,     [Date], Particulars,   Project,   Category, Payment
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf in('CPV') 
 
-- --------------------------------------------------------------------------------------------------------------
-- INSERT INTO [dbo].[Billing] (Bill_id, Name, [Date], [Description], [Control], Category, Amount) 
-- SELECT                       Bill_No, Name, [Date], Particulars,   Project,   Category, Bill
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf =('')

---- --------------------------------------------------------------------------------------------------------------
-- INSERT INTO [dbo].[BankReceiptVoucher] (Vnumber, Received_From, [Date], Narration, Category, Bank, Amount) 
-- SELECT                                 Bill_No,  Project      , [Date], Particulars,       Category,  Bank,  Payment
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf in('BRV') 

--  --------------------------------------------------------------------------------------------------------------
--INSERT INTO [dbo].[CashReceiptVoucher] (Vnumber, Received_From, [Date], Narration, Category, Amount) 
-- SELECT                                 Bill_No, Project,     [Date], Particulars, Category, Payment
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf in('CRV') 


INSERT INTO [dbo].[Paid_to_Details] (Paid_to) 
SELECT DISTINCT Name FROM Mima_Finance_.[dbo].Market_Data
WHERE Name not in (select Paid_to from [dbo].[Paid_to_Details])
 --------------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[Control_Details] ([Control]) 
SELECT DISTINCT [Project ] FROM Mima_Finance_.[dbo].Market_Data
WHERE [Project ] not in (select Control FROM [dbo].[Control_Details])
AND  [Project ] not in ('Agha Sb Drawing','Agha Sb Home','Boss Home 13-D Gulshan','Boss Home 3/820 Shah Faisal','Boss Home 77/1 DHA')
 --------------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[bankPaymentVoucher] ([Vnumber],[Date],[ChequeNo],[Bank],	[Org],[Branch],	[Account],[PaidTo],	[Control], [Category],[Amount],
[Description] ,[Rupees],[filterDate],[createAT],[isPending],[isCancel],[pdcDate]) 

SELECT                                  [Bill no],[Date], Null     ,Bank  ,Null  ,Null    , Null     ,Name    , [Project ], 'Civil'  ,Payment ,
 Particulars  ,Null    ,[Date]      ,[Date]    ,0          ,0         ,[Date]
 FROM  Mima_Finance_.[dbo].Market_Data
 WHERE REf in('BPV')
 UNION ALL
SELECT [Vnumber],[Date],[ChequeNo],[Bank],	[Org],[Branch],	[Account],[PaidTo],	[Control], [Category],[Amount],
[Description] ,[Rupees],[filterDate],[createAT],[isPending],[isCancel],[pdcDate] FROM [dbo].[bankPaymentVoucher_OLD] 
 WHERE Account is Not Null
 UNION ALL
SELECT [Vnumber],[Date],[ChequeNo],[Bank],	[Org],[Branch],	[Account],[PaidTo],	[Control], [Category],[Amount],
[Description] ,[Rupees],[filterDate],[createAT],[isPending],[isCancel],[Date] from [dbo].[bankPaymentVoucher_OLD] where Category in('Drawing','Admin Exp.')

 --------------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].[cashPaymentVoucher] ([Vnumber],[Date],[PaidTo],[Control] ,[Category],[Amount],[Description],[Rupees],[filterDate],[createAT],[isPending],[isCancel]) 
SELECT                                 [Bill no] ,[Date], Name   ,[Project ], Category , Payment, Particulars ,Null    , [Date]     ,[Date]     ,0          ,0 
 FROM  Mima_Finance_.[dbo].Market_Data
 WHERE REf in('CPV') 
 UNION ALL
SELECT [Vnumber],[Date],[PaidTo],[Control] ,[Category],[Amount],[Description],[Rupees],[filterDate],CAST([createAT] AS Date),[isPending],[isCancel]
 FROM [dbo].[cashPaymentVoucher_OLD] where Rupees is Not Null
 UNION ALL
SELECT [Vnumber],[Date],[PaidTo],[Control] ,[Category],[Amount],[Description],[Rupees],[filterDate],[createAT],[isPending],[isCancel]
 FROM [dbo].[cashPaymentVoucher_OLD] Where Category in('Drawing','Admin Exp.')
 
 --------------------------------------------------------------------------------------------------------------
 INSERT INTO [dbo].[Billing](Bill_id,   Name, [Date],  createAt, [Description], [Control], Category, Amount, imgPath) 
SELECT                       [Bill no], Name, [Date],  [Date],   Particulars,   [Project ],Category, Bills, Null
 FROM  Mima_Finance_.[dbo].Market_Data
 WHERE REf =('')
 UNION ALL
SELECT Bill_id, Name, CAST(Coalesce([Date],createAt) AS DATE),  createAt, [Description], [Control], Category, Amount, imgPath FROM [dbo].[Billing_OLD] 
WHERE imgPath is not null AND id <> 475

-- --------------------------------------------------------------------------------------------------------------
 --INSERT INTO [dbo].[BankReceiptVoucher] (Vnumber, Received_From, [Date], Narration, Category, Bank, Amount) 
 --SELECT                                 Bill_No,  Project      , [Date], Particulars,       Category,  Bank,  Payment
 --FROM  Mima_Finance_.[dbo].Market_Data
 --WHERE REf in('BRV') 

  --------------------------------------------------------------------------------------------------------------
--INSERT INTO [dbo].[CashReceiptVoucher] (Vnumber, Received_From, [Date], Narration, Category, Amount) 
-- SELECT                                 Bill_No, Project,     [Date], Particulars, Category, Payment
-- FROM  Mima_Finance_.[dbo].Market_Data
-- WHERE REf in('CRV') 
END

GO
USE [master]
GO
ALTER DATABASE [Mima_Finance_] SET  READ_WRITE 
GO
