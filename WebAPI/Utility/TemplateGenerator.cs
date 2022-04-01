using EntitiesLayer.ViewModel.WriterModel;
using Microsoft.Extensions.Primitives;
using System.Text;
using System.Text.Json;

namespace WebAPI.Utility
{
    public static class TemplateGenerator
    {
        public static string? GetHTMLString(List<WritersModel> oModels)
        {
            var sb = new StringBuilder();
            var movies = "";
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>Yazar Listesi</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Ad</th>
                                        <th>Soyad</th>
                                        <th>Kitaplar</th>
                                    </tr>");
            foreach (var writer in oModels)
            {

                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>", writer.Name, writer.Surname, JsonSerializer.Serialize(writer.Movies.ToList().Select(x =>x.Name))) ;


                sb.Append(@" </td></tr>");
            }

            sb.Append(@" </table> </body> </html>");
            return sb.ToString();
        }
    }
}
