using RailwayReservationJWT.Data;
using RailwayReservationJWT.Interface;
using RailwayReservationJWT.Models;

namespace RailwayReservationJWT.Repository
{
    public class TrainDetailRepository : ITrainDetail
    {
        private readonly RailwayContext _context;
        public TrainDetailRepository(RailwayContext context)
        {
            _context = context;
        }
        public TrainDetail Get(int id)
        {
            return _context.trainDetail.FirstOrDefault(u => u.TrainNo == id);
        }
        public List<TrainDetail> GetAll()
        {
            return _context.trainDetail.ToList();
        }
        public TrainDetail Delete(int id)
        {
            TrainDetail train = _context.trainDetail.FirstOrDefault(u => u.TrainNo == id);
            if (train != null)
            {
                _context.trainDetail.Remove(train);
                _context.SaveChanges();
            }
            return train;
        }
        public void Add(TrainDetail journeyDetail)
        {
            _context.trainDetail.Add(journeyDetail);
            _context.SaveChanges();
        }
        public TrainDetail Update(int id, TrainDetail train)
        {
            TrainDetail train1 = _context.trainDetail.FirstOrDefault();
            if (train1 != null)
            {
                train1 = train;
                _context.SaveChanges();
            }
            return train1;
        }
    }
}