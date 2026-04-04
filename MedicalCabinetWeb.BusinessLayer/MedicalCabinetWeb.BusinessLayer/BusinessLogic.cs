

using MedicalCabinetWeb.BusinessLayer.Core;
using MedicalCabinetWeb.BusinessLayer.Interfaces;

namespace MedicalCabinetWeb.BusinessLayer;

public class BusinessLogic
{
        public BusinessLogic() { }

        public INewsLogic GetNewsLogic()
        {
            return new NewsLogic();
        }
        
    /*public IReviewsLogic GetReviewsLogic()
    {
        return new ReviewsLogic();
    }*/
}