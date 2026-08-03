using Dilekce597.Models;
using Microsoft.EntityFrameworkCore;

namespace Dilekce597.Data
{
    public class FeedbackDb : DbContext
    {
        public FeedbackDb(DbContextOptions<FeedbackDb> options) : base(options)
        {
        }

        public virtual DbSet<Feedback> Feedbacks { get; set; }
    }
}
