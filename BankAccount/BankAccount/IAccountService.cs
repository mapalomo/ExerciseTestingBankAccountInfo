
using System.Threading.Tasks;

namespace Bank
{
    public interface IAccountService
    {
        double GetAccountAmount(int accountId);
        Task<double> GetAccountAmountAsync(int accountId);
    }

}
