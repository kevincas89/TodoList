using Entity;
using Site.Models;

namespace Site.Profile
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<NoteDTO, Note>();
        }
    }
}
