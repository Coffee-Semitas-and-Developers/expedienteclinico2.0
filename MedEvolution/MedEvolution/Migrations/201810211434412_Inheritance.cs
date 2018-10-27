namespace MedEvolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cita",
                c => new
                {
                    IdCita = c.Int(nullable: false, identity: true),
                    FechaCreada = c.DateTime(nullable: false),
                    FechaCita = c.DateTime(nullable: false),
                    Causa = c.String(nullable: false, maxLength: 100),
                    Estado_CodigoEstado = c.Int(nullable: false),
                    Medico_Jvpm = c.String(nullable: false, maxLength: 10),
                    Paciente_IdPaciente = c.String(nullable: false, maxLength: 10),
                })
                .PrimaryKey(t => t.IdCita)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado, cascadeDelete: true)
                .ForeignKey("dbo.Medico", t => t.Medico_Jvpm)
                .ForeignKey("dbo.Paciente", t => t.Paciente_IdPaciente)
                .Index(t => t.Estado_CodigoEstado)
                .Index(t => t.Medico_Jvpm)
                .Index(t => t.Paciente_IdPaciente);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        CodigoEstado = c.Int(nullable: false),
                        NombreEstado = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CodigoEstado);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Dui = c.String(nullable: false, maxLength: 10),
                        Nombre1 = c.String(nullable: false, maxLength: 15),
                        Nombre2 = c.String(maxLength: 15),
                        Apellido1 = c.String(nullable: false, maxLength: 15),
                        Apellido2 = c.String(maxLength: 15),
                        Telefono = c.String(nullable: false, maxLength: 9),
                        Celular = c.String(nullable: false, maxLength: 9),
                        TipoSangre = c.String(maxLength: 10),
                        FechaNac = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false, maxLength: 10),
                        Ocupacion = c.String(nullable: false, maxLength: 30),
                        CorreoElectronico = c.String(nullable: false),
                        Alergia = c.String(nullable: false, maxLength: 50),
                        Discapacidad = c.Boolean(nullable: false),
                        TipoDiscapacidad = c.String(maxLength: 254),
                        NombreMadre = c.String(maxLength: 15),
                        ApellidoMadre = c.String(maxLength: 15),
                        NombrePadre = c.String(maxLength: 15),
                        ApellidoPadre = c.String(maxLength: 15),
                        EstadoCivil = c.String(nullable: false, maxLength: 20),
                        NombreConyugue = c.String(maxLength: 15),
                        ApellidoConyugue = c.String(maxLength: 15),
                        NombreContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        ApellidoContactoEmergencia = c.String(nullable: false, maxLength: 15),
                        TelefonoContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        CelularContactoEmergencia = c.String(nullable: false, maxLength: 9),
                        Direccion_Colonia = c.String(nullable: false, maxLength: 30),
                        Direccion_Pasaje_calle = c.String(nullable: false, maxLength: 30),
                        Direccion_Casa = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Dui)
                .ForeignKey("dbo.Direccion", t => new { t.Direccion_Colonia, t.Direccion_Pasaje_calle, t.Direccion_Casa }, cascadeDelete: true)
                .Index(t => new { t.Direccion_Colonia, t.Direccion_Pasaje_calle, t.Direccion_Casa });
            
            CreateTable(
                "dbo.Clinica",
                c => new
                    {
                        IdClinica = c.Int(nullable: false),
                        NombreClinica = c.String(nullable: false, maxLength: 30),
                        Telefono = c.String(nullable: false, maxLength: 10),
                        FechaApertura = c.DateTime(nullable: false),
                        Direccion_Colonia = c.String(nullable: false, maxLength: 30),
                        Direccion_Pasaje_calle = c.String(nullable: false, maxLength: 30),
                        Direccion_Casa = c.String(nullable: false, maxLength: 30),
                        Director_IdEmpleado = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.IdClinica)
                .ForeignKey("dbo.Direccion", t => new { t.Direccion_Colonia, t.Direccion_Pasaje_calle, t.Direccion_Casa }, cascadeDelete: true)
                .ForeignKey("dbo.Empleado", t => t.Director_IdEmpleado)
                .Index(t => new { t.Direccion_Colonia, t.Direccion_Pasaje_calle, t.Direccion_Casa })
                .Index(t => t.Director_IdEmpleado);
            
            CreateTable(
                "dbo.Direccion",
                c => new
                    {
                        Colonia = c.String(nullable: false, maxLength: 30),
                        Pasaje_calle = c.String(nullable: false, maxLength: 30),
                        Casa = c.String(nullable: false, maxLength: 30),
                        Detalle = c.String(nullable: false, maxLength: 50),
                        Municipio_CodigoMunicipio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Colonia, t.Pasaje_calle, t.Casa })
                .ForeignKey("dbo.Municipio", t => t.Municipio_CodigoMunicipio, cascadeDelete: true)
                .Index(t => t.Municipio_CodigoMunicipio);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        CodigoMunicipio = c.Int(nullable: false),
                        NombreMun = c.String(nullable: false, maxLength: 30),
                        Departamento_CodigoDepartamento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoMunicipio)
                .ForeignKey("dbo.Departamento", t => t.Departamento_CodigoDepartamento, cascadeDelete: true)
                .Index(t => t.Departamento_CodigoDepartamento);
            
            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        CodigoDepartamento = c.Int(nullable: false),
                        NombreDep = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CodigoDepartamento);
            
            CreateTable(
                "dbo.EspecialidadDesempeniada",
                c => new
                    {
                        CodigoEspecialidad = c.Int(nullable: false),
                        NombreEspecialidad = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CodigoEspecialidad);
            
            CreateTable(
                "dbo.HorarioDeAtencion",
                c => new
                    {
                        CodigoHorario = c.Int(nullable: false),
                        HoraInicio = c.DateTime(nullable: false),
                        HoraFin = c.DateTime(nullable: false),
                        NumeroCitasAtender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoHorario);
            
            CreateTable(
                "dbo.ConjuntoSignosVitales",
                c => new
                    {
                        IdSignos = c.Int(nullable: false, identity: true),
                        PresionArterial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Temperatura = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Peso = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PulsoCardiaco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estatura = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdSignos);
            
            CreateTable(
                "dbo.Consulta",
                c => new
                    {
                        IdConsulta = c.Int(nullable: false, identity: true),
                        Sintomatología = c.String(nullable: false, maxLength: 254),
                        Diagnostico = c.String(nullable: false, maxLength: 254),
                        Tratamiento = c.String(nullable: false, maxLength: 254),
                        HoraConsulta = c.DateTime(nullable: false),
                        ProcedimientoEnfermera = c.String(maxLength: 254),
                        Cita_IdCita = c.Int(nullable: false),
                        Signos_IdSignos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdConsulta)
                .ForeignKey("dbo.Cita", t => t.Cita_IdCita, cascadeDelete: true)
                .ForeignKey("dbo.ConjuntoSignosVitales", t => t.Signos_IdSignos, cascadeDelete: true)
                .Index(t => t.Cita_IdCita)
                .Index(t => t.Signos_IdSignos);

            CreateTable(
                "dbo.OrdenExamen",
                c => new
                {
                    IdOrden = c.Int(nullable: false, identity: true),
                    Urgencia = c.Boolean(nullable: false),
                    Resultado = c.Byte(nullable: false),
                    FechaResultado = c.DateTime(nullable: false),
                    Consulta_IdConsulta = c.Int(),
                    Examen_CodigoExamen = c.Int(),
                })
                .PrimaryKey(t => t.IdOrden)
                .ForeignKey("dbo.Consulta", t => t.Consulta_IdConsulta)
                .ForeignKey("dbo.OrdenExamen", t => t.Examen_CodigoExamen)
                .Index(t => t.Examen_CodigoExamen)
                .Index(t => t.Consulta_IdConsulta);


            CreateTable(
                "dbo.Examen",
                c => new
                {
                    CodigoExamen = c.Int(nullable: false),
                    TipoMuestra = c.String(nullable: false, maxLength: 30),
                    NombreExamen = c.String(nullable: false, maxLength: 30),
                })
                .PrimaryKey(t => t.CodigoExamen);

            CreateTable(
                "dbo.Receta",
                c => new
                {
                    IdReceta = c.Int(nullable: false, identity: true),
                    Instrucciones = c.String(nullable: false, maxLength: 254),
                    Consulta_IdConsulta = c.Int(),
                    Medicamento_CodigoMedicamento = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.IdReceta)
                .ForeignKey("dbo.Consulta", t => t.Consulta_IdConsulta)
                .ForeignKey("dbo.Medicamento", t => t.Medicamento_CodigoMedicamento, cascadeDelete: true)
                .Index(t => t.Consulta_IdConsulta)
                .Index(t => t.Medicamento_CodigoMedicamento);
            
            CreateTable(
                "dbo.Medicamento",
                c => new
                    {
                        CodigoMedicamento = c.Int(nullable: false),
                        NombreMedicamento = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CodigoMedicamento);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        CodigoMenu = c.Int(nullable: false, identity: true),
                        Men_codigoMenu = c.Int(),
                        NombreMenu = c.String(nullable: false, maxLength: 15),
                        Rol_CodigoRol = c.Int(),
                    })
                .PrimaryKey(t => t.CodigoMenu)
                .ForeignKey("dbo.Rol", t => t.Rol_CodigoRol)
                .Index(t => t.Rol_CodigoRol);
            
            CreateTable(
                "dbo.Privilegio",
                c => new
                    {
                        CodigoPrivilegio = c.Int(nullable: false, identity: true),
                        NombrePrivilegio = c.String(nullable: false, maxLength: 30),
                        Url = c.String(nullable: false, maxLength: 80),
                        Leer = c.Boolean(nullable: false),
                        Borrar = c.Boolean(nullable: false),
                        Modificar = c.Boolean(nullable: false),
                        Escribir = c.Boolean(nullable: false),
                        Rol_CodigoRol = c.Int(),
                    })
                .PrimaryKey(t => t.CodigoPrivilegio)
                .ForeignKey("dbo.Rol", t => t.Rol_CodigoRol)
                .Index(t => t.Rol_CodigoRol);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        CodigoRol = c.Int(nullable: false, identity: true),
                        NombreRol = c.String(nullable: false, maxLength: 30),
                        Usuario_CorreoElectronicoLaboral = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CodigoRol)
                .ForeignKey("dbo.Usuario", t => t.Usuario_CorreoElectronicoLaboral)
                .Index(t => t.Usuario_CorreoElectronicoLaboral);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        CorreoElectronicoLaboral = c.String(nullable: false, maxLength: 128),
                        Contrasenia = c.String(nullable: false, maxLength: 16),
                        Empleado_IdEmpleado = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CorreoElectronicoLaboral)
                .ForeignKey("dbo.Empleado", t => t.Empleado_IdEmpleado)
                .Index(t => t.Empleado_IdEmpleado);

            CreateTable(
                "dbo.Empleado",
                c => new
                {
                    Dui = c.String(nullable: false, maxLength: 10),
                    Clinica_IdClinica = c.Int(nullable: false),
                    Estado_CodigoEstado = c.Int(nullable: false),
                    Clinica_IdClinica1 = c.Int(),
                    IdEmpleado = c.Int(nullable: false),
                    Cargo = c.String(nullable: false, maxLength: 30),
                    FechaContratacion = c.DateTime(nullable: false),
                    FechaDespido = c.DateTime(),
                    Salario = c.Double(nullable: false),
                    HorasLaborales = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Persona", t => t.Dui)
                .ForeignKey("dbo.Clinica", t => t.Clinica_IdClinica, cascadeDelete: true)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado, cascadeDelete: true)
                .Index(t => t.Dui)
                .Index(t => t.Clinica_IdClinica)
                .Index(t => t.Estado_CodigoEstado);
            
            CreateTable(
                "dbo.Medico",
                c => new
                    {
                        Empleado_IdEmpleado = c.Int(nullable: false, identity: true),
                        Especialidad_Desempeniada_CodigoEspecialidad = c.Int(nullable: false),
                        Horarios_De_Atencion_CodigoHorario = c.Int(nullable: false),
                        Jvpm = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Jvpm)
                .ForeignKey("dbo.Empleado", t => t.Empleado_IdEmpleado)
                .ForeignKey("dbo.EspecialidadDesempeniada", t => t.Especialidad_Desempeniada_CodigoEspecialidad, cascadeDelete: true)
                .ForeignKey("dbo.HorarioDeAtencion", t => t.Horarios_De_Atencion_CodigoHorario, cascadeDelete: true)
                .Index(t => t.Empleado_IdEmpleado)
                .Index(t => t.Especialidad_Desempeniada_CodigoEspecialidad)
                .Index(t => t.Horarios_De_Atencion_CodigoHorario);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Dui = c.String(nullable: false, maxLength: 10),
                        Estado_CodigoEstado = c.Int(nullable: false),
                        IdPaciente = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaDeBaja = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPaciente)
                .ForeignKey("dbo.Persona", t => t.Dui)
                .ForeignKey("dbo.Estado", t => t.Estado_CodigoEstado, cascadeDelete: true)
                .Index(t => t.Dui)
                .Index(t => t.Estado_CodigoEstado);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "Estado_CodigoEstado", "dbo.Estado");
            DropForeignKey("dbo.Paciente", "Dui", "dbo.Persona");
            DropForeignKey("dbo.Medico", "Horarios_De_Atencion_CodigoHorario", "dbo.HorarioDeAtencion");
            DropForeignKey("dbo.Medico", "Especialidad_Desempeniada_CodigoEspecialidad", "dbo.EspecialidadDesempeniada");
            DropForeignKey("dbo.Medico", "IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Empleado", "Estado_CodigoEstado", "dbo.Estado");
            DropForeignKey("dbo.Empleado", "Clinica_IdClinica", "dbo.Clinica");
            DropForeignKey("dbo.Empleado", "Dui", "dbo.Persona");
            DropForeignKey("dbo.Rol", "Usuario_CorreoElectronicoLaboral", "dbo.Usuario");
            DropForeignKey("dbo.Usuario", "Empleado_IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Privilegio", "Rol_CodigoRol", "dbo.Rol");
            DropForeignKey("dbo.Menu", "Rol_CodigoRol", "dbo.Rol");
            DropForeignKey("dbo.Persona", new[] { "Direccion_Colonia", "Direccion_Pasaje_calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Consulta", "Signos_IdSignos", "dbo.ConjuntoSignosVitales");
            DropForeignKey("dbo.Receta", "Medicamento_CodigoMedicamento", "dbo.Medicamento");
            DropForeignKey("dbo.Receta", "Consulta_IdConsulta", "dbo.Consulta");
            DropForeignKey("dbo.OrdenExamen", "Examen_CodigoExamen", "dbo.Examen");
            DropForeignKey("dbo.OrdenExamen", "Consulta_IdConsulta", "dbo.Consulta");
            DropForeignKey("dbo.Consulta", "Cita_IdCita", "dbo.Cita");
            DropForeignKey("dbo.Cita", "Paciente_IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.Cita", "Medico_Jvpm", "dbo.Medico");
            DropForeignKey("dbo.Clinica", "Director_IdEmpleado", "dbo.Empleado");
            DropForeignKey("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_calle", "Direccion_Casa" }, "dbo.Direccion");
            DropForeignKey("dbo.Direccion", "Municipio_CodigoMunicipio", "dbo.Municipio");
            DropForeignKey("dbo.Municipio", "Departamento_CodigoDepartamento", "dbo.Departamento");
            DropForeignKey("dbo.Cita", "Estado_CodigoEstado", "dbo.Estado");
            DropIndex("dbo.Paciente", new[] { "Estado_CodigoEstado" });
            DropIndex("dbo.Paciente", new[] { "Dui" });
            DropIndex("dbo.Medico", new[] { "Horarios_De_Atencion_CodigoHorario" });
            DropIndex("dbo.Medico", new[] { "Especialidad_Desempeniada_CodigoEspecialidad" });
            DropIndex("dbo.Medico", new[] { "Empleado_IdEmpleado" });
            DropIndex("dbo.Empleado", new[] { "Estado_CodigoEstado" });
            DropIndex("dbo.Empleado", new[] { "Clinica_IdClinica" });
            DropIndex("dbo.Empleado", new[] { "Dui" });
            DropIndex("dbo.Usuario", new[] { "Empleado_IdEmpleado" });
            DropIndex("dbo.Rol", new[] { "Usuario_CorreoElectronicoLaboral" });
            DropIndex("dbo.Privilegio", new[] { "Rol_CodigoRol" });
            DropIndex("dbo.Menu", new[] { "Rol_CodigoRol" });
            DropIndex("dbo.Receta", new[] { "Medicamento_CodigoMedicamento" });
            DropIndex("dbo.Receta", new[] { "Consulta_IdConsulta" });
            DropIndex("dbo.OrdenExamen", new[] { "Examen_CodigoExamen" });
            DropIndex("dbo.OrdenExamen", new[] { "Consulta_IdConsulta" });
            DropIndex("dbo.Consulta", new[] { "Signos_IdSignos" });
            DropIndex("dbo.Consulta", new[] { "Cita_IdCita" });
            DropIndex("dbo.Municipio", new[] { "Departamento_CodigoDepartamento" });
            DropIndex("dbo.Direccion", new[] { "Municipio_CodigoMunicipio" });
            DropIndex("dbo.Clinica", new[] { "Director_IdEmpleado" });
            DropIndex("dbo.Clinica", new[] { "Direccion_Colonia", "Direccion_Pasaje_calle", "Direccion_Casa" });
            DropIndex("dbo.Persona", new[] { "Direccion_Colonia", "Direccion_Pasaje_calle", "Direccion_Casa" });
            DropIndex("dbo.Cita", new[] { "Paciente_IdPaciente" });
            DropIndex("dbo.Cita", new[] { "Medico_Jvpm" });
            DropIndex("dbo.Cita", new[] { "Estado_CodigoEstado" });
            DropTable("dbo.Paciente");
            DropTable("dbo.Medico");
            DropTable("dbo.Empleado");
            DropTable("dbo.Usuario");
            DropTable("dbo.Rol");
            DropTable("dbo.Privilegio");
            DropTable("dbo.Menu");
            DropTable("dbo.Medicamento");
            DropTable("dbo.Receta");
            DropTable("dbo.Examen");
            DropTable("dbo.OrdenExamen");
            DropTable("dbo.Consulta");
            DropTable("dbo.ConjuntoSignosVitales");
            DropTable("dbo.HorarioDeAtencion");
            DropTable("dbo.EspecialidadDesempeniada");
            DropTable("dbo.Departamento");
            DropTable("dbo.Municipio");
            DropTable("dbo.Direccion");
            DropTable("dbo.Clinica");
            DropTable("dbo.Persona");
            DropTable("dbo.Estado");
            DropTable("dbo.Cita");
        }
    }
}
