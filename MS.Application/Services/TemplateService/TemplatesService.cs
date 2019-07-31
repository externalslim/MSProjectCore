using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;

namespace MS.Application.Services.TemplateService
{
    public class TemplatesService : ITemplatesService
    {
        private ITemplatesRepository _templatesRepository;
        private ITypesRepository _typesRepository;
        private IMapper _mapper;
        public TemplatesService(
            ITemplatesRepository templatesRepository,
            ITypesRepository typesRepository,
            IMapper mapper)
        {
            _templatesRepository = templatesRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }



        #region Read
        public TemplatesOutput GetAllActiveTemplates()
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.GetAllActiveTemplates();
            return output;
        }

        public TemplatesOutput GetAllTemplates()
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.GetAllTemplates();
            return output;
        }

        public TemplatesOutput GetTemplateById(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.GetTemplateById(input);
            return output;
        }

        public TemplatesOutput GetAllTemplatesWithTypes()
        {
            var output = new TemplatesOutput();

            output = _templatesRepository.GetAllTemplates();
            var typeIdList = output.TemplatesListModel.Select(x => x.TypeId).ToList();
            if (typeIdList.Count > 0)
            {
                TypeFilter(typeIdList, output);

            }
            return output;
        }

        public TemplatesOutput GetAllActiveTemplatesWithTypes()
        {
            var output = new TemplatesOutput();

            output = _templatesRepository.GetAllActiveTemplates();
            var typeIdList = output.TemplatesListModel.Select(x => x.TypeId).ToList();

            if (typeIdList.Count > 0)
            {
                TypeFilter(typeIdList, output);

            }

            return output;
        }

        public TemplatesOutput GetTemplateWithTypeByTemplateId(TemplatesInput input)
        {
            var output = new TemplatesOutput();

            output = _templatesRepository.GetTemplateById(input);
            if (output.TemplatesModel != null)
            {
                var typeId = output.TemplatesModel.TypeId;
                if (typeId.HasValue && typeId > 0)
                {
                    var typeInput = new TypesInput();
                    typeInput.Id = typeId.Value;
                    var type = _typesRepository.GetTypeById(typeInput);
                    if (type.TypesModel != null)
                    {
                        var typeDto = new TypesDto();
                        typeDto = _mapper.Map<TypesDto>(type.TypesModel);
                        output.TemplatesModel.TypeModel = typeDto;
                    }
                }
            }
            return output;
        }


        public TemplatesOutput GetAllTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.GetAllTemplatesByTypeId(input);
            return output;
        }

        public TemplatesOutput GetAllActiveTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.GetAllActiveTemplatesByTypeId(input);
            return output;
        }
        #endregion


        #region Create, Update, Delete
        public TemplatesOutput CreateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.CreateTemplate(input);
            return output;
        }
        public TemplatesOutput UpdateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesRepository.UpdateTemplate(input);
            return output;
        }
        public bool DeleteTemplate(TemplatesInput input)
        {
            return _templatesRepository.DeleteTemplate(input);
        }
        #endregion

        #region Extends
        private void TypeFilter(List<int?> typeIdList, TemplatesOutput output)
        {
            var types = _typesRepository.GetAllTypes().TypesListModel;
            if (types != null)
            {
                var typeFiltered = types.Where(x => typeIdList.Contains(x.Id));
                foreach (var template in output.TemplatesListModel)
                {
                    template.TypeModel = types.Where(x => x.Id == template.TypeId).SingleOrDefault();
                }
            }
        }
        #endregion
    }
}
