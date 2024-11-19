using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

[Table("TeamTodo")]
public partial class TeamTodo
{
    [Key]
    public int Id { get; set; }

    public int? TeamId { get; set; }

    public int? TodoId { get; set; }

    [ForeignKey("TeamId")]
    [InverseProperty("TeamTodos")]
    public virtual Team? Team { get; set; }

    [ForeignKey("TodoId")]
    [InverseProperty("TeamTodos")]
    public virtual Todo? Todo { get; set; }
}
