using MedicalCabinetWeb.DataAccessLayer.Context;
using MedicalCabinetWeb.Domain.Entities.News;
using MedicalCabinetWeb.Domain.Models.News;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Structure;

public class NewsActions
{
    private readonly NewsDbContext _context = new NewsDbContext();

    protected bool CreateNewsAction(NewsCreateDto newsInfo)
    {
        var validate = ValidateNews(newsInfo);
        if (!validate.IsSuccess)
            return false;

        var newsEntity = new NewsEntity
        {
            Name = newsInfo.Name,
            Description = newsInfo.Description,
            Type = newsInfo.Type
        };

        try
        {
            _context.Add(newsEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private ActionResponse ValidateNews(NewsCreateDto data)
    {
        if (string.IsNullOrEmpty(data.Name))
            return new ActionResponse { IsSuccess = false, Message = "Title is empty" };

        if (string.IsNullOrEmpty(data.Description))
            return new ActionResponse { IsSuccess = false, Message = "Description is empty" };

        return new ActionResponse { IsSuccess = true };
    }

    protected bool DeleteNewsAction(int id)
    {
        var newsEntity = _context.News.Find(id);
        if (newsEntity == null)
            return false;
        
        try
        {
            newsEntity.IsDeleted = true;
            _context.News.Update(newsEntity);
            _context.SaveChanges();
            return true;
        }
        
        catch (Exception e)
        {
            return false;
        }
    }

    protected bool UpdateNewsAction(int id, NewsCreateDto newsInfo)
    {
        var newsEntity = _context.News.Find(id);
        if (newsEntity == null)
            return false;

        if (newsEntity.IsDeleted)
            return false;

        newsEntity.Name = newsInfo.Name;
        newsEntity.Description = newsInfo.Description;
        newsEntity.Type = newsInfo.Type;
        newsEntity.Date = DateTime.UtcNow;

        try
        {
            _context.News.Update(newsEntity);
            _context.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}