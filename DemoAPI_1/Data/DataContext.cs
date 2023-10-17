using Microsoft.EntityFrameworkCore;

namespace DemoAPI_1.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }
    }
}
