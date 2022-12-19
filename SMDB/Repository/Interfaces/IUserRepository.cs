using SMDP.SMDPModels;
namespace SMDP.Repository
{
    public interface IUserRepository : IDisposable
    {
        void Register(User request);
        dynamic Login(Userr request);
    }
}
