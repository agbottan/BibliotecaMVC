using BibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();


            // ------------------ Adiciona os LIVROS ------------------

            // Se não existir nenhum livro
            if (!context.Livro.Any())
            {
                var livros = new Livro[]
                {
                    new Livro { Titulo = "PHP para quem conhece PHP",                            Quantidade = 10 },
                    new Livro { Titulo = "Internet das Coisas com ESP8266, Arduino e Raspberry", Quantidade = 10 },
                    new Livro { Titulo = "Gamification em Help Desk e Service Desk",             Quantidade = 10 },
                    new Livro { Titulo = "Avaliação de segurança de redes",                      Quantidade = 10 },
                    new Livro { Titulo = "Desenvolvendo Jogos Mobile com HTML5",                 Quantidade = 10 }
                };

                foreach (Livro l in livros)
                {
                    context.Livro.Add(l);
                }
            }


            // ------------------ Adiciona os AUTORES ------------------

            // Se não existir nenhum autor
            if (!context.Autor.Any())
            {
                var autores = new Autor[]
                {
                    new Autor { Nome = "Sérgio de Oliveira" },
                    new Autor { Nome = "Renato da Silva" },
                    new Autor { Nome = "Paulo Sérgio Travolla" },
                    new Autor { Nome = "Juliano Niederaure" },
                    new Autor { Nome = "Roberto Cohen" },
                    new Autor { Nome = "Cris McNab" },
                    new Autor { Nome = "Luiz Fernando Estevarengo" }
                };

                foreach (Autor a in autores)
                {
                    context.Autor.Add(a);
                }
            }


            // ------------------ Adiciona os USUÁRIOS ------------------

            // Se não existir nenhum usuário
            if (!context.Usuario.Any())
            {
                var usuarios = new Usuario[]
                {
                    new Usuario { Nome = "Teste", Email = "teste@teste.com", Senha = "abc123" }
                };

                foreach (Usuario u in usuarios)
                {
                    context.Usuario.Add(u);
                }
            }


            // ------------------ Salva tudo ------------------

            context.SaveChanges();
        }
    }
}
/* !!!-1
*/