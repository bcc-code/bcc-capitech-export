/****** Object:  View [dbo].[vwPhases]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwPhases]
AS
SELECT DISTINCT 
                         CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) + '-' + CAST(SubProjectId AS nvarchar) + '-' + CAST(ProjectPhaseId AS nvarchar) AS ProjectPhaseUID, CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) 
                         AS ProjectUID, CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) + '-' + CAST(SubProjectId AS nvarchar) AS SubProjectUID, ProjectId, SubProjectId, ProjectPhaseId, ClientId, ProjectPhase AS Description
FROM            dbo.TimeTransactions AS y
WHERE        (NOT (ProjectPhaseId IS NULL))
GO
/****** Object:  View [dbo].[vwProjects]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProjects]
AS
SELECT        CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) AS ProjectUID, ProjectId, ClientId, Description, StartDate, PlannedFinishDate, FinishDate, HourlyRate, Status, UsesSubProjects, ProjectCustomer, ProjectLeader, 
                         Description2, AlphanumericCode
FROM            dbo.Projects
GO
/****** Object:  View [dbo].[vwSubProjects]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwSubProjects]
AS
SELECT        CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) AS ProjectUID, CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) + '-' + CAST(SubProjectId AS nvarchar) AS SubProjectUID, SubProjectId, ProjectId, 
                         ClientId, UniqueId, Description, StartDate, PlannedFinishDate, FinishDate, HourlyRate, Status, UsesPhases, PercentagePart, ProjectCustomer, ProjectLeader, AlphanumericCode, Description2, DateImported
FROM            dbo.SubProjects
GO
/****** Object:  View [dbo].[vwProjectHierarchy]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwProjectHierarchy]
AS
SELECT        ProjectUID AS ProjectHierarchyUID, NULL AS ProjectHierarchyParentUID, 1 AS [ProjectHierarchyLevel], ProjectUID, NULL AS SubProjectUID, NULL AS ProjectPhaseUID , ClientId, ProjectId, NULL AS SubProjectId, NULL AS ProjectPhaseId, Description AS Name
FROM            dbo.vwProjects
UNION
SELECT        SubProjectUID AS ProjectHierarchyUID, ProjectUID AS ProjectHierarchyParentUID, 2 AS [ProjectHierarchyLevel], ProjectUID, SubProjectUID AS SubProjectUID, NULL AS ProjectPhaseUID , ClientId, ProjectId, SubprojectId AS SubProjectId, NULL AS ProjectPhaseId, Description AS Name
FROM            dbo.vwSubProjects
UNION
SELECT        ProjectPhaseUID AS ProjectHierarchyUID, SubProjectUID AS ProjectHierarchyParentUID, 3 AS [ProjectHierarchyLevel], ProjectUID, SubProjectUID AS SubProjectUID, ProjectPhaseUID AS ProjectPhaseUID , ClientId, ProjectId, SubProjectId,ProjectPhaseId, Description as Name
FROM            dbo.vwPhases
GO
/****** Object:  View [dbo].[vwEmployees]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwEmployees]
AS
SELECT        EmployeeUID, MAX(EmployeeId) AS EmployeeId, MAX(ClientId) AS ClientId, MAX(EmployeeName) AS EmployeeName
FROM            (SELECT DISTINCT CAST(ClientId AS nvarchar) + '-' + CAST(EmployeeId AS nvarchar) AS EmployeeUID, EmployeeId, ClientId, Employee AS EmployeeName
                          FROM            dbo.TimeTransactions AS y) AS x
GROUP BY EmployeeUID
GO
/****** Object:  View [dbo].[vwDepartments]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwDepartments]
AS
SELECT        CAST(ClientId AS nvarchar) + '-' + CAST(DepartmentId AS nvarchar) AS DepartmentUID, DepartmentId, ClientId, Description, IsActive, DateImported
FROM            dbo.Departments
GO
/****** Object:  View [dbo].[vwTimeTransactions]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwTimeTransactions]
AS
SELECT        (CASE WHEN NOT projectPhaseId IS NULL THEN projectPhaseUID WHEN NOT subprojectId IS NULL THEN subprojectUID WHEN NOT projectId IS NULL THEN projectUID ELSE NULL END) AS ProjectHierarchyUID, 
                         (CASE WHEN NOT projectPhaseId IS NULL THEN subprojectUID WHEN NOT subprojectId IS NULL THEN projectUID ELSE NULL END) AS ProjectHierarchyParentUID, TimeTransactionUID, ProjectUID, SubProjectUID, 
                         ProjectPhaseUID, EmployeeUID, DepartmentUID, Uid, ClientId, EmployeeId, Employee, DateIn, TimeIn, DateOut, TimeOut, DepartmentId, Department, TaskId, Task, ClassicDutyId, ClassicDutyCode, ClassicDuty, OrderId, [Order], 
                         ProjectId, Project, SubProjectId, SubProject, ProjectPhaseId, ProjectPhase, ShiftId, Shift, FreeDimension1Id, FreeDimension1, FreeDimension2Id, FreeDimension2, [FreeText], ApprovedLevelOne, ApprovedLevelTwo, 
                         ApprovedLevelThree, ApprovedLevelFour, ApprovedLevelOneBy, ApprovedLevelTwoBy, ApprovedLevelThreeBy, ApprovedLevelFourBy, ApprovedLevelOneOn, ApprovedLevelTwoOn, ApprovedLevelThreeOn, 
                         ApprovedLevelFourOn, TimeCategoryId, TimeCategory, TimeCategoryTypeId, TimeCategoryType, TimeCategoryPayable, Qty, ExternalStatusCode, LastUpdatedOn, RecordStateKey, DateImported
FROM            (SELECT        CAST(ClientId AS nvarchar) + '-' + CAST(Uid AS nvarchar) AS TimeTransactionUID, CASE WHEN ProjectId IS NULL THEN NULL ELSE CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) END AS ProjectUID, 
                                                    CASE WHEN SubProjectId IS NULL THEN NULL ELSE CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) + '-' + CAST(SubProjectId AS nvarchar) END AS SubProjectUID, 
                                                    CASE WHEN ProjectPhaseID IS NULL THEN NULL ELSE CAST(ClientId AS nvarchar) + '-' + CAST(ProjectId AS nvarchar) + '-' + CAST(SubProjectId AS nvarchar) + '-' + CAST(ProjectPhaseId AS nvarchar) 
                                                    END AS ProjectPhaseUID, CASE WHEN EmployeeId IS NULL THEN NULL ELSE CAST(ClientId AS nvarchar) + '-' + CAST(EmployeeId AS nvarchar) END AS EmployeeUID, CASE WHEN DepartmentId IS NULL 
                                                    THEN NULL ELSE CAST(ClientId AS nvarchar) + '-' + CAST(DepartmentId AS nvarchar) END AS DepartmentUID, Uid, ClientId, EmployeeId, Employee, DateIn, TimeIn, DateOut, TimeOut, DepartmentId, Department, 
                                                    TaskId, Task, ClassicDutyId, ClassicDutyCode, ClassicDuty, OrderId, [Order], ProjectId, Project, SubProjectId, SubProject, ProjectPhaseId, ProjectPhase, ShiftId, Shift, FreeDimension1Id, FreeDimension1, 
                                                    FreeDimension2Id, FreeDimension2, [FreeText], ApprovedLevelOne, ApprovedLevelTwo, ApprovedLevelThree, ApprovedLevelFour, ApprovedLevelOneBy, ApprovedLevelTwoBy, ApprovedLevelThreeBy, 
                                                    ApprovedLevelFourBy, ApprovedLevelOneOn, ApprovedLevelTwoOn, ApprovedLevelThreeOn, ApprovedLevelFourOn, TimeCategoryId, TimeCategory, TimeCategoryTypeId, TimeCategoryType, TimeCategoryPayable, 
                                                    Qty, ExternalStatusCode, LastUpdatedOn, RecordStateKey, DateImported
                          FROM            dbo.TimeTransactions) AS derivedtbl_1
GO
/****** Object:  View [dbo].[vwEmployeeDepartments]    Script Date: 10.04.2021 22:22:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwEmployeeDepartments]
AS
SELECT DISTINCT t.EmployeeUID, t.DepartmentUID, d.Description AS DepartmentName, e.EmployeeName
FROM            dbo.vwTimeTransactions AS t LEFT OUTER JOIN
                         dbo.vwDepartments AS d ON d.DepartmentUID = t.DepartmentUID LEFT OUTER JOIN
                         dbo.vwEmployees AS e ON e.EmployeeUID = t.EmployeeUID
GO
