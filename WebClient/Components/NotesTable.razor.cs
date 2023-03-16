using AntDesign;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using NotesApplication.Models;
using NotesPresistence;
using System.Text.Json;
using WebClient.Services;

namespace WebClient.Components;

/// <summary>
/// Class NotesTable.
/// Implements the <see cref="Microsoft.AspNetCore.Components.ComponentBase" />
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
public partial class NotesTable
{
    /// <summary>
    /// Gets or sets the note service.
    /// </summary>
    /// <value>The note service.</value>
    [Inject]
    private INoteService? NoteService { get; set; }

    /// <summary>
    /// Gets or sets the notes.
    /// </summary>
    /// <value>The notes.</value>
    private List<NoteLookUpDto>? Notes { get; set; } = new();

    /// <summary>
    /// Gets or sets the selected rows.
    /// </summary>
    /// <value>The selected rows.</value>
    private IEnumerable<NoteLookUpDto>? SelectedRows { get; set; }

    /// <summary>
    /// The table
    /// </summary>
    private ITable? _table;

    /// <summary>
    /// The page index
    /// </summary>
    private int _pageIndex = 1;

    /// <summary>
    /// The page size
    /// </summary>
    private int _pageSize = 10;

    /// <summary>
    /// The total
    /// </summary>
    private int _total = 0;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is visible.
    /// </summary>
    /// <value><c>true</c> if this instance is visible; otherwise, <c>false</c>.</value>
    private bool IsVisible { get; set; } = false;

    /// <summary>
    /// Gets or sets the dto.
    /// </summary>
    /// <value>The dto.</value>
    private CreateNoteDto? Dto { get; set; } = new();

    /// <summary>
    /// On initialized as an asynchronous operation.
    /// </summary>
    /// <returns>A Task representing the asynchronous operation.</returns>
    protected override async Task OnInitializedAsync()
    {
        Notes = new List<NoteLookUpDto>();

        var ret = await NoteService?.GetAllAsync()!;

        if (ret != null)
            Notes = ret;

        _total = 50;
    }

    /// <summary>
    /// Called when [change].
    /// </summary>
    /// <param name="queryModel">The query model.</param>
    public async Task OnChange(QueryModel<NoteLookUpDto> queryModel)
    {
        Console.WriteLine(JsonSerializer.Serialize(queryModel));
    }

    /// <summary>
    /// Removes the selection.
    /// </summary>
    /// <param name="id">The identifier.</param>
    public void RemoveSelection(int id)
    {
        var selected = SelectedRows!.Where(x => x.Id != id.ToString());
        SelectedRows = selected;
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    private async void Delete(int id)
    {
        if (Notes != null)
        {
            Notes = Notes.Where(x => x.Id == id.ToString()).ToList();

            foreach (var note in Notes)
            {
                await NoteService?.DeleteAsync(note.Id)!;
            }

            _total = Notes.Count;
        }
    }

    /// <summary>
    /// Update as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    private async void UpdateAsync(string id)
    {
        var ret = await NoteService?.GetIdAsync(id.ToString())!;

        Dto = new CreateNoteDto()
        {
            Title = ret?.Title! ?? "default",
            Details = ret?.Details!
        };

        IsVisible = true;
    }

    /// <summary>
    /// Shows the modal.
    /// </summary>
    private void ShowModal()
    {
        Dto = new CreateNoteDto();

        IsVisible = true;
    }
}