using _14_MVCTodos.Data;
using _14_MVCTodos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Controllers;

public class TeamTodoContainer
{
    public int Id;
    public Team Teams;
    public Todo Todos;
}

public class AdminController : Controller
{
    private static bool _isLoggedIn;
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Admin admin)
    {
        using (MvctodoContext context = new())
        {
            Admin? selectedAdmin = await context.Admins.FirstOrDefaultAsync(adm => adm.Password == admin.Password && adm.Username == admin.Username);

            if (selectedAdmin != null)
            {
                _isLoggedIn = true;
                return RedirectToAction(nameof(Todo));
            }
            else
            {
                _isLoggedIn = false;
                return View(new Admin());
            }
        }
    }

    public async Task<IActionResult> Todo()
    {
        if (!_isLoggedIn)
        {
            return RedirectToAction(nameof(Index));
        }

        using (MvctodoContext context = new())
        {
            var joinedTables = await context.TeamTodos.Join
                (context.Todos,
                teamtodos => teamtodos.TodoId,
                todos => todos.Id,
                (TeamTodos, Todos) => new { TeamTodos, Todos })
                .Join(context.Teams,
                TeamTodosJoined => TeamTodosJoined.TeamTodos.TeamId,
                teams => teams.Id,
                (TeamTodosJoined, Teams) => new { TeamTodosJoined.Todos, TeamTodosJoined.TeamTodos, Teams }
                ).ToListAsync();

            Todo todos = new();
            Team teams = new();
            List<TeamTodoContainer> teamTodos = [];

            joinedTables.ForEach(table =>
            {
                todos = new Todo
                {
                    Id = table.Todos.Id,
                    Title = table.Todos.Title,
                    Description = table.Todos.Description,
                    Deadline = table.Todos.Deadline,
                    IsDone = table.Todos.IsDone,
                    Status = table.Todos.Status,
                };
                teams = new Team
                {
                    Id = table.Teams.Id,
                    Name = table.Teams.Name,
                };

                teamTodos.Add(new TeamTodoContainer
                {
                    Id = table.TeamTodos.Id,
                    Todos = todos,
                    Teams = teams
                });
            });
            return View(teamTodos);
        }
    }

    public async Task<IActionResult> Update(int? id)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        using (MvctodoContext context = new())
        {
            TeamTodo? todo = await context.TeamTodos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            var joinedTables = await context.TeamTodos.Join
                (context.Todos,
                teamtodos => teamtodos.TodoId,
                todos => todos.Id,
                (TeamTodos, Todos) => new { TeamTodos, Todos })
                .Join(context.Teams,
                TeamTodosJoined => TeamTodosJoined.TeamTodos.TeamId,
                teams => teams.Id,
                (TeamTodosJoined, Teams) => new { TeamTodosJoined.Todos, TeamTodosJoined.TeamTodos, Teams }
                ).ToListAsync();

            Todo todos = new();
            Team teams = new();
            TeamTodoContainer teamTodos = new();
            ViewBag.Teams = await context.Teams.ToListAsync();

            joinedTables.ForEach(table =>
            {
                todos = new Todo
                {
                    Id = table.Todos.Id,
                    Title = table.Todos.Title,
                    Description = table.Todos.Description,
                    Deadline = table.Todos.Deadline,
                    IsDone = table.Todos.IsDone,
                    Status = table.Todos.Status,
                };
                teams = new Team
                {
                    Id = table.Teams.Id,
                    Name = table.Teams.Name,
                };

                teamTodos = new TeamTodoContainer
                {
                    Id = table.TeamTodos.Id,
                    Todos = todos,
                    Teams = teams
                };
            });
            return View(teamTodos);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(int? id, string Title, string Description, DateTime Deadline, int TeamId)
    {
        if (!id.HasValue)
        {
            return BadRequest();
        }

        using (MvctodoContext context = new())
        {
            TeamTodo? entity = await context.TeamTodos.FindAsync(id);
            Todo? entityTodo = await context.Todos.FindAsync(entity?.TodoId);
            if (entity == null || entityTodo == null)
            {
                return NotFound();
            }

            entityTodo.Title = Title;
            entityTodo.Description = Description;
            entityTodo.Deadline = Deadline;
            entityTodo.IsDone = false;
            entity.TeamId = TeamId;

            if (Deadline > DateTime.Now)
                entityTodo.Status = "pending";

            if (Deadline < DateTime.Now)
                entityTodo.Status = "failed";

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Todo));
        }
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (!id.HasValue) return BadRequest();

        using (MvctodoContext context = new())
        {
            TeamTodo? entity =  await context.TeamTodos.FindAsync(id);
            if (entity == null) return NotFound();

            context.TeamTodos.Remove(entity);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Todo));
        }
    }

    public async Task<ActionResult> Create()
    {
        using (MvctodoContext context = new())
        {
            List<Team> teams = await context.Teams.ToListAsync() ?? new List<Team>();
            return View(teams);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(string Title, string Description, DateTime Deadline, int TeamId)
    {
        using (MvctodoContext context = new())
        {
            Todo todo = new Todo
            {
                Title = Title,
                Description = Description,
                Deadline = Deadline,
                IsDone = false,
                Status = "pending",
            };

            await context.Todos.AddAsync(todo);
            await context.SaveChangesAsync();
           
            Todo? createdTodo = context.Todos.FirstOrDefault(td => td.Title == todo.Title && td.Description == todo.Description && td.Deadline == todo.Deadline);
            await context.TeamTodos.AddAsync(new TeamTodo
            {
                TeamId = TeamId,
                TodoId = createdTodo?.Id
            });

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Todo));
        }
    }
}
