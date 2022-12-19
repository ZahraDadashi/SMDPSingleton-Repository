using SMDP.SMDPModels;
using SMDP.Controllers;

namespace SMDP.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SmdpContext _db;

        public UserRepository(SmdpContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
      
        public void Register(User usr)
        {

            _db.Users.Add(usr);
            _db.SaveChanges();
           
        }
        public dynamic Login(Userr userlogin)
        {
            var usertable = _db.Users.Where(i =>
               i.UserName == userlogin.UserName).FirstOrDefault();
            return usertable;
        }

    }
}
