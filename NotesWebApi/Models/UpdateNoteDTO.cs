using AutoMapper;
using NotesApplication.common.mapping;
using NotesApplication.Notes.Commands;

namespace NotesWebApi.Models
{
    public class UpdateNoteDTO : IMapWith<UpdateNoteCommand>
    {
        public Guid ID { get; set; }
        public string head { get; set; }
        public string body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNoteDTO,UpdateNoteCommand>()
                .ForMember(noteCommand => noteCommand.ID, opt => opt.MapFrom(noteDTO => noteDTO.ID))
                .ForMember(noteCommand => noteCommand.head, opt => opt.MapFrom(noteDTO => noteDTO.head))
                .ForMember(noteCommand => noteCommand.body, opt => opt.MapFrom(noteDTO => noteDTO.body));
        }
    }
}
