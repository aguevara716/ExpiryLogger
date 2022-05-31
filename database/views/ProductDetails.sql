CREATE OR REPLACE VIEW ProductDetails
AS
    SELECT
        p.`Id` AS `Id`,
        p.`Name` AS `Name`,
        p.ExpirationDate AS `ExpirationDate`,
        p.ImageUri AS `ImageUri`,
        p.CategoryId AS `CategoryId`,
        c.`Name` AS `CategoryName`,
        p.LocationId AS `LocationId`,
        l.`Name` AS `LocationName`,
        p.CreatorUserId AS `CreatorUserId`,
        u1.Username AS `CreatorUsername`,
        p.CreateDate AS `CreateDate`,
        p.UpdaterUserId AS `UpdaterUserId`,
        u2.Username AS `UpdaterUsername`,
        p.UpdateDate AS `UpdateDate`
    FROM
        Products p
    LEFT JOIN
        Locations l ON p.LocationId = l.Id
    LEFT JOIN
        Categories c ON p.CategoryId = c.Id
    JOIN
        Users u1 ON p.CreatorUserId = u1.Id
    JOIN
    	Users u2 ON p.UpdaterUserId = u2.Id
