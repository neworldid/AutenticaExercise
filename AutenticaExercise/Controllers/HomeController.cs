using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using AutenticaExercise.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;

namespace AutenticaExercise.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var locations = GetFormattedDataFromCsv();
        var borderLocations = new List<CentroidModel?>
        {
            locations.MaxBy(x => x.DD_N),
            locations.MinBy(x => x.DD_N),
            locations.MaxBy(x => x.DD_E),
            locations.MinBy(x => x.DD_E)
        };

        ViewBag.BorderLocations = JsonSerializer.Serialize(borderLocations);
        return View();
    }

    public JsonResult GetLocations(string subString)
    {
        var locations = GetFormattedDataFromCsv();
        var filteredLocations = locations.Where(x => x.Name.Contains(subString)).ToList();
        
        return Json(new{data = filteredLocations});
    }

    private static List<CentroidModel>? GetFormattedDataFromCsv()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";"
        };

        List<CentroidModel>? formattedLocations;
        using (var reader = new StreamReader("wwwroot/data/AW_VIETU_CENTROIDI.csv"))
        using (var csv = new CsvReader(reader, config))
        {
            var locations = csv.GetRecords<CentroidModel>().ToList();
            var formattedJsonLocations = JsonSerializer.Serialize(locations).Replace("#", "");
            formattedLocations = JsonSerializer.Deserialize<List<CentroidModel>>(formattedJsonLocations);
        }

        return formattedLocations;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}