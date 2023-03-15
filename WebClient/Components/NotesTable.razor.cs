using AntDesign;
using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using NotesPresistence;
using OneOf.Types;
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
    [Inject]
    private INoteService? NoteService { get; set; }

    private List<NoteLookUpDto>? Notes { get; set; } = new();

    private IEnumerable<NoteLookUpDto>? SelectedRows { get; set; }

    private ITable? _table;

    private int _pageIndex = 1;

    private int _pageSize = 10;

    private int _total = 0;

    protected override async Task OnInitializedAsync()
    {
        Notes = new List<NoteLookUpDto>();

        var ret = await NoteService?.GetAll()!;

        if (ret != null)
            Notes = ret;

        _total = 50;
    }

    public async Task OnChange(QueryModel<NoteLookUpDto> queryModel)
    {
        Console.WriteLine(JsonSerializer.Serialize(queryModel));
    }

    public void RemoveSelection(int id)
    {
        var selected = SelectedRows!.Where(x => x.Id != id.ToString());
        SelectedRows = selected;
    }

    private void Delete(int id)
    {
        if (Notes != null)
        {
            Notes = Notes.Where(x => x.Id != id.ToString()).ToList();
            _total = Notes.Count;
        }
    }
}