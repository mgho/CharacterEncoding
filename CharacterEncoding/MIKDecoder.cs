using System.Linq;
using System.Text;

namespace CharacterEncoding
{
    class MIKDecoder : CodePageDecoder
    {
        // https://en.wikipedia.org/wiki/MIK_(character_set)

        public string DecodeFrom(string utf8String)
        {
            // decode "COORDTYPE  1970,Ѓ «ІЁ©±Є" -> "COORDTYPE  1970,Балтийска"

            Encoding inputEncoding = Encoding.Default;
            Encoding windows1251 = Encoding.GetEncoding(1251);
            byte[] cp866Bytes = inputEncoding.GetBytes(utf8String);

            var result = cp866Bytes.Select(Convert).ToArray();

            return windows1251.GetString(result);
        }

        private byte Convert(byte b)
        {
            return b >= 128 ? (byte)(b + 64) : b;
        }
    }
}
