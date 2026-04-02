using MedicalCabinetWeb.BusinessLayer;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;

namespace MedicalCabinetWeb.Api.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController : ControllerBase
{
    private readonly BusinessLogic _businessLogic;

    public PatientController()
    {
        _businessLogic = new BusinessLogic(new UserDbContext());
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_businessLogic.GetPatientLogic().GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var patient = _businessLogic.GetPatientLogic().GetById(id);
        if (patient == null)
            return NotFound($"Pacientul cu id {id} nu a fost găsit.");
        return Ok(patient);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Patient patient)
    {
        _businessLogic.GetPatientLogic().Create(patient);
        return CreatedAtAction(nameof(GetById), new { id = patient.Id }, patient);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Patient patient)
    {
        var existing = _businessLogic.GetPatientLogic().GetById(id);
        if (existing == null)
            return NotFound($"Pacientul cu id {id} nu a fost găsit.");
        _businessLogic.GetPatientLogic().Update(id, patient);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var patient = _businessLogic.GetPatientLogic().GetById(id);
        if (patient == null)
            return NotFound($"Pacientul cu id {id} nu a fost găsit.");
        _businessLogic.GetPatientLogic().Delete(id);
        return NoContent();
    }
}