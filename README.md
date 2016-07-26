# CustomSerializer

Serialize/Deserialize object graph to binary view and use selected stream to write/read bytes;

Serialized object will be present in accordance with the scheme:

Object type name length (2 bytes) | Object type name (in accordance with previous part) | All field values in accordance with the scheme.

If object type is simple (int, bool , etc.)  or string, object type name length will have value 0x0000.
Next byte value presents simple type code:
  0x00 - Byte
  0x01 - SByte
  0x02 - Int16
  0x03 - UInt16
  0x04 - Int32
  0x05 - UInt32
  0x06 - Int64
  0x07 - UInt64
  0x08 - Single
  0x09 - Double
  0x0A - Decimal
  0x0B - Boolean
  0x0C - String

And scheme will be next:
0x0000 | Simple Type Code (1 byte) | Value bytes (in accordance with previous part)
For String: Two Zero Bytes | Simple Type Code (1 byte) | String length (4 bytes) | String bytes (in accordance with previous part)

If object type is array, object type name length will have value 0x0001.

Array will be present in accordance with the next scheme:
0x0001 | Element type name length (2 bytes) | Element type name (in accordance with previous part) | Array Length (4 bytes) | Elements (in accordance with default scheme)

