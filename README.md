# FreelanceHub project
## A basic demonstration of creating a Freelance Hub project using Entity Framework Core.
### Generated SQL script to create the database in MySQL:

#### Table Clients:
```
CREATE TABLE `Clients` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `Address_Street` varchar(50) NOT NULL,
  `Address_City` varchar(50) NOT NULL,
  `Address_Country` varchar(50) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`);
```
#### Table AgencyFreelancers:
```
CREATE TABLE `AgencyFreelancers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `Agency_Name` varchar(50) DEFAULT NULL,
  `Agency_Contact_Email` varchar(100) DEFAULT NULL,
  `Address_Street` varchar(50) NOT NULL,
  `Address_City` varchar(50) NOT NULL,
  `Address_Country` varchar(50) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`);
```
#### Table Projects:
```
CREATE TABLE `Projects` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ClientId` int DEFAULT NULL,
  `Title` varchar(50) NOT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleteDate` datetime(6) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `IX_Projects_ClientId` (`ClientId`),
  KEY `IX_Projects_IsDeleted` (`IsDeleted`),
  CONSTRAINT `FK_Projects_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE SET NULL);
```
#### Table Contracts:
```
CREATE TABLE `Contracts` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProjectId` int DEFAULT NULL,
  `Rate_Type` varchar(20) DEFAULT NULL,
  `MoneyAmount_Amount` decimal(15,3) NOT NULL,
  `MoneyAmount_Currency` varchar(50) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Contracts_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_Contracts_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE SET NULL);
```
#### Table IndpendentFreelancers:
```
CREATE TABLE `IndpendentFreelancers` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  `HourlyRate` int NOT NULL,
  `Availability` varchar(30) NOT NULL,
  `Address_Street` varchar(50) NOT NULL,
  `Address_City` varchar(50) NOT NULL,
  `Address_Country` varchar(50) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`);
```

#### Table Skills:
```
CREATE TABLE `Skills` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Skill_Name` varchar(50) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`);
```
#### Table FreelancerSkills:
```
CREATE TABLE `FreelancerSkills` (
  `FreelancerId` int NOT NULL,
  `SkillId` int NOT NULL,
  `Proficiency` varchar(30) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`FreelancerId`,`SkillId`),
  KEY `IX_FreelancerSkills_SkillId` (`SkillId`),
  CONSTRAINT `FK_FreelancerSkills_Skills_SkillId` FOREIGN KEY (`SkillId`) REFERENCES `Skills` (`Id`) ON DELETE CASCADE);
```
#### Table Invoices:
```
CREATE TABLE `Invoices` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `ProjectId` int NOT NULL,
  `Status` varchar(20) DEFAULT NULL,
  `MoneyAmount_Amount` decimal(15,3) NOT NULL,
  `MoneyAmount_Currency` varchar(50) NOT NULL,
  `IsDeleted` tinyint(1) NOT NULL,
  `DeleteDate` datetime(6) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `IX_Invoices_IsDeleted` (`IsDeleted`),
  KEY `IX_Invoices_ProjectId` (`ProjectId`),
  CONSTRAINT `FK_Invoices_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE);
```
#### Table ProjectFreelancer:
```
CREATE TABLE `ProjectFreelancer` (
  `ProjectId` int NOT NULL,
  `FreelancerId` int NOT NULL,
  `Hours_Allocated` int NOT NULL,
  `Role` varchar(30) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ProjectId`,`FreelancerId`),
  KEY `IX_ProjectFreelancer_FreelancerId` (`FreelancerId`),
  CONSTRAINT `FK_ProjectFreelancer_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE);
```
#### Inserting values to tables:
```
INSERT INTO `AgencyFreelancers` VALUES
(2,'Name2','2026-05-11 09:37:55','2026-05-11 09:37:55','AgencyName2','Email2','Street2','City2','Country2'),
(3,'Name3','2026-05-11 09:37:55','2026-05-11 09:37:55','AgencyName3','Email3','Street3','City3','Country3'),
(5,'Name5','2026-05-11 09:37:55','2026-05-11 09:37:55','AgencyName5','Email5','Street5','City5','Country5');

INSERT INTO `Clients` VALUES
(1,'Name1','Email1','Street1','City1','Country1','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,'Name2','Email2','Street2','City2','Country2','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,'Name3','Email3','Street3','City3','Country3','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,'Name4','Email4','Street4','City4','Country4','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,'Name5','Email5','Street5','City5','Country5','2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `Contracts` VALUES
(1,4,'Hourly',50.000,'USD','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,1,'Fixed',5000.000,'EUR','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,3,'Fixed',75.000,'GBP','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,2,'Hourly',1200.000,'USD','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,5,'Hourly',45.000,'CAD','2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `FreelancerSkills` VALUES
(1,1,'Expert','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(1,2,'Advanced','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,3,'Intermediate','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,4,'Expert','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,5,'Beginner','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,6,'Advanced','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(6,7,'Intermediate','2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `IndpendentFreelancers` VALUES
(1,'Name1','2026-05-11 09:37:55','2026-05-11 09:37:55',50,'Full_Time','Street1','City1','Country1'),
(4,'Name4','2026-05-11 09:37:55','2026-05-11 09:37:55',60,'Part_Time','Street4','City4','Country4'),
(6,'Name6','2026-05-11 09:37:55','2026-05-11 09:37:55',70,'Full_Time','Street6','City6','Country6');

INSERT INTO `Invoices` VALUES
(1,3,'Draft',1500.000,'USD',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,1,'Paid',250.500,'EUR',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,5,'Overdue',3000.000,'GBP',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,4,'Sent',450.000,'USD',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,2,'Paid',1200.000,'CAD',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(6,1,'Draft',85.000,'USD',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `ProjectFreelancer` VALUES
(1,1,40,'Developer','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(1,2,20,'Project_Management','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,3,35,'Designer','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,1,10,'Markting','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,4,15,'Developer','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,5,50,'Project_Management','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,2,30,'Markting','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,6,25,'Developer','2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `Projects` VALUES
(1,3,'Title1','Draft',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,5,'Title2','Overdue',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,4,'Title3','Sent',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,1,'Title4','Overdue',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,2,'Title5','Paid',0,NULL,'2026-05-11 09:37:55','2026-05-11 09:37:55');

INSERT INTO `Skills` VALUES
(1,'C# Development','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(2,'ASP.NET Core','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(3,'React.js','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(4,'SQL Server','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(5,'UI/UX Design','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(6,'DevOps','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(7,'Project Management','2026-05-11 09:37:55','2026-05-11 09:37:55'),
(8,'Mobile App Development','2026-05-11 09:37:55','2026-05-11 09:37:55');
```
