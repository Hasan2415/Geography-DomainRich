using Framework.Data;
using Geography.Domain.Provinces.Contracts;
using Geography.Domain.Provinces.Dtos;
using Geography.Domain.Provinces.Entities;
using Geography.Domain.Provinces.ValueObjects;

namespace Geography.ApplicationServices.Provinces;

public class AddProvinceCommandHandler : AddProvinceHandler
{
    private readonly ProvinceRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public AddProvinceCommandHandler(
        ProvinceRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddProvinceDto dto)
    {
        await StopIfProvinceNameIsExist(dto);
        
        var province = Province.Create(
            ProvinceName.FromString(dto.Name));
        
        _repository.Add(province);
        await _unitOfWork.Complete();
    }

    private async Task StopIfProvinceNameIsExist(AddProvinceDto dto)
    {
        if (await _repository.IsExist(dto.Name))
        {
            throw new InvalidOperationException("این استان قبلا ثبت شده است");
        }
    }
}