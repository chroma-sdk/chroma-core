namespace Chroma.NetCore.Api.Chroma
{

    public class AnimationFrame : DeviceContainer
    {
        public AnimationFrame()
        {
            Delay = 1000 / 15;
        }

        public AnimationFrame(int delay)
        {
            Delay = delay;
        }

        public int Number { get; set; }
        public int Delay { get;  set; }
    }
}
