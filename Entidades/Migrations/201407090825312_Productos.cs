namespace Entidades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Productos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Comentarios", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "Comentarios");
        }
    }
}
