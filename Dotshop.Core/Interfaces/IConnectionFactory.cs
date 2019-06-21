namespace Dotshop.Core
{
    public interface IConnectionFactory <T>
    {
        T Connection();
    }
}
