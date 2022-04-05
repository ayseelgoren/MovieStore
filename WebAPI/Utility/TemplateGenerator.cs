using EntitiesLayer.ViewModel.MovieModel;
using EntitiesLayer.ViewModel.OrderModel;
using EntitiesLayer.ViewModel.WriterModel;
using Microsoft.Extensions.Primitives;
using System.Text;
using System.Text.Json;

namespace WebAPI.Utility
{
    public static class TemplateGenerator
    {
        public static string? GetHTMLDirectors(List<DirectorsModel> list)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='headerDirector'><h1>Yönetmen Listesi</h1></div>
                                <table align='center'>
                                    <tr class='director'>
                                        <th>Ad</th>
                                        <th>Soyad</th>
                                        <th>Kitaplar</th>
                                    </tr>");
            foreach (var writer in list)
            {

                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>", writer.Name, writer.Surname, string.Join(",", writer.Movies.ToList().Select(x =>x.Name))) ;
                

                sb.Append(@" </td></tr>");
            }

            sb.Append(@" </table> </body> </html>");
            return sb.ToString();
        }

        public static string GetHTMLOrders(List<OrdersModel> list)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='headerOrder'><h1>Sipariş Listesi</h1></div>
                                <table align='center'>
                                    <tr class='order'>
                                        <th>Müşteri Ad-Soyad</th>
                                        <th>Film Ad</th>
                                        <th>Film Türü</th>
                                        <th>Film Yazarı</th>
                                        <th>Oyuncular</th>
                                        <th>Fiyat</th>
                                        <th>Alış Tarih</th>
                                    </tr>");
            foreach (var order in list)
            {

                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                    <td>{4}</td>
                                    <td>{5}</td>
                                    <td>{6}</td>", order.Customer, order.MovieName ,order.GenreName, order.Director, string.Join(",", order.Players.ToList().Select(x => { return x.Name + " " + x.Surname; })),order.Price, order.OrderDate);


                sb.Append(@" </td></tr>");
            }

            sb.Append(@" </table> </body> </html>");
            return sb.ToString();
        }

        public static string GetHTMLMovies(List<MoviesModel> list)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='headerMovie'><h1>Film Listesi</h1></div>
                                <table align='center'>
                                    <tr class='movie'>
                                        <th>Film Ad</th>
                                        <th>Yazar Ad-Soyad</th>
                                        <th>Fiyat</th>
                                        <th>Oyuncular</th>
                                    </tr>");
            foreach (var movie in list)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>", movie.Name, movie.Director, movie.Price, string.Join(",", movie.Players.ToList().Select(x => {return x.Name + " " + x.Surname; })));


                sb.Append(@" </td></tr>");
            }

            sb.Append(@" </table> </body> </html>");
            return sb.ToString();
        }
    }
}
