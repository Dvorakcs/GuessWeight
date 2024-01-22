using GuessWeight.Api.Entities;
using GuessWeight.Library.Models;

namespace GuessWeight.Api.Mappings
{
    public static class MappingDtos
    {
        public static UsuarioDto ConvertToDto(this Usuario Usuario)
        {
            return new UsuarioDto();
        }
    }
}
