namespace Contracts.Domains.Interfaces
{
    public interface IUserTracking
    {
        string CreateBy { set; get; }
        string LastModifiedBy { set; get; }
    }
}
