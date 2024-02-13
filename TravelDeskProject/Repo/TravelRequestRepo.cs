using TravelDeskProject.IRepo;
using TravelDeskProject.Models;

namespace TravelDeskProject.Repo
{
    public class TravelRequestRepo : ITravelRequestRepo
    {
        public TravelDbContext _db;
        public TravelRequestRepo(TravelDbContext db)
        {
            _db = db;
        }

        public string AddRequest(TravelRequest travelRequest)
        {
            travelRequest.IsActive = true;
            _db.TravelRequests.Add(travelRequest);
            _db.SaveChanges();
            return "Added Successfully";

        }

        public List<TravelRequest> Allrequest()
        {
            throw new NotImplementedException();
        }

        public TravelRequest GetTravelRequest(int requestId)
        {
            throw new NotImplementedException();
        }
    }
}
