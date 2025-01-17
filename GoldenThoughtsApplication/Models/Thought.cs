using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GoldenThoughtsApplication.Models;
public class Thought
    {
    public int Id { get; set; }

    [StringLength(120, MinimumLength = 3)]
    [Required]
    public string? Content { get; set; }

    [Display(Name = "Date")]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? AuthorName { get; set; }
}