-- the image of the product we`re looking at
CREATE OR REPLACE TABLE Images
(
    Id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
    `File` VARCHAR(300),
    CONSTRAINT `UX_Image_File` UNIQUE (`File`),
    `Url` VARCHAR(300),
    CONSTRAINT `UX_Image_Url` UNIQUE (`Url`)
)
