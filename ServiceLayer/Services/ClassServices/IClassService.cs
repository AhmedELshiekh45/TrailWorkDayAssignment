using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using Domain.Models;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.ClassServices
{
    public interface IClassService:IGenericService<ClassDto,Class>
    {
        ValueTask<bool> Exist(int id);
    }
}
