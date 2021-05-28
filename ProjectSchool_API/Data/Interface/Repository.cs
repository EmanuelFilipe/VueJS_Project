using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Interface
{
    public class Repository : IRepository
    {
        private DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        //GERAL
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }


        //ALUNO
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.Professor);

            //AsNoTracking = não trava recurso
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosByProfessorIdAsync(int professorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.Professor);

            //AsNoTracking = não trava recurso
            query = query.AsNoTracking().Where(a => a.ProfessorId == professorId).OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
                query = query.Include(a => a.Professor);

            //AsNoTracking = não trava recurso
            query = query.AsNoTracking().Where(a => a.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }


        //PROFESSOR
        public async Task<Professor[]> GetAllProfessoresAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
                query = query.Include(a => a.Alunos);

            //AsNoTracking = não trava recurso
            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorByIdAsync(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
                query = query.Include(p => p.Alunos);

            //AsNoTracking = não trava recurso
            query = query.AsNoTracking().Where(p => p.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}