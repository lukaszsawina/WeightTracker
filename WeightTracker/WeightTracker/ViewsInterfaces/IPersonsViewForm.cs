using System.Threading.Tasks;

namespace WeightTracker
{
    public interface IPersonsViewForm
    {
        void InitializeData();
        Task SaveNewPersonAsync();
    }
}