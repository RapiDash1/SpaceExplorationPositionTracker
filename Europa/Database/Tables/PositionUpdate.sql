﻿CREATE TABLE [dbo].[PositionUpdate]
(
	[Id] BIGINT NOT NULL IDENTITY(1,1),
	[DeviceKey] UNIQUEIDENTIFIER NOT NULL,
	[Latitude] DECIMAL(8,6) NOT NULL,
	[Longitude] DECIMAL(9,6) NOT NULL,
	[DateTime] DATETIMEOFFSET NOT NULL,
	FOREIGN KEY (DeviceKey) REFERENCES DeviceInfo(DeviceKey)
)