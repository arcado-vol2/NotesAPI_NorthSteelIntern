using AutoMapper;
using NotesApplication.common.mapping;
using NotesApplication.Notes.Commands;

namespace NotesWebApi.Models
{
    public class CreateNoteDTO : IMapWith<CreateNoteCommand>
    {
        public string head {  get; set; }
        public string body { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDTO, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.head, opt => opt.MapFrom(noteDTO => noteDTO.head))
                .ForMember(noteCommand => noteCommand.body, opt => opt.MapFrom(noteDTO => noteDTO.body));
        }
    }
}
