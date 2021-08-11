using Microsoft.AspNetCore.Hosting;
using MyCompany.Domain.Entities;
using System.IO;

namespace MyCompany.Service
{
	public static class Extensions
	{
		public static string CutController(this string str) 
		{ 
			return str.Replace("Controller", ""); 
		}

		public static NewsItem ConvertToNews(this NewsMessage newsMessage)
		{
			NewsItem newsItem = new NewsItem();

			newsItem.Id = newsMessage.Id;
			newsItem.DateAdded = newsMessage.DateAdded;
			newsItem.Title = newsMessage.Title;
			newsItem.Subtitle = newsMessage.Subtitle;
			newsItem.Text = newsMessage.Text;
			newsItem.TitleImagePath = newsMessage.TitleImagePath;
			newsItem.MetaTitle = newsMessage.MetaTitle;
			newsItem.MetaDescription = newsMessage.MetaDescription;
			newsItem.MetaKeywords = newsMessage.MetaKeywords;

			return newsItem;
		}

		public static class FileManager
		{
			public static void Delete(string name, string path, IWebHostEnvironment webHostEnvironment)
			{
				if (name != null)
				{
					FileInfo file = new FileInfo(Path.Combine(webHostEnvironment.WebRootPath, path, name));
					if (file.Exists)
						file.Delete();
				}
				else
				{
					throw new System.ArgumentNullException();
				}
			}
		}

	}
}
