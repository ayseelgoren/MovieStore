using BusinessLayer.Abstracts;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.DirectorModel;

namespace BusinessLayer.Concretes
{
    public interface IDirectorService 
    {
        void Add(DirectorModel model);
        List<DirectorsModel> GetAll();
        void Update(UpdateDirectorModel model);
        void Delete(DeleteDirectorModel model);
    }
}