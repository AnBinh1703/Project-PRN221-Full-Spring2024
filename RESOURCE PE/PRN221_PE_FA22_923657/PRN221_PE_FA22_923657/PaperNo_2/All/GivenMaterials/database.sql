USE [master]
GO
/****** Object:  Database [PE_PRN_Fall22B1]    Script Date: 10/30/2022 1:40:18 PM ******/
CREATE DATABASE [PE_PRN_Fall22B1]
GO
USE [PE_PRN_Fall22B1]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](40) NOT NULL,
	[Male] [bit] NOT NULL,
	[Dob] [date] NOT NULL,
	[Nationality] [varchar](30) NOT NULL,
	[Description] [ntext] NOT NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Genre]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Genre](
	[MovieId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_Movie_Genre] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie_Star]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie_Star](
	[MovieId] [int] NOT NULL,
	[StarId] [int] NOT NULL,
 CONSTRAINT [PK_Movie_Star] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC,
	[StarId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](200) NOT NULL,
	[ReleaseDate] [date] NULL,
	[Description] [text] NULL,
	[Language] [varchar](30) NOT NULL,
	[ProducerId] [int] NULL,
	[DirectorId] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producers]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Productions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stars]    Script Date: 10/30/2022 1:40:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NOT NULL,
	[Male] [bit] NULL,
	[Dob] [date] NULL,
	[Description] [text] NULL,
	[Nationality] [varchar](30) NULL,
 CONSTRAINT [PK_Stars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Directors] ON 
