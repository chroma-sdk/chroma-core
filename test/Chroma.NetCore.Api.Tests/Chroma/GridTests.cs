using System;
using System.Collections.Generic;
using System.Text;
using Chroma.NetCore.Api.Chroma;
using Chroma.NetCore.Api.Exceptions;
using Chroma.NetCore.Tests.Base;
using Newtonsoft.Json;
using Xunit;
using Xunit.Sdk;

namespace Chroma.NetCore.Api.Tests.Chroma
{

    public class GridTests
    {

        private const int GRID_ROWS = 7, GRID_COLS = 4;

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void Constructor_InitMatrix()
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            Assert.Equal(grid.Rows, GRID_ROWS);
            Assert.Equal(grid.Cols, grid.Cols);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetPosition_ReturnRightValueRed()
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            var result = grid.SetPosition(2, 3, Color.Red);
            Assert.True(result);

            var resultColor = grid.GetPosition(2, 3);

            Assert.Equal(resultColor, Color.Red);
        }



        [Theory, InlineData(1, 89)]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetPosition_ReturnChromaNetCoreApiException(int outRow, int outCol)
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            var ex =Assert.Throws<ChromaNetCoreApiException>(() => grid.SetPosition(1, 89, Color.Red));
            Assert.Contains(ex.Message, $"The column index is out of range {outCol}");

        }

        [Theory, InlineData(29, 79)]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void GetPosition_ReturnChromaNetCoreApiException(int outRow, int outCol)
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            var ex =  Assert.Throws<ChromaNetCoreApiException>(() => grid.GetPosition(outRow, outCol));
            Assert.Contains(ex.Message, $"The row index is out of range {outRow}");
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetCol_ReturnRightValueRed()
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            var result = grid.SetCol(2, Color.Red);
            Assert.True(result);

            var resultColor = grid.GetPosition(2, 2);

            Assert.Equal(resultColor, Color.Red);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void SetRow_ReturnRightValueRed()
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            var result = grid.SetCol(1, Color.Red);
            Assert.True(result);

            var resultColor = grid.GetPosition(1, 2);

            Assert.Equal(resultColor, Color.Red);
        }

        [Fact]
        [Trait("Category", TraitCategory.UNIT_TEST)]
        public void ToJson_ReturnGridAsJsonString()
        {
            var grid = new Grid(GRID_ROWS, GRID_COLS);
            Assert.True(grid.SetPosition(2, 3, Color.Blue));

            var result = grid.ToJson();
            var matrix = JsonConvert.DeserializeObject<int[,]>(result);
            Assert.Equal(matrix[2,3], 16711680);

        }

    }
}
