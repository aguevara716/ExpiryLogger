-- where in the house a product is stored (e.g. 1st floor fridge, kitchen, etc)
CREATE OR REPLACE TABLE Locations
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Location_Name` UNIQUE (`Name`)
)