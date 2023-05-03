using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace m02s09_exercicio.Model
{
   public class SemanaContext : DbContext
    {
        public SemanaContext(DbContextOptions<SemanaContext> options) : base(options)
        {             
            //Todo: Configurar migration
            //ToDo: Executar os comandos do migratin
            //ToDo: Inserir, Atualizar, Deletar e Selecionar
        }

        public DbSet<SemanaModel> Semana { get; set; }
    }
}