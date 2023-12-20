SET IDENTITY_INSERT [dbo].[Setting] ON 
--Clear first then insert all rows
DELETE FROM [dbo].[Setting] 
GO

-- USER TYPE
IF NOT EXISTS (SELECT * FROM [dbo].[Setting] WHERE SettingType = 'UserType' AND DisplayText = 'Admin')
	INSERT [dbo].[Setting] ([ID], [SettingType], [DisplayText]) VALUES (1,N'UserType',N'Admin')
GO
IF NOT EXISTS (SELECT * FROM [dbo].[Setting] WHERE SettingType = 'UserType' AND DisplayText = 'Instructor')
	INSERT [dbo].[Setting] ([ID], [SettingType], [DisplayText]) VALUES (2,N'UserType',N'Instructor')
GO
IF NOT EXISTS (SELECT * FROM [dbo].[Setting] WHERE SettingType = 'UserType' AND DisplayText = 'Learner')
	INSERT [dbo].[Setting] ([ID], [SettingType], [DisplayText]) VALUES (3,N'UserType',N'Learner')
GO
