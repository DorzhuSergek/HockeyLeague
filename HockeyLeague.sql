USE [HockeyLeague]
GO
/****** Object:  ApplicationRole [Manager]    Script Date: 10.12.2021 20:38:38 ******/
/* To avoid disclosure of passwords, the password is generated in script. */
declare @idx as int
declare @randomPwd as nvarchar(64)
declare @rnd as float
select @idx = 0
select @randomPwd = N''
select @rnd = rand((@@CPU_BUSY % 100) + ((@@IDLE % 100) * 100) + 
       (DATEPART(ss, GETDATE()) * 10000) + ((cast(DATEPART(ms, GETDATE()) as int) % 100) * 1000000))
while @idx < 64
begin
   select @randomPwd = @randomPwd + char((cast((@rnd * 83) as int) + 43))
   select @idx = @idx + 1
select @rnd = rand()
end
declare @statement nvarchar(4000)
select @statement = N'CREATE APPLICATION ROLE [Manager] WITH DEFAULT_SCHEMA = [dbo], ' + N'PASSWORD = N' + QUOTENAME(@randomPwd,'''')
EXEC dbo.sp_executesql @statement
GO
/****** Object:  Table [dbo].[Cause_cansel_game]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cause_cansel_game](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[GameId] [int] NULL,
	[Cause] [varchar](50) NULL,
	[NewDataGame] [datetime] NULL,
 CONSTRAINT [PK_Cause cansel game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[HostTeam] [int] NULL,
	[GuestTeam] [int] NULL,
	[HostTeamScore] [numeric](18, 0) NULL,
	[GuestTeamScore] [numeric](18, 0) NULL,
	[GameData] [datetime] NULL,
	[City] [varchar](50) NULL,
	[Match_status] [bit] NULL,
 CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Game_Account_Information]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game_Account_Information](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PlayerId] [int] NULL,
	[time] [time](7) NULL,
	[Period] [int] NULL,
	[GameId] [int] NULL,
 CONSTRAINT [PK_Game_Account_Information] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Position] [varchar](50) NULL,
	[Number] [int] NULL,
	[ID_Team] [int] NULL,
 CONSTRAINT [PK_Plauer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Roles] [varchar](50) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[CoachName] [varchar](50) NOT NULL,
	[CoachSurname] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamTwo]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamTwo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[CoachName] [varchar](50) NULL,
	[CoachSurname] [varchar](50) NULL,
 CONSTRAINT [PK_TeamTwo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cause_cansel_game] ON 

INSERT [dbo].[Cause_cansel_game] ([id], [GameId], [Cause], [NewDataGame]) VALUES (1, 1, N'Растаял лед', CAST(N'2021-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Cause_cansel_game] ([id], [GameId], [Cause], [NewDataGame]) VALUES (2, 1006, N'Упал метеорит', CAST(N'2021-12-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Cause_cansel_game] ([id], [GameId], [Cause], [NewDataGame]) VALUES (3, 2, N'Коронавирус', CAST(N'2021-12-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Cause_cansel_game] ([id], [GameId], [Cause], [NewDataGame]) VALUES (4, 1007, N'Локдаун', CAST(N'2021-12-18T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Cause_cansel_game] OFF
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (1, 6, 5, CAST(7 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(N'2021-05-11T00:00:00.000' AS DateTime), N'Омск', 1)
INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (2, 5, 4, CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'Амур', 0)
INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (3, 4, 7, CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(N'2021-11-25T00:00:00.000' AS DateTime), N'Омск', 0)
INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (1003, 5, 4, CAST(2 AS Numeric(18, 0)), CAST(2 AS Numeric(18, 0)), CAST(N'2021-05-11T00:00:00.000' AS DateTime), N'Омск', 0)
INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (1006, 3, 5, CAST(3 AS Numeric(18, 0)), CAST(3 AS Numeric(18, 0)), CAST(N'2021-11-07T00:00:00.000' AS DateTime), N'Омск', 0)
INSERT [dbo].[Game] ([id], [HostTeam], [GuestTeam], [HostTeamScore], [GuestTeamScore], [GameData], [City], [Match_status]) VALUES (1007, 10, 1, CAST(3 AS Numeric(18, 0)), CAST(4 AS Numeric(18, 0)), CAST(N'2021-11-11T00:00:00.000' AS DateTime), N'Омск', 0)
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
SET IDENTITY_INSERT [dbo].[Game_Account_Information] ON 

INSERT [dbo].[Game_Account_Information] ([ID], [PlayerId], [time], [Period], [GameId]) VALUES (1, 3, CAST(N'00:45:00' AS Time), 3, 1)
SET IDENTITY_INSERT [dbo].[Game_Account_Information] OFF
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (3, N'Телегин', N' Иван', N'Нападающий', 77, 1)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (4, N'Дронов', N'Григорий', N'Защитник', 2, 2)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (5, N'Коледов', N'Павел', N'Защитник', 2, 3)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (6, N'Тему', N'Пулккинен', N'Нападающий', 6, 4)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (7, N'Адамчук', N'Кирилл', N'Защитник', 77, 5)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (8, N'Галкин', N'Владимир', N'Вратарь', 1, 6)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (1002, N'Кнот', N'Рональд', N'Защитник', 3, 7)
INSERT [dbo].[Player] ([id], [Surname], [Name], [Position], [Number], [ID_Team]) VALUES (1003, N'Аликин', N'Евгений', N'Вратарь', 18, 8)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([id], [Login], [Password], [Roles]) VALUES (1, N'Sergek', N'123', N'Manager')
INSERT [dbo].[Roles] ([id], [Login], [Password], [Roles]) VALUES (2, N'User', N'user', N'User')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Team] ON 

INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (1, N'Авангард', N'Омск', N'Хартли', N'Боб')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (2, N'Металлург Мг', N'Магнитогорск', N'Илья ', N'Воробьёв')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (3, N'Салават Юлаев', N'Уфа', N'Ламса', N'Томи')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (4, N'Трактор', N'Челябинск', N'Гатиятулин ', N'Анвар')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (5, N'Ак Барс', N'Казан', N'Квартальнов', N'Дмитрий')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (6, N'Автомобилист', N'Екатеринбург', N'Отмахов', N'Владислав')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (7, N'Нефтехимик', N'Нижнекамск', N'Леонтьев', N'Олег')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (8, N'Амур', N'Хабаровск', N'Кравец', N'Михаил')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (9, N'Адмирал ', N'Владивосток', N'Андриевский', N'Александр')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (10, N'Барыс', N'Нур-Султан', N'Высоцкий', N'Александр')
INSERT [dbo].[Team] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (11, N'Сибирь', N'Новосибирск', N'Мартемьянов', N'Андрей')
SET IDENTITY_INSERT [dbo].[Team] OFF
GO
SET IDENTITY_INSERT [dbo].[TeamTwo] ON 

INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (1, N'Авангард', N'Омск', N'Хартли', N'Боб')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (2, N'Металлург Мг', N'Магнитогорск', N'Илья ', N'Воробьёв')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (3, N'Салават Юлаев', N'Уфа', N'Ламса', N'Томи')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (4, N'Трактор', N'Челябинск', N'Гатиятулин ', N'Анвар')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (5, N'Ак Барс', N'Казан', N'Квартальнов', N'Дмитрий')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (6, N'Автомобилист', N'Екатеринбург', N'Отмахов', N'Владислав')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (7, N'Нефтехимик', N'Нижнекамск', N'Леонтьев', N'Олег')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (8, N'Амур', N'Хабаровск', N'Кравец', N'Михаил')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (9, N'Адмирал ', N'Владивосток', N'Андриевский', N'Александр')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (10, N'Барыс', N'Нур-Султан', N'Высоцкий', N'Александр')
INSERT [dbo].[TeamTwo] ([id], [Name], [City], [CoachName], [CoachSurname]) VALUES (11, N'Сибирь', N'Новосибирск', N'Мартемьянов', N'Андрей')
SET IDENTITY_INSERT [dbo].[TeamTwo] OFF
GO
ALTER TABLE [dbo].[Cause_cansel_game]  WITH CHECK ADD  CONSTRAINT [FK_Cause_cansel_game_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([id])
GO
ALTER TABLE [dbo].[Cause_cansel_game] CHECK CONSTRAINT [FK_Cause_cansel_game_Game]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_Team2] FOREIGN KEY([HostTeam])
REFERENCES [dbo].[Team] ([id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_Team2]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK_Game_TeamTwo] FOREIGN KEY([GuestTeam])
REFERENCES [dbo].[TeamTwo] ([id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK_Game_TeamTwo]
GO
ALTER TABLE [dbo].[Game_Account_Information]  WITH CHECK ADD  CONSTRAINT [FK_Game_Account_Information_Game] FOREIGN KEY([GameId])
REFERENCES [dbo].[Game] ([id])
GO
ALTER TABLE [dbo].[Game_Account_Information] CHECK CONSTRAINT [FK_Game_Account_Information_Game]
GO
ALTER TABLE [dbo].[Game_Account_Information]  WITH CHECK ADD  CONSTRAINT [FK_Game_Account_Information_Player] FOREIGN KEY([PlayerId])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Game_Account_Information] CHECK CONSTRAINT [FK_Game_Account_Information_Player]
GO
ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team] FOREIGN KEY([ID_Team])
REFERENCES [dbo].[Team] ([id])
GO
ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Team]
GO
/****** Object:  StoredProcedure [dbo].[LogUser]    Script Date: 10.12.2021 20:38:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[LogUser]
            @login nvarchar(MAX),
            @password nvarchar(MAX)
        AS
            SELECT *
            FROM Roles
            WHERE Login = @login AND Password = @password 
GO
