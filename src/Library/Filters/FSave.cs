namespace CompAndDel.Filters
{
    public class FSave: IFilter
    {
        //Se crea un contador para que la imagen se vaya guardando en un .jpg distinto cada vez que s ele aplica filtro
        private static int i = 0;
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
            //Por creator
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, $@"beer{i}.jpg");
            return image;
        }

    }
}