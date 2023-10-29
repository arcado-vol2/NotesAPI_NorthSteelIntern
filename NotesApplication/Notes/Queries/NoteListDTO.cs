using AutoMapper;
using NotesApplication.common.mapping;
using NotesBase;

namespace NotesApplication.Notes.Queries
{
    public class NoteListDTO : IMapWith<Note>
    {
        public Guid ID { get; set; }
        public string head {  get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteListDTO>()
                .ForMember(noteDTO => noteDTO.ID, opt => opt.MapFrom(note => note.ID))
                .ForMember(noteDTO => noteDTO.head, opt => opt.MapFrom(note => note.head));

        }
    }
}
