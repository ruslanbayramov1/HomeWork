using _14_MVCTodos.Data;
using _14_MVCTodos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _14_MVCTodos.Controllers;

public class EmployeeController : Controller
{
    private static bool _isLoggedIn = false;
    private static int _empId;
    private static int? _empTeamId;
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Employee employee)
    {
        using (MvctodoContext context = new())
        {
            Employee? selectedEmp = await context.Employees.FirstOrDefaultAsync(emp => emp.Password == employee.Password && emp.Username == employee.Username);

            if (selectedEmp != null)
            {
                _isLoggedIn = true;
                _empId = selectedEmp.Id;
                _empTeamId = selectedEmp.TeamId;
                return RedirectToAction(nameof(Todo));
            }
            else
            {
                _isLoggedIn = false;
                return View();
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
                )
                .Join(context.Employees,
                TeamTodosJoined => TeamTodosJoined.Teams.Id,
                employees => employees.Id,
                (TeamTodosJoined, Employees) => new { TeamTodosJoined.Todos, TeamTodosJoined.TeamTodos, TeamTodosJoined.Teams, Employees}
                ).
                Where(tables => tables.Employees.Id == _empId)
                .ToListAsync();


            List<int> failedTodoIds = await context.Todos.Where(teamtodos => teamtodos.Deadline < DateTime.Now && teamtodos.IsDone != true).Select(teamtodos => teamtodos.Id).ToListAsync();
            foreach (int id in failedTodoIds)
            {
                Todo? entity = context.Todos.FirstOrDefault(todo => todo.Id == id);
                entity.Status = "failed";
                entity.IsDone = false;
            }
            
            await context.SaveChangesAsync();

            
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

    [HttpGet]
    public async Task<IActionResult> Update(int? id)
    {
        using (MvctodoContext context = new())
        {
            Todo? todo = await context.Todos.FindAsync(id);

            if (todo == null || todo.Deadline < DateTime.Now) return NotFound();

            todo.IsDone = true;
            todo.Status = "success";

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Todo));
        }
    }
}
