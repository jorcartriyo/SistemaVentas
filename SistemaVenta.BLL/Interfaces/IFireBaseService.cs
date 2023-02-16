using System;
namespace SistemaVenta.BLL.Interfaces
{
	public interface IFireBaseService
	{
        Task<string> SubirStorage(Stream streamArchivo, string CarpetaDestino, string NombreArchivo);
        Task<bool> EliminarStorage(string CarpetaDestino, string NombreArchivo);


    }
}

