USE [master]
GO
/****** Object:  Table [dbo].[Accomodation]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accomodation](
	[IdAccommodation] [int] IDENTITY(1,1) NOT NULL,
	[IdCity] [int] NOT NULL,
	[NameAccommodation] [text] NULL,
	[StyleAccommodation] [text] NULL,
	[NumberPhoneAccommodation] [text] NULL,
	[AlbumPhotoAccommodation] [text] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Accomodation] PRIMARY KEY CLUSTERED 
(
	[IdAccommodation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Activity]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activity](
	[IdActivity] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NULL,
	[FinalDate] [datetime] NULL,
	[NumberOfPlacesTotal] [int] NULL,
	[Price] [int] NULL,
	[ActivitiesPhotoAlbum] [text] NULL,
 CONSTRAINT [PK_Activity] PRIMARY KEY CLUSTERED 
(
	[IdActivity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityReserved]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityReserved](
	[IdActivityReserved] [int] IDENTITY(1,1) NOT NULL,
	[IdBooking] [int] NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[IdActivity] [int] NOT NULL,
	[IdPayment] [int] NOT NULL,
 CONSTRAINT [PK_ActivityReserved] PRIMARY KEY CLUSTERED 
(
	[IdActivityReserved] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityTrip]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityTrip](
	[IdActivityTrip] [int] IDENTITY(1,1) NOT NULL,
	[IdActivity] [int] NOT NULL,
 CONSTRAINT [PK_ActivityTrip] PRIMARY KEY CLUSTERED 
(
	[IdActivityTrip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AlbumPhoto]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumPhoto](
	[IdAlbumPhoto] [text] NOT NULL,
	[IdCustomer] [int] NULL,
	[InstagramLinks] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authentification]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authentification](
	[IdAuthentification] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NULL,
	[Email] [text] NULL,
	[UserPassword] [text] NULL,
 CONSTRAINT [PK_Authentification] PRIMARY KEY CLUSTERED 
(
	[IdAuthentification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[IdBooking] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NULL,
	[IdPayment] [int] NULL,
	[FIrstValidation] [bit] NULL,
	[FinalValidation] [bit] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[IdBooking] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[City]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[IdCity] [int] IDENTITY(1,1) NOT NULL,
	[NameCity] [text] NULL,
	[ZIPCode] [int] NULL,
	[Departments] [text] NULL,
	[Regions] [text] NULL,
	[NameTrip] [text] NULL,
	[AlbumPhotoTrip] [text] NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[IdCity] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[IdComment] [int] IDENTITY(1,1) NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[TitleComment] [text] NULL,
	[ContentComment] [text] NULL,
	[Star] [decimal](18, 0) NULL,
	[CategoryComment] [text] NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[IdComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[IdCustomer] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [text] NULL,
	[FirstName] [text] NULL,
	[Adress] [text] NULL,
	[City] [text] NULL,
	[ZIPCode] [int] NULL,
	[PhoneNumber] [int] NULL,
	[AlbumPhotoCustomer] [text] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[IdCustomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[IdPayment] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [datetime] NULL,
	[Sum] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[IdPayment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[IdPhoto] [int] IDENTITY(1,1) NOT NULL,
	[Photos] [text] NULL,
	[idTrip] [int] NOT NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[IdPhoto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transport]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transport](
	[IdTransport] [int] IDENTITY(1,1) NOT NULL,
	[IdActivity] [int] NOT NULL,
	[IdCity] [int] NOT NULL,
	[DepartureTime] [time](7) NULL,
	[ArrivingTime] [time](7) NULL,
	[DepartureCity] [text] NULL,
	[ArrivalCity] [text] NULL,
 CONSTRAINT [PK_Transport] PRIMARY KEY CLUSTERED 
(
	[IdTransport] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Trip]    Script Date: 1/11/2021 2:25:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trip](
	[IdTrip] [int] IDENTITY(1,1) NOT NULL,
	[IdComment] [int] NOT NULL,
	[IdCustomer] [int] NOT NULL,
	[IdActivityTrip] [int] NOT NULL,
	[Details] [text] NULL,
	[Title] [text] NULL,
	[StartDate] [datetime] NULL,
	[FinalDate] [datetime] NULL,
	[Price] [int] NULL,
	[NumberOfParticipants] [int] NULL,
 CONSTRAINT [PK_Trip] PRIMARY KEY CLUSTERED 
(
	[IdTrip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accomodation] ON 

INSERT [dbo].[Accomodation] ([IdAccommodation], [IdCity], [NameAccommodation], [StyleAccommodation], [NumberPhoneAccommodation], [AlbumPhotoAccommodation], [Price]) VALUES (2, 1, N'Chalet joyeux', N'Chalet', N'0556443241', N'hebergement_chalet_en_bois.jpg', 30)
SET IDENTITY_INSERT [dbo].[Accomodation] OFF
SET IDENTITY_INSERT [dbo].[Activity] ON 

INSERT [dbo].[Activity] ([IdActivity], [StartDate], [FinalDate], [NumberOfPlacesTotal], [Price], [ActivitiesPhotoAlbum]) VALUES (1, CAST(N'2020-11-24T00:00:00.000' AS DateTime), CAST(N'2020-11-24T00:00:00.000' AS DateTime), 12, 30, N'NULLactivite_jour_apprendre_a_faire_des_cocktails.jpg')
SET IDENTITY_INSERT [dbo].[Activity] OFF
SET IDENTITY_INSERT [dbo].[ActivityTrip] ON 

INSERT [dbo].[ActivityTrip] ([IdActivityTrip], [IdActivity]) VALUES (1, 1)
SET IDENTITY_INSERT [dbo].[ActivityTrip] OFF
SET IDENTITY_INSERT [dbo].[City] ON 

INSERT [dbo].[City] ([IdCity], [NameCity], [ZIPCode], [Departments], [Regions], [NameTrip], [AlbumPhotoTrip]) VALUES (1, N'Saint lary', 9800, N'Ariège', N'Occitanie', N'Bouffée d''aire pure', N'montagne.jpg')
SET IDENTITY_INSERT [dbo].[City] OFF
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([IdComment], [IdCustomer], [TitleComment], [ContentComment], [Star], [CategoryComment]) VALUES (1, 1, N'voyage trop fun', N'j''ai participé à ce voyage trop fun , j''ai kiffé', CAST(3 AS Decimal(18, 0)), N'voyage')
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([IdCustomer], [LastName], [FirstName], [Adress], [City], [ZIPCode], [PhoneNumber], [AlbumPhotoCustomer]) VALUES (1, N'Duval', N'Didier', N'9 rue de la république', N'Saint seurin sur l''isle', 33660, 682233974, NULL)
INSERT [dbo].[Customer] ([IdCustomer], [LastName], [FirstName], [Adress], [City], [ZIPCode], [PhoneNumber], [AlbumPhotoCustomer]) VALUES (2, N'Bernard', N'Corinne', N'14 rue charles péguy', N'Saint seurin sur l''isle', 33660, 634279136, NULL)
INSERT [dbo].[Customer] ([IdCustomer], [LastName], [FirstName], [Adress], [City], [ZIPCode], [PhoneNumber], [AlbumPhotoCustomer]) VALUES (3, N'Brun', N'Pierre', N'3 allée des grands rois', N'Coutras', 33230, 673101023, N'')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([IdPayment], [PaymentDate], [Sum]) VALUES (1, CAST(N'2014-07-24T00:00:00.000' AS DateTime), 600)
INSERT [dbo].[Payment] ([IdPayment], [PaymentDate], [Sum]) VALUES (2, CAST(N'2020-07-24T00:00:00.000' AS DateTime), 300)
SET IDENTITY_INSERT [dbo].[Payment] OFF
SET IDENTITY_INSERT [dbo].[Trip] ON 

INSERT [dbo].[Trip] ([IdTrip], [IdComment], [IdCustomer], [IdActivityTrip], [Details], [Title], [StartDate], [FinalDate], [Price], [NumberOfParticipants]) VALUES (4, 1, 1, 1, N'voyage fun', N'direction funLand', CAST(N'2020-11-23T00:00:00.000' AS DateTime), CAST(N'2020-11-26T00:00:00.000' AS DateTime), 60, 12)
SET IDENTITY_INSERT [dbo].[Trip] OFF
ALTER TABLE [dbo].[Accomodation]  WITH CHECK ADD  CONSTRAINT [FK_Accomodation_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Accomodation] CHECK CONSTRAINT [FK_Accomodation_City]
GO
ALTER TABLE [dbo].[ActivityReserved]  WITH CHECK ADD  CONSTRAINT [FK_ActivityReserved_Activity] FOREIGN KEY([IdActivity])
REFERENCES [dbo].[Activity] ([IdActivity])
GO
ALTER TABLE [dbo].[ActivityReserved] CHECK CONSTRAINT [FK_ActivityReserved_Activity]
GO
ALTER TABLE [dbo].[ActivityReserved]  WITH CHECK ADD  CONSTRAINT [FK_ActivityReserved_Booking] FOREIGN KEY([IdBooking])
REFERENCES [dbo].[Booking] ([IdBooking])
GO
ALTER TABLE [dbo].[ActivityReserved] CHECK CONSTRAINT [FK_ActivityReserved_Booking]
GO
ALTER TABLE [dbo].[ActivityReserved]  WITH CHECK ADD  CONSTRAINT [FK_ActivityReserved_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[ActivityReserved] CHECK CONSTRAINT [FK_ActivityReserved_Customer]
GO
ALTER TABLE [dbo].[ActivityReserved]  WITH CHECK ADD  CONSTRAINT [FK_ActivityReserved_Payment] FOREIGN KEY([IdPayment])
REFERENCES [dbo].[Payment] ([IdPayment])
GO
ALTER TABLE [dbo].[ActivityReserved] CHECK CONSTRAINT [FK_ActivityReserved_Payment]
GO
ALTER TABLE [dbo].[ActivityTrip]  WITH CHECK ADD  CONSTRAINT [FK_ActivityTrip_Activity] FOREIGN KEY([IdActivity])
REFERENCES [dbo].[Activity] ([IdActivity])
GO
ALTER TABLE [dbo].[ActivityTrip] CHECK CONSTRAINT [FK_ActivityTrip_Activity]
GO
ALTER TABLE [dbo].[AlbumPhoto]  WITH CHECK ADD  CONSTRAINT [FK_AlbumPhoto_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[AlbumPhoto] CHECK CONSTRAINT [FK_AlbumPhoto_Customer]
GO
ALTER TABLE [dbo].[AlbumPhoto]  WITH CHECK ADD  CONSTRAINT [FK_AlbumPhoto_Customer1] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[AlbumPhoto] CHECK CONSTRAINT [FK_AlbumPhoto_Customer1]
GO
ALTER TABLE [dbo].[Authentification]  WITH CHECK ADD  CONSTRAINT [FK_Authentification_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[Authentification] CHECK CONSTRAINT [FK_Authentification_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Payment] FOREIGN KEY([IdPayment])
REFERENCES [dbo].[Payment] ([IdPayment])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Payment]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comments_Customer]
GO
ALTER TABLE [dbo].[Photo]  WITH CHECK ADD  CONSTRAINT [FK_Photo_Trip] FOREIGN KEY([idTrip])
REFERENCES [dbo].[Trip] ([IdTrip])
GO
ALTER TABLE [dbo].[Photo] CHECK CONSTRAINT [FK_Photo_Trip]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_Activity] FOREIGN KEY([IdActivity])
REFERENCES [dbo].[Activity] ([IdActivity])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_Activity]
GO
ALTER TABLE [dbo].[Transport]  WITH CHECK ADD  CONSTRAINT [FK_Transport_City] FOREIGN KEY([IdCity])
REFERENCES [dbo].[City] ([IdCity])
GO
ALTER TABLE [dbo].[Transport] CHECK CONSTRAINT [FK_Transport_City]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_ActivityTrip] FOREIGN KEY([IdActivityTrip])
REFERENCES [dbo].[ActivityTrip] ([IdActivityTrip])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_ActivityTrip]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_Comments] FOREIGN KEY([IdComment])
REFERENCES [dbo].[Comment] ([IdComment])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_Comments]
GO
ALTER TABLE [dbo].[Trip]  WITH CHECK ADD  CONSTRAINT [FK_Trip_Customer] FOREIGN KEY([IdCustomer])
REFERENCES [dbo].[Customer] ([IdCustomer])
GO
ALTER TABLE [dbo].[Trip] CHECK CONSTRAINT [FK_Trip_Customer]
GO
USE [master]
GO

