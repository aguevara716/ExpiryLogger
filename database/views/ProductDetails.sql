CREATE OR REPLACE VIEW ProductDetails
AS
    SELECT
        p.`Id` as `ProductId`,
        p.`Name` as `Name`,
        p.ExpirationDate as `ExpirationDate`,
        p.CategoryId as `CategoryId`,
        c.`Name` as `CategoryName`,
        p.ImageId as `ImageId`,
        i.`File` as `ImageFile`,
        i.`Url` as `ImageUrl`,
        p.LocationId as `LocationId`,
        l.`Name` as `LocationName`,
        p.AddDate as `AddDate`
    FROM
        Products p
    LEFT JOIN
        Locations l on p.LocationId = l.Id
    LEFT JOIN
        Categories c on p.CategoryId = c.Id
    LEFT JOIN
        Images i on p.ImageId = i.Id