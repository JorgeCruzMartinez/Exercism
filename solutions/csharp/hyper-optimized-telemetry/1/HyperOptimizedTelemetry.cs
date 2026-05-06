public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte prefix;
        byte[] payload;
        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            // ushort, 2 байта
            payload = BitConverter.GetBytes((ushort)reading);
            prefix = 2;
        }
        else if (reading >= -32768 && reading <= -1)
        {
            // short, 2 байта
            payload = BitConverter.GetBytes((short)reading);
            prefix = (byte)(256 - 2);
        }
        else if (reading >= -2147483648 && reading <= 2147483647)
        {
            // int, 4 байта
            payload = BitConverter.GetBytes((int)reading);
            prefix = (byte)(256 - 4);
        }
        else if (reading >= 0 && reading <= uint.MaxValue)
        {
            // uint, 4 байта
            payload = BitConverter.GetBytes((uint)reading);
            prefix = 4;
        }
        else
        {
            // long, 8 байт
            payload = BitConverter.GetBytes(reading);
            prefix = (byte)(256 - 8);
        }
        byte[] buffer = new byte[9];
        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }
    
    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length != 9)
            return 0;
        byte prefix = buffer[0];
        int payloadLength;
        bool signed = false;
        if (prefix >= 128)
        {
            // отрицательный префикс: signed type
            payloadLength = 256 - prefix;
            signed = true;
        }
        else
            payloadLength = prefix;
    
        if (payloadLength <= 0 || payloadLength > 8)
            return 0;
        byte[] payload = new byte[8];
        Array.Copy(buffer, 1, payload, 0, payloadLength);
        if (signed)
        {
            switch (payloadLength)
            {
                case 2: return BitConverter.ToInt16(payload, 0);
                case 4: return BitConverter.ToInt32(payload, 0);
                case 8: return BitConverter.ToInt64(payload, 0);
            }
        }
        else
        {
            switch (payloadLength)
            {
                case 2: return BitConverter.ToUInt16(payload, 0);
                case 4: return BitConverter.ToUInt32(payload, 0);
                case 8: return (long)BitConverter.ToUInt64(payload, 0);
            }
        }
        return 0;
    }
}
