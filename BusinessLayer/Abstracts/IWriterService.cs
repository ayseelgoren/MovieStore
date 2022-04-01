using BusinessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.WriterModel;

namespace BusinessLayer.Concretes
{
    public interface IWriterService 
    {
        void Add(WriterModel model);
        List<WritersModel> GetAll();
        void Update(UpdateWriterModel model);
        void Delete(DeleteWriterModel model);
    }
}