using System.Collections.Generic;
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

        #endregion

        #region Methods

        void SetStatic(Color color);
        void SetAll(Color color);
        void SetNone();

        #endregion




    }
}
