namespace ExpiryLogger.DataAccessLayer.Entities;

public interface IEntity
{
    int Id { get; set; }

    int CreatorUserId { get; set; }
    DateTime CreateDate { get; set; }

    int UpdaterUserId { get; set; }
    DateTime UpdateDate { get; set; }
}
