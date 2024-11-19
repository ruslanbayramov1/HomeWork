using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

[Index("Username", Name = "UQ__Employee__536C85E426186634", IsUnique = true)]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [StringLength(32)]
    public string Name { get; set; } = null!;

    [StringLength(42)]
    public string Surname { get; set; } = null!;

    [StringLength(32)]
    public string Username { get; set; } = null!;

    [StringLength(32)]
    public string Password { get; set; } = null!;

    public int? TeamId { get; set; }

    public int? RoleId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? HireDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Salary { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual Role? Role { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("Employees")]
    public virtual Team? Team { get; set; }
}
