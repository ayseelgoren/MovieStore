using DinkToPdf;
using EntitiesLayer.ViewModel.MovieModel;
using EntitiesLayer.ViewModel.OrderModel;
using EntitiesLayer.ViewModel.WriterModel;

namespace WebAPI.Utility.CreatePdf
{
    public interface ICreatePdf
    {
        HtmlToPdfDocument PdfOrder(string name, List<OrdersModel> list);
        HtmlToPdfDocument PdfMovie(string name, List<MoviesModel> list);
        HtmlToPdfDocument PdfDirector(string name, List<DirectorsModel> list);
    }
}
