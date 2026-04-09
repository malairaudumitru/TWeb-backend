using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using MedicalCabinetWeb.Domain.Models.Admin;
using MedicalCabinetWeb.Domain.Models.Medic;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class AdminActions
{
    private readonly UserDbContext _context;

    public AdminActions()
    {
        _context = new UserDbContext();
    }

    protected bool CreateAdminAction(AdminCreateDto admin)
    {
        var adminEntity = new Admin
        {
           LastName = admin.LastName,
           FirstName = admin.FirstName,
           Email = admin.Email,
           Password = admin.Password
        };
        try
        {
            _context.Add(adminEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected List<AdminInfoDto> GetAdminListAction()
    {
        var adminList = _context.Admins
            .Where(x => x.IsDeleted == false)
            .Select(adminEntity => new AdminInfoDto
            {
                Id = adminEntity.Id,
                LastName =  adminEntity.LastName,
                FirstName =  adminEntity.FirstName,
                Email = adminEntity.Email,
                Password = adminEntity.Password
            })
            .ToList();
        
        return adminList;
    
    }
    
    
}