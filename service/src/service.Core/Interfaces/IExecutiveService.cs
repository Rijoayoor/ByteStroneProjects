namespace service.Core.Interfaces;
public interface IExecutiveService
{
    Task GetBookingDetailsByExecutive(CancellationToken cancellationToken);
}