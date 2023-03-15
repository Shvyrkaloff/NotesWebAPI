using AutoMapper;
using NotesApplication.Notes.Commands.CreateNote;
using NotesPresistence.Mappings;

namespace NotesApplication.Models;

/// <summary>
/// Class CreateNoteDto.
/// Implements the <see cref="CreateNoteCommand" />
/// </summary>
/// <seealso cref="CreateNoteCommand" />
public class CreateNoteDto : IMapWith<CreateNoteCommand>
{
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the details.
    /// </summary>
    /// <value>The details.</value>
    public string Details { get; set; }

    /// <summary>
    /// Mappings the specified profile.
    /// </summary>
    /// <param name="profile">The profile.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}