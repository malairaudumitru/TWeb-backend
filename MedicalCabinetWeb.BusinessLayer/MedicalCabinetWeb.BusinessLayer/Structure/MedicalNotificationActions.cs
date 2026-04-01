using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.MedicalNotification;
using MedicalCabinetWeb.Domain.Models.MedicalNotification;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class MedicalNotificationActions
{
    private readonly MedicalNotificationContext _context;
        
        public MedicalNotificationActions()
        {
            _context = new MedicalNotificationContext();
        }
        
        protected bool CreateMedicalNotificationAction(MedicalNotificationCreateDto notificationInfo)
        {
            var validate = ValidateMedicalNotificationsName(notificationInfo);
            if(!validate.IsSuccess)
                return false;

            var notificationEntity = new MedicalNotificationData
            {
                UserId = notificationInfo.UserId,
                Title = notificationInfo.Title,
                Message = notificationInfo.Message,
                
            };
            try
            {
                _context.Add(notificationEntity);
                _context.SaveChanges();
                return true;
            } 
            catch (Exception e)
            {
                return false;
            }
        }
        
        private ActionResponse ValidateMedicalNotificationsName(MedicalNotificationCreateDto data)
        {
            if (string.IsNullOrEmpty(data.UserId.ToString()))
                return new ActionResponse { IsSuccess = false, Message = "UserId is empty" };

            if (data.UserId <= 0)
                return new ActionResponse { IsSuccess = false, Message = "UserId is invalid" };

            if (string.IsNullOrEmpty(data.Title))
                return new ActionResponse { IsSuccess = false, Message = "Title is empty" };

            if (string.IsNullOrEmpty(data.Message))
                return new ActionResponse { IsSuccess = false, Message = "Message is empty" };

            return new ActionResponse { IsSuccess = true };
        }
        
        protected bool DeleteMedicalNotificationAction(int id)
        {
            var notificationEntity = _context.MedicalNotifications.Find(id);
            {
                if (notificationEntity == null)
                    return false;
            }
            try
            {
                notificationEntity.IsDeleted = true;
                _context.MedicalNotifications.Update(notificationEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        protected bool UpdateReadStatusAction(int id)
        {
            var notificationEntity = _context.MedicalNotifications.Find(id);
            if (notificationEntity == null)
                return false;
            if (notificationEntity.IsRead == true)
                return false;

            try
            {
                notificationEntity.IsRead = true;
                notificationEntity.UpdatedAt = DateTime.UtcNow;
                _context.MedicalNotifications.Update(notificationEntity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        protected bool MarkAllAsReadAction(int userId)
        {
            var notifications = _context.MedicalNotifications
                .Where(n => n.UserId == userId && n.IsRead == false && n.IsDeleted == false)
                .ToList();

            if (!notifications.Any())
                return false;

            try
            {
                foreach (var notification in notifications)
                {
                    notification.IsRead = true;
                    notification.UpdatedAt = DateTime.UtcNow;
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        protected List<MedicalNotificationInfoDto> GetMedicalNotificationListAction()
        {
            var notificationList = _context.MedicalNotifications
                .Where(x => x.IsDeleted == false)
                .Select(notificationEntity => new MedicalNotificationInfoDto
                {
                    Id = notificationEntity.Id,
                    UserId = notificationEntity.UserId,
                    Title = notificationEntity.Title,
                    Message = notificationEntity.Message,
                    IsRead = notificationEntity.IsRead,
                    CreatedAt = notificationEntity.CreatedAt
                })
                .ToList();

            return notificationList;
        }
    
}