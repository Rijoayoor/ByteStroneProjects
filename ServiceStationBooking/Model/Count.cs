using Model;

public static class Count
{
    private static ServiceContext _context;
    public static void updatecount(int? id, ServiceContext context)
    {
        _context = context;
        var executive = _context.ServiceExecutives.FirstOrDefault(e => e.ExecutiveId == id);
        if (executive != null)
        {
            int count = _context.Bookings.Count(b => (b.ExecutiveId == id) && (b.Status == "new" || b.Status == "In progress"));
            executive.Count = count;
            _context.SaveChanges();
        }


    }

}