namespace _14_MVCTodos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            app.MapControllerRoute("default", "{controller=Employee}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
