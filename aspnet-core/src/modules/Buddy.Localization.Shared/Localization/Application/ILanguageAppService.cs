using System.Collections.Generic;
using Buddy.Localization.Application.Dto;

namespace Buddy.Localization.Application
{
    public interface ILanguageAppService
    {
        List<LanguageDto> GelAll();

        void CreateOrEdit(LanguageEditDto dto);

        void Delete(int dto);
    }
}
