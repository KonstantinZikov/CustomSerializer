# CustomSerializer
Serialize/Deserialize object graph to binary view and use selected stream to write/read bytes. <br/>
<br/>
Serialized object will be present in accordance with the scheme: <br/>
<br/>
<b>Object type name length (2 bytes) | Object type name (in accordance with previous part) | All field values in accordance with the scheme. <br/></b>
<br/>
If object type is simple (int, bool , etc.)  or string, object type name length will have value 0x0000. <br/>
Next byte value presents simple type code: <br/>
  0x00 - Byte <br/>
  0x01 - SByte <br/>
  0x02 - Int16 <br/>
  0x03 - UInt16 <br/>
  0x04 - Int32 <br/>
  0x05 - UInt32 <br/>
  0x06 - Int64 <br/>
  0x07 - UInt64 <br/>
  0x08 - Single <br/>
  0x09 - Double <br/>
  0x0A - Decimal <br/>
  0x0B - Boolean <br/>
  0x0C - String <br/>
<br/>
And scheme will be next: <br/>
<b>0x0000 | Simple Type Code (1 byte) | Value bytes (in accordance with previous part)<br/></b>
For String: <b>Two Zero Bytes | Simple Type Code (1 byte) | String length (4 bytes) | String bytes (in accordance with previous part)<br/></b>
<br/>
If object type is array, object type name length will have value 0x0001.<br/>
<br/>
Array will be present in accordance with the next scheme:<br/>
<b>0x0001 | Element type name length (2 bytes) | Element type name (in accordance with previous part) | Array Length (4 bytes) | Elements (in accordance with default scheme)</b>
