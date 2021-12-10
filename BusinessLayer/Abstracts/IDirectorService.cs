using BusinessLayer.Abstracts;
using BusinessLayer.Result;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel.DirectorModel;

namespace BusinessLayer.Concretes
{
    public interface IDirectorService 
    {
        Response Add(DirectorModel model);
        ResponseList<DirectorsModel> GetAll();
        Response Update(UpdateDirectorModel model);
        Response Delete(DeleteDirectorModel model);
    }
}