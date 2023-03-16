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
    [Parameter]
    public CreateNoteDto Model { get; set; } = new();

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
    bool loading = false;

    /// <summary>
    /// Toggles the specified value.
    /// </summary>
    /// <param name="value">if set to <c>true</c> [value].</param>
    void toggle(bool value) => loading = value;

    #endregion

    #region original modal coding

    /// <summary>
    /// The visible
    /// </summary>
    /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
    [Parameter]
    public bool Visible { get; set; } = false;

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
    private Form<CreateNoteDto> _form;

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
        var ret = await NoteService?.CreateAsync(Model)!;
        _form.Submit();
    }
}