﻿using JewelryStore.Business.Base;
using JewelryStore.Common;
using JewelryStore.Data;
using JewelryStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JewelryStore.Business
{
    public interface IOrderItemBusiness
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Save(OrderItem orderItem);
        Task<IBusinessResult> Update(OrderItem orderItem);
        Task<IBusinessResult> DeleteById(int id);
    }
    public class OrderItemBusiness : IOrderItemBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderItemBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            
            try
            {
                #region Business rule
                #endregion

                var orderItems = await _unitOfWork.OrderItemRepository.GetAllAsync();
                foreach (var item in orderItems)
                {
                       item.Subtotal = item.Quantity * item.Price;
                }

                if(orderItems == null)
                {
                    return new BusinessResult(Const.FAIL_READ_CODE,Const.FAIL_READ_MSG);
                }
                else if(orderItems.Count == 0)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA__MSG);
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderItems);
                }

            }
            catch(Exception ex)
            {
                   return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }
        public async Task<IBusinessResult> GetById(int id)
        {

            try
            {
                #region Business rule
                #endregion

                OrderItem orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(id);

                if (orderItem == null)
                {
                    return new BusinessResult(Const.FAIL_READ_CODE, Const.FAIL_READ_MSG);
                }
                else 
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, orderItem);
                }

            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Save(OrderItem orderItem)
        {
            try
            {
                int result = await _unitOfWork.OrderItemRepository.CreateAsync(orderItem);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(OrderItem orderItem)
        {
            try
            {
                int result = await _unitOfWork.OrderItemRepository.UpdateAsync(orderItem);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }   

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(id);
                if (orderItem == null)
                {
                    return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                }
                else
                {
                    bool result = await _unitOfWork.OrderItemRepository.RemoveAsync(orderItem);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG);
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }   
        }

    }
}

