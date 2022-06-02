using TwitterUCU;
using CognitiveCoreUCU;

namespace CompAndDel
{
    public class PipeConditionalFork: IPipe
    {
     
        protected IPipe pipeTrue;
        protected IPipe pipeFalse;
        public PipeConditionalFork(IPipe pipeTrue, IPipe pipeFalse)
        {
            this.pipeFalse = pipeFalse;
            this.pipeTrue = pipeTrue;
        }

        public IPicture Send(IPicture picture)
        {

            CognitiveFace cog = new CognitiveFace(false);
            cog.Recognize(@"beer.jpg");
            //Devuelve True si encuentra una cara o False si no encuentra
            if (cog.FaceFound)
            {
                return this.pipeTrue.Send(picture);
            } else
            {
                return this.pipeFalse.Send(picture);
            }
            

        }

    }
}