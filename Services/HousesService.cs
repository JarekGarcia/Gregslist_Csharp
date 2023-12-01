

namespace Gregslist_Csharp.Services;

public class HousesService
{
    private readonly HousesRepository _housesRepository;

    public HousesService(HousesRepository housesRepository)
    {
        _housesRepository = housesRepository;
    }

    internal House CreateHouse(House houseData)
    {
        House house = _housesRepository.CreateHouse(houseData);
        return house;
    }

    internal string DeleteHouse(int houseId)
    {
        House house = GetHouseById(houseId);
        _housesRepository.DeleteHouse(houseId);
        return "House has been deleted";
    }

    internal House GetHouseById(int houseId)
    {
        House house = _housesRepository.GetHouseById(houseId);

        if (house == null)
        {
            throw new Exception($"Invalid Id: {houseId}");
        }
        return house;
    }

    internal List<House> GetHouses()
    {
        List<House> houses = _housesRepository.GetHouses();
        return houses;
    }

    internal House UpdateHouse(int houseId, House houseData)
    {
        House originalHouse = GetHouseById(houseId);

        originalHouse.Sqft = houseData.Sqft ?? originalHouse.Sqft;
        originalHouse.Bathrooms = houseData.Bathrooms ?? originalHouse.Bathrooms;
        originalHouse.Bedrooms = houseData.Bedrooms ?? originalHouse.Bedrooms;
        originalHouse.Description = houseData.Description ?? originalHouse.Description;
        originalHouse.Price = houseData.Price ?? originalHouse.Price;
        originalHouse.ImgUrl = houseData.ImgUrl ?? originalHouse.ImgUrl;

        _housesRepository.UpdateHouse(originalHouse);

        return originalHouse;
    }
}