using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Base
{
    public class TemplatesRepository : Repository<Templates>, ITemplatesRepository
    {

        private readonly IMapper _mapper;

        public TemplatesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Read
        public TemplatesOutput GetAllActiveTemplates()
        {
            var output = new TemplatesOutput();

            var templates = GetAllWithFilter(x => !x.IsDeleted);
            if (templates.Count > 0)
            {
                output.TemplatesListModel = _mapper.Map<List<TemplatesDto>>(templates);
            }

            return output;
        }

        public TemplatesOutput GetAllTemplates()
        {
            var output = new TemplatesOutput();

            var templates = GetAll();
            if (templates.Count > 0)
            {
                output.TemplatesListModel = _mapper.Map<List<TemplatesDto>>(templates);
            }

            return output;
        }

        public TemplatesOutput GetTemplateById(TemplatesInput input)
        {
            var output = new TemplatesOutput();

            var template = GetWithFilter(x => x.Id == input.Id);
            if (template != null)
            {
                output.TemplatesModel = _mapper.Map<TemplatesDto>(template);
            }

            return output;
        }

        public TemplatesOutput GetAllTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            var templates = GetAllWithFilter(x => x.TypeId == input.TypeId);
            if (templates.Count > 0)
            {
                output.TemplatesListModel = _mapper.Map<List<TemplatesDto>>(templates);
            }
            return output;
        }


        public TemplatesOutput GetAllActiveTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            var templates = GetAllWithFilter(x => x.TypeId == input.TypeId && !x.IsDeleted);
            if (templates.Count > 0)
            {
                output.TemplatesListModel = _mapper.Map<List<TemplatesDto>>(templates);
            }
            return output;
        }
        #endregion

        #region Create, Update, Delete
        public TemplatesOutput CreateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();

            var template = Create(_mapper.Map<Templates>(input));
            if (template != null)
            {
                output.TemplatesModel = _mapper.Map<TemplatesDto>(template);
            }

            return output;
        }

        public TemplatesOutput UpdateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            Update(_mapper.Map<Templates>(input));
            var template = GetWithFilter(x => x.Id == input.Id);
            output.TemplatesModel = _mapper.Map<TemplatesDto>(template);
            return output;
        }

        public bool DeleteTemplate(TemplatesInput input)
        {
            return Delete(_mapper.Map<Templates>(input));
        }

        #endregion

    }
}
