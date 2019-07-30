using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.TypesService
{
    public interface ITypesService
    {
        TypesOutput GetAllTypes();
    }
}
