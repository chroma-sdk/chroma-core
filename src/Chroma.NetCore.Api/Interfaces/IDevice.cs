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
        string EffectId { get; }

        dynamic EffectData { get; set; }


        #endregion

        #region Methods

        Task SetStatic(Color color);
        Task SetAll(Color color);
        Task SetNone();

        #endregion




    }
}
