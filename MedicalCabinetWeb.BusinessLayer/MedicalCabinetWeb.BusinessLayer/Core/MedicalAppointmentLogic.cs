using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.BusinessLayer.Structure;
using MedicalCabinetWeb.Domain.Models.MedicalAppointment;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Core;

public class MedicalAppointmentLogic : MedicalAppointmentActions, IMedicalAppointmentLogic
{
    public ActionResponse CreateMedicalAppointment(MedicalAppointmentCreateDto serviceInfo)
    {
        var result = CreateMedicalAppointmentAction(serviceInfo);
        if (result == false)
            return ActionResponse.BadRequest("Error creating appointment");
        
        return ActionResponse.Ok("Appointment created successfully");

    }
}