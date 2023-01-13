using BlazorInputFile;

namespace FileUpload.Service
	{
	public interface IFileUpload
		{

		Task UploadAsync(IFileListEntry file);


		}
	}
