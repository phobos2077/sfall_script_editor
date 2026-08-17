# requirement: pip install pefile

import sys, pefile

pe = pefile.PE(sys.argv[1])
pe.OPTIONAL_HEADER.SizeOfStackReserve = int(sys.argv[2])
pe.OPTIONAL_HEADER.SizeOfStackCommit = int(sys.argv[3])

data = pe.write() # returns the rebuilt PE as a bytearray, doesn't touch disk
pe.close()        # release the mmap/file handle on the original file

with open(sys.argv[1], "wb") as f:
    f.write(data)
