using System.Data.Entity;
using Classmate.Models;


namespace Classmate.Services
{
    public class Service : DbContext
    {
       
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarea> Tarea { get; set; }

        public DbSet<Nota> Nota { get; set; }

        public DbSet<TemaClass> TemaClass { get; set; }

        public DbSet<HabitoClass> HabitoClass { get; set; }

        public Service() : base("Classmate") { }


        #region Usuario

        public Usuario login(string user, string clave)
        {
            var usuarioLogueado = Usuarios.FirstOrDefault(u => u.NombreUsuario == user && u.Clave == clave);
            if (usuarioLogueado != null)
                return usuarioLogueado;
            else
                throw new Exception("EL USUARIO NO ESTA REGISTRADO");

        }



        public void agregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
            SaveChanges();
        }



        public List<Usuario> mostrarUsuario()
        {
            return Usuarios.ToList();
        }

        public void eliminarUsuario(Usuario usuario)
        {
           Usuarios.Remove(usuario);
            SaveChanges();
        }

        public Usuario buscarUsuario(int id)
        {
            var usuarioBuscado = Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuarioBuscado != null)

                return usuarioBuscado;
            else
                throw new Exception("ESTE USUARIO NO ESTA REGISTRAD0");




        }


        public void actualizarUsuario(Usuario usuario)
        {
            var usuarioActualizado = Usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            if (usuarioActualizado != null)
            {
                usuarioActualizado.Nombre = usuario.Nombre;
                usuarioActualizado.ApellidoUno = usuario.ApellidoUno;
                usuarioActualizado.ApellidoDos = usuario.ApellidoDos;
                usuarioActualizado.NombreUsuario = usuario.NombreUsuario;
                usuarioActualizado.Clave = usuario.Clave;
                usuarioActualizado.Correo = usuario.Correo;
                SaveChanges();

            }
            else
                throw new Exception("ESTE USUARIO NO ESTA REGISTRAD0");

        }

        #endregion



        #region TareaClass

        

        public List<Tarea> buscarTemasTareas(string tema)
        {
            var tareasPorTema = Tarea.Where(n => n.Tema == tema).ToList();
            return tareasPorTema;
        }
        public void agregarTareaNueva(Tarea tarea)
        {
            Tarea.Add(tarea);
            SaveChanges();
        }

        public List<Tarea> mostrarTarea()
        {
            return Tarea.ToList();
        }

        public void eliminarTarea(Tarea tarea)
        {
            Tarea.Remove(tarea);
            SaveChanges();
        }

        public Tarea buscarTarea(int id)
        {
            var tareaBuscada = Tarea.FirstOrDefault(x => x.Id == id);
            if (tareaBuscada != null)
                return tareaBuscada;
            else
                throw new Exception("TAREA NO EXISTE");
        }

        public void actualizarTarea(Tarea tarea)
        {
            var tareaActualizada = Tarea.FirstOrDefault(x => x.Id == tarea.Id);
            if (tareaActualizada != null)

            {
                tareaActualizada.Id = tarea.Id;
                tareaActualizada.Nombre = tarea.Nombre;
                tareaActualizada.Contenido = tarea.Contenido;
                tareaActualizada.Tema = tarea.Tema;
                tareaActualizada.Fecha = tarea.Fecha;

                SaveChanges();
            }
            else
                throw new Exception("TAREA NO EXISTE");
        }


        public void MarcarTareaComoPendiente(int id)
        {
            var tarea = Tarea.FirstOrDefault(x => x.Id == id);
            if (tarea != null)
            {
                tarea.Pendiente = !tarea.Pendiente;
                SaveChanges();
                
            }
            else
            {
                throw new Exception("TAREA NO EXISTE");
            }
        }



        #endregion



        #region NotaClass

       

        public List<Nota> buscarTemasNotas(string tema)
        {
            var notasPorTema = Nota.Where(n => n.Tema == tema).ToList();
            return notasPorTema;
        }

        public void agregarNotaNueva(Nota nota)
        
        {
            Nota.Add(nota);
            SaveChanges();
        }
        public List<Nota> mostrarNota()
        
        {
            return Nota.ToList();
        }
        
        public void eliminarNota(Nota nota)
        {
            Nota.Remove(nota);
            SaveChanges();
        }

        public Nota buscarNota(int id)
        {
            var notaBuscada = Nota.FirstOrDefault(x => x.Id == id);
            if (notaBuscada != null)
                return notaBuscada;
            else
                throw new Exception("NOTA NO EXISTE");
        }
        
        public void actualizarNota(Nota nota)
        {
            var notaActualizada = Nota.FirstOrDefault(x => x.Id == nota.Id);
            if (notaActualizada != null)
            
            {
            notaActualizada.Id = nota.Id;
            notaActualizada.Nombre = nota.Nombre;
            notaActualizada.Contenido = nota.Contenido;
            notaActualizada.Tema = nota.Tema;
            notaActualizada.Fecha = nota.Fecha;

                SaveChanges();
            
            }
            
            else
                throw new Exception("NOTA NO EXISTE");
        
        }



        public void MarcarNotaComoPendiente(int id)
        {
            var nota = Nota.FirstOrDefault(x => x.Id == id);
            if (nota != null)
            {
                nota.Pendiente = !nota.Pendiente;
                SaveChanges();

            }
            else
            {
                throw new Exception("NOTA NO EXISTE");
            }
        }



        #endregion



        #region TemaClass






        public void agregarTemaClass(TemaClass tema)
        {
            TemaClass.Add(tema);
            SaveChanges();
        }

        public List<TemaClass> mostrarTemaClass()
        {
            return TemaClass.ToList();
        }

        public void eliminarTemaClass(TemaClass tema)
        {
            TemaClass.Remove(tema);
            SaveChanges();
        }

        public TemaClass buscarTemaClass(int id)
        {
            var temaCLassBuscada = TemaClass.FirstOrDefault(x => x.Id == id);
            if (temaCLassBuscada != null)
                return temaCLassBuscada;
            else
                throw new Exception("ESTE TEMA NO ESTA REGISTRADO");
        }

        public void actualizarTemaClass(TemaClass tema)
        {
            var temaClassActualizada = TemaClass.FirstOrDefault(x => x.Id == tema.Id);
            if (temaClassActualizada != null)

            {
                temaClassActualizada.Id = tema.Id;
                temaClassActualizada.Tema = tema.Tema;
                
                SaveChanges();
            }
            else
                throw new Exception("ESTE TEMA NO ESTA REGISTRADO");
        }



        #endregion


        #region HabitoClass

        public void agregarHabitoClass(HabitoClass habito)
        {
            HabitoClass.Add(habito);
            SaveChanges();
        }

        public List<HabitoClass> mostrarHabitoClass()
        {
            return HabitoClass.ToList();
        }

        public void eliminarHabitoClass(HabitoClass habito)
        {
            HabitoClass.Remove(habito);
            SaveChanges();
        }

        public HabitoClass buscarHabitoClass(int id)
        {
            var habitoCLassBuscada = HabitoClass.FirstOrDefault(x => x.Id == id);
            if (habitoCLassBuscada != null)
                return habitoCLassBuscada;
            else
                throw new Exception("ESTE HÁBITO NO ESTA REGISTRADO");
        }

        public void actualizarHabitoClass(HabitoClass habito)
        {
            var habitoClassActualizada = HabitoClass.FirstOrDefault(x => x.Id == habito.Id);
            if (habitoClassActualizada != null)

            {
                habitoClassActualizada.Id = habito.Id;
                habitoClassActualizada.Habito = habito.Habito;

                SaveChanges();
            }
            else
                throw new Exception("ESTE HÁBITO NO ESTA REGISTRADO");
        }
        #endregion

    }


}

