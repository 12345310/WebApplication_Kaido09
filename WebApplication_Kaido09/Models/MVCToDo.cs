namespace WebApplication_Kaido09.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MVCToDo : DbContext
    {
        public MVCToDo()
            : base("name=MVCToDo")
        {
        }

        public virtual DbSet<MVCList> MVCList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
