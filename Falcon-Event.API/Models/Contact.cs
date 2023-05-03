using System.ComponentModel.DataAnnotations;

namespace Falcon_Event.API.Models;

public class Contact
{
    [Key]
    public int ContactId { get; set; }
    public Guid QId { get; set; } = new Guid();
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}