using AntDesign;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using NotesApplication.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using WebClient.Services;

namespace WebClient.Components;

/// <summary>
/// Class CreateNoteModal.
/// Implements the <see cref="Microsoft.AspNetCore.Components.ComponentBase" />
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Components.ComponentBase" />
public partial class CreateNoteModal
{
    [Inject]
    private INoteService? NoteService { get; set; }

    #region original form coding

    /// <summary>
    /// The model
    /// </summary>
    private CreateNoteDto _model = new CreateNoteDto();

    /// <summary>
    /// Called when [finish failed].
    /// </summary>
    /// <param name="editContext">The edit context.</param>
    private void OnFinishFailed(EditContext editContext)
    {
        Console.WriteLine($"Failed:{JsonSerializer.Serialize(_model)}");
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
    [Parameter]
    public bool Visible { get; set; } = false;

    /// <summary>
    /// Handles the cancel.
    /// </summary>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
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
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    private async void HandleOk(MouseEventArgs e)
    {
        var ret = await NoteService?.CreateAsync(_model)!;
        _form.Submit();
    }
}