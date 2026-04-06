using MedicalCabinetWeb.BusinessLayer.Interfaces;
using MedicalCabinetWeb.Domain.Models.News;
using MedicalCabinetWeb.Domain.Models.Responses;
using MedicalCabinetWeb.BusinessLayer.Structure;
namespace MedicalCabinetWeb.BusinessLayer.Core;

public class NewsLogic : NewsActions, INewsLogic
{
    public ActionResponse CreateNews(NewsCreateDto newsCreateInfo)
    {
        var result = CreateNewsAction(newsCreateInfo);
        if (result == false)
            return ActionResponse.BadRequest("Error creating news");
        return ActionResponse.Ok("News created successfully");
    }
    
    public ActionResponse GetNewsById(int id)
    {
        var result = GetNewsByIdAction(id);
        if (result == null)
            return ActionResponse.BadRequest("Error finding news");
        
        return ActionResponse.Ok("News found successfully");
        
    }

    

    public  ActionResponse GetNewsList()
    {
        var result = GetNewsListAction();
            return ActionResponse.Ok("News found successfully");

    }

    public ActionResponse DeleteNews(int id)
    {
        var result = DeleteNewsAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting news");

        return ActionResponse.Ok("News deleted successfully");
    }
    
    public ActionResponse UpdateNews(int id, NewsCreateDto data)
    {
        var result = UpdateNewsAction(id, data);
        if (result == false)
            return ActionResponse.BadRequest("Error updating news");

        return ActionResponse.Ok("News updated successfully");
    }
}
