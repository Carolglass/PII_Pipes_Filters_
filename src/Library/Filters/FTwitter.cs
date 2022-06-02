using TwitterUCU;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FTwitter: IFilter
    {
        //Se crea un contador para que la imagen se vaya guardando en un .jpg distinto cada vez que s ele aplica filtro
        private static int i = 3;
        
        //Comienza en 3 para guardar en otros beer4.jpg, beer5.jpg y chequear que este funcionando bien 
        public static int I
        {
            get
            {
                return i;
            }
        }
      
        public IPicture Filter(IPicture image)
        {
            i++;
            var twitter = new TwitterImage();
            //twitter.PublishToTwitter("hey hey hey hey", $@"beer{i}.jpg");
            twitter.PublishToTwitter("hey hey hey hey", $@"luke.jpg");
            return image;
        }

    }
}