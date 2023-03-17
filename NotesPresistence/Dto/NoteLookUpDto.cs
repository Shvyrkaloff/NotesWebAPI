using AutoMapper;
using NotesPresistence.Entities;
using NotesPresistence.Mappings;

namespace NotesPresistence.Dto;

/// <summary>
/// Class NoteLookUpDto.
/// Implements the <see cref="IMapWith{Note}" />
/// </summary>
/// <seealso cref="IMapWith{Note}" />
public class NoteLookUpDto : IMapWith<Note>
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
    /// Mappings the specified profile.
    /// </summary>
    /// <param name="profile">The profile.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteLookUpDto>()
            .ForMember(noteDto => noteDto.Id, opt => opt.MapFrom(note => note.Id))
            .ForMember(noteDto => noteDto.Title, opt => opt.MapFrom(note => note.Title));
    }
}