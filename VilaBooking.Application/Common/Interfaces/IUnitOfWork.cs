namespace VilaBooking.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IVilaRepository Vila {get;}
        public IVilaNumberRepository VilaNumber {get;}
        public IAmenityRepository Amenity { get;}
        
        void Save();
    }
}
