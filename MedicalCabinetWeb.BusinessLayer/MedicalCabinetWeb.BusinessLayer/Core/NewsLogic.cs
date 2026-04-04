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
        return !result ? ActionResponse.BadRequest("Error creating news") : ActionResponse.Ok("News created");
    }
    
    public ActionResponse GetNewsById(int id)
    {
        var newsInfoDto = GetNewsById(id);
        if (newsInfoDto == null)
            return new ActionResponse()
            {
                IsSuccess = false,
                Message = "Error 404"
            };
        return new ActionResponse()
        {
            IsSuccess = true,
            Message = "Success",
            Data = newsInfoDto
        };
    }

    

    public  ActionResponse GetNewsList()
    {
        var productList = GetNewsList();
        return new ActionResponse()
        {
            IsSuccess = true,
            Data = productList
        };
    }

    public ActionResponse DeleteNews(int id)
    {
        var result = DeleteNewsAction(id);
        if (result == false)
            return ActionResponse.BadRequest("Error deleting news");

        return ActionResponse.Ok(message: "News deleted successfully");    }
}
