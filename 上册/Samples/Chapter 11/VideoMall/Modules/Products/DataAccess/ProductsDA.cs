using System;
using System.Collections.Generic;
using System.Data.Common;
using Artech.VideoMall.Common;
using Artech.VideoMall.Products.BusinessEntity;
namespace Artech.VideoMall.Products.DataAccess
{
    public class ProductsDA: DataAccessBase
    {
        public Movie[] GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (DbDataReader reader = this.Helper.ExecuteReader("P_PRODUCT_GET_ALL"))
            {
                while (reader.Read())
                {
                    Movie movie = new Movie
                    {
                        Id = (string)reader["ID"],
                        Categogy = (string)reader["CATEGORY"],
                        Director = (string)reader["DIRECTOR"],
                        Name = (string)reader["NAME"],
                        Poster = (string)reader["POSTER"],
                        Price = (decimal)reader["PRICE"],
                        ReleaseYear = (DateTime)reader["RELAESE_DATE"],
                        RuningTime = (int)reader["RUNING_TIME"],
                        Starring = (string)reader["STARRING"],
                        Story = (string)reader["STORY"],
                    };
                    movies.Add(movie);
                }
            }
            return movies.ToArray();
        }
        public int  GetStock(string productId)
        {
            return this.Helper.ExecuteScalar<int>("P_PRODUCT_GET_STOCK", productId);
        }
    }
}
