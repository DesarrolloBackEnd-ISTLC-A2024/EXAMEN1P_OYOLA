create database Furbol


go

use Furbol

go


CREATE TABLE [dbo].[Equipos](
	[ID_Equipo] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Lugar_Equipo] [varchar](50) NULL,
	[Campeonatos_Ganados] [int] NULL,
	[Fecha_Inicio] [date] NOT NULL,
	[Fecha_Fin] [date] NULL,
	[Estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[ID_Equipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Futbolista](
	[ID] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Apellido] [varchar](100) NOT NULL,
	[Numero_Camisa] [int] NULL,
	[Fecha_Nacimiento] [datetime] NULL,
	[Fecha_Retiro] [datetime] NULL,
	[Estado] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Futbolista] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[HistoricoEquipos](
	[ID_HistoricoEquipos] [int] NOT NULL,
	[ID_Futbolista] [int] NOT NULL,
	[ID_Equipo] [int] NOT NULL,
	[Fecha_Inicio] [date] NOT NULL,
	[Fecha_Fin] [date] NULL,
 CONSTRAINT [PK_HistoricoEquipos] PRIMARY KEY CLUSTERED 
(
	[ID_HistoricoEquipos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[HistoricoEquipos]  WITH CHECK ADD FOREIGN KEY([ID_Equipo])
REFERENCES [dbo].[Equipos] ([ID_Equipo])
GO

ALTER TABLE [dbo].[HistoricoEquipos]  WITH CHECK ADD FOREIGN KEY([ID_Futbolista])
REFERENCES [dbo].[Futbolista] ([ID])
GO



CREATE PROCEDURE [dbo].[SP_DEL_Futbolistas]
	@PI_ID INT

AS
BEGIN
	UPDATE [Furbol].[dbo].[Futbolista]
	SET [Estado] = 'I'
	WHERE [ID] = @PI_ID

END
GO


CREATE PROCEDURE [dbo].[SP_GET_Futbolistas]
	@PI_ID INT
AS
BEGIN
	SELECT * FROM [Furbol].[dbo].[Futbolista]
	WHERE [ID] = @PI_ID
END
GO

CREATE PROCEDURE [dbo].[SP_GET_FutbolistasACTIVE]
	
AS
BEGIN
	SELECT * FROM [Furbol].[dbo].[Futbolista]
	WHERE [Estado] = 'A'
END
GO



CREATE PROCEDURE [dbo].[SP_GET_HISTORICOFUTBOLISTAS]
	@PI_ID INT 
AS
BEGIN
	SELECT f.Nombre,  f.Apellido, e.Nombre as nombreequipo, h.Fecha_Inicio, h.Fecha_Fin
	FROM [Furbol].[dbo].[Futbolista] f
	INNER JOIN [Furbol].[dbo].[HistoricoEquipos] h on f.ID = h.ID_Futbolista
	INNER JOIN [Furbol].[dbo].[Equipos] e on h.ID_Equipo = e.ID_Equipo
	WHERE F.ID = @PI_ID

END
GO


CREATE PROCEDURE [dbo].[SP_INS_Futbolistas]
	@PV_Nombre [varchar](100),
	@PV_Apellido [varchar](100),
	@PI_Numero_Camisa [int],
	@PD_Fecha_Nacimiento [datetime],
	@PD_Fecha_Retiro [datetime]

AS
	DECLARE @CONTADOR_ID INTEGER;
BEGIN
	SELECT @CONTADOR_ID=ISNULL(MAX([ID]),0)+1
	FROM [Furbol].[dbo].[Futbolista];

	INSERT INTO [Furbol].[dbo].[Futbolista] ([ID],[Nombre],[Apellido],[Numero_Camisa],[Fecha_Nacimiento],[Fecha_Retiro],[Estado])
	VALUES (@CONTADOR_ID, @PV_Nombre, @PV_Apellido, @PI_Numero_Camisa, @PD_Fecha_Nacimiento,@PD_Fecha_Retiro , 'A')

END
GO



CREATE PROCEDURE [dbo].[SP_UPD_Futbolistas]
	@PI_ID INT,
	@PV_Nombre [varchar](100),
	@PV_Apellido [varchar](100),
	@PI_Numero_Camisa [int],
	@PD_Fecha_Nacimiento [datetime],
	@PD_Fecha_Retiro [datetime]

AS
	
BEGIN
	UPDATE [Furbol].[dbo].[Futbolista]
	SET [Nombre] = @PV_Nombre,
		[Apellido] = @PV_Apellido,
		[Numero_Camisa] = @PI_Numero_Camisa,
		[Fecha_Nacimiento] = @PD_Fecha_Nacimiento,
		[Fecha_Retiro] = @PD_Fecha_Retiro
	WHERE [ID] = @PI_ID

END
GO

