using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UsoApiPublica_JuanDiegoSilva.Models;
using UsoApiPublica_JuanDiegoSilva.Services;

namespace UsoApiPublica_JuanDiegoSilva.ViewModels
{
    public class ApodViewModelJDS
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ApodViewModelJDS()
        {
            ChosenDate_JDS = DateTime.Now;
        }
        private DateTime dateTime_JDS;
        public DateTime ChosenDate_JDS
        {
            get { return dateTime_JDS; }
            set
            {
                if (value != dateTime_JDS)
                {
                    dateTime_JDS = value;
                    NotifyPropertyChanged();
                }
                _= GetPictureOfTheDay(dateTime_JDS);
            }
        }
        //La diferencia entre title y Title es que title es un campo privado usado para guardar
        //el valor de title mientras que Title es una propiedad pública que proporciona acceso
        //al campo title y lanza el evento PropertyChanged cuando su valor cambia, lo que es usado
        //para el data binding y las notificaciones de cambio.
        //El getter retorna el valor del campo title mientras que el setter permite asignar un
        //nuevo valor al campo title.
        private string title_JDS;
        public string Title_JDS
        {
            get { return title_JDS; }
            set
            {
                if (value != title_JDS)
                {
                    title_JDS = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri imageUri_JDS;
        public Uri ImageURI_JDS
        {
            get { return imageUri_JDS; }
            set
            {
                if (imageUri_JDS != value)
                {
                    imageUri_JDS = value;
                    NotifyPropertyChanged();
                }
            }

        }
        private string didactic_JDS;
        public string Didactic_JDS
        {
            get { return didactic_JDS; }
            set
            {
                if (didactic_JDS != value)
                {
                    didactic_JDS = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private ApodServiceJDS service_JDS;
        public ApodServiceJDS Service_JDS
        {
            get
            {
                if (service_JDS == null)
                {
                    service_JDS = new ApodServiceJDS();
                }
                return service_JDS;
            }
        }
        private async Task GetPictureOfTheDay(DateTime day)
        {
            ApodJDS dto = await Service_JDS.GetImage_JDS(day);
            if (dto == null)
            {
                ImageURI_JDS = new Uri("https://image.freepik.com/vector-gratis/error-404-no-encontradoefecto-falla_8024-5.jpg");
                Didactic_JDS = "";
                Title_JDS = "Intenta con otra fecha";
            }
            else
            {
                ImageURI_JDS = new Uri(dto.hdurl_JDS);
                Didactic_JDS = dto.explanation_JDS;
                Title_JDS = dto.title_JDS;
            }
        }
    }

}

