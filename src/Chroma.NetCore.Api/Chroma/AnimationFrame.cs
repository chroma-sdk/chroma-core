namespace Chroma.NetCore.Api.Chroma
{

    public class AnimationFrame : DeviceContainer
    {

        public int Number { get; set; }
        public int Delay => 1000 / 15;
    }
}
