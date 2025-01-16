using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ReportingController : ControllerBase
{
    private readonly IReportingService _reportingService;

    public ReportingController(IReportingService reportingService)
    {
        _reportingService = reportingService;
    }

    [HttpGet("class-summary/{classId}")]
    public async Task<IActionResult> GetClassSummary(int classId)
    {
        var summary = await _reportingService.GetAbsenceSummaryByClassAsync(classId);
        return Ok(summary);
    }

    [HttpGet("student-summary/{studentId}")]
    public async Task<IActionResult> GetStudentSummary(int studentId)
    {
        var summary = await _reportingService.GetAbsenceSummaryByStudentAsync(studentId);
        return Ok(summary);
    }

    [HttpGet("detailed-report/{ficheAbsenceId}")]
    public async Task<IActionResult> GetDetailedReport(int ficheAbsenceId)
    {
        var report = await _reportingService.GenerateDetailedAbsenceReportAsync(ficheAbsenceId);
        return File(report, "application/pdf", "AbsenceReport.pdf");
    }
}
