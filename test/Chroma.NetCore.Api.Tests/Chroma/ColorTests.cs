using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Tests.Base;
using Xunit;

namespace Chroma.NetCore.Api.Tests.Chroma
{

    public class ColorTests
    {
        [Fact]
        [Trait("Category",TraitCategory.UNIT_TEST)]
        public void ToString_HexColor_ReturnRGB()
        {
            var heyColor = new Color("7BFF14");
            var result = heyColor.ToString();

            Assert.Equal(result,"123 255 20");
        }

    }
}
