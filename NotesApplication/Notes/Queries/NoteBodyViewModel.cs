using AutoMapper;
using NotesApplication.common.mapping;
using NotesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApplication.Notes.Queries
{
    public class NoteBodyViewModel : IMapWith<Note>
    {
        public Guid ID { get; set; }
        public string head {  get; set; }
        public string body { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updatedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteBodyViewModel>()
                .ForMember(noteViewModel => noteViewModel.head, opt => opt.MapFrom(note => note.head))
                .ForMember(noteVm => noteVm.body, opt => opt.MapFrom(note => note.body))
                .ForMember(noteVm => noteVm.ID, opt => opt.MapFrom(note => note.ID))
                .ForMember(noteVm => noteVm.creationDate, opt => opt.MapFrom(note => note.creationDate))
                .ForMember(noteVm => noteVm.updatedDate, opt => opt.MapFrom(note => note.updatedDate));
        }
    }
}
