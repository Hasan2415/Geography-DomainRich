using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Geography.Domain.Provinces.Entities;
using Geography.Domain.Provinces.ValueObjects;

namespace Geography.ApplicationServices.Provinces;

public class AddProvinceCommandHandler : AddProvinceHandler
{
    private readonly ProvinceRepository _repository;

    public AddProvinceCommandHandler(ProvinceRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(AddProvinceDto dto)
    {
        await StopIfProvinceNameIsExist(dto);
        
        var province = Province.Create(
            ProvinceName.FromString(dto.Name));
        _repository.Add(province);
    }

    private async Task StopIfProvinceNameIsExist(AddProvinceDto dto)
    {
        if (await _repository.IsExistProvinceName(dto.Name))
        {
            throw new InvalidOperationException("این استان قبلا ثبت شده است");
        }
    }
}