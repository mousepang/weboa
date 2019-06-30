using Microsoft.EntityFrameworkCore;
using WebOa.Models;

namespace WebOa.Data
{
    public class KucunContext : DbContext 
    {
        //这里定义实体数据库模型
        public DbSet<OldHouse> OldHouse { get; set; }
        public DbSet<User> User { set; get; }
        public DbSet<Account> Account { set; get; }
        public DbSet<SalesHistory> SalesHistory { get; set; }
        public DbSet<KucunTable> KucunTable { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<KucunOutHistory> KucunOutHistory { get; set; }
        //这个构造函数是必须的，使用依赖注入必须这么写
        public KucunContext (DbContextOptions<KucunContext> options)
             : base(options)
        {
        }
    }
}
