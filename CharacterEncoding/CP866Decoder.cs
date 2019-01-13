using System.Text;

namespace CharacterEncoding
{
    class CP866Decoder : CodePageDecoder
    {
        public string DecodeFrom(string utf8String)
        {
            Encoding cp866 = Encoding.GetEncoding(866);
            Encoding windows1251 = Encoding.GetEncoding(1251);
            byte[] cp866Bytes = cp866.GetBytes(utf8String);
            return windows1251.GetString(cp866Bytes);
        }
    }
}
