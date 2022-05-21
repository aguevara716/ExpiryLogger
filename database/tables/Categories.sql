-- the type of product we're looking at (e.g. food)
CREATE OR REPLACE TABLE Categories
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Category_Name` UNIQUE (`Name`),
    CreatorUserId INT NOT NULL,
    CONSTRAINT `FK_Category_CreatorUserId`
        FOREIGN KEY (CreatorUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    CreateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdaterUserId INT NOT NULL,
    CONSTRAINT `FK_Category_UpdaterUserId`
        FOREIGN KEY (UpdaterUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    UpdateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
