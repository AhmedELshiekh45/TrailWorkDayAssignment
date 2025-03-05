using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOS;
using Domain.Models;
using ServiceLayer.Generic;

namespace ServiceLayer.Services.MarkServces
{
    public interface IMarkService:IGenericService<MarkDto,Mark>
    {
        ValueTask<decimal> GetAvargeMarksForClass(int classid);
    }
}
