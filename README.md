# CustomSerializer

Serialize/Deserialize object graph to binary view and use selected stream to write/read bytes;

Serialized object will be present in accordance with the scheme:

Object type name length (2 bytes) | Object type name (in accordance with previous part) | All field values in accordance with the scheme.

If object type is simple (int, bool , etc.)  or string, object type name length will have zero value.
Next byte value presents simple type code:
  0x1 - Byte
  0x1 - Byte
  0x1 - Byte
  0x1 - Byte
  0x1 - Byte
  0x1 - Byte
