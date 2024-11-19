using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

public partial class Todo
{
    [Key]
    public int Id { get; set; }

    [StringLength(64)]
    public string Title { get; set; } = null!;

    [StringLength(255)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Deadline { get; set; }

    [StringLength(32)]
    [Unicode(false)]
    public string? Status { get; set; }

    public bool? IsDone { get; set; }

    [InverseProperty("Todo")]
    public virtual ICollection<TeamTodo> TeamTodos { get; set; } = new List<TeamTodo>();
}
