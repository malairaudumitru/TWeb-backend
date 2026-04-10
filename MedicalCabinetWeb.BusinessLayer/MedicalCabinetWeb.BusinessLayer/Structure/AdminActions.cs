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

    protected AdminInfoDto GetAdminByIdAction(int id)
    {
        var adminEntity = _context.Admins
            .FirstOrDefault(x =>  x.Id == id && x.IsDeleted == false);
        if(adminEntity == null)
            return null;

        var adminInfoDto = new AdminInfoDto
        {
            Id = adminEntity.Id,
            LastName = adminEntity.LastName,
            FirstName = adminEntity.FirstName,
            Email = adminEntity.Email,
            Password = adminEntity.Password
        };
        
        return adminInfoDto;
    }

    protected bool UpdateAdminAction(int id, AdminCreateDto adminInfo)
    {
        var adminEntity = _context.Admins.Find(id);
        if(adminEntity == null)
            return false;
        
        if (adminEntity.IsDeleted == true)
            return false;
        
        adminEntity.LastName = adminInfo.LastName;
        adminEntity.FirstName = adminInfo.FirstName;
        adminEntity.Email = adminInfo.Email;
        adminEntity.Password = adminInfo.Password;

        try
        {
            _context.Admins.Update(adminEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    protected bool DeleteAdminAction(int id)
    {
        var adminEntity = _context.Admins.Find(id);
        {
            if (adminEntity == null)
                return false;
        }
        try
        {
            adminEntity.IsDeleted = true;
            _context.Admins.Update(adminEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    
}