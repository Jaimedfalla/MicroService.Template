using MicroService.Template.Application.DTO.Enums;

namespace MicroService.Template.Application.DTO;

public record DiscountDto(int Id, string Name, string Description, decimal Percent,DiscountStatusDto Status);