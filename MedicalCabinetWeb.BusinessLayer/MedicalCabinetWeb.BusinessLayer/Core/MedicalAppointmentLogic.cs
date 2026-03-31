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
        var serviceList = GetMedicalAppointmentListAction();
        
        return ActionResponse.Ok(data: serviceList);
    }
    
}