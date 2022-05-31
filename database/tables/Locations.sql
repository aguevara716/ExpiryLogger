-- where in the house a product is stored (e.g. 1st floor fridge, kitchen, etc)
CREATE OR REPLACE TABLE Locations
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Location_Name` UNIQUE (`Name`),
    CreatorUserId INT NOT NULL,
    CONSTRAINT `FK_Location_CreatorUserId`
        FOREIGN KEY (CreatorUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    CreateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdaterUserId INT NOT NULL,
    CONSTRAINT `FK_Location_UpdaterUserId`
        FOREIGN KEY (UpdaterUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    UpdateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
