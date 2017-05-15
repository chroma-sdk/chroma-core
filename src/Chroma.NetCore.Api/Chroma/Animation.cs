using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Interfaces;

namespace Chroma.NetCore.Api.Chroma
{
    public class Animation
    {
        public Stack<AnimationFrame> Frames { get; }
        public bool IsPlaying { get; set; }
        public int CurrentFrame { get; set; }

        private bool isInit;

        public Animation()
        {
            Frames = new Stack<AnimationFrame>();   
        }
    }

    public class AnimationFrame : DeviceContainer
    {
  
        public double Delay => 1000 / 15f;
    }

}
