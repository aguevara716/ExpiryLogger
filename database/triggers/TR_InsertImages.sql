CREATE OR REPLACE TRIGGER TR_InsertImages
BEFORE INSERT ON Images FOR EACH ROW
BEGIN
    IF new.`File` IS NULL AND new.`Url` IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'You must specify either the [Data] OR [Url]';
    END IF
END;
