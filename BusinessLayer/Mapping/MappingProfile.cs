using AutoMapper;
using BusinessLayer.TokenOperation.Models;
using EntitiesLayer.Models;
using EntitiesLayer.ViewModel;
using EntitiesLayer.ViewModel.CustomerModel;
using EntitiesLayer.ViewModel.MovieModel;
using EntitiesLayer.ViewModel.OrderModel;
using EntitiesLayer.ViewModel.PlayerModel;
using EntitiesLayer.ViewModel.WriterModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<kim, kime>();
            CreateMap<Customer, Token>();
            CreateMap<DeleteCustomerModel, Customer>();
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Customer, CreateCustomerModel>();

            CreateMap<CreateMovieModel, Movie>(); 
            CreateMap<UpdateMovieModel, Movie>();
            CreateMap<DeleteMovieModel, Movie>();
            CreateMap<Movie, MoviesModel>().ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.MoviePlayers.Select(y => y.Players).ToList()))
                                           .ForMember(dest=>dest.IsItSold, opt=>opt.MapFrom(src=>src.Status.ToString()))
                                           .ForMember(dest=>dest.GenreName,opt=>opt.MapFrom(src=>src.Genre.GenreName))
                                           .ForMember(dest=>dest.Director,opt=>opt.MapFrom(src=>src.Writer.Name+" "+src.Writer.Surname));
            CreateMap<OrderModel, Order>();

            CreateMap<MoviePlayerModel, MoviePlayer>();


            CreateMap<WriterModel, Writer>();
            CreateMap<UpdateWriterModel, Writer>();
            CreateMap<DeleteWriterModel, Writer>();
            CreateMap<Writer, WritersModel > ();

            CreateMap<PlayerModel, Player>();
            CreateMap<UpdatePlayerModel, Player>();
            CreateMap<DeletePlayerModel, Player>();
            CreateMap<Player, PlayersModel>().ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.PlayerMovies.Select(y => y.Movies).ToList()));

            CreateMap<Order, OrdersModel>().ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Movie.Genre.GenreName))
                                          .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name))
                                          .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer.Name + " " + src.Customer.Surname))
                                          .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Date))
                                          .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Movie.Writer.Name + " " + src.Movie.Writer.Surname));

        }
    }
}
