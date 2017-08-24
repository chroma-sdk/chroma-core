using System.Collections.Generic;
using System.Threading.Tasks;
using Chroma.NetCore.Api.Chroma;

namespace Chroma.NetCore.Api.Interfaces
{
    public interface IDevice
    {
        #region Properties

        string Device { get; }
        List<Effect> Supports { get; }

        Effect ActiveEffect { get; }
        string EffectId { get; set; }

        dynamic EffectData { get; set; }


        #endregion

        #region Methods

        void SetStatic(Color color);
        void SetAll(Color color);
        void SetNone();

        #endregion
    }
}
