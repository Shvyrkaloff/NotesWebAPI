using AutoMapper;
using NotesApplication.Notes.Commands.UpdateNote;
using NotesPresistence.Mappings;

namespace NotesApplication.Models;

/// <summary>
/// Class UpdateNoteDto.
/// Implements the <see cref="UpdateNoteDto" />
/// </summary>
/// <seealso cref="UpdateNoteDto" />
public class UpdateNoteDto : IMapWith<UpdateNoteDto>
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public string Id { get; set; }

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
        profile.CreateMap<UpdateNoteDto, UpdateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}