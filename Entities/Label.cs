using System.ComponentModel.DataAnnotations;

public class Label
{
    [Key]
    public string Name { get; set; } = string.Empty;
}
