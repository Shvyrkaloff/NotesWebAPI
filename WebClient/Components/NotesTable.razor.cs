using AntDesign.TableModels;
using AntDesign;
using System.ComponentModel;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
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
    private INoteService NoteService { get; set; }

    WeatherForecast[] forecasts;

    IEnumerable<WeatherForecast> selectedRows;
    ITable table;

    int _pageIndex = 1;
    int _pageSize = 10;
    int _total = 0;

    protected override async Task OnInitializedAsync()
    {
        var ret = NoteService.GetAll();

        forecasts = await GetForecastAsync(1, 50);
        _total = 50;
    }

    public class WeatherForecast
    {
        public int Id { get; set; }

        [DisplayName("Date")]
        public DateTime? Date { get; set; }

        [DisplayName("Temp. (C)")]
        public int TemperatureC { get; set; }

        [DisplayName("Summary")]
        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public bool Hot { get; set; }
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task OnChange(QueryModel<WeatherForecast> queryModel)
    {
        Console.WriteLine(JsonSerializer.Serialize(queryModel));
    }

    public Task<WeatherForecast[]> GetForecastAsync(int pageIndex, int pageSize)
    {
        var rng = new Random();
        return Task.FromResult(Enumerable.Range((pageIndex - 1) * pageSize + 1, pageSize).Select(index =>
        {
            var temperatureC = rng.Next(-20, 55);
            return new WeatherForecast
            {
                Id = index,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = temperatureC,
                Summary = Summaries[rng.Next(Summaries.Length)],
                Hot = temperatureC > 30,
            };
        }).ToArray());
    }

    public void RemoveSelection(int id)
    {
        var selected = selectedRows.Where(x => x.Id != id);
        selectedRows = selected;
    }

    private void Delete(int id)
    {
        forecasts = forecasts.Where(x => x.Id != id).ToArray();
        _total = forecasts.Length;
    }
}