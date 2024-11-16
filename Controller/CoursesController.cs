
using enrollment.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseEnrollment.Data;
using StudentCourseEnrollment.Models;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : ControllerBase
{
    private readonly EnrollmentContext _context;

    public EnrollmentsController(EnrollmentContext context)
    {
        _context = context;
    }

   
    [HttpPost]
    public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
    {
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEnrollment", new { id = enrollment.Id }, enrollment);
    }
}