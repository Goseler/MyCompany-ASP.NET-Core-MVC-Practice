using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MyCompany.Domain.Entities;
using System;
using System.IO;

namespace MyCompany.Service
{
	public static class Extensions
	{
		public static string CutController(this string str) => str.Replace("Controller", "");

		public static NewsItem ConvertToNews(this NewsMessage newsMessage)
		{
			NewsItem newsItem = new()
			{
				//Id = newsMessage.Id,
				DateAdded = newsMessage.DateAdded,
				Title = newsMessage.Title,
				Subtitle = newsMessage.Subtitle,
				Text = newsMessage.Text,
				TitleImagePath = newsMessage.TitleImagePath,
				MetaTitle = newsMessage.MetaTitle,
				MetaDescription = newsMessage.MetaDescription,
				MetaKeywords = newsMessage.MetaKeywords
			};

			return newsItem;
		}

		public static class FileManager
		{
			public static void Delete(string name, string path, IWebHostEnvironment webHostEnvironment)
			{
				if (name != null)
				{
					FileInfo file = new(Path.Combine(webHostEnvironment.WebRootPath, path, name));
					if (file.Exists)
						file.Delete();
				}
			}

			public static void SaveImage(IFormFile formFile, string titleImagePath, IWebHostEnvironment webHostEnvironment)
			{
				if (formFile != null)
				{
					Delete(titleImagePath, "images/uploads/", webHostEnvironment);

					titleImagePath = Guid.NewGuid().ToString("N") + formFile.FileName;
					using var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/uploads/", titleImagePath), FileMode.Create);
					formFile.CopyTo(stream);
				}
			}
		}

	}
}
