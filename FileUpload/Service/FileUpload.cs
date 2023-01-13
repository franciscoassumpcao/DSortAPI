﻿using BlazorInputFile;

namespace FileUpload.Service
	{
	public class FileUpload : IFileUpload
		{

		private readonly IWebHostEnvironment _environment;
		public FileUpload(IWebHostEnvironment environment)
			{
			_environment = environment;
			}

		public async Task UploadAsync(IFileListEntry fileEntry)
			{
			var path=Path.Combine(_environment.ContentRootPath,"Upload", fileEntry.Name);
			var ms = new MemoryStream();
			await fileEntry.Data.CopyToAsync(ms);

			using (FileStream file=new FileStream(path,FileMode.Create,FileAccess.Write))
				{
				ms.WriteTo(file);
				}

			
			}
		}
	}
