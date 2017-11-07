CREATE TABLE [dbo].[MstCrew](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CrewId] [varchar](10) NOT NULL,
	[CrewName] [varchar](50) NOT NULL,
	[DrivingLicenseNumber] [varchar](15) NOT NULL,
	[Address] [varchar](300) NOT NULL,
	[PlaceOfBirth] [varchar](15) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [char](1) NOT NULL,
	[Role] [char](1) NOT NULL,
	[IsInDuty] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MstCrew] PRIMARY KEY CLUSTERED 
(
	[CrewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [varchar](10) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[OrganizationName] [varchar](50) NULL,
	[CustomerAddress] [varchar](300) NOT NULL,
	[OrganizationAddress] [varchar](300) NULL,
	[IdNumber] [varchar](30) NOT NULL,
	[CustomerPhone] [varchar](15) NOT NULL,
	[OrganizationPhone] [varchar](15) NULL,
	[OrganizationEmail] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MstCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstFleet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FleetId] [varchar](10) NOT NULL,
	[TypeId] [varchar](10) NOT NULL,
	[LicenseNumber] [varchar](15) NOT NULL,
	[Karoseri] [varchar](10) NOT NULL,
	[SeatCapacity] [int] NOT NULL,
	[IsInUse] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MstFleet] PRIMARY KEY CLUSTERED 
(
	[FleetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MstFleet]  WITH CHECK ADD  CONSTRAINT [FK_MstFleet_MstKaroseri] FOREIGN KEY([Karoseri])
REFERENCES [dbo].[MstKaroseri] ([KaroseriId])

ALTER TABLE [dbo].[MstFleet] CHECK CONSTRAINT [FK_MstFleet_MstKaroseri]

ALTER TABLE [dbo].[MstFleet]  WITH CHECK ADD  CONSTRAINT [FK_MstFleet_MstTypeBus] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MstTypeBus] ([TypeId])

ALTER TABLE [dbo].[MstFleet] CHECK CONSTRAINT [FK_MstFleet_MstTypeBus]

CREATE TABLE [dbo].[MstCustomer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [varchar](10) NOT NULL,
	[CustomerName] [varchar](50) NOT NULL,
	[OrganizationName] [varchar](50) NULL,
	[CustomerAddress] [varchar](300) NOT NULL,
	[OrganizationAddress] [varchar](300) NULL,
	[IdNumber] [varchar](30) NOT NULL,
	[CustomerPhone] [varchar](15) NOT NULL,
	[OrganizationPhone] [varchar](15) NULL,
	[OrganizationEmail] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MstCustomer] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstFleet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FleetId] [varchar](10) NOT NULL,
	[TypeId] [varchar](10) NOT NULL,
	[LicenseNumber] [varchar](15) NOT NULL,
	[Karoseri] [varchar](10) NOT NULL,
	[SeatCapacity] [int] NOT NULL,
	[IsInUse] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MstFleet] PRIMARY KEY CLUSTERED 
(
	[FleetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[MstFleet]  WITH CHECK ADD  CONSTRAINT [FK_MstFleet_MstKaroseri] FOREIGN KEY([Karoseri])
REFERENCES [dbo].[MstKaroseri] ([KaroseriId])

ALTER TABLE [dbo].[MstFleet] CHECK CONSTRAINT [FK_MstFleet_MstKaroseri]

ALTER TABLE [dbo].[MstFleet]  WITH CHECK ADD  CONSTRAINT [FK_MstFleet_MstTypeBus] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MstTypeBus] ([TypeId])

ALTER TABLE [dbo].[MstFleet] CHECK CONSTRAINT [FK_MstFleet_MstTypeBus]

CREATE TABLE [dbo].[MstKaroseri](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KaroseriId] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MstKaroseri] PRIMARY KEY CLUSTERED 
(
	[KaroseriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstMerkBus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MerkId] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MstMerkBus] PRIMARY KEY CLUSTERED 
(
	[MerkId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstService](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ServiceId] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MstService] PRIMARY KEY CLUSTERED 
(
	[ServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[MstTypeBus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeId] [varchar](10) NOT NULL,
	[MerkId] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MstTypeBus] PRIMARY KEY CLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_PADDING OFF

ALTER TABLE [dbo].[MstTypeBus]  WITH CHECK ADD  CONSTRAINT [FK_MstTypeBus_MstMerkBus] FOREIGN KEY([MerkId])
REFERENCES [dbo].[MstMerkBus] ([MerkId])

ALTER TABLE [dbo].[MstTypeBus] CHECK CONSTRAINT [FK_MstTypeBus_MstMerkBus]

CREATE TABLE [dbo].[MstPart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PartId] [varchar](10) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_MstPart] PRIMARY KEY CLUSTERED 
(
	[PartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