GO
INSERT [dbo].[Directors] ([Id], [FullName], [Male], [Dob], [Nationality], [Description]) VALUES (1, N'David Gordon Green', 1, CAST(N'1975-04-09' AS Date), N'USA', N'David Gordon Green was born on April 9, 1975 in Little Rock, Arkansas, USA. He is a producer and director, known for Sát Nhân Halloween (2018), Halloween Kills (2021) and George Washington (2000).')
GO
INSERT [dbo].[Directors] ([Id], [FullName], [Male], [Dob], [Nationality], [Description]) VALUES (2, N'Aaron Horvath', 1, CAST(N'1980-08-19' AS Date), N'USA', N'No photo available. Represent Aaron Horvath? Add or change photos at IMDbPro
SEE RANK
Aaron Horvath
Producer | Writer | Animation Department
+ Add or change photo on IMDbPro »
Aaron Horvath was born on August 19, 1980 in California, USA. He is a producer and writer, known for Biet Doi Sieu Anh Hung Teen Titans (2018), Biet Doi Thieu Nien Titan Xuat Kich! (2013) and Naruto.')
GO
INSERT [dbo].[Directors] ([Id], [FullName], [Male], [Dob], [Nationality], [Description]) VALUES (4, N'David Bruckner', 1, CAST(N'1981-08-19' AS Date), N'England', N'David Bruckner is known for The Night House (2020), Nghi Lễ Tế Thần (2017) and Southbound (2015).')
GO
INSERT [dbo].[Directors] ([Id], [FullName], [Male], [Dob], [Nationality], [Description]) VALUES (5, N'Mike Barker', 1, CAST(N'1965-11-29' AS Date), N'England', N'Mike Barker was born on November 29, 1965 in England, UK. He is a director and producer, known for Fargo (2014) and Broadchurch (2013).')
GO
INSERT [dbo].[Directors] ([Id], [FullName], [Male], [Dob], [Nationality], [Description]) VALUES (6, N'Joseph Kosinski', 1, CAST(N'1974-05-03' AS Date), N'USA', N'Joseph Kosinski is a director whose uncompromising style has quickly made a mark in the filmmaking zeitgeist. His feature film debut, "Tron: Legacy" for Walt Disney Studios, grossed over $400 million worldwide and was nominated for several awards, including an Academy Award for Sound Editing and a Grammy for the score by Daft Punk.')
GO
SET IDENTITY_INSERT [dbo].[Directors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (1, N'
Action  ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (2, N'Drama     ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (6, N'Adventure ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (7, N'Comedy    ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (8, N'Animation ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (9, N'Fantasy   ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (10, N'Sci-fi    ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (11, N'Crime     ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (12, N'Thriller  ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (13, N'Family    ')
GO
INSERT [dbo].[Genres] ([Id], [Title]) VALUES (14, N'Horror    ')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (2, 12)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (2, 14)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 6)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 7)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 8)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 9)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (3, 10)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (5, 12)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (5, 14)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (6, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (6, 12)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (8, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (8, 11)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (9, 1)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (9, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (10, 2)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (10, 7)
GO
INSERT [dbo].[Movie_Genre] ([MovieId], [GenreId]) VALUES (10, 11)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (2, 1)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (2, 2)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (2, 3)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (3, 4)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (3, 5)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (3, 6)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (5, 7)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (5, 8)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (10, 9)
GO
INSERT [dbo].[Movie_Star] ([MovieId], [StarId]) VALUES (10, 10)
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (2, N'Halloween Ends', CAST(N'2022-10-14' AS Date), N'The saga of Michael Myers and Laurie Strode comes to a spine-chilling climax in this final installment of this trilogy.', N'English', 3, 1)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (3, N'The Super Mario Bros. Movie', CAST(N'2023-04-07' AS Date), N'A plumber named Mario travels through an underground labyrinth with his brother, Luigi, trying to save a captured princess. Feature film adaptation of the popular video game.', N'English', 6, 2)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (5, N'Hellraiser', CAST(N'2022-10-07' AS Date), N'A take on Clive Barker''s 1987 horror classic where a young woman struggling with addiction comes into possession of an ancient puzzle box, unaware that its purpose is to summon the Cenobites.', N'English', 7, 4)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (6, N'
Luckiest Girl Alive', CAST(N'2022-10-07' AS Date), N'A woman in New York, who seems to have things under control, is faced with a trauma that makes her life unravel.', N'English', 8, 5)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (8, N'Broadchurch', CAST(N'2013-03-04' AS Date), N'The murder of a young boy in a small coastal town brings a media frenzy, which threatens to tear the community apart.', N'English', 7, 5)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (9, N'Top Gun: Maverick', CAST(N'2022-05-27' AS Date), N'After thirty years, Maverick is still pushing the envelope as a top naval aviator, but must confront ghosts of his past when he leads TOP GUN''s elite graduates on a mission that demands the ultimate sacrifice from those chosen to fly it.', N'English', 1, 6)
GO
INSERT [dbo].[Movies] ([Id], [Title], [ReleaseDate], [Description], [Language], [ProducerId], [DirectorId]) VALUES (10, N'The Wolf of Wall Street', CAST(N'2014-01-11' AS Date), N'Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.', N'English', 1, 5)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
SET IDENTITY_INSERT [dbo].[Producers] ON 
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (1, N'Paramount Pictures')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (2, N'Disney Channel')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (3, N'Blumhouse Productions')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (4, N'Universal Pictures')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (5, N'Cinemundo')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (6, N'Illumination Entertainment')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (7, N'20th Century Studios')
GO
INSERT [dbo].[Producers] ([Id], [Name]) VALUES (8, N'Made Up Stories')
GO
SET IDENTITY_INSERT [dbo].[Producers] OFF
GO
SET IDENTITY_INSERT [dbo].[Stars] ON 
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (1, N'Jamie Lee Curtis', 0, CAST(N'1958-11-22' AS Date), N'Jamie Lee Curtis was born on November 22, 1958 in Los Angeles, California, the daughter of legendary actors Janet Leigh and Tony Curtis. She got her big break at acting in 1978 when she won the role of Laurie Strode in Halloween (1978). After that, she became famous for roles in movies like Trading Places (1983), Perfect (1985)', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (2, N'Andi Matichak', 0, CAST(N'1970-09-11' AS Date), N'Andi Matichak is an American actress. She has appeared in such television series as 666 Park Avenue, Orange Is the New Black and Blue Bloods. She stars as Allyson Nelson in the horror film Halloween (2018), a direct sequel to the 1978 original film of the same name. Matichak was born in Framingham, Massachusetts, but raised in the suburbs of Chicago, Illinois. She attended St. Francis High School in Wheaton, Illinois. During a summer while still in high school, Matichak worked as a model in Greece, where she met a talent agent who encouraged her to act.', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (3, N'James Jude Courtney', 1, CAST(N'1957-01-31' AS Date), N'James Jude Courtney was born on January 31, 1957 in Portland, Ohio, USA. He is an actor, known for Far and Away (1992), Halloween Kills (2021) ', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (4, N'Chris Pratt', 1, CAST(N'1979-06-21' AS Date), N'Christopher Michael "Chris" Pratt was born on June 21, 1979 in Virginia, Minnesota and raised in Lake Stevens, Washington, to Kathleen Louise (Indahl), who worked at a supermarket, and Daniel Clifton Pratt, who remodeled houses. He is of mostly Norwegian descent. He graduated from Lake Stevens High School in 1997, and has two older siblings.', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (5, N'
Anya Taylor-Joy', 0, CAST(N'1996-04-16' AS Date), N'Anya-Josephine Marie Taylor-Joy (born 16 April 1996) is a British-American actress. She is best known for her roles as Beth Harmon in Gambit H?u (2020), Thomasin in the period horror film Phu Thuy (2015), as Casey Cooke in the horror-thriller Tach Biet (2016)', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (6, N'Charlie Day', 1, CAST(N'1976-02-09' AS Date), N'Charles Peckham Day was born in New York City, NY, and raised in Middletown, Rhode Island. His parents are both music teachers - his mother, Mary (Peckham), is a piano teacher, and his father, Dr. Thomas Charles Day, was a professor of music at Salve Regina University in Newport, Rhode Island. Charlie plays both piano and guitar.', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (7, N'Odessa A’zion', 0, CAST(N'1984-10-01' AS Date), N'Odessa A’zion is known for Hellraiser (2022), Conception (2011) and The Inhabitant (2022).', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (8, N'Jamie Clayton', 0, CAST(N'1978-01-15' AS Date), N'Jamie Clayton''s big break was playing Kyla on season three of the hit HBO series Hung alongside Thomas Jane. After her multi-episode arc on Hung, Jamie joined actors Mary Lynn Rajskub and Hank Harris as a lead in the Emmy winning digital series, Dirty Work, playing crime scene cleanup maven Michelle.', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (9, N'Leonardo DiCaprio', 1, CAST(N'1974-11-11' AS Date), N'Leonardo Wilhelm DiCaprio was born November 11, 1974 in Los Angeles, California, the only child of Irmelin DiCaprio (née Indenbirken) and former comic book artist George DiCaprio. His father is of Italian and German descent, and his mother, who is German-born, is of German and Russian ancestry. His middle name, "Wilhelm", was his maternal grandfather''s first name.', N'USA')
GO
INSERT [dbo].[Stars] ([Id], [FullName], [Male], [Dob], [Description], [Nationality]) VALUES (10, N'Jonah Hill', 1, CAST(N'1983-12-20' AS Date), N'Jonah Hill was born and raised in Los Angeles, the son of Sharon Feldstein (née Chalkin), a fashion designer and costume stylist, and Richard Feldstein, a tour accountant for Guns N'' Roses. He is the brother of music manager Jordan Feldstein and actress Beanie Feldstein.', N'USA')
GO
SET IDENTITY_INSERT [dbo].[Stars] OFF
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_Movie_Genre_Genres]
GO
ALTER TABLE [dbo].[Movie_Genre]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Movie_Genre] CHECK CONSTRAINT [FK_Movie_Genre_Movies]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Star_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK_Movie_Star_Movies]
GO
ALTER TABLE [dbo].[Movie_Star]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Star_Stars] FOREIGN KEY([StarId])
REFERENCES [dbo].[Stars] ([Id])
GO
ALTER TABLE [dbo].[Movie_Star] CHECK CONSTRAINT [FK_Movie_Star_Stars]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Directors]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Producers] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Producers] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Producers]
GO
USE [master]
GO
ALTER DATABASE [PE_PRN_Fall22B1] SET  READ_WRITE 
GO
