using AntDesign;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using NotesApplication.Models;
using NotesPresistence.Dto;
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
    /// Gets or sets a value indicating whether this instance is create.
    /// </summary>
    /// <value><c>true</c> if this instance is create; otherwise, <c>false</c>.</value>
    private bool IsCreate { get; set; } = false;

    /// <summary>
    /// Gets or sets the dto.
    /// </summary>
    /// <value>The dto.</value>
    private CreateNoteDto? Dto { get; set; } = new();

    /// <summary>
    /// Gets or sets the note identifier.
    /// </summary>
    /// <value>The note identifier.</value>
    private string? NoteId { get; set; }

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
    private async void Delete(string id)
    {
        if (Notes != null)
        {
            Notes = Notes.Where(x => x.Id == id).ToList();

            foreach (var note in Notes)
            {
                await NoteService?.DeleteAsync(note.Id)!;
            }

            _total = Notes.Count;
        }

        StateHasChanged();
    }

    /// <summary>
    /// Update as an asynchronous operation.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    private async void UpdateAsync(string id)
    {
        IsCreate = false;

        NoteId = id;
        var ret = await NoteService?.GetIdAsync(id.ToString())!;

        Dto = new CreateNoteDto()
        {
            Title = ret?.Title! ?? "default",
            Details = ret?.Details!
        };
        
        IsVisible = true;
        StateHasChanged();
    }

    /// <summary>
    /// Shows the modal.
    /// </summary>
    private void ShowModal()
    {
        Dto = new CreateNoteDto();

        IsCreate = true;
        IsVisible = true;

        StateHasChanged();
    }

    /// <summary>
    /// Method invoked after each time the component has been rendered. Note that the component does
    /// not automatically re-render after the completion of any returned <see cref="T:System.Threading.Tasks.Task" />, because
    /// that would cause an infinite render loop.
    /// </summary>
    /// <param name="firstRender">Set to <c>true</c> if this is the first time <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> has been invoked
    /// on this component instance; otherwise <c>false</c>.</param>
    /// <returns>A <see cref="T:System.Threading.Tasks.Task" /> representing any asynchronous operation.</returns>
    /// <remarks>The <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender(System.Boolean)" /> and <see cref="M:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync(System.Boolean)" /> lifecycle methods
    /// are useful for performing interop, or interacting with values received from <c>@ref</c>.
    /// Use the <paramref name="firstRender" /> parameter to ensure that initialization work is only performed
    /// once.</remarks>
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        return base.OnAfterRenderAsync(firstRender);
    }
}