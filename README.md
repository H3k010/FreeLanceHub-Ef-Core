# FreelanceHub project
## A basic demo for creating a FreelanceHub project using Entity Framework Core.
### Generated SQL script to create the database in MySQL:

#### Table Clients:
#### 
#### CREATE TABLE `Clients` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `Name` VARCHAR(50) NOT NULL,
####    `Email` VARCHAR(50) NOT NULL,
####    `Address_Street` VARCHAR(50) NOT NULL,
####    `Address_City` VARCHAR(50) NOT NULL,
####    `Address_Country` VARCHAR(50) NOT NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`Id`)
#### );

#### Table Freelancer:
####
#### CREATE TABLE `Freelancers` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `Name` VARCHAR(255) NOT NULL,
####    `Type` VARCHAR(50) NOT NULL,
####    `Address_Street` VARCHAR(50) NOT NULL,
####    `Address_City` VARCHAR(50) NOT NULL,
####    `Address_Country` VARCHAR(50) NOT NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `Freelancer` VARCHAR(30) NOT NULL,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    `Agency_Name` VARCHAR(50) NULL,
####    `Agency_Contact_Email` VARCHAR(100) NULL,
####    `HourlyRate` int NULL,
####    `Availability` VARCHAR(30) NULL,
####    PRIMARY KEY (`Id`)
#### );

#### Table Skill:
####
#### CREATE TABLE `Skills` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `Skill_Name` VARCHAR(50) NOT NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`Id`)
#### );

#### Table Projects:
####
#### CREATE TABLE `Projects` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `ClientId` int NULL,
####    `Title` VARCHAR(50) NOT NULL,
####    `Status` VARCHAR(20) NULL,
####    `IsDeleted` tinyint(1) NOT NULL,
####    `DeleteDate` datetime(6) NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`Id`),
####    CONSTRAINT `FK_Projects_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `Clients` (`Id`) ON DELETE SET NULL
#### );

#### Table FreelanceSkill:
####
#### CREATE TABLE `FreelancerSkills` (
####    `FreelancerId` int NOT NULL,
####    `SkillId` int NOT NULL,
####    `Proficiency` VARCHAR(30) NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`FreelancerId`, `SkillId`),
####    CONSTRAINT `FK_FreelancerSkills_Freelancers_FreelancerId` FOREIGN KEY (`FreelancerId`) REFERENCES `Freelancers` (`Id`) ON DELETE CASCADE,
####    CONSTRAINT `FK_FreelancerSkills_Skills_SkillId` FOREIGN KEY (`SkillId`) REFERENCES `Skills` (`Id`) ON DELETE CASCADE
#### );

#### Table Contracts:
####
#### CREATE TABLE `Contracts` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `ProjectId` int NULL,
####    `Rate_Type` VARCHAR(20) NULL,
####    `MoneyAmount_Amount` decimal(15,3) NOT NULL,
####    `MoneyAmount_Currency` VARCHAR(50) NOT NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`Id`),
####    CONSTRAINT `FK_Contracts_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE SET NULL
#### );

#### Table Invoices:
####
#### CREATE TABLE `Invoices` (
####    `Id` int NOT NULL AUTO_INCREMENT,
####    `ProjectId` int NOT NULL,
####    `Status` VARCHAR(20) NULL,
####    `MoneyAmount_Amount` decimal(15,3) NOT NULL,
####    `MoneyAmount_Currency` VARCHAR(50) NOT NULL,
####    `IsDeleted` tinyint(1) NOT NULL,
####    `DeleteDate` datetime(6) NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`Id`),
####    CONSTRAINT `FK_Invoices_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
#### );

#### Table ProjectFreelance:
####
#### CREATE TABLE `ProjectFreelancer` (
####    `ProjectId` int NOT NULL,
####    `FreelancerId` int NOT NULL,
####    `Hours_Allocated` int NOT NULL,
####    `Role` VARCHAR(30) NOT NULL,
####    `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
####    `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
####    PRIMARY KEY (`ProjectId`, `FreelancerId`),
####    CONSTRAINT `FK_ProjectFreelancer_Freelancers_FreelancerId` FOREIGN KEY (`FreelancerId`) REFERENCES `Freelancers` (`Id`) ON DELETE CASCADE,
####    CONSTRAINT `FK_ProjectFreelancer_Projects_ProjectId` FOREIGN KEY (`ProjectId`) REFERENCES `Projects` (`Id`) ON DELETE CASCADE
#### );


### Inserting data to tables:

#### INSERT INTO `Clients` VALUES 
#### (1,'Name1','Email1','Street1','City1','Country1','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,'Name2','Email2','Street2','City2','Country2','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,'Name3','Email3','Street3','City3','Country3','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,'Name4','Email4','Street4','City4','Country4','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,'Name5','Email5','Street5','City5','Country5','2026-05-09 13:27:53','2026-05-09 13:27:53');

