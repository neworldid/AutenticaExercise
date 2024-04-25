using CsvHelper.Configuration.Attributes;

namespace AutenticaExercise.Models;

public class CentroidModel
{
    [Name("#KODS#")]
    public string? Code { get; set; }

    [Name("#TIPS_CD#")]
    public string? Type { get; set; }
    
    [Name("#NOSAUKUMS#")]
    public string? Name { get; set; }

    [Name("#VKUR_CD#")]
    public string? VKUR { get; set; }
    
    [Name("#VKUR_TIPS#")]
    public string? VKURType { get; set; }

    [Name("#STD#")]
    public string? Std { get; set; }
    
    [Name("#KOORD_X#")]
    public string? CoordinateX { get; set; }

    [Name("#KOORD_Y#")]
    public string? CoordinateY { get; set; }
    
    [Name("#DD_N#")]
    public string? DD_N { get; set; }

    [Name("#DD_E#")]
    public string? DD_E { get; set; }
}