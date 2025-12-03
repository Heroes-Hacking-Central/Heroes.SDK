using System;
using System.Runtime.InteropServices;

namespace Heroes.SDK.Classes.NativeClasses
{

    [Equals(DoNotAddEqualityOperators = true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct TObject
    {
        [FieldOffset(0)]
        void* __vftable /*VFT*/;
        [FieldOffset(4)]
        public char* ClassName;
        [FieldOffset(8)]
        public UInt16 Signal;
        [FieldOffset(0xA)]
        public UInt16 Tag;
        [FieldOffset(0xC)]
        public TObject* Prev;
        [FieldOffset(0X10)]
        public TObject* Next;
        [FieldOffset(0x14)]
        public TObject* Parent;
        [FieldOffset(0x18)]
        public TObject* Child;
        [FieldOffset(0x1C)]
        public UInt16 ExecTime;
        [FieldOffset(0x1E)]
        public UInt16 DispTime;
        [FieldOffset(0x20)]
        public UInt16 TDispTime;
        [FieldOffset(0x22)]
        public UInt16 PDispTime;
        [FieldOffset(0x24)]
        public UInt16 ImmAftSetRasterTime;
        [FieldOffset(0x26)]
        public short field_26;
    }
}
