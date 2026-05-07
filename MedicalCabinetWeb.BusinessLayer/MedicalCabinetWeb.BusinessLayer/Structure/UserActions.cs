using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.User;
using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.Domain.Models.User;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class UserActions
{
    public UserActions() { }

    internal UserAccount? UserLoginDataValidationExecution(UserLoginDto udata)
    {
        var passwordHash = PasswordHasher.Hash(udata.Password);

        using (var db = new UserDbContext())
        {
            return db.UserAccounts
                .FirstOrDefault(x =>
                    x.Email        == udata.Email &&
                    x.PasswordHash == passwordHash &&
                    x.IsDeleted    == false);
        }
    }

    internal string UserTokenGeneration(UserAccount user)
    {
        var token = new TokenService();
        return token.GenerateToken(user.Id, user.FirstName, user.LastName, user.Role.ToString());
    }

    internal ActionResponse UserRegDataValidationAction(UserRegisterDto uReg)
    {
        UserAccount? user;
        using (var db = new UserDbContext())
        {
            user = db.UserAccounts
                .FirstOrDefault(x =>
                    x.FirstName == uReg.FirstName &&
                    x.LastName  == uReg.LastName);
        }

        if (user != null)
        {
            return ActionResponse.BadRequest("Un utilizator cu acest nume exista deja.");
        }

        user = new UserAccount
        {
            FirstName    = uReg.FirstName,
            LastName     = uReg.LastName,
            Email        = uReg.Email, 
            PasswordHash = PasswordHasher.Hash(uReg.Password),
            Role         = UserRole.Patient,
            CreatedAt    = DateTime.UtcNow
        };

        var patient = new Patient
        {
            FirstName   = uReg.FirstName,
            LastName    = uReg.LastName,
            Email       = uReg.Email,
            Phone       = uReg.Phone,
            Sex         = uReg.Sex,
            DateOfBirth = uReg.DateOfBirth,
            UserAccount = user
        };

        using (var db = new UserDbContext())
        {
            db.UserAccounts.Add(user);
            db.Patients.Add(patient);
            db.SaveChanges();
        }

        return ActionResponse.Ok("Inregistrare reusita.");
    }
}