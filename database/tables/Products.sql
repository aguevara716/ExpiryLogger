CREATE OR REPLACE TABLE Products
(
    Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` VARCHAR(500) NOT NULL,
    ExpirationDate DATETIME,
    CategoryId INT,
    CONSTRAINT `FK_Product_Category`
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    ImageId INT,
    CONSTRAINT `FK_Product_Image`
        FOREIGN KEY (ImageId) REFERENCES Images(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    LocationId INT,
    CONSTRAINT `FK_Product_Location`
        FOREIGN KEY (LocationId) REFERENCES Locations(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    AddDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
)
