using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using SecureGateTypes;

namespace BusinessLayer
{
    public class ExternalProcessor
    {
        private readonly ExternalRepository externalRepository;
        private readonly LocationRepository locationRepository;
        private readonly PictureRepository pictureRepository;
        private readonly ApplicationParametersRepository applicationParametersRepository;

        public ExternalProcessor()
        {
            externalRepository = new ExternalRepository();
            pictureRepository = new PictureRepository();
            applicationParametersRepository = new ApplicationParametersRepository();
        }
        

        public void SetExternal(Bitmap rostro, Bitmap placaT, Bitmap placaD, Bitmap credencial, string tipoRegistro, string placa, string nombre, string apellidos, string domicilio)
        {
            string PicturePath = applicationParametersRepository.GetParameterByKey("PicturesPath");
            string pictureID = applicationParametersRepository.GetParameterByKey("PictureID");
            if (tipoRegistro != "Personal")
            {
                credencial.Save(PicturePath + placa + "-Credencial" + pictureID + ".jpg");
                rostro.Save(PicturePath + placa + "-Rostro" + pictureID + ".jpg");
                placaT.Save(PicturePath + placa + "-PlacaT" + pictureID + ".jpg");
                placaD.Save(PicturePath + placa + "-PlacaD" + pictureID + ".jpg");
                applicationParametersRepository.increasePictureID();
            }
        }
        
        public List<ExternalTypeCbbx> GetExternalTypes()
        {
            return externalRepository.GetExternalTypes().Select(s => new ExternalTypeCbbx{ID =s.Id,Tipo = s.Description }).ToList();
        }
    }
}
