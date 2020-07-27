using System.Threading.Tasks;

namespace VotacaoAlterData.Repository
{
    public interface IRepository
    {
        Task<T[]> GetAllAsync<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        //Retorna todos os emprestimos pelo id do livro
        //Task<Emprestimo[]> GetAllEmprestimoByLivroIdAsync(int livroId);



        Task<bool> SaveChangesAsync();
    }
}
