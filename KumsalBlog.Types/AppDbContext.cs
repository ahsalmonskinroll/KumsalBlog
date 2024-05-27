using KumsalBlog.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KumsalBlog.Types
{
	public class AppDbContext : DbContext
	{
		/// <Options>
		/// veri tabani yolunu bu dbcontextoptions uzerinden verecegiz
		/// </Options>
		/// <param name="options"></param>
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		/// <Dbset>
		/// DbSet ef.core'un bize sağladığı bir nimettir.
		/// </Dbset>
		
		public DbSet<User> User { get; set; } //tablo

		string connectionString = "Data Source=KUMSAL;Initial Catalog=KumsalBlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(connectionString, builder =>
			{
				builder.MigrationsAssembly("KumsalBlog");
			});
		}

		/// <summary>
		/// Model Builder bizim types katmaninda olusturdugumuz configurationlarimizi kaydetmeye yariyor
		/// Assemblyden kaydetmemizin sebebi ise birden cok config olmasi durumunda bize kolaylik saglamasidir-
		/// GetExecutingAssembly de bizim hali hazirda calistigimiz assemblydeki hepsini kaydedecektir.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}
	}
}