using CorsoWebApi.Models;

namespace CorsoWebApi.Service
{
    public interface IBigliettoService
    {
        Biglietto Get(int id);
        Biglietto[] Get();
        Biglietto Add(Biglietto biglietto);
        Biglietto Update(Biglietto biglietto, int id);
        void Delete(int id);
    }
}