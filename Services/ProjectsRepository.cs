using Portfolio.Interfaces;
using Portfolio.Models;

namespace Portfolio.Services
{
    public class ProjectsRepository : IProjectsRepository
    {
        public List<ProjectDTO> GetProjects()
        {
            return new List<ProjectDTO>()
            {
                new ProjectDTO()
                {
                    Title = "Rock Paper Scissors game",
                    Description = "My first project, made mainly with JS, CSS and HTML",
                    ImageURL = "/images/rps-img.png",
                    Link = "https://joaquintalice.github.io/RPSGame/"
                },
                new ProjectDTO()
                {
                    Title = "Etch-A-Sketch",
                    Description = "Paint style project made with JS, CSS and HTML",
                    ImageURL = "/images/etch-a-sketch-img.png",
                    Link = "https://joaquintalice.github.io/Etch-A-Sketch/"
                },
                new ProjectDTO()
                {
                    Title = "Calculator",
                    Description = "Calculator made with JS, CSS and HTML",
                    ImageURL = "/images/calculator-img.png",
                    Link = "https://joaquintalice.github.io/calculator/"
                },
                new ProjectDTO()
                {
                    Title = "Next project",
                    Description = "Here will go my next project made with C# and ASP.NET Core",
                    ImageURL = "",
                    Link = ""
                },
            };
        }
    }
}
