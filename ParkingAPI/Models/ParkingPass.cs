using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ParkingPass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ให้ DB สร้าง Id อัตโนมัติ
    public int Id { get; set; }

    [Required]
    public string PlateNumber { get; set; }

    [Required]
    public string DriverName { get; set; }

    [Required]
    public string CarColor { get; set; }

    [Required]
    public string CarType { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public decimal? Price { get; set; }
}
