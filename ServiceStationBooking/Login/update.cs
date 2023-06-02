
// public class LoginEndpoint : Endpoint<Login>

// {
//     private readonly AttendanceContext _dbContext;
//     public LoginEndpoint(AttendanceContext dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     public override void Configure()
//     {
//         Post("/api/login");
//         AllowAnonymous();
//     }

//     public override async Task HandleAsync(Login lg, CancellationToken ct)

//     {

//         // Check if the provided username and password match a record in the database

//         var user = await _dbContext.Logins.FirstOrDefaultAsync(u =>

//             u.Username == lg.Username && u.Password == lg.Password && u.Role == lg.Role);
//         if (user != null)

//         {
//             // User credentials are valid

//             await SendAsync("Login successful");
//         }

//         else

//         {
//             // User credentials are invalid

//             await SendAsync("Invalid username or password");
//         }

//     }

// }