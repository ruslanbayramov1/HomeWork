using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Models;

[Index("Username", Name = "UQ__Admins__536C85E4EB5806FF", IsUnique = true)]
public partial class Admin
{
    [Key]
    public int Id { get; set; }

    [StringLength(32)]
    public string Username { get; set; } = null!;

    [StringLength(32)]
    public string Password { get; set; } = null!;
}
