using HW10.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW10.Services
{
    public interface IEntitySaverService
    {
        Task SaveEntity(EntityDTO entity);
    }
}
