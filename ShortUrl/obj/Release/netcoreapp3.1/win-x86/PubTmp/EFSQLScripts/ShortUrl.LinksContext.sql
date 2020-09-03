  IF EXISTS(SELECT 1 FROM information_schema.tables 
  WHERE table_name = '
'__EFMigrationsHistory'' AND table_schema = DATABASE()) 
BEGIN
CREATE TABLE `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200903012740_InitialMigration')
BEGIN
    CREATE TABLE `Links` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `LongURL` text NULL,
        `ShortUrl` varchar(767) NULL,
        `CreatedData` text NULL,
        `Count` int NOT NULL,
        PRIMARY KEY (`Id`)
    );
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200903012740_InitialMigration')
BEGIN
    CREATE UNIQUE INDEX `IX_Links_ShortUrl` ON `Links` (`ShortUrl`);
END;

IF NOT EXISTS(SELECT * FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20200903012740_InitialMigration')
BEGIN
    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20200903012740_InitialMigration', '3.1.7');
END;

