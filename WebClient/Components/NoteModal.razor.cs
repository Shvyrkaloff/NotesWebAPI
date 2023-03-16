using AntDesign;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using NotesApplication.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using WebClient.Services;

namespace WebClient.Components;

/// <summary>
/// Class NoteModal.
/// Implements the <see cref="ComponentBase" />
/// </summary>
/// <seealso cref="ComponentBase" />
public partial class NoteModal
{
    /// <summary>
    /// Gets or sets the note service.
    /// </summary>
    /// <value>The note service.</value>
    [Inject]
    private INoteService? NoteService { get; set; }

    #region original form coding

    /// <summary>
    /// The model
    /// </summary>
    /// <value>The model.</value>
    [Parameter]
    public CreateNoteDto? Model { get; set; } = new();

    /// <summary>
    /// Gets or sets the note identifier.
    /// </summary>
    /// <value>The note identifier.</value>
    [Parameter]
    public string? NoteId { get; set; }

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed:{JsonSerializer.Serialize(Model)}");
    }

    /// <summary>
    /// The loading
    /// </summary>
    private bool _loading = false;

    /// <summary>
    /// Toggles the specified value.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    private void Toggle(bool value) => _loading = value;

    #endregion

    #region original modal coding

    /// <summary>
    /// The visible
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; } = false;

    /// <summary>
    /// Gets or sets the visible changed.
    /// </summary>
    /// <value>The visible changed.</value>
    [Parameter]
    public EventCallback<bool> VisibleChanged { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is create.
    /// </summary>
    /// <value><c>true</c> if this instance is create; otherwise, <c>false</c>.</value>
    [Parameter] 
    public bool IsCreate { get; set; }

    /// <summary>
    /// Handles the <see cref="E:VisibleChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="ChangeEventArgs" /> instance containing the event data.</param>
    private async Task OnVisibleChanged(ChangeEventArgs e)
    {
        Visible = (bool)e.Value!;

        await VisibleChanged.InvokeAsync(Visible);
    }

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private void HandleCancel(MouseEventArgs e)
    {
        Console.WriteLine("e");
        Visible = false;
    }

    #endregion

    /// <summary>
    /// The form
    /// </summary>
    private Form<CreateNoteDto>? _form;

    /// <summary>
    /// when form is submited, close the modal
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinish(EditContext editContext)
    {
        Console.WriteLine("e");
        Visible = false;
    }

    /// <summary>
    /// on modal OK button is click, submit form manually
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    private async void HandleOk(MouseEventArgs e)
    {
        if (IsCreate)
        {
            var ret = await NoteService?.CreateAsync(Model!)!;
            //todo: Update table in NotesTable.razor after create new note
        }
        else
        {
            var ret = await NoteService?.UpdateAsync(new UpdateNoteDto()
            {
                Id = NoteId,
                Title = Model?.Title!,
                Details = Model?.Details!,
            })!;
        }

        _form?.Submit();
        StateHasChanged();
    }
}