using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

[Index("Name", Name = "UQ__Teams__737584F6377EFE22", IsUnique = true)]
public partial class Team
{
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Name { get; set; } = null!;

    [InverseProperty("Team")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    [InverseProperty("Team")]
    public virtual ICollection<TeamTodo> TeamTodos { get; set; } = new List<TeamTodo>();
}
