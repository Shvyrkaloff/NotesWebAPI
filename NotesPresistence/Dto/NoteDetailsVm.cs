using System.Text.Json.Serialization;
using AutoMapper;
using NotesPresistence.Entities;
using NotesPresistence.Mappings;

namespace NotesPresistence.Dto;

/// <summary>
/// Class NoteDetailsVm.
/// Implements the <see cref="IMapWith{Note}" />
/// </summary>
/// <seealso cref="IMapWith{Note}" />
public class NoteDetailsVm : IMapWith<Note>
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
    /// Gets or sets the creation date.
    /// </summary>
    /// <value>The creation date.</value>
    [JsonIgnore]
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Gets or sets the edit date.
    /// </summary>
    /// <value>The edit date.</value>
    [JsonIgnore]
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// Mappings the specified profile.
    /// </summary>
    /// <param name="profile">The profile.</param>
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteDetailsVm>()
            .ForMember(noteVm => noteVm.Title, opt => opt.MapFrom(note => note.Title))
            .ForMember(noteVm => noteVm.Details, opt => opt.MapFrom(note => note.Details))
            .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
            .ForMember(noteVm => noteVm.CreationDate, opt => opt.MapFrom(note => note.CreationDate))
            .ForMember(noteVm => noteVm.EditDate, opt => opt.MapFrom(note => note.EditDate));
    }
}