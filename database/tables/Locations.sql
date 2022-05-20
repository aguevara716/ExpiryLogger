-- where in the house a product is stored (e.g. 1st floor fridge, kitchen, etc)
CREATE OR REPLACE TABLE Locations
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Location_Name` UNIQUE (`Name`),
    AddBy INT NOT NULL,
    CONSTRAINT `FK_Location_AddBy`
        FOREIGN KEY (AddBy) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    AddDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
