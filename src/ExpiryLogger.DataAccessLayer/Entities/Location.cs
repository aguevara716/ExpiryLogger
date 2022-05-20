﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Locations")]
[Index(nameof(Location.Name), IsUnique = true, Name = "UX_Location_Name")]
public class Location : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [ForeignKey("FK_Location_AddBy")]
    public int AddBy { get; set; }

    [Required]
    public DateTime AddDate { get; set; }

    public Location()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Location location &&
               Id == location.Id &&
               Name == location.Name &&
               AddBy == location.AddBy &&
               AddDate == location.AddDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, AddBy, AddDate);
    }
}
