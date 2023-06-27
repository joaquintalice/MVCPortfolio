using Portfolio.Models;

namespace Portfolio.Interfaces
{
    public interface IProjectsRepository
    {
        List<ProjectDTO> GetProjects();
    }

}