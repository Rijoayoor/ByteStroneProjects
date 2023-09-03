using Model;

public static class CountTechnicianJob
{
    private static ServiceContext _context;
    public static void updatecounttechnician(int? id, ServiceContext context)
    {
        _context = context;
        var technician = _context.ServiceTechnicians.FirstOrDefault(e => e.TechnicianId == id);
        if (technician != null)
        {
            int count = _context.Bookings.Count(b => (b.TechnicianId == id) && (b.Status == "new" || b.Status == "In progress"|| b.Status == "Assigned"));
            technician.Count=count;
            _context.SaveChanges();
        }


    }

}