USE [CapitechData]
GO
/****** Object:  Table [dbo].[Absences]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absences](
	[AbsenceId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[Employee] [nvarchar](500) NULL,
	[AbsenceCode] [nvarchar](50) NULL,
	[AbsenceDescription] [nvarchar](max) NULL,
	[AbsenceType] [int] NULL,
	[FromDate] [datetime2](0) NULL,
	[EndDate] [datetime2](0) NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[Hours] [decimal](18, 2) NULL,
	[AbsencePercent] [decimal](18, 2) NULL,
	[DepartmentId] [int] NULL,
	[Department] [nvarchar](500) NULL,
	[CreatedOn] [datetime2](0) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime2](0) NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Absences] PRIMARY KEY CLUSTERED 
(
	[AbsenceId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AbsenceTransactions]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbsenceTransactions](
	[AbsenceId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[Employee] [nvarchar](500) NULL,
	[AbsenceCode] [nvarchar](50) NULL,
	[AbsenceDescription] [nvarchar](50) NULL,
	[AbsenceType] [int] NULL,
	[FromDate] [datetime2](0) NULL,
	[EndDate] [datetime2](0) NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[Hours] [decimal](18, 2) NULL,
	[AbsencePercent] [decimal](18, 2) NULL,
	[DepartmentId] [int] NULL,
	[Department] [nvarchar](500) NULL,
	[CreatedOn] [datetime2](0) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime2](0) NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[DateImported] [datetimeoffset](7) NULL,
	[DayDate] [datetime2](0) NOT NULL,
	[DayStartTime] [time](0) NULL,
	[DayEndTime] [time](7) NULL,
	[DayTaskId] [int] NULL,
	[DayTask] [nvarchar](500) NULL,
	[DayOrderId] [int] NULL,
	[DayOrder] [nvarchar](500) NULL,
	[DayProjectNr] [int] NULL,
	[DayProject] [nvarchar](500) NULL,
	[DaySubProjectId] [int] NULL,
	[DaySubProject] [nvarchar](500) NULL,
	[DayPhaseId] [int] NULL,
	[DayPhase] [nvarchar](500) NULL,
	[DayShiftId] [int] NULL,
	[DayFreeDimension1Id] [int] NULL,
	[DayFreeDimension1] [nvarchar](500) NULL,
	[DayFreeDimension2Id] [int] NULL,
	[DayFreeDimension2] [nvarchar](500) NULL,
	[DayClassicDutyId] [int] NULL,
	[DayAbsencePercent] [int] NULL,
	[DaySelfDeclaration] [bit] NULL,
	[DayTransactionStatus] [int] NULL,
	[DayTimeCategoryId] [int] NULL,
	[DayTimeCategory] [nvarchar](500) NULL,
	[DayCalculatedHours] [decimal](18, 2) NULL,
	[DayPaidHours] [decimal](18, 2) NULL,
 CONSTRAINT [PK_AbsenceTransactions] PRIMARY KEY CLUSTERED 
(
	[AbsenceId] ASC,
	[ClientId] ASC,
	[DayDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Competences]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Competences](
	[CompetenceId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[SortNumber] [int] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Competences] PRIMARY KEY CLUSTERED 
(
	[CompetenceId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[DepartmentId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[IsActive] [bit] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DutyDefinitions]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutyDefinitions](
	[DutyDefinitionId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[Start] [time](0) NULL,
	[End] [time](0) NULL,
	[BreakStart] [time](0) NULL,
	[BreakEnd] [time](0) NULL,
	[Hours] [decimal](18, 2) NULL,
	[SortNumber] [int] NULL,
	[DutyTypeId] [int] NULL,
	[CompetenceId] [int] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_DutyDefinitions] PRIMARY KEY CLUSTERED 
(
	[DutyDefinitionId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DutyTypes]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DutyTypes](
	[DutyTypeId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Name] [nvarchar](500) NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
	[SortNumber] [int] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_DutyTypes] PRIMARY KEY CLUSTERED 
(
	[DutyTypeId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FirstName] [nvarchar](250) NULL,
	[LastName] [nvarchar](250) NULL,
	[IsTimeActive] [bit] NULL,
	[IsAbsenceActive] [bit] NULL,
	[IsPlanActive] [bit] NULL,
	[Gender] [nvarchar](10) NULL,
	[EmployeeStartDate] [datetime] NULL,
	[EmployeeEndDate] [datetime] NULL,
	[EmployeeSeniorityDate] [date] NULL,
	[ExternalId] [nvarchar](250) NULL,
	[WageGroupId] [int] NULL,
	[TaskId] [int] NULL,
	[ProjectId] [int] NULL,
	[SubProjectId] [int] NULL,
	[PhaseId] [int] NULL,
	[OrderId] [int] NULL,
	[FreeDimension1Id] [int] NULL,
	[FreeDimension2Id] [int] NULL,
	[CostCarrierId] [int] NULL,
	[StatisticsGroupCode] [nvarchar](250) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FreeDimension1s]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreeDimension1s](
	[FreeDimension1Id] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[UniqueId] [int] NOT NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_FreeDimension1] PRIMARY KEY CLUSTERED 
(
	[FreeDimension1Id] ASC,
	[ClientId] ASC,
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FreeDimension2s]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FreeDimension2s](
	[FreeDimension2Id] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[UniqueId] [int] NOT NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_FreeDimension2] PRIMARY KEY CLUSTERED 
(
	[FreeDimension2Id] ASC,
	[ClientId] ASC,
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OperationalPlans]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OperationalPlans](
	[Id] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[UpdatedOn] [datetime2](7) NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[Name] [nvarchar](1000) NULL,
	[Description] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[Start] [datetime2](0) NULL,
	[End] [datetime2](0) NULL,
	[StartTime] [time](0) NULL,
	[EndTime] [time](0) NULL,
	[Period] [nvarchar](500) NULL,
	[ShortDutyDescription] [nvarchar](1000) NULL,
	[LongDutyDescription] [nvarchar](max) NULL,
	[Hours] [decimal](18, 2) NULL,
	[NewStart] [datetime2](0) NULL,
	[NewEnd] [datetime2](0) NULL,
	[NewHours] [decimal](18, 2) NULL,
	[Count] [int] NULL,
	[SubstituteDutyId] [int] NULL,
	[PreviousDutyId] [int] NULL,
	[HasSubstituteNeed] [bit] NULL,
	[SubstituteProviderId] [int] NULL,
	[SubstituteProviderName] [nvarchar](500) NULL,
	[ExchangeDutyId] [int] NULL,
	[ShiftRotationRollOutId] [int] NULL,
	[DutyDefinitionId] [int] NULL,
	[EmployeeId] [int] NULL,
	[EmployeeFullName] [nvarchar](500) NULL,
	[EmployeeDepartmentId] [int] NULL,
	[EmployeeDepartmentName] [nvarchar](500) NULL,
	[DepartmentId] [int] NULL,
	[DepartmentName] [nvarchar](500) NULL,
	[CompetenceRoleId] [int] NULL,
	[CompetenceRoleName] [nvarchar](500) NULL,
	[TaskId] [int] NULL,
	[TaskName] [nvarchar](500) NULL,
	[OrderId] [int] NULL,
	[OrderName] [nvarchar](500) NULL,
	[ProjectId] [int] NULL,
	[ProjectName] [nvarchar](500) NULL,
	[SubProjectId] [int] NULL,
	[SubProjectName] [nvarchar](500) NULL,
	[PhaseId] [int] NULL,
	[PhaseName] [nvarchar](500) NULL,
	[FreeDimension1Id] [int] NULL,
	[FreeDimension1Name] [nvarchar](500) NULL,
	[FreeDimension2Id] [int] NULL,
	[FreeDimension2Name] [nvarchar](500) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_OperationalPlans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsActive] [bit] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phases]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phases](
	[PhaseId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[SubProjectId] [int] NULL,
	[Description] [nvarchar](1000) NULL,
	[StartDate] [datetime2](7) NULL,
	[PlannedFinishDate] [datetime2](7) NULL,
	[FinishDate] [datetime2](7) NULL,
	[Status] [nvarchar](50) NULL,
	[HourlyRate] [decimal](18, 0) NULL,
	[PercentagePart] [decimal](18, 0) NULL,
	[UniqueId] [int] NOT NULL,
	[AlphanumericCode] [nvarchar](100) NULL,
	[Description2] [nvarchar](max) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Phases] PRIMARY KEY CLUSTERED 
(
	[PhaseId] ASC,
	[ClientId] ASC,
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[ProjectId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[UniqueId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[StartDate] [datetime2](7) NULL,
	[PlannedFinishDate] [datetime2](7) NULL,
	[FinishDate] [datetime2](7) NULL,
	[HourlyRate] [decimal](18, 0) NULL,
	[Status] [nvarchar](50) NULL,
	[UsesSubProjects] [bit] NULL,
	[ProjectCustomer] [nvarchar](500) NULL,
	[ProjectLeader] [nvarchar](500) NULL,
	[AlphanumericCode] [nvarchar](100) NULL,
	[Description2] [nvarchar](max) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[ClientId] ASC,
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubProjects]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubProjects](
	[SubProjectId] [int] NOT NULL,
	[ProjectId] [int] NULL,
	[ClientId] [int] NOT NULL,
	[UniqueId] [int] NOT NULL,
	[Description] [nvarchar](1000) NULL,
	[StartDate] [datetime2](7) NULL,
	[PlannedFinishDate] [datetime2](7) NULL,
	[FinishDate] [datetime2](7) NULL,
	[HourlyRate] [decimal](18, 0) NULL,
	[Status] [nvarchar](50) NULL,
	[UsesPhases] [bit] NULL,
	[PercentagePart] [decimal](18, 0) NULL,
	[ProjectCustomer] [nvarchar](500) NULL,
	[ProjectLeader] [nvarchar](500) NULL,
	[AlphanumericCode] [nvarchar](100) NULL,
	[Description2] [nvarchar](max) NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_SubProjects] PRIMARY KEY CLUSTERED 
(
	[SubProjectId] ASC,
	[ClientId] ASC,
	[UniqueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[DepartmentId] [int] NULL,
	[TaskDescription] [nvarchar](4000) NULL,
	[TaskStatus] [int] NULL,
	[CostCarrierId] [int] NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC,
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeTransactions]    Script Date: 09.04.2021 12:28:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTransactions](
	[Uid] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[EmployeeId] [int] NULL,
	[Employee] [nvarchar](500) NULL,
	[DateIn] [datetime2](0) NULL,
	[TimeIn] [time](0) NULL,
	[DateOut] [datetime2](0) NULL,
	[TimeOut] [time](0) NULL,
	[DepartmentId] [int] NULL,
	[Department] [nvarchar](500) NULL,
	[TaskId] [int] NULL,
	[Task] [nvarchar](500) NULL,
	[ClassicDutyId] [int] NULL,
	[ClassicDutyCode] [nvarchar](100) NULL,
	[ClassicDuty] [nvarchar](500) NULL,
	[OrderId] [int] NULL,
	[Order] [nvarchar](500) NULL,
	[ProjectId] [int] NULL,
	[Project] [nvarchar](500) NULL,
	[SubProjectId] [int] NULL,
	[SubProject] [nvarchar](500) NULL,
	[ProjectPhaseId] [int] NULL,
	[ProjectPhase] [nvarchar](500) NULL,
	[ShiftId] [int] NULL,
	[Shift] [nvarchar](500) NULL,
	[FreeDimension1Id] [int] NULL,
	[FreeDimension1] [nvarchar](500) NULL,
	[FreeDimension2Id] [int] NULL,
	[FreeDimension2] [nvarchar](500) NULL,
	[FreeText] [nvarchar](max) NULL,
	[ApprovedLevelOne] [int] NULL,
	[ApprovedLevelTwo] [int] NULL,
	[ApprovedLevelThree] [int] NULL,
	[ApprovedLevelFour] [int] NULL,
	[ApprovedLevelOneBy] [nvarchar](500) NULL,
	[ApprovedLevelTwoBy] [nvarchar](500) NULL,
	[ApprovedLevelThreeBy] [nvarchar](500) NULL,
	[ApprovedLevelFourBy] [nvarchar](500) NULL,
	[ApprovedLevelOneOn] [datetime2](0) NULL,
	[ApprovedLevelTwoOn] [datetime2](0) NULL,
	[ApprovedLevelThreeOn] [datetime2](0) NULL,
	[ApprovedLevelFourOn] [datetime2](0) NULL,
	[TimeCategoryId] [int] NOT NULL,
	[TimeCategory] [nvarchar](500) NULL,
	[TimeCategoryTypeId] [nvarchar](50) NULL,
	[TimeCategoryType] [nvarchar](500) NULL,
	[TimeCategoryPayable] [bit] NULL,
	[Qty] [decimal](18, 2) NOT NULL,
	[ExternalStatusCode] [int] NULL,
	[LastUpdatedOn] [datetimeoffset](7) NULL,
	[RecordStateKey] [nvarchar](250) NOT NULL,
	[DateImported] [datetimeoffset](7) NOT NULL,
 CONSTRAINT [PK_Times] PRIMARY KEY CLUSTERED 
(
	[Uid] ASC,
	[ClientId] ASC,
	[TimeCategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TimeTransactions] ADD  CONSTRAINT [DF_TimeTransactions_TimeCategoryId]  DEFAULT ((0)) FOR [TimeCategoryId]
GO
