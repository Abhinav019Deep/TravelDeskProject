using TravelDeskProject.Models;
using TravelDeskProject.ViewModel;

namespace TravelDeskProject.IRepo
{
    public interface ITravelRequestRepo
    {

        string AddRequest(TravelRequest travelRequest);
        TravelRequest GetTravelRequest(int requestId);
        List<TravelRequest> Allrequest();
        
        //void DeleteRequest(int id);
        //void EditRequest(int id, TravelRequest travelRequest);

    }
}
