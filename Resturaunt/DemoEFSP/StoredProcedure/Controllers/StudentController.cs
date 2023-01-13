using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoredProcedure.Models;
using System;

namespace StoredProcedure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            this._context = context;
        }

        [HttpGet("Lnames/{s}")]
        public async Task<ActionResult<IEnumerable<Student>>>? GetLnames(string s)
        {
            return await _context.Students.FromSql($"EXEC dbo.GetStudentLname @Lname = {s}").ToListAsync();
        }

        [HttpGet("Fnames/{s}")]
        public async Task<ActionResult<IEnumerable<Student>>>? GetFnames(string s)
        {
            return await _context.Students.FromSql($"EXEC dbo.GetStudentFname @Fname = {s}").ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>>? GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
