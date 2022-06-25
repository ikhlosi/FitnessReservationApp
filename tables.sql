CREATE TABLE [dbo].[Client] (
    [ID]    INT          IDENTITY (1, 1) NOT NULL,
    [Fname] VARCHAR (50) NOT NULL,
    [Lname] VARCHAR (50) NOT NULL,
    [Email] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Device] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [Type]      VARCHAR (50) NOT NULL,
    [Is_usable] BIT          NOT NULL,
    CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Reservation] (
    [ID]               INT  IDENTITY (1, 1) NOT NULL,
    [Client_id]        INT  NOT NULL,
    [Reservation_date] DATE NOT NULL,
    CONSTRAINT [PK_Reservation_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Reservationdetails] (
    [ID]             INT IDENTITY (1, 1) NOT NULL,
    [Reservation_id] INT NOT NULL,
    [Device_id]      INT NOT NULL,
    [Timeslot_id]    INT NOT NULL,
    CONSTRAINT [PK_Reservationdetails] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Timeslot] (
    [ID]   INT          IDENTITY (1, 1) NOT NULL,
    [Slot] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Timeslot] PRIMARY KEY CLUSTERED ([ID] ASC)
);

