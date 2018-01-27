
using System.Linq;
using RH.Models;

namespace Initializer.Data
{
    public static class DBInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            InitializeTecnologias(context);
            context.SaveChanges();
        }

        private static void InitializeTecnologias(Context context)
        {
            if (context.Tecnologias.Count() > 0)
                return;

            var tecnologias = new Tecnologia[]{
                new Tecnologia{Id=0, Nome= "Tecnologia 1"},
                new Tecnologia{Id=0, Nome= "Tecnologia 2"},
                new Tecnologia{Id=0, Nome= "Tecnologia 3"},
                new Tecnologia{Id=0, Nome= "Tecnologia 4"},
                new Tecnologia{Id=0, Nome= "Tecnologia 5"}
            };

            context.Tecnologias.Concat(tecnologias);
        }
    }
}
