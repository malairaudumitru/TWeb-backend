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

    public ActionResponse DeleteMedicalAppointment(int id)
    {
        var result = DeleteMedicalAppointmentAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting appointment");

        return ActionResponse.Ok("Appointment deleted successfully");
        
    }
    
    public ActionResponse GetMedicalAppointmentList()
    {
        var appointmentList = GetMedicalAppointmentListAction();
        
        return ActionResponse.Ok(data: appointmentList);
    }
    
    public ActionResponse GetMedicalAppointmentById(int id)
    {
        var appointment = GetMedicalAppointmentByIdAction(id);
        if (appointment == null)
            return ActionResponse.NotFound("Appointment not found");
        
        return ActionResponse.Ok(data: appointment);
    }
    
    public ActionResponse UpdateMedicalAppointment(int id, MedicalAppointmentCreateDto data)
    {
        var result = UpdateMedicalAppointmentAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating appointment");
        
        return ActionResponse.Ok("Appointment updated successfully");
    }
    
}