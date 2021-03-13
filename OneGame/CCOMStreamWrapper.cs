using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using Marshal = System.Runtime.InteropServices.Marshal;

namespace OneGame
{
    internal sealed class CCOMStreamWrapper : IStream
    {
        private readonly Stream stream;

        public CCOMStreamWrapper(Stream streamWrap) => stream = streamWrap;
        public void Clone(out IStream ppstm) => ppstm = new CCOMStreamWrapper(stream);
        public void Commit(int grfCommitFlags) => stream.Flush();
        public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten) { }

        public void LockRegion(long libOffset, long cb, int dwLockType) => throw new NotImplementedException();

        public void Read(byte[] pv, int cb, IntPtr pcbRead) => Marshal.WriteInt64(pcbRead, stream.Read(pv, 0, cb));
        public void Revert() => throw new NotImplementedException();
        public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
        {
            long posMoveTo;
            Marshal.WriteInt64(plibNewPosition, stream.Position);
            switch (dwOrigin)
            {
                case 0: /* STREAM_SEEK_SET */
                    posMoveTo = dlibMove;
                    break;
                case 1: /* STREAM_SEEK_CUR */
                    posMoveTo = stream.Position + dlibMove;
                    break;
                case 2: /* STREAM_SEEK_END */
                    posMoveTo = stream.Length + dlibMove;
                    break;
                default:
                    return;
            }
            if (posMoveTo >= 0 && posMoveTo < stream.Length)
            {
                stream.Position = posMoveTo;
                Marshal.WriteInt64(plibNewPosition, stream.Position);
            }
        }
        public void SetSize(long libNewSize) => stream.SetLength(libNewSize);
        public void Stat(out STATSTG pstatstg, int grfStatFlag)
        {
            pstatstg = new STATSTG();
            pstatstg.cbSize = stream.Length;
            if ((grfStatFlag & 0x0001/* STATFLAG_NONAME */) != 0) return;
            pstatstg.pwcsName = stream.ToString();
        }
        public void UnlockRegion(long libOffset, long cb, int dwLockType) => throw new NotImplementedException();
        public void Write(byte[] pv, int cb, IntPtr pcbWritten)
        {
            Marshal.WriteInt64(pcbWritten, 0);
            stream.Write(pv, 0, cb);
            Marshal.WriteInt64(pcbWritten, cb);
        }
    }
}
