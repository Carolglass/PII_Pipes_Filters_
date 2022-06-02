using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ejercicio 1

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"beer.jpg");

            //Se le aplican 2 filtros
            PipeSerial PipeSerialNegative1 = new PipeSerial(new FilterNegative(), new PipeNull());
            PipeSerial PipeSerialGrey1 = new PipeSerial(new FilterGreyscale(),PipeSerialNegative1);
            //Se manda la foto con ambos filtros
            IPicture newPicture = PipeSerialNegative1.Send(picture);
            provider.SavePicture(newPicture, @"beerSI.jpg");

            //Ejercicio 2
            //Se quiere que se mande la foto cada vez que se le aplica un filtro

            PipeSerial PipeS3 = new PipeSerial(new FSave(), new PipeNull());
            PipeSerial PipeSerialNegative2 = new PipeSerial(new FilterNegative(), PipeS3);
            PipeSerial PipeS2 = new PipeSerial(new FSave(),PipeSerialNegative2);
            PipeSerial PipeSerialGrey2 = new PipeSerial(new FilterGreyscale(),PipeS2);
            PipeSerial PipeS1 = new PipeSerial(new FSave(),PipeSerialGrey2);
            PipeSerial PipeBlur2 = new PipeSerial(new FilterBlurConvolution(),PipeS1);

            PipeBlur2.Send(picture);

            //Ejercicio 3
            //Se publica en Twitter el resultado de una secuencia de transformaciones en cualquiera de sus pasos intermedios
            PipeSerial PipeT3 = new PipeSerial(new FTwitter(), new PipeNull());
            PipeSerial PipeSave3 = new PipeSerial(new FSave(), PipeT3);
            PipeSerial PipeSerialNegative3 = new PipeSerial(new FilterNegative(), PipeSave3);
            PipeSerial PipeT2 = new PipeSerial(new FTwitter(),PipeSerialNegative3);
            PipeSerial PipeSave2 = new PipeSerial(new FSave(),PipeT2);
            PipeSerial PipeSerialGrey3 = new PipeSerial(new FilterGreyscale(),PipeSave2);  

            PipeSerialGrey3.Send(picture);

            //Ejercicio 4

            PictureProvider provider1 = new PictureProvider();
            IPicture picture1 = provider1.GetPicture(@"luke.jpg");
            PipeNull pipeNull = new PipeNull();
            PipeSerial PipeSerial4 = new PipeSerial(new FilterGreyscale(),new PipeConditionalFork(new PipeSerial(new FTwitter(),pipeNull),new PipeSerial(new FilterNegative(),pipeNull)));

            PipeSerial4.Send(picture1);
            
           // si es True se le aplica Filtro de Twitter y el último PipeNull 
           // si es False sse le aplica Filternegative y el último que es PipeNull
            

        }
    }
}
