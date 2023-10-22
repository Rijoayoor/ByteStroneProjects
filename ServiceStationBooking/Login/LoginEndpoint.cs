using FastEndpoints;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Model;

public class LoginEndpoint : Endpoint<Login>
{
    private readonly ServiceContext _context;
    public LoginEndpoint(ServiceContext context)
    {
        _context = context;
    }
    public override void Configure()
    {
        Post("/api/login");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Login log, CancellationToken ct)
    {
        var user = await _context.Logins.FirstOrDefaultAsync(u =>
            u.Username == log.Username && u.Password == log.Password && u.Userrole == log.Userrole);
        if (user != null)
        {
            await SendAsync(user);
        }
        else
        {
            await SendAsync(null);
        }
    }
}