CREATE OR REPLACE TABLE Products
(
    Id INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    `Name` VARCHAR(500) NOT NULL,
    ExpirationDate DATETIME,
    ImageUri VARCHAR(800),
    CategoryId INT,
    CONSTRAINT `FK_Product_Category`
        FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    LocationId INT,
    CONSTRAINT `FK_Product_Location`
        FOREIGN KEY (LocationId) REFERENCES Locations(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    CreatorUserId INT NOT NULL,
    CONSTRAINT `FK_Product_CreatorUserId`
        FOREIGN KEY (CreatorUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    CreateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdaterUserId INT NOT NULL,
    CONSTRAINT `FK_Product_UpdaterUserId`
        FOREIGN KEY (UpdaterUserId) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    UpdateDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
