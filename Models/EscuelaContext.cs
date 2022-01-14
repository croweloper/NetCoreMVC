using Microsoft.EntityFrameworkCore;
namespace NetCoreMVC.Models
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluación> Evaluaciones { get; set; }
        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Crear Escuela
            var escuela=CargarEscuela();

            //Cargar Escuela
            modelBuilder.Entity<Escuela>().HasData(escuela);

            //Generar Cursos en la escuela
            var cursos = CargarCursos(escuela);

            //Cargar Cursos
            modelBuilder.Entity<Curso>().HasData(cursos.ToArray());

            //Generar Asignaturas
            var asignaturas=CargarAsignaturas(cursos);

            //Cargar Asignaturas
            modelBuilder.Entity<Asignatura>().HasData(asignaturas.ToArray());

            //Generar Alumnos
            var alumnos=CargarAlumnos(cursos);

            //Cargar Alumnos
            modelBuilder.Entity<Alumno>().HasData(alumnos.ToArray());

            //Cargar Asignaturas
            
            // modelBuilder.Entity<Asignatura>().HasData(
            // new Asignatura { Nombre = "Matemáticas", CursoId = Cursos.Id, Id = Guid.NewGuid().ToString() },
            // new Asignatura { Nombre = "Castellano", Id = Guid.NewGuid().ToString() },
            // new Asignatura { Nombre = "Ciencias Naturales", Id = Guid.NewGuid().ToString() },
            // new Asignatura { Nombre = "Educacion Fisica", Id = Guid.NewGuid().ToString() },
            // new Asignatura { Nombre = "Programacion", Id = Guid.NewGuid().ToString() }
            // );

            //Cargar Alumnos
            //modelBuilder.Entity<Alumno>().HasData(GenerarAlumnosAlAzar().ToArray());
            
        }
        private List<Alumno> CargarAlumnos(List<Curso> cursos)
        {
            var listaAlumnos = new List<Alumno>();

            Random rnd = new Random();
            foreach (var curso in cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                var tmplist = GenerarAlumnosAlAzar(curso, cantRandom);
                listaAlumnos.AddRange(tmplist);
            }
            return listaAlumnos;
        }

        private List<Alumno> GenerarAlumnosAlAzar(Curso curso,int cantidad)
        {
            string[] nombre1 = { "Susana", "Emer", "Alba", "Elsa", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Oria", "Curio", "Pato", "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {a1}",CursoId=curso.Id, Id = Guid.NewGuid().ToString() };

            return listaAlumnos.OrderBy((al) => al.Id).Take(cantidad).ToList();
        }

        private static List<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>(){
                        new Curso() {Id = Guid.NewGuid().ToString(),EscuelaId = escuela.Id,Nombre = "101",Jornada = TiposJornada.Mañana },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Id = Guid.NewGuid().ToString(), EscuelaId = escuela.Id, Nombre = "501", Jornada = TiposJornada.Tarde},
            };
        }

        private static List<Asignatura> CargarAsignaturas(List<Curso> cursos){

            var listaCompleta=new List<Asignatura>();

            foreach (var curso in cursos)
            {
                var tmpList=new List<Asignatura>{
                    new Asignatura { Nombre = "Matemáticas",CursoId=curso.Id, Id = Guid.NewGuid().ToString() },
                    new Asignatura { Nombre = "Castellano", CursoId=curso.Id,Id = Guid.NewGuid().ToString() },
                    new Asignatura { Nombre = "Ciencias Naturales", CursoId=curso.Id,Id = Guid.NewGuid().ToString() },
                    new Asignatura { Nombre = "Educacion Fisica",CursoId=curso.Id, Id = Guid.NewGuid().ToString() },
                    new Asignatura { Nombre = "Programacion",CursoId=curso.Id, Id = Guid.NewGuid().ToString() }
                };
                listaCompleta.AddRange(tmpList);
                //curso.Asignaturas=tmpList;

            }

            return listaCompleta;

        }

        private Escuela CargarEscuela(){

            var escuela = new Escuela();
            escuela.AñoDeCreación = 1992;
            escuela.Id = Guid.NewGuid().ToString();
            escuela.Nombre = "Lider del Norte";
            escuela.Ciudad = "Lima";
            escuela.Pais = "Perú";
            escuela.Dirección = "Av Javier Prado Este 2018";
            escuela.TipoEscuela = TiposEscuela.Secundaria;

            return escuela;
        }

    }
}
