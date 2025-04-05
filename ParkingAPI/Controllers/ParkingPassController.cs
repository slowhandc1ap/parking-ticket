using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// กำหนด Route สำหรับ API โดยใช้ชื่อ Controller เป็นจุดเริ่มต้น
[Route("api/[controller]")]
[ApiController]
public class ParkingPassController : ControllerBase
{
    private readonly AppDbContext _context;
    
    // Constructor รับ Dependency Injection ของ Database Context
    public ParkingPassController(AppDbContext context) => _context = context;

    // GET: api/ParkingPass
    // ดึงข้อมูลบัตรจอดรถทั้งหมด
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ParkingPass>>> Get() =>
        await _context.ParkingPasses.ToListAsync();

    // GET: api/ParkingPass/5
    // ดึงข้อมูลบัตรจอดรถเฉพาะรายการจาก ID
    [HttpGet("{id}")]
    public async Task<ActionResult<ParkingPass>> Get(int id)
    {
        // ค้นหาข้อมูลจาก Database โดยใช้ ID
        var pass = await _context.ParkingPasses.FindAsync(id);
        
        // ถ้าไม่พบข้อมูลจะส่งกลับว่า Not Found
        return pass == null ? NotFound() : pass;
    }

    // POST: api/ParkingPass
    // สร้างบัตรจอดรถใหม่
    [HttpPost]
    public async Task<IActionResult> Post(ParkingPass pass)
    {
        // ถ้าไม่ได้ระบุเวลาเข้า ให้ใช้เวลาปัจจุบัน
        if (pass.EntryTime == default)
        {
            pass.EntryTime = DateTime.Now;
        }

        // ถ้ามีเวลาเข้าและเวลาออก แต่ยังไม่ได้คำนวณราคา
        if (pass.EntryTime != default && pass.ExitTime != null && pass.Price == null)
        {
            // คำนวณระยะเวลาจอดเป็นนาที
            var minutes = ((DateTime)pass.ExitTime - pass.EntryTime).TotalMinutes;

            // กำหนดอัตราค่าจอดตามประเภทรถ
            decimal ratePerMinute = pass.CarType?.ToLower() switch
            {
                "มอไซ" or "motorcycle" => 1.5m,    // มอเตอร์ไซค์ 1.5 บาท/นาที
                "รถยนต์" or "car" => 2.0m,        // รถยนต์ 2.0 บาท/นาที
                "รถบรรทุก" or "truck" => 3.0m,     // รถบรรทุก 3.0 บาท/นาที
                _ => 1.0m                          // ประเภทอื่น 1.0 บาท/นาที
            };

            // คำนวณราคารวม ปัดเศษ 2 ตำแหน่ง
            pass.Price = Math.Round((decimal)minutes * ratePerMinute, 2);
        }

        // เพิ่มข้อมูลใหม่ลง Database
        _context.ParkingPasses.Add(pass);
        await _context.SaveChangesAsync();

        // ส่งกลับผลลัพธ์พร้อม URL ของข้อมูลที่สร้างใหม่
        return CreatedAtAction(nameof(Get), new { id = pass.Id }, pass);
    }

    // PUT: api/ParkingPass/5
    // อัปเดตข้อมูลบัตรจอดรถ
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ParkingPass pass)
    {
        // ตรวจสอบว่า ID ใน URL ตรงกับ ID ในข้อมูลหรือไม่
        if (id != pass.Id) return BadRequest();

        // ถ้ามีเวลาเข้าและเวลาออก แต่ยังไม่ได้คำนวณราคา
        if (pass.EntryTime != default && pass.ExitTime != null && pass.Price == null)
        {
            // คำนวณระยะเวลาจอดเป็นนาที
            var minutes = ((DateTime)pass.ExitTime - pass.EntryTime).TotalMinutes;

            // กำหนดอัตราค่าจอดตามประเภทรถ
            decimal ratePerMinute = pass.CarType?.ToLower() switch
            {
                "มอไซ" or "motorcycle" => 0.5m,    // มอเตอร์ไซค์ 0.5 บาท/นาที
                "รถยนต์" or "car" => 1.0m,        // รถยนต์ 1.0 บาท/นาที
                "รถบรรทุก" or "truck" => 2.0m,     // รถบรรทุก 2.0 บาท/นาที
                _ => 1.0m                          // ประเภทอื่น 1.0 บาท/นาที
            };
            
            // คำนวณราคารวม ปัดเศษ 2 ตำแหน่ง
            pass.Price = Math.Round((decimal)minutes * ratePerMinute, 2);
        }

        // กำหนดสถานะของ Entity เป็น Modified เพื่ออัปเดต
        _context.Entry(pass).State = EntityState.Modified;
        
        // บันทึกการเปลี่ยนแปลงลง Database
        await _context.SaveChangesAsync();
        
        // ส่งกลับสถานะสำเร็จ (ไม่มีเนื้อหา)
        return NoContent();
    }

    // DELETE: api/ParkingPass/5
    // ลบข้อมูลบัตรจอดรถ
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        // ค้นหาข้อมูลจาก Database โดยใช้ ID
        var pass = await _context.ParkingPasses.FindAsync(id);
        
        // ถ้าไม่พบข้อมูลจะส่งกลับว่า Not Found
        if (pass == null) return NotFound();
        
        // ลบข้อมูลออกจาก Database
        _context.ParkingPasses.Remove(pass);
        await _context.SaveChangesAsync();
        
        // ส่งกลับสถานะสำเร็จ (ไม่มีเนื้อหา)
        return NoContent();
    }
}