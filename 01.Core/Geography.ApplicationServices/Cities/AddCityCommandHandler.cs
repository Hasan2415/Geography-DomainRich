using Geography.Domain.Cities.Contracts;
using Geography.Domain.Cities.Dtos;
using Geography.Domain.Cities.Entities;
using Geography.Domain.Cities.ValueObjects;
using Geography.Domain.Provinces.Contracts;

namespace Geography.ApplicationServices.Cities;

public class AddCityCommandHandler : AddCityHandler
{
    private readonly CityRepository _repository;
    private readonly ProvinceRepository _provinceRepository;

    public AddCityCommandHandler(
        CityRepository repository,
        ProvinceRepository provinceRepository)
    {
        _repository = repository;
        _provinceRepository = provinceRepository;
    }

    public async Task Handle(AddCityDto dto)
    {
        await StopIfCityNameIsExist(dto);
        await StopIfProvinceNotExist(dto);

        var city = City.Create(
            CityName.FromString(dto.Name),
            ProvinceId.FromInt(dto.ProvinceId)
        );

        _repository.Add(city);
    }

    private async Task StopIfProvinceNotExist(AddCityDto dto)
    {
        if (!await _provinceRepository.IsExist(dto.ProvinceId))
        {
            throw new InvalidOperationException("استان پیدا نشد");
        }
    }

    private async Task StopIfCityNameIsExist(AddCityDto dto)
    {
        if (await _repository.IsExist(dto.Name))
        {
            throw new InvalidOperationException("این شهر قبلا ثبت شده است");
        }
    }
}