﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExpiryLogger.DataAccessLayer.Entities;

[Table("Categories")]
[Index(nameof(Category.Name), IsUnique = true, Name = "UX_Category_Name")]
public class Category : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; }

    [Required]
    [ForeignKey("FK_Category_CreatorUserId")]
    public int CreatorUserId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    [ForeignKey("FK_Category_UpdaterUserId")]
    public int UpdaterUserId { get; set; }

    [Required]
    public DateTime UpdateDate { get; set; }

    public Category()
    {
        Name = string.Empty;
    }

    public override bool Equals(object? obj)
    {
        return obj is Category category &&
               Id == category.Id &&
               Name == category.Name &&
               CreatorUserId == category.CreatorUserId &&
               CreateDate == category.CreateDate &&
               UpdaterUserId == category.UpdaterUserId &&
               UpdateDate == category.UpdateDate;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, CreatorUserId, CreateDate, UpdaterUserId, UpdateDate);
    }

}
