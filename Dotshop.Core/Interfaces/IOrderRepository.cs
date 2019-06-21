﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dotshop.Core.Models;

namespace Dotshop.Core.Interfaces
{
    public interface IOrderRepository
    {

        Task<IEnumerable<Order>> GetAll();

        Task<Order> GetById(int id);

        //Task<Order> CreateNew(Order);

        //Task<Order> ChangeStatus(int id, byte status);




    }
}