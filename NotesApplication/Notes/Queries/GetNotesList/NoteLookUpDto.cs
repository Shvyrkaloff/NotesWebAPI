using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotesApplication.Common.Mappings;
using AutoMapper;
using MediatR;
using NotesDomain;

namespace NotesApplication.Notes.Queries.GetNotesList
{
    public class NoteLookUpDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookUpDto>().ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id)).ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title));
        }
    }
}
