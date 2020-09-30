namespace TestJudicial123.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstudiosSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO EstudiosJuridicos (Nombre, Direccion, Telefono, Correo) Values ('Estudio Juridico 1', 'El paraiso', '0212123456', 'estudiojuridico1@gmail.com')");
            Sql("INSERT INTO EstudiosJuridicos (Nombre, Direccion, Telefono, Correo) Values ('Estudio Juridico 2', 'Juan Pablo', '0212987654', 'estudiojuridico2@gmail.com')");
            Sql("INSERT INTO EstudiosJuridicos (Nombre, Direccion, Telefono, Correo) Values ('Estudio Juridico 3', 'Montalban', '0413233133', 'estudiojuridico3@gmail.com')");
            Sql("INSERT INTO EstudiosJuridicos (Nombre, Direccion, Telefono, Correo) Values ('Estudio Juridico 4', 'El paraiso', '0412323323', 'estudiojuridico4@gmail.com')");
        }
        
        public override void Down()
        {
        }
    }
}
