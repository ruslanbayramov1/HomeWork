using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

[Index("Role1", Name = "UQ__Roles__DA15413E3E356222", IsUnique = true)]
public partial class Role
{
    [Key]
    public int Id { get; set; }

    [Column("Role")]
    [StringLength(32)]
    public string Role1 { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