#### INSERT INTO `Contracts` VALUES 
#### (1,4,'Hourly',50.000,'USD','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,1,'Fixed',5000.000,'EUR','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,3,'Fixed',75.000,'GBP','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,2,'Hourly',1200.000,'USD','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,5,'Hourly',45.000,'CAD','2026-05-09 13:27:53','2026-05-09 13:27:53');

#### INSERT INTO `FreelancerSkills` VALUES 
#### (1,1,'Expert','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (1,2,'Advanced','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,3,'Intermediate','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,4,'Expert','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,5,'Beginner','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,6,'Advanced','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (6,7,'Intermediate','2026-05-09 13:27:53','2026-05-09 13:27:53');

#### INSERT INTO `Freelancers` VALUES 
#### (1,'Name1','Type1','Street1','City1','Country1','2026-05-09 13:27:53','INDEPENDENT','2026-05-09 13:27:53',NULL,NULL,50,'Full_Time'),
#### (2,'Name2','Type2','Street2','City2','Country2','2026-05-09 13:27:53','AGENCY','2026-05-09 13:27:53','AgencyName2','Email2',NULL,NULL),
#### (3,'Name3','Type3','Street3','City3','Country3','2026-05-09 13:27:53','AGENCY','2026-05-09 13:27:53','AgencyName3','Email3',NULL,NULL),
#### (4,'Name4','Type4','Street4','City4','Country4','2026-05-09 13:27:53','INDEPENDENT','2026-05-09 13:27:53',NULL,NULL,60,'Part_Time'),
#### (5,'Name5','Type5','Street5','City5','Country5','2026-05-09 13:27:53','AGENCY','2026-05-09 13:27:53','AgencyName5','Email5',NULL,NULL),
#### (6,'Name6','Type6','Street6','City6','Country6','2026-05-09 13:27:53','INDEPENDENT','2026-05-09 13:27:53',NULL,NULL,70,'Full_Time');

#### INSERT INTO `Invoices` VALUES 
#### (1,3,'Draft',1500.000,'USD',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,1,'Paid',250.500,'EUR',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,5,'Overdue',3000.000,'GBP',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,4,'Sent',450.000,'USD',1,'2026-05-10 19:36:29.281820','2026-05-09 13:27:53','2026-05-10 16:36:29'),
#### (5,2,'Paid',1200.000,'CAD',1,'2026-05-10 19:36:29.282061','2026-05-09 13:27:53','2026-05-10 16:36:29'),
#### (6,1,'Draft',85.000,'USD',1,'2026-05-10 19:36:29.282124','2026-05-09 13:27:53','2026-05-10 16:36:29');

#### INSERT INTO `ProjectFreelancer` VALUES 
#### (1,1,40,'Developer','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (1,2,20,'Project_Management','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,3,35,'Designer','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,1,10,'Markting','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,4,15,'Developer','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,5,50,'Project_Management','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,2,30,'Markting','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,6,25,'Developer','2026-05-09 13:27:53','2026-05-09 13:27:53');

#### INSERT INTO `Projects` VALUES 
#### (1,3,'Title1','Draft',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,5,'Title2','Overdue',1,'2026-05-10 18:46:50.929594','2026-05-09 13:27:53','2026-05-10 15:46:51'),
#### (3,4,'Title3','Sent',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,1,'Title4','Overdue',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,2,'Title5','Paid',0,NULL,'2026-05-09 13:27:53','2026-05-09 13:27:53');

#### INSERT INTO `Skills` VALUES 
#### (1,'C# Development','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (2,'ASP.NET Core','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (3,'React.js','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (4,'SQL Server','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (5,'UI/UX Design','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (6,'DevOps','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (7,'Project Management','2026-05-09 13:27:53','2026-05-09 13:27:53'),
#### (8,'Mobile App Development','2026-05-09 13:27:53','2026-05-09 13:27:53');


### Creating Indexs:
#### 
#### CREATE UNIQUE INDEX `IX_Contracts_ProjectId` ON `Contracts` (`ProjectId`);
#### CREATE INDEX `IX_FreelancerSkills_SkillId` ON `FreelancerSkills` (`SkillId`);
#### CREATE INDEX `IX_Invoices_IsDeleted` ON `Invoices` (`IsDeleted`);
#### CREATE INDEX `IX_Invoices_ProjectId` ON `Invoices` (`ProjectId`);
#### CREATE INDEX `IX_ProjectFreelancer_FreelancerId` ON `ProjectFreelancer` (`FreelancerId`);
#### CREATE INDEX `IX_Projects_ClientId` ON `Projects` (`ClientId`);
#### CREATE INDEX `IX_Projects_IsDeleted` ON `Projects` (`IsDeleted`);
