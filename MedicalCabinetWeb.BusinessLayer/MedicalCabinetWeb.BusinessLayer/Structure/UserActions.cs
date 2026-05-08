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
    
    internal ActionResponse PromoteToMedicAction(int userId, string speciality)
    {
        using (var db = new UserDbContext())
        {
            var patient = db.Patients.FirstOrDefault(x => x.UserAccountId == userId);
            var user = db.UserAccounts.FirstOrDefault(x => x.Id == userId);

            if (user == null || patient == null)
                return ActionResponse.BadRequest("Utilizatorul nu a fost gasit.");

            if (user.Role == UserRole.Medic)
                return ActionResponse.BadRequest("Utilizatorul este deja medic.");

            var medic = new Medic
            {
                FirstName     = patient.FirstName,
                LastName      = patient.LastName,
                Speciality    = Enum.Parse<MedicSpeciality>(speciality),
                UserAccountId = userId,
                UserAccount   = user
            };

            user.Role = UserRole.Medic;
            db.Patients.Remove(patient);  
            db.Medics.Add(medic);         
            db.SaveChanges();

            return ActionResponse.Ok("Utilizatorul a fost promovat la medic.");
        }
    }

    internal ActionResponse PromoteToAdminAction(int userId)
    {
        using (var db = new UserDbContext())
        {
            var user = db.UserAccounts.FirstOrDefault(x => x.Id == userId);

            if (user == null)
                return ActionResponse.BadRequest("Utilizatorul nu a fost gasit.");

            if (user.Role == UserRole.Admin)
                return ActionResponse.BadRequest("Utilizatorul este deja admin.");

            
            var patient = db.Patients.FirstOrDefault(x => x.UserAccountId == userId);
            var medic = db.Medics.FirstOrDefault(x => x.UserAccountId == userId);

            var admin = new Admin
            {
                FirstName     = patient?.FirstName ?? medic?.FirstName,
                LastName      = patient?.LastName  ?? medic?.LastName,
                Email         = user.Email,
                UserAccountId = userId,
                UserAccount   = user
            };

            
            if (patient != null) db.Patients.Remove(patient);
            if (medic != null)   db.Medics.Remove(medic);

            user.Role = UserRole.Admin;
            db.Admins.Add(admin);
            db.SaveChanges();

            return ActionResponse.Ok("Utilizatorul a fost promovat la admin.");
        }
    }
    
}