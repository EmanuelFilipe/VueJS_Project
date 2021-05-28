using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Interface
{
    public interface IRepository
    {
        //Repositório genérico... poderá receber classes tanto de aluno e de professor

        //GERAL
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor);
        Task<Aluno[]> GetAlunosByProfessorIdAsync(int professorId, bool includeProfessor);
        Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor);

        //PROFESSOR
        Task<Professor[]> GetAllProfessoresAsync(bool includeAluno);
        Task<Professor> GetProfessorByIdAsync(int professorId, bool includeAluno);
    }
}