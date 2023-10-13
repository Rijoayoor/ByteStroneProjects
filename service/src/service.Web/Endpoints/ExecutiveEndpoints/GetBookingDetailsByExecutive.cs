// using FastEndpoints;
// using Microsoft.EntityFrameworkCore;
// using Model;
// using service.Core.Services;

// public class GetBookingEndpoint : EndpointWithoutRequest<int>
// {
//     private readonly ExecutiveService _executiveService;
//     public override void Configure()
//     {
//         Get("/api/executive/{id}");
//         AllowAnonymous();
//     }
//     public GetBookingEndpoint(ExecutiveService executiveService)
//     {
//         _executiveService = executiveService;
//     }
//     public override async Task HandleAsync(CancellationToken ct)
//     {
//         var id = Route<int>("id");
//         await SendAsync(id);
//     }
// }