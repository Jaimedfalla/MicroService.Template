using AutoMapper;
using MicroService.Template.Application.DTO;
using MicroService.Template.Application.Interface.Persistence;
using MicroService.Template.Application.Interface.UseCases;
using MicroService.Template.Application.Validator;
using MicroService.Template.Transversal.Common;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MicroService.Template.Application.UseCases.Discounts
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper    _mapper;
        private readonly DiscountDtoValidator _validator;

        public DiscountApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDtoValidator validator)
        {
            _unitOfWork = unitOfWork;
            _mapper     = mapper;
            _validator  = validator;
        }

        public async Task<Response<bool>> CreateAsync(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            Response<bool> response = new ();
            try
            {
                var validation = await _validator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de validación";
                    response.Errors = validation.Errors;

                    return response;
                }

                var discount = _mapper.Map<Domain.Entities.Discount>(discountDto);
                await _unitOfWork.Discounts.AddAsync(discount);

                response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0 ;
                if(response.Data){
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            Response<bool> response = new ();
            try
            {
                var validation = await _unitOfWork.Discounts.DeleteAsync(id.ToString());
                response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0 ;
                
                if(response.Data){
                    response.IsSuccess = true;
                    response.Message = "Eliminación exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<List<DiscountDto>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            Response<List<DiscountDto>> response = new ();
            try
            {
                var discounts = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<DiscountDto>>(discounts); 
                
                if(response.Data != null ){
                    response.IsSuccess = true;
                    response.Message = "Consulta exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<DiscountDto>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            Response<DiscountDto> response = new ();
            try
            {
                var discount = await _unitOfWork.Discounts.GetAsync(id,cancellationToken);
                
                if(discount == null){
                    response.Message = "No se encontró el registro";

                    return response;
                }
                response.Data = _mapper.Map<DiscountDto>(discount);
                response.IsSuccess = true;
                response.Message = "Consulta exitosa";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> UpdateAsync(DiscountDto discountDto, CancellationToken cancellationToken = default)
        {
            Response<bool> response = new ();
            try
            {
                var validation = await _validator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de validación";
                    response.Errors = validation.Errors;

                    return response;
                }

                var discount = _mapper.Map<Domain.Entities.Discount>(discountDto);
                await _unitOfWork.Discounts.UpdateAsync(discount);

                response.Data = await _unitOfWork.SaveAsync(cancellationToken) > 0 ;
                if(response.Data){
                    response.IsSuccess = true;
                    response.Message = "Actualización exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}