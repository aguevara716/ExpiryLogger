-- the image of the product we`re looking at
CREATE OR REPLACE TABLE Images
(
    Id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(300) NOT NULL,
    `File` VARCHAR(300),
    CONSTRAINT `UX_Image_File` UNIQUE (`File`),
    `Url` VARCHAR(300),
    CONSTRAINT `UX_Image_Url` UNIQUE (`Url`),
    AddBy INT NOT NULL,
    CONSTRAINT `FK_Image_AddBy`
        FOREIGN KEY (AddBy) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    AddDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
