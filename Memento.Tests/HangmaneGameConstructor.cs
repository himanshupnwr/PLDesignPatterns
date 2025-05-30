using Memento.V2;

namespace Memento.Tests
{
    public class HangmaneGameConstructor
    {
        private const string TEST_SECRET_WORD = "TEST";

        private HangmanGame _game = new HangmanGame(TEST_SECRET_WORD);

        [Fact]
        public void HasMaskedWordOfAllUnderscores()
        {
            Assert.Equal("____", _game.CurrentMaskedWord);
        }
    }
}