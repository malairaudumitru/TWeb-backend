using MedicalCabinetWeb.Domain.Models.News;
using MedicalCabinetWeb.Domain.Models.Responses;

namespace MedicalCabinetWeb.BusinessLayer.Interfaces;

public interface INewsLogic
{
    ActionResponse CreateNews(NewsCreateDto data);
    ActionResponse GetNewsById(int id);
    ActionResponse GetNewsList();
    ActionResponse DeleteNews(int id);
}