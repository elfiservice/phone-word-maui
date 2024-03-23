namespace Phoneword;

public interface ILatLongService
{
    Task<(double Latitude, double Longitude)> GetLatLong();
}
